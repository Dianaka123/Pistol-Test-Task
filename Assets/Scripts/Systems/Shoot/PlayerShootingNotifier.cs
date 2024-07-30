using Assets.Scripts.InputSystem.Interface;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.InputSystem.Implementation
{
    public class PlayerShootingNotifier : MonoBehaviour, IShootingNotifier, IPointerDownHandler, IPointerUpHandler
    {
        public bool IsShoot { get; private set; }

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
