using System;

namespace Assets.Scripts.Enums
{
    [Flags]
    public enum PlayerInputState
    {
        None = 0,
        Right = 1,
        Left = 2, 
        Up = 4, 
        Down = 8,
    }
}
