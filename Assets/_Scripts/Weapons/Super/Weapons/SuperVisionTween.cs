using UnityEngine;
using System.Collections;

namespace Assets._Scripts.Weapons
{
	public class SuperVisionTween : Weapon
	{
		
		public override void Shoot(bool isPlayer1){
			
			try
			{
				if(isPlayer1){
					
					Debug.Log("Screw with player two's camera.!");
				}else{
					
					Debug.Log("Screw with player one's camera.!");
				}
			}
			catch
			{
				Debug.Log("There was an error during creating a projectile");
			}
		}
	}
}