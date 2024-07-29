using UnityEngine;

namespace Assets.Scripts.InputSystem.Interface
{
    public interface IInputSystem
    {
        public float Horizontal { get; }
        public float Vertical { get; }
        public Vector2 Direction { get; }
    }
}
