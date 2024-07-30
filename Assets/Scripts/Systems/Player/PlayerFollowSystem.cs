using Assets.Scripts.Managers;
using Zenject;

namespace Assets.Scripts.Systems.Player
{
    public class PlayerFollowSystem : ITickable
    {
        private readonly UIManager _uiManager;
        private readonly GameManager _gameManager;

        public PlayerFollowSystem(UIManager uiManager, GameManager gameManager)
        {
            _uiManager = uiManager;
            _gameManager = gameManager;
        }

        public void Tick()
        {
            _uiManager.Camera.transform.position = _gameManager.Player.transform.position + UnityEngine.Vector3.back;
        }
    }
}
