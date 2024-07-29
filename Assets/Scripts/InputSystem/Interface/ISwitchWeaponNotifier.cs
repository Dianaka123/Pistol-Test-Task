using Assets.Scripts.Models;
using System;

namespace Assets.Scripts.InputSystem.Interface
{
    public interface ISwitchWeaponNotifier
    {
        event Action<Weapon> Switch;
    }
}
