using Assets.Scripts.InputSystem.Interface;
using Assets.Scripts.Managers;
using Assets.Scripts.Models;
using Zenject;

namespace Assets.Scripts.Handlers
{
    public class PlayerInputHandler : IFixedTickable
    {
        private readonly IMovingSystem _inputSystem;
        private readonly IShootingNotifier _shootingNotifier;
        private readonly GameManager _gameManager;

        public PlayerInputHandler(IMovingSystem inputSystem, IShootingNotifier shootingNotifier, GameManager gameManager)
        {
            _inputSystem = inputSystem;
            _gameManager = gameManager;
            _shootingNotifier = shootingNotifier;
        }

        public void FixedTick()
        {
            _gameManager.Player.PlayRunAnimation(_inputSystem.Direction != UnityEngine.Vector2.zero);
            _gameManager.Player.PlayShootAnimation(_shootingNotifier.IsShoot);

            _gameManager.Player.Move(_inputSystem.Direction);

        }
    }
}
