using Assets.Scripts.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Assets.Scripts.Systems
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
