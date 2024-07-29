using Assets.Scripts.Configurations;
using Assets.Scripts.InputSystem.Interface;
using Assets.Scripts.Managers;
using Assets.Scripts.Models;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class GameWorldInitializer : IInitializable
    {
        private readonly PlayerConfiguration _playerConfiguration;
        private readonly EnviromentConfiguration _enviromentConfiguration;
        private readonly GameManager _gameManager;

        public GameWorldInitializer(PlayerConfiguration playerConfiguration, GameManager gameManager, EnviromentConfiguration enviromentConfiguration)
        {
            _playerConfiguration = playerConfiguration;
            _gameManager = gameManager;
            _enviromentConfiguration = enviromentConfiguration;
        }

        public void Initialize()
        {
            var enviroment = GameObject.Instantiate(_enviromentConfiguration.LevelEnviroment);

            var player = GameObject.Instantiate<Player>(_playerConfiguration.Prefab);
            player.transform.SetParent(enviroment.transform);
            player.Init(_playerConfiguration.Health, _playerConfiguration.Speed);

            _gameManager.Player = player;
        }
    }
}