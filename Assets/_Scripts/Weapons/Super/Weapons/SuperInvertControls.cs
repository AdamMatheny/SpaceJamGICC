using UnityEngine;
using System.Collections;

namespace Assets._Scripts.Weapons
{
	public class SuperInvertControls : Weapon
	{
		
		public override void Shoot(bool isPlayer1){
			
			try
			{
				if(isPlayer1){

					Debug.Log("Screw with player two's controls.!");
				}else{

					Debug.Log("Screw with player one's controls.!");
				}
			}
			catch
			{
				Debug.Log("There was an error during creating a projectile");
			}
		}
	}
}