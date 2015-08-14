using UnityEngine;
using System.Collections;

namespace Assets._Scripts.Weapons
{
	public class SuperEnemyDisplacement : Weapon
	{
		
		public override void Shoot(bool isPlayer1){
			
			try
			{
				if(isPlayer1){
					
					Debug.Log("Displace enemies to player 2.");
				}else{
					
					Debug.Log("Displace enemies to player 1");
				}
			}
			catch
			{
				Debug.Log("There was an error during creating a projectile");
			}
		}
	}
}