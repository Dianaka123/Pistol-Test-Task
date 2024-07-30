using Assets.Scripts.Models;
using System;

namespace Assets.Scripts.Systems.Weapons
{
    public interface IWeaponSystem
    {
        Weapon CurrentWeapon { get; }
    }
}
