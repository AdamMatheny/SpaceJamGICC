using UnityEngine;
using System.Collections;
using Assets._Scripts.Player;

namespace Assets._Scripts.Weapons
{
	public class SuperWeaponDisable : Weapon
	{
		
		public override void Shoot(GameObject playerToAffect){
			
			try
			{

				if(!playerToAffect.gameObject.GetComponent<PlayerControl> ().deflect){
					
					playerToAffect.gameObject.GetComponent<PlayerWeapons> ().canShoot = false;
					playerToAffect.gameObject.GetComponent<PlayerControl> ().DisableWeapon();
				}else{
					
					playerToAffect.gameObject.GetComponent<PlayerControl> ().deflect = false;
				}
			}
			catch
			{
				Debug.Log("There was an error during creating a projectile");
			}
		}
	}
}