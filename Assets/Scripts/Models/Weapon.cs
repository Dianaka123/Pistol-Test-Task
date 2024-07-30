using Assets.Scripts.Configurations;
using Assets.Scripts.Enums;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public class Weapon
    {
        public float Damage { get; private set; }
        public float HitRadius { get; private set; }
        public float ShootAngle { get; private set; }
        public int AdditionalBulletCount { get; private set; }
        public Sprite Bullet { get; private set; }
        public Sprite WeaponImage { get; private set; }
        public WeaponTypes Type { get; private set; }

        public Weapon(WeaponsConfiguration.WeaponConfiguration weaponConfiguration)
        {
            Damage = weaponConfiguration.Damage;
            HitRadius = weaponConfiguration.HitRadius;
            AdditionalBulletCount = weaponConfiguration.AdditionalBulletCount;
            Bullet = weaponConfiguration.Bullet;
            WeaponImage = weaponConfiguration.Weapon;
            Type = weaponConfiguration.Type;
            ShootAngle = weaponConfiguration.ShootAngle;
        }
    }
}
