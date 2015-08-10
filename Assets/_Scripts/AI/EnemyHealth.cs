using UnityEngine;

namespace Assets._Scripts.AI
{
    public class EnemyHealth : MonoBehaviour
    {
        public int HealthPoints;

        public virtual void TakeDamage(int amount)
        {
            HealthPoints -= amount;
            if (HealthPoints <= 0)
            {
                Die();
            }
        }

        protected virtual void Die()
        {
            //TODO Show Die Animation;
            Destroy(gameObject);
        }
    }
}
