using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.InputSystem.Interface
{
    public interface IMovingSystem
    {
        public float Horizontal { get; }
        public float Vertical { get; }
        public Vector2 Direction { get; }
    }
}
