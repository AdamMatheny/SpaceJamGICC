using UnityEngine;
using System.Collections;

namespace Assets._Scripts.Weapons
{
	public class SuperSlowMotion : Weapon
	{
		
		public override void Shoot(bool isPlayer1){
			
			try
			{
				if(isPlayer1){
					
					Debug.Log("Slow down player 2.");
				}else{
					
					Debug.Log("Slow down player 1.");
				}
			}
			catch
			{
				Debug.Log("There was an error during creating a projectile");
			}
		}
	}
}