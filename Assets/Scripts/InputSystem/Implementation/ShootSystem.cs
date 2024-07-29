using Assets.Scripts.InputSystem.Interface;
using Assets.Scripts.Managers;
using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.InputSystem.Implementation
{
    public class ShootSystem : IShootSystem, IFixedTickable
    {
        private const float Speed = 5;
        private const double TimeoutSec = 1;

        private IWeaponSystem _weaponSystem;
        private IShootingNotifier _shootingNotifier;
        private Bullet.Pool _pool;
        private GameManager _gameManager;

        private List<Bullet> _bullets = new();
        private TimeSpan _intervalFromLastShoot = TimeSpan.FromSeconds(TimeoutSec);

        public ShootSystem(IWeaponSystem weaponSystem, IShootingNotifier shootingNotifier, GameManager gameManager, Bullet.Pool pool)
        {
            _weaponSystem = weaponSystem;
            _shootingNotifier = shootingNotifier;
            _gameManager = gameManager;
            _pool = pool;
        }

        public void FixedTick()
        {
            _intervalFromLastShoot += TimeSpan.FromSeconds(Time.fixedDeltaTime);

            for (int i = 0; i < _bullets.Count; i++)
            {
                var bullet = _bullets[i];
                bullet.transform.position += bullet.transform.up * Speed * Time.fixedDeltaTime;

                if (bullet.IsMoveInsideRadius)
                {
                    _pool.Despawn(bullet);
                    _bullets.Remove(bullet);
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

                _bullets.Add(_pool.Spawn(weapon.HeatRadius, weapon.Bullet, player.WeaponShootTransform.position, player.transform.rotation));

                float angleStep = weapon.ShootAngle / (weapon.AdditionalBulletCount * 2);

                for (int i = 1; i <= weapon.AdditionalBulletCount; i++)
                {
                    var angle = angleStep * i;

                    var playerRotation = player.transform.rotation;

                    var startRotation = Quaternion.Euler(0, 0, angle) * playerRotation;
                    var mirorredStartRotation = Quaternion.Euler(0, 0, -angle) * playerRotation;

                    _bullets.Add(_pool.Spawn(weapon.HeatRadius, weapon.Bullet, player.WeaponShootTransform.position, startRotation));
                    _bullets.Add(_pool.Spawn(weapon.HeatRadius, weapon.Bullet, player.WeaponShootTransform.position, mirorredStartRotation));
                }
            }
        }
    }
}
