﻿using UnityEngine;
using System.Collections;

namespace Assets._Scripts.Weapons
{
	public class SuperWeaponDisable : Weapon
	{
		
		public override void Shoot(GameObject playerToAffect){
			
			try
			{

			}
			catch
			{
				Debug.Log("There was an error during creating a projectile");
			}
		}
	}
}