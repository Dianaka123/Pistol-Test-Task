using Assets.Scripts.Systems.InputSystem.Implementation.Joystick.Base;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Systems.InputSystem.Implementation.Joystick
{
    public class FloatingJoystick : JoystickBase
    {
        protected override void Start()
        {
            base.Start();
            background.gameObject.SetActive(false);
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
            background.gameObject.SetActive(true);
            base.OnPointerDown(eventData);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            background.gameObject.SetActive(false);
            base.OnPointerUp(eventData);
        }
    }
}