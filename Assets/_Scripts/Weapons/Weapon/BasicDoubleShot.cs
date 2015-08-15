﻿using UnityEngine;

namespace Assets._Scripts.Weapons
{
	public class BasicDoubleShot : Weapon
	{
		public override void Shoot(GameObject playerToAffect){
			
			try
			{
				if(!isUpgraded){
					
					//Debug.Log("Created a basic bullet.");
					var spawnedProjectileLeft = (Projectile)Instantiate(WeaponProjectile, new Vector2(gameObject.transform.position.x - 1, gameObject.transform.position.y), gameObject.transform.rotation);
					spawnedProjectileLeft.Init(Damage, Speed);

					var spawnedProjectileRight = (Projectile)Instantiate(WeaponProjectile, new Vector2(gameObject.transform.position.x + 1, gameObject.transform.position.y), gameObject.transform.rotation);
					spawnedProjectileRight.Init(Damage, Speed);
				}else{
					
					//Debug.Log("Created an upgraded triple bullet.");
					
					var spawnedProjectile = (Projectile)Instantiate(WeaponProjectile, gameObject.transform.position, gameObject.transform.rotation);
					spawnedProjectile.Init(UpgradedDamage, UpgradedSpeed);
					
					var spawnedProjectileLeft = (Projectile)Instantiate(UpgradedWeaponProjectile, gameObject.transform.position, gameObject.transform.rotation);
					spawnedProjectileLeft.transform.Rotate(new Vector3(0, 0, -45));
					spawnedProjectileLeft.Init(UpgradedDamage, UpgradedSpeed);
					
					var spawnedProjectileRight = (Projectile)Instantiate(UpgradedWeaponProjectile, gameObject.transform.position, gameObject.transform.rotation);
					spawnedProjectileRight.transform.Rotate(new Vector3(0, 0, 45));
					spawnedProjectileRight.Init(UpgradedDamage, UpgradedSpeed);
				}
			}
			catch
			{
				Debug.Log("There was an error during creating a projectile");
			}
		}
	}
}