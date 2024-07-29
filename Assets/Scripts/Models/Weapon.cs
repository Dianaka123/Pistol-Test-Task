using Assets.Scripts.Enums;
using UnityEngine;
using static Assets.Scripts.Configurations.WeaponsConfiguration;

namespace Assets.Scripts.Models
{
    public class Weapon
    {
        public float Damage { get; private set; }
        public float HeatRadius { get; private set; }
        public int BulletCountInOneShoot { get; private set; }
        public GameObject Bullet { get; private set; }
        public Sprite WeaponImage { get; private set; }
        public WeaponTypes Type { get; private set; }

        public Weapon(WeaponConfiguration weaponConfiguration)
        {
            Damage = weaponConfiguration.Damage;
            HeatRadius = weaponConfiguration.HeatRadius;
            BulletCountInOneShoot = weaponConfiguration.BulletCountInOneShoot;
            Bullet = weaponConfiguration.Bullet;
            WeaponImage = weaponConfiguration.Weapon;
            Type = weaponConfiguration.Type;
        }
    }
}
