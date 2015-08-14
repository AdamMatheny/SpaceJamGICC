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

        public Weapon SuperWeapon1 = null;

        public void ShootBaseWeapon()
        {
            BaseWeapon.Shoot(false); //Giving false because it doens't affect
            AudioManager.instance.PlayerRedShipSound(ShipRedSoundType.ShootBasic);
        }

        public void ShootSuperWeapon1(bool isPlayer1)
        {
            SuperWeapon1.Shoot(isPlayer1);
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
