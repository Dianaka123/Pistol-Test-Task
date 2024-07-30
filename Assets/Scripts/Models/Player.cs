using UnityEngine;

namespace Assets.Scripts.Models
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        private readonly int WalkTriggerHash = Animator.StringToHash("Walk");
        private readonly int ShootTriggerHash = Animator.StringToHash("Shoot");

        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private Transform _weaponShootPosition;

        [SerializeField]
        private Rigidbody2D _rigidbody2D;

        private float _speed;

        public Transform WeaponShootTransform => _weaponShootPosition;

        public void Init(float speed)
        {
            _speed = speed;
        }

        public void PlayRunAnimation(bool isRun)
        {
            PlayAnimationByBool(isRun, WalkTriggerHash);
        }

        public void PlayShootAnimation(bool isShoot)
        {
            PlayAnimationByBool(isShoot, ShootTriggerHash);
        }

        public void Move(Vector2 direction)
        {
            _rigidbody2D.MovePosition(_rigidbody2D.position + direction * _speed);
        }

        public void SetRotation(float angle)
        {
            _rigidbody2D.MoveRotation(angle);
        }

        private void PlayAnimationByBool(bool isAniamtionActive, int hash)
        {
            if (isAniamtionActive)
            {
                _animator.SetTrigger(hash);
            }
            else
            {
                _animator.ResetTrigger(hash);
            }
        }
    }
}
