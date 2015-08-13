using UnityEngine;
using Assets._Scripts.Weapons;

namespace Assets._Scripts.Player
{
    public class PlayerWeapons : MonoBehaviour
    {
		public float fireRate;
		public float tempFireRate;

        public Weapon BaseWeapon;

        public Weapon SuperWeapon1;

        public void ShootBaseWeapon()
        {
            BaseWeapon.Shoot();
        }

        public void ShootSuperWeapon1()
        {
            SuperWeapon1.Shoot();
        }

		public void Start(){

			fireRate = BaseWeapon.FireRate / 10;

			tempFireRate = fireRate;
		}

		public void Update(){

			if (tempFireRate > 0) {

				tempFireRate -= Time.deltaTime;
			} else {

				ShootBaseWeapon();
				tempFireRate = fireRate;
			}
		}
    }
}
