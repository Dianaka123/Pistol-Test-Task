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
        [SerializeField]
        private Animator _animator;

        private int _health;
        private float _speed;
        private float _jumpHeight;

        public void Init(int health, float speed, float jumpHeight)
        {
            _health = health;
            _speed = speed;
            _jumpHeight = jumpHeight;
        }
    }
}
