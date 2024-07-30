using Assets.Scripts.Configurations;
using Assets.Scripts.InputSystem.Interface;
using Assets.Scripts.Managers;
using Assets.Scripts.Models;
using Assets.Scripts.Systems.Weapons;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.InputSystem.Implementation
{
    public class ShootSystem : IFixedTickable
    {
        private const double TimeoutSec = 1;

        private IWeaponSystem _weaponSystem;
        private IShootingNotifier _shootingNotifier;
        private Bullet.Pool _pool;
        private GameManager _gameManager;

        private List<Bullet> _bullets = new();
        private TimeSpan _intervalFromLastShoot = TimeSpan.FromSeconds(TimeoutSec);
        private float _speed;

        public ShootSystem(IWeaponSystem weaponSystem, IShootingNotifier shootingNotifier, GameManager gameManager, Bullet.Pool pool, WeaponsConfiguration weaponsConfiguration)
        {
            _weaponSystem = weaponSystem;
            _shootingNotifier = shootingNotifier;
            _gameManager = gameManager;
            _pool = pool;
            _speed = weaponsConfiguration.bulletSpeed;
        }

        public void FixedTick()
        {
            _intervalFromLastShoot += TimeSpan.FromSeconds(Time.fixedDeltaTime);

            for (int i = 0; i < _bullets.Count; i++)
            {
                var bullet = _bullets[i];
                var direction = bullet.transform.up;
                var distance = _speed * Time.fixedDeltaTime;
                var hit = Physics2D.Raycast(bullet.transform.position, direction, distance);
                if (hit.collider != null && hit.collider.gameObject.TryGetComponent(out BulletTarget bulletTarget))
                {
                    bulletTarget.OnBulletColision(bullet);
                    DestroyBullet(bullet);
                    i--;
                }

                bullet.transform.position += direction * distance;
                if (!bullet.IsInsideRadius)
                {
                    DestroyBullet(bullet);
                    i--;
                }
            }

            if (_shootingNotifier.IsShoot)
            {
                if (_intervalFromLastShoot.TotalSeconds < TimeoutSec)
                {
                    return;
                }
                _intervalFromLastShoot = TimeSpan.FromSeconds(_intervalFromLastShoot.TotalSeconds % TimeoutSec);

                var weapon = _weaponSystem.CurrentWeapon;
                var player = _gameManager.Player;
                var bulletCount = weapon.AdditionalBulletCount * 2 + 1;
                var bulletDamage = weapon.Damage / bulletCount;

                Bullet.SpawnArgs GetSpawnArgs(Quaternion rotation) 
                    => new (weapon.HeatRadius, bulletDamage, weapon.Bullet, player.WeaponShootTransform.position, rotation);

                _bullets.Add(_pool.Spawn(GetSpawnArgs(player.transform.rotation)));

                float angleStep = weapon.ShootAngle / (weapon.AdditionalBulletCount * 2);
                for (int i = 1; i <= weapon.AdditionalBulletCount; i++)
                {
                    var angle = angleStep * i;
                    var playerRotation = player.transform.rotation;

                    var startRotation = Quaternion.Euler(0, 0, angle) * playerRotation;
                    _bullets.Add(_pool.Spawn(GetSpawnArgs(startRotation)));

                    var mirorredStartRotation = Quaternion.Euler(0, 0, -angle) * playerRotation;
                    _bullets.Add(_pool.Spawn(GetSpawnArgs(mirorredStartRotation)));
                }
            }
        }

        private void DestroyBullet(Bullet bullet)
        {
            _pool.Despawn(bullet);
            _bullets.Remove(bullet);
        }
    }
}
