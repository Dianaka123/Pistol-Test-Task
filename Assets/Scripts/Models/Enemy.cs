using System;
using UnityEngine;
using static Assets.Scripts.Configurations.EnemiesConfiguration;

namespace Assets.Scripts.Models
{
    [RequireComponent(typeof(Collider2D))]
    public class Enemy : BulletTarget
    {
        private Collider2D _collider;

        private float _maxHealth;

        public float RelativeHealth => Health / _maxHealth;
        public float Health { get; private set; }
        public Vector2 Size => _collider.bounds.size;

        public event Action<Enemy> DamageTaken;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
        }

        public void Init(EnemyConfig config)
        {
            _maxHealth = config.Health;
            Health = config.Health;
        }

        public void TakeDamage(float damage)
        {
            OnTakeDamage(damage);

            DamageTaken?.Invoke(this);

            if (Health <= 0)
            {
                Destroy(gameObject);
            }

        }

        public override void OnBulletColision(Bullet bullet)
        {
            TakeDamage(bullet.Damage);
            base.OnBulletColision(bullet);
        }

        public virtual void OnTakeDamage(float damage)
        {
            Health -= damage;
        }
    }
}
