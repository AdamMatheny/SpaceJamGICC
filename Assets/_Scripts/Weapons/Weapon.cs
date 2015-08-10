using UnityEngine;

namespace Assets._Scripts.Weapons
{
    public class Weapon : MonoBehaviour
    {
        [Header("Base Weapon Info")]
        public int Damage;
        public float Speed;
        public float FireRate;

        [Header("Projectyles to Shoot")]
        public Projectile WeaponProjectile;

        public virtual void Shoot()
        {
            try
            {
                var spawnedProjectile = (Projectile)Instantiate(WeaponProjectile, gameObject.transform.position, gameObject.transform.rotation);
                spawnedProjectile.Init(Damage, Speed);
            }
            catch
            {
                Debug.Log("There was an error during creating a projectile");
            }
        }
    }
}
