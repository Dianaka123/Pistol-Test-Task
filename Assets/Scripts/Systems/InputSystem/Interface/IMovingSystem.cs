using UnityEngine;

namespace Assets.Scripts.Systems.InputSystem.Interface
{
    public interface IMovingSystem
    {
        public float Horizontal { get; }
        public float Vertical { get; }
        public Vector2 Direction { get; }
    }
}
