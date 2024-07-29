using Assets.Scripts.InputSystem.Interface;
using Assets.Scripts.Managers;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.InputSystem.Implementation
{
    //TODO: add pool for bullets
    public class ShootSystem : IShootSystem, IFixedTickable
    {
        private IWeaponSystem _weaponSystem;
        private IShootingNotifier _shootingNotifier;
        private GameManager _gameManager;

        private List<GameObject> bullets = new ();
        private const float _speed = 1;

        public ShootSystem(IWeaponSystem weaponSystem, IShootingNotifier shootingNotifier, GameManager gameManager)
        {
            _weaponSystem = weaponSystem;
            _shootingNotifier = shootingNotifier;
            _gameManager = gameManager;
        }

        public void FixedTick()
        {
            foreach (var bullet in bullets)
            {
                bullet.transform.position += bullet.transform.up * _speed * Time.fixedDeltaTime;
            }

            if (_shootingNotifier.IsShoot)
            {
                var bullet = GameObject.Instantiate(_weaponSystem.CurrentWeapon.Bullet);
                bullet.transform.position = _gameManager.Player.WeaponShootTransform.position;
                bullet.transform.rotation = _gameManager.Player.transform.rotation;
                bullets.Add(bullet.GameObject());
            }

        }
    }
}
