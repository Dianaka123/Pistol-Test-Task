using Assets.Scripts.InputSystem.Interface;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.InputSystem.Implementation
{
    public class PlayerShootingNotifier : MonoBehaviour, IShootingNotifier, IPointerDownHandler, IPointerUpHandler
    {
        public bool IsShoot { get; private set; }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                IsShoot = true;
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                IsShoot = false;
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            IsShoot = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            IsShoot= false;
        }
    }
}
