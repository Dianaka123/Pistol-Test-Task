using Assets.Scripts.InputSystem.Interface;
using Assets.Scripts.Managers;
using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.InputSystem.Implementation
{
    //TODO: add pool for bullets
    public class ShootSystem : IShootSystem, IFixedTickable
    {
        private const float Speed = 5;
        private const double TimeoutSec = 1;
        private const float ShootAngle = 60; //2alpha

        private IWeaponSystem _weaponSystem;
        private IShootingNotifier _shootingNotifier;
        private Bullet.Pool _pool;
        private GameManager _gameManager;

        private List<Bullet> _bullets = new();

        public ShootSystem(IWeaponSystem weaponSystem, IShootingNotifier shootingNotifier, GameManager gameManager, Bullet.Pool pool)
        {
            _weaponSystem = weaponSystem;
            _shootingNotifier = shootingNotifier;
            _gameManager = gameManager;
            _pool = pool;
        }

        public void FixedTick()
        {
            for (int i = 0; i < _bullets.Count; i++)
            {
                var bullet = _bullets[i];
                bullet.transform.position += bullet.transform.up * Speed * Time.fixedDeltaTime;

                if (bullet.IsMoveInsideRaius)
                {
                    _pool.Despawn(bullet);
                    _bullets.Remove(bullet);
                }
            }

            if (_shootingNotifier.IsShoot)
            {
                if (_bullets.Count > 0 && _bullets[0].TimeLife.TotalSeconds < TimeoutSec)
                {
                    return;
                }

                var weapon = _weaponSystem.CurrentWeapon;
                var player = _gameManager.Player;

                _bullets.Add(_pool.Spawn(DateTime.Now, weapon.HeatRadius, weapon.Bullet, player.WeaponShootTransform.position, player.transform.rotation));

                float angleStep = weapon.ShootAngle / (weapon.AdditionalBulletCount * 2);

                for (int i = 1; i <= weapon.AdditionalBulletCount; i++)
                {
                    var angle = angleStep * i;

                    var playerRotation = player.transform.rotation;

                    var startRotation = Quaternion.Euler(0, 0, angleStep) * playerRotation;
                    var mirorredStartRotation = Quaternion.Euler(0, 0, -angleStep) * playerRotation;

                    _bullets.Add(_pool.Spawn(DateTime.Now, weapon.HeatRadius, weapon.Bullet, player.WeaponShootTransform.position, startRotation));
                    _bullets.Add(_pool.Spawn(DateTime.Now, weapon.HeatRadius, weapon.Bullet, player.WeaponShootTransform.position, mirorredStartRotation));
                }
            }
        }
    }
}
