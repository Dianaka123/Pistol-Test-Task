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

        public void Init(float radius, Sprite image, Vector3 startPosition, Quaternion startRotation)
        {
            _image.sprite = image;
            _radius = radius;
            _startPosition = startPosition;

            transform.position = _startPosition;
            transform.rotation = startRotation;
        }

        public bool IsMoveInsideRadius => GetBulletDistanceFromStart() > _radius;

        public class Pool : MonoMemoryPool<float, Sprite, Vector3, Quaternion, Bullet>
        {
            protected override void Reinitialize(float radius, Sprite image, Vector3 startPosition, Quaternion startRotattion, Bullet item)
            {
                item.Init( radius, image, startPosition, startRotattion);
            }
        }

        private float GetBulletDistanceFromStart() => Mathf.Sqrt(Mathf.Pow(transform.position.x - _startPosition.x, 2f) + Mathf.Pow(transform.position.y - _startPosition.y, 2f));
    }
}