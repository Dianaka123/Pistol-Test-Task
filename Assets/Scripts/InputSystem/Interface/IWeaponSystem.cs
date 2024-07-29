using Assets.Scripts.Models;
using System;

namespace Assets.Scripts.InputSystem.Interface
{
    public interface IWeaponSystem
    {
        Weapon CurrentWeapon { get; }
    }
}
