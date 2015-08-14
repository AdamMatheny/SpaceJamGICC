using UnityEngine;
using System.Collections;
using Assets._Scripts.Player;

namespace Assets._Scripts.Weapons
{
	public class SuperInvertControls : Weapon
	{
		public override void Shoot(GameObject playerToAffect){
			
			try
			{
				playerToAffect.gameObject.GetComponent<PlayerControl> ().FlySpeed *= -1;
			}
			catch
			{
				Debug.Log("There was an error during creating a projectile");
			}
		}
	}
}