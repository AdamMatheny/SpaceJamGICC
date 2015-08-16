using UnityEngine;
using System.Collections;
using Assets._Scripts.Player;

namespace Assets._Scripts.Weapons
{
	public class SuperSlowMotion : Weapon
	{
		
		public override void Shoot(GameObject playerToAffect){
			
			try
			{

				if(!playerToAffect.gameObject.GetComponent<PlayerControl> ().deflect){
					
					playerToAffect.gameObject.GetComponent<PlayerControl> ().FlySpeed /= 3;
					playerToAffect.gameObject.GetComponent<PlayerWeapons> ().fireRate *= 3;
					playerToAffect.gameObject.GetComponent<PlayerControl> ().SlowMotion();
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