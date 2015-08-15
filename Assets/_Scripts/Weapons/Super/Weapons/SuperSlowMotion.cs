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
				
				playerToAffect.gameObject.GetComponent<PlayerControl> ().FlySpeed /= 3;
				playerToAffect.gameObject.GetComponent<PlayerWeapons> ().fireRate *= 3;
				playerToAffect.gameObject.GetComponent<PlayerControl> ().SlowMotion();
			}
			catch
			{
				Debug.Log("There was an error during creating a projectile");
			}
		}
	}
}