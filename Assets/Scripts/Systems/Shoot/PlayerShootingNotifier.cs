using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Systems.Shoot
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
            IsShoot = false;
        }
    }
}
