using UnityEngine;
using System.Collections;

namespace Assets._Scripts.Weapons
{
	public class SuperWeaponDisable : Weapon
	{
		
		public override void Shoot(bool isPlayer1){
			
			try
			{
				if(isPlayer1){
					
					Debug.Log("Disable player 2's weapon.");
				}else{
					
					Debug.Log("Disable player 1's weapon.");
				}
			}
			catch
			{
				Debug.Log("There was an error during creating a projectile");
			}
		}
	}
}