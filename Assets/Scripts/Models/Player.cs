using UnityEngine;

namespace Assets.Scripts.Models
{
    public class Player : MonoBehaviour
    {
        private readonly int WalkTriggerHash = Animator.StringToHash("Walk");
        private readonly int ShootTriggerHash = Animator.StringToHash("Shoot");

        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private Transform _weaponShootPosition;

        private int _health;
        private float _speed;

        public Transform WeaponShootTransform => _weaponShootPosition;

        public void Init(int health, float speed)
        {
            _health = health;
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
            var directionV3 = new Vector3(direction.x, direction.y, 0);
            transform.position += directionV3 * _speed;
            
            if(direction == Vector2.zero) { return; }

            var rotationTan = direction.y / direction.x;
            var rotationAngle = Mathf.Atan(rotationTan) * 180 / Mathf.PI - 90;
            if(direction.x < 0)
            {
                rotationAngle += 180;
            }
            transform.rotation = Quaternion.AngleAxis(rotationAngle, new Vector3(0, 0, 1));
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
