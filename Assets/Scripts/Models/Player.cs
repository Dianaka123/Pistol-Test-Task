using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public class Player : MonoBehaviour
    {
        private readonly int WalkTriggerHash = Animator.StringToHash("Walk");
        private readonly int ShootTriggerHash = Animator.StringToHash("Shoot");

        [SerializeField]
        private Animator _animator;

        private int _health;
        private float _speed;

        public void Init(int health, float speed)
        {
            _health = health;
            _speed = speed;
        }

        public void PlayRunAnimation(bool isRun)
        {
            PlayAnimationByBool(isRun, WalkTriggerHash);
        }

        public void Move(Vector2 direction)
        {
            var directionV3 = new Vector3(direction.x, direction.y, 0);
            transform.position += directionV3 * _speed;
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
