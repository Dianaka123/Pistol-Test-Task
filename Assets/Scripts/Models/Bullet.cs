using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Models
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _image;

        private DateTime _spawnTime;
        private float _radius;
        private Vector3 _startPosition;

        public void Init(DateTime spawnTime, float radius, Sprite image, Vector3 startPosition, Quaternion startRotation)
        {
            _image.sprite = image;
            _spawnTime = spawnTime;
            _radius = radius;
            _startPosition = startPosition;

            transform.position = _startPosition;
            transform.rotation = startRotation;
        }

        public TimeSpan TimeLife => DateTime.Now - _spawnTime;

        public bool IsMoveInsideRaius => GetBulletDistanceFromStart() > _radius;

        public class Pool : MonoMemoryPool<DateTime, float, Sprite, Vector3, Quaternion, Bullet>
        {
            protected override void Reinitialize(DateTime spawnTime, float radius, Sprite image, Vector3 startPosition, Quaternion startRotattion, Bullet item)
            {
                item.Init(spawnTime, radius, image, startPosition, startRotattion);
            }
        }

        private float GetBulletDistanceFromStart() => Mathf.Sqrt(Mathf.Pow(transform.position.x - _startPosition.x, 2f) + Mathf.Pow(transform.position.y - _startPosition.y, 2f));
    }
}