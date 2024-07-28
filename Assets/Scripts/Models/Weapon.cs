using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public abstract class Weapon : MonoBehaviour
    {
        private float _damage;
        private float _heatRadius;
        private int _bulletCountInOneShoot;

        public void Init(float damage, float heatRadius, int bulletCountInOneShoot)
        {
            _damage = damage;
            _heatRadius = heatRadius;
            _bulletCountInOneShoot = bulletCountInOneShoot;
        }
    }
}
