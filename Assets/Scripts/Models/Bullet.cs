using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Models
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _image;

        private float _radius;
        private Vector3 _startPosition;
        private float _damage;
        public bool IsInsideRadius => GetBulletDistanceFromStart() < _radius;
        public float Damage => _damage;

        public void Init(SpawnArgs spawnArgs)
        {
            _image.sprite = spawnArgs.Image;
            _radius = spawnArgs.Radius;
            _startPosition = spawnArgs.StartPosition;
            _damage = spawnArgs.Damage;

            transform.position = _startPosition;
            transform.rotation = spawnArgs.StartRotation;
        }

        private float GetBulletDistanceFromStart() => (transform.position - _startPosition).magnitude;

        public class SpawnArgs
        {
            public float Radius { get; }
            public float Damage { get; }
            public Sprite Image { get; }
            public Vector3 StartPosition { get; }
            public Quaternion StartRotation { get; }

            public SpawnArgs(float radius, float damage, Sprite image, Vector3 startPosition, Quaternion startRotation)
            {
                Radius = radius;
                Damage = damage;
                Image = image;
                StartPosition = startPosition;
                StartRotation = startRotation;
            }
        }

        public class Pool : MonoMemoryPool<SpawnArgs, Bullet>
        {
            protected override void Reinitialize(SpawnArgs spawnArgs, Bullet item)
            {
                item.Init(spawnArgs);
            }
        }
    }
}