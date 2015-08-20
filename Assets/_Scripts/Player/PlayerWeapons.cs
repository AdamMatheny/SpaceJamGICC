using UnityEngine;
using Assets._Scripts.Weapons;
using Assets._Scripts.Managers;
using Assets._Scripts.Audio;
using Assets._Scripts.AI;
using System.Collections;

namespace Assets._Scripts.Player
{
	public class PlayerWeapons : MonoBehaviour
	{
		public GameObject gunDamage;

		public Weapon[] SuperScripts = new Weapon[5];

		public GameObject[] enemySpawners = new GameObject[1];

		public bool canShoot;

		public float fireRate;
		public float tempFireRate;
		
		public Weapon BaseWeapon;
		
		public Weapon SuperWeapon1 = null;
		
		public void ShootBaseWeapon()
		{
			BaseWeapon.Shoot(null); 

			AudioManager.instance.PlayRedShipSound(ShipRedSoundType.ShootBasic);
		}
		
		public void ShootSuperWeapon1(GameObject playerToAffect)
		{
			SuperWeapon1.Shoot(playerToAffect);
		}
		
		public void Start(){

			enemySpawners = GameObject.FindGameObjectsWithTag ("Spawner");

			fireRate = BaseWeapon.FireRate / 10;
			
			tempFireRate = fireRate;
		}
		
		public void Update(){

			if (BaseWeapon.isMega) {

				tempFireRate = 0;
			}

			if (canShoot) {

				gunDamage.SetActive (false);
			} else {

				gunDamage.SetActive (true);
			}

			if (canShoot) {
			
				if (tempFireRate > 0) {
				
					tempFireRate -= Time.deltaTime;
				} else {
				
					ShootBaseWeapon ();
					tempFireRate = fireRate;
				}
			}
		}

		public void MegaTimer(){

			BaseWeapon.isMega = true;
			StartCoroutine ("MegaTimerEnum");
		}

		private IEnumerator MegaTimerEnum(){

			yield return new WaitForSeconds (6);
			BaseWeapon.isMega = false;
		}

        public void UnlockSuperWeapon(WeaponType type)
        {
            //Debug.Log("Unlock Weapon here! " + type);

			switch (type) {
				
			case WeaponType.ControlSwap:
				//other.GetComponent<PlayerWeapons> ().SuperWeapon1 = SuperScripts[0];
				//other.GetComponent<PlayerWeapons> ().UnlockSuperWeapon("InvertControls");
				SuperWeapon1 = SuperScripts[0];
				break;
			case WeaponType.EnemyDisplacement:
				SuperWeapon1 = SuperScripts[1];
				break;
			case WeaponType.SlowMotion:
				//other.GetComponent<PlayerWeapons> ().SuperWeapon1 = SuperScripts[2];
				SuperWeapon1 = SuperScripts[2];
				break;
			case WeaponType.WeaponDisable:
				//other.GetComponent<PlayerWeapons> ().SuperWeapon1 = SuperScripts[3];
				SuperWeapon1 = SuperScripts[3];
				break;
			case WeaponType.VisualHindrance:
				SuperWeapon1 = SuperScripts[4];
				break;
			case WeaponType.SuperDeflect:
				SuperWeapon1 = SuperScripts[5];
				break;
			case WeaponType.WeaponUpgrade:
				SuperWeapon1 = SuperScripts[6];
				break;
			default:
				//other.GetComponent<PlayerWeapons> ().SuperWeapon1 = null;
				SuperWeapon1 = null;
				break;
			}
        }
	}
}
