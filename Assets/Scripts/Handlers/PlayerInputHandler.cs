using Assets.Scripts.InputSystem.Interface;
using Assets.Scripts.Managers;
using Zenject;

namespace Assets.Scripts.Handlers
{
    public class PlayerInputHandler : IFixedTickable
    {
        private readonly IInputSystem _inputSystem;
        private readonly GameManager _gameManager;

        public PlayerInputHandler(IInputSystem inputSystem, GameManager gameManager)
        {
            _inputSystem = inputSystem;
            _gameManager = gameManager;
        }

        public void FixedTick()
        {
            _gameManager.Player.PlayRunAnimation(_inputSystem.Direction != UnityEngine.Vector2.zero);

            _gameManager.Player.Move(_inputSystem.Direction);
        }
    }
}
