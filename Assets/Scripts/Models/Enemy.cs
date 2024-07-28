using UnityEngine;

namespace Assets.Scripts.Models
{
    public class Enemy : MonoBehaviour
    {
        private int _health;
        private bool _isCanBeDestroyed;

        public void Init(int health, bool isCanBeDestroyed)
        {
            _health = health;
            _isCanBeDestroyed = isCanBeDestroyed;
        }
    }
}
