using UnityEngine;
using Assets._Scripts.Weapons;
using Assets._Scripts.Managers;
using Assets._Scripts.Audio;

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
            AudioManager.instance.PlayerRedShipSound(ShipRedSoundType.ShootBasic);
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
