using Assets.Scripts.InputSystem.Interface;
using Assets.Scripts.Managers;
using Assets.Scripts.Models;
using Assets.Scripts.Systems;
using Assets.Scripts.Systems.Weapons;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Handlers
{
    public class PlayerInputHandler : IFixedTickable
    {
        private readonly IMovingSystem _inputSystem;
        private readonly IShootingNotifier _shootingNotifier;
        private readonly IWeaponSystem _weaponSystem;
        private readonly IEnemyManager _enemyManager;
        private readonly GameManager _gameManager;

        public PlayerInputHandler(IMovingSystem inputSystem, IShootingNotifier shootingNotifier, GameManager gameManager, IEnemyManager enemyManager, IWeaponSystem weaponSystem)
        {
            _inputSystem = inputSystem;
            _gameManager = gameManager;
            _shootingNotifier = shootingNotifier;
            _enemyManager = enemyManager;
            _weaponSystem = weaponSystem;
        }

        public void FixedTick()
        {
            var direction = _inputSystem.Direction;

            _gameManager.Player.PlayRunAnimation(direction != Vector2.zero);
            _gameManager.Player.PlayShootAnimation(_shootingNotifier.IsShoot);

            _gameManager.Player.Move(direction);

            var enemyRotation = ComputeEnemyRotation();
            if (direction == Vector2.zero && enemyRotation == null)
            { 
                return; 
            }

            var rotationAngle = enemyRotation ?? ComputeDefaultRotation(direction);

            _gameManager.Player.SetRotation(rotationAngle);
        }

        private float? ComputeEnemyRotation()
        {
            var enemy = GetNearestEnemy();
            if (enemy == null)
            {
                return null;
            }

            var direction = Vector3.Normalize(enemy.transform.position - _gameManager.Player.transform.position);
            return ComputeDefaultRotation(direction);
        }

        private float ComputeDefaultRotation(Vector2 direction)
        {

            var rotationTan = direction.y / direction.x;
            var rotationAngle = Mathf.Atan(rotationTan) * 180 / Mathf.PI - 90;
            if (direction.x < 0)
            {
                rotationAngle += 180;
            }

            return rotationAngle;
        }

        private Enemy GetNearestEnemy()
        {
            var enemies = _enemyManager.GetEnemies();
            if (!enemies.Any())
            {
                return null;
            }

            var radius = _weaponSystem.CurrentWeapon.HitRadius;
            var playerPosition = _gameManager.Player.transform.position;

            var minDistance = float.MaxValue;
            Enemy nearEnemy = null;
            foreach (var enemy in enemies)
            {
                var enemyPosition = enemy.transform.position;
                var distanceToPlayer = Vector3.Distance(playerPosition, enemyPosition);
                if (distanceToPlayer < minDistance)
                {
                    minDistance = distanceToPlayer;
                    nearEnemy = enemy;
                }
            }

            Debug.Log(nearEnemy?.name);
            return minDistance < radius ? nearEnemy : null;
        }
    }
}
