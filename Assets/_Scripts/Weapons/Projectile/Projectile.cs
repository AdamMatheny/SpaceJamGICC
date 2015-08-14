using UnityEngine;
using System.Collections;
using Assets._Scripts.AI;
using Assets._Scripts.Managers;

namespace Assets._Scripts.Weapons
{
    public class Projectile : MonoBehaviour
    {

		public bool isPlayerOne;

        public Animator ProjectileAnimator;

        public int Damage;
        public float FlySpeed;

        public void Init(int damage, float flySpeed)
        {
			Damage = damage;
			FlySpeed = flySpeed;

			//ProjectileAnimator.ShowSpawnAnimaton;
			StartCoroutine ("DieAfterTimeCoroutine");
		}

        protected virtual void Move()
        {
            gameObject.transform.Translate(Vector3.up * FlySpeed * Time.deltaTime);
        }
        
        protected virtual void DealDamage(Enemy enemy)
        {
            //ProjectileAnimator.ShowHitAnimation;
            enemy.EnemyShipDie();
        }

        void Update()
        {
            Move();
			gameObject.transform.parent = ObjectManager.instance.ContainerTransform;
        }

        private IEnumerator DieAfterTimeCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(10);
                Destroy(gameObject);
            }
        }
    }
}
