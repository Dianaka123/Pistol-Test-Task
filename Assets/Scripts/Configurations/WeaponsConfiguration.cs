using Assets.Scripts.Enums;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Assets.Scripts.Configurations
{
    [CreateAssetMenu(fileName = "WeaponsConfiguration", menuName = "ScriptableObjects/WeaponsConfiguration")]
    public class WeaponsConfiguration : ScriptableObject
    {
        [Serializable]
        public class WeaponConfiguration
        {
            public Sprite Weapon;
            public Sprite Bullet;
            public float Damage;
            public float HitRadius;
            public int AdditionalBulletCount;
            public float ShootAngle;
            public WeaponTypes Type;
        }

        public List<WeaponConfiguration> weapons = new ();
        public float bulletSpeed;

        private void OnValidate()
        {
            foreach(WeaponTypes weaponType in Enum.GetValues(typeof(WeaponTypes)))
            {
                Assert.AreEqual(weapons.FindAll(w => w.Type == weaponType).Count, 1, $"Should be only one {weaponType}! Please remove duplication.");
            }
        }
    }
}