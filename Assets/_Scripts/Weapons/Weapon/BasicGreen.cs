﻿using UnityEngine;

namespace Assets._Scripts.Weapons
{
	public class BasicGreen : Weapon
	{
		public override void Shoot(GameObject playerToAffect){
			
			////try
			////{
				if(!isUpgraded){
					
					//Debug.Log("Created a basic bullet.");
					var spawnedProjectileLeft = (Projectile)Instantiate(WeaponProjectile, new Vector2(gameObject.transform.position.x - 1, gameObject.transform.position.y), new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z, 0));
					//spawnedProjectileLeft.mPlayerNumber = playerNumber;
					//spawnedProjectileLeft.transform.Rotate(new Vector3(0, 0, 30));
					spawnedProjectileLeft.Init(Damage, Speed);

					var spawnedProjectileMiddle = (Projectile)Instantiate(WeaponProjectile, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 1), new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z, 0));
					//spawnedProjectileMiddle.mPlayerNumber = playerNumber;
					//spawnedProjectileLeft.transform.Rotate(new Vector3(0, 0, 30));
					spawnedProjectileMiddle.Init(Damage, Speed);
					
					var spawnedProjectileRight = (Projectile)Instantiate(WeaponProjectile, new Vector2(gameObject.transform.position.x + 1, gameObject.transform.position.y), new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z, 0));
					//spawnedProjectileRight.mPlayerNumber = playerNumber;
					//spawnedProjectileRight.transform.Rotate(new Vector3(0, 0, -30));
					spawnedProjectileRight.Init(Damage, Speed);
				}else{
					
					//Debug.Log("Created an upgraded triple bullet.");
					
				var spawnedProjectile = (Projectile)Instantiate(WeaponProjectile, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 1.8f), gameObject.transform.rotation);
					//spawnedProjectile.mPlayerNumber = playerNumber;
					spawnedProjectile.Init(UpgradedDamage, UpgradedSpeed);
					
				var spawnedProjectileLeft = (Projectile)Instantiate(UpgradedWeaponProjectile, new Vector2(gameObject.transform.position.x + 1.3f, gameObject.transform.position.y), gameObject.transform.rotation);
					//spawnedProjectileLeft.mPlayerNumber = playerNumber;
					spawnedProjectileLeft.transform.Rotate(new Vector3(0, 0, -45));
					spawnedProjectileLeft.Init(UpgradedDamage, UpgradedSpeed);
					
				var spawnedProjectileRight = (Projectile)Instantiate(UpgradedWeaponProjectile, new Vector2(gameObject.transform.position.x - 1.3f, gameObject.transform.position.y), gameObject.transform.rotation);
					//spawnedProjectileRight.mPlayerNumber = playerNumber;
					spawnedProjectileRight.transform.Rotate(new Vector3(0, 0, 45));
					spawnedProjectileRight.Init(UpgradedDamage, UpgradedSpeed);
				}
			////}
			///catch
			///{
			///	Debug.Log("There was an error during creating a projectile");
			///}
		}
	}
}