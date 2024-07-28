using Assets.Scripts.Models;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Configurations
{
    [CreateAssetMenu(fileName = "WeaponsConfiguration", menuName = "ScriptableObjects/WeaponsConfiguration")]
    public class WeaponsConfiguration : ScriptableObject
    {
        public class WeaponConfiguration
        {
            public Weapon Prefab;
            public float Damage;
            public float HeatRadius;
            public float BulletCountInOneShoot;
        }

        public List<WeaponConfiguration> weapons = new();
    }
}