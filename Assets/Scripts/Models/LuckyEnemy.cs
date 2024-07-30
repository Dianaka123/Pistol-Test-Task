using UnityEngine;

namespace Assets.Scripts.Models
{
    public class LuckyEnemy : Enemy
    {
        [SerializeField]
        [Range(0, 100)]
        private int _skipDamageChance = 15;

        public override void OnTakeDamage(float damage)
        {
            var random = Random.Range(0, 100);

            if (random < _skipDamageChance)
            {
                Debug.Log("Lucky");
                return;
            }

            base.OnTakeDamage(damage);
        }
    }
}