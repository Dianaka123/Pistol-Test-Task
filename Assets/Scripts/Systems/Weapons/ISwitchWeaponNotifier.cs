using Assets.Scripts.Models;
using System;

namespace Assets.Scripts.Systems.Weapons
{
    public interface ISwitchWeaponNotifier
    {
        event Action<Weapon> Switch;
    }
}
