using Assets.Scripts.Configurations;
using Assets.Scripts.Managers;
using Assets.Scripts.Models;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using static Assets.Scripts.Configurations.EnemiesConfiguration;

namespace Assets.Scripts.Systems
{
    public class EnemySystem : IInitializable, ITickable
    {
        private class EnemyInfo
        {
            public HealthBar HealthBar { get; set; }
            public Enemy Enemy { get; set; }
        }

        private readonly UIManager _uiManager;
        private readonly EnemiesConfiguration _enemiesConfiguration;
        private readonly GameManager _gameManager;

        private readonly List<EnemyInfo> _enemiesInfo = new();

        public EnemySystem(UIManager uiManager, EnemiesConfiguration enemiesConfiguration, GameManager gameManager)
        {
            _uiManager = uiManager;
            _enemiesConfiguration = enemiesConfiguration;
            _gameManager = gameManager;
        }

        public void Initialize()
        {
            SpawnEnemy(_enemiesConfiguration.Enemies[0], Vector2.down * 5);
            SpawnEnemy(_enemiesConfiguration.Enemies[1], Vector2.right * 10);
        }

        public void Tick()
        {
            foreach(var enemyInfo in _enemiesInfo)
            {
                var enemy = enemyInfo.Enemy;
                var helthBar = enemyInfo.HealthBar;

                var healthBarWorldPosition = enemy.transform.position + Vector3.up * enemy.Size.y * 0.6f;
                
                helthBar.transform.position= _uiManager.Camera.WorldToScreenPoint(healthBarWorldPosition);
            }
        }

        private void SpawnEnemy(EnemyConfig enemyConfig, Vector3 position)
        {
            var enemy = GameObject.Instantiate(enemyConfig.Prefab, _gameManager.Enviroment.transform);

            var healthBarAsset = _enemiesConfiguration.HealthBar;
            var healthBar = GameObject.Instantiate(healthBarAsset, _uiManager.HealthBarContainer);

            enemy.Init(enemyConfig);
            enemy.transform.position = position;

            enemy.DamageTaken += OnDamageTaken;

            _enemiesInfo.Add(new EnemyInfo() { Enemy = enemy, HealthBar = healthBar});
        }

        private void OnDamageTaken(Enemy enemy)
        {
            EnemyInfo enemyInfo = _enemiesInfo.First(it => it.Enemy == enemy);
            if (enemy.RelativeHealth <= 0)
            {
                enemyInfo.HealthBar.Destroy();
                _enemiesInfo.Remove(enemyInfo);
                return;
            }
            enemyInfo.HealthBar.CurrentHealth = enemy.RelativeHealth;
        }
    }
}
