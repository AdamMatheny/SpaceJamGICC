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
				
				playerToAffect.gameObject.GetComponent<PlayerWeapons> ().canShoot = false;
				playerToAffect.gameObject.GetComponent<PlayerControl> ().DisableWeapon();
			}
			catch
			{
				Debug.Log("There was an error during creating a projectile");
			}
		}
	}
}