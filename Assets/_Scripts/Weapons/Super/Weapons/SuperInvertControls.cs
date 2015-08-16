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
				if(!playerToAffect.gameObject.GetComponent<PlayerControl> ().deflect){

					playerToAffect.gameObject.GetComponent<PlayerControl> ().FlySpeed *= -1;
					playerToAffect.gameObject.GetComponent<PlayerControl> ().InvertTimer();
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