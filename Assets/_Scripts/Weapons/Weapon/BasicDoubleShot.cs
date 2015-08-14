using UnityEngine;
using System.Collections;

namespace Assets._Scripts.Weapons
{
	public class BasicDoubleShot : Weapon
	{

		public override void Shoot(bool isPlayer1){
			
			try
			{
				if(!isUpgraded){

					var spawnedProjectile1 = (Projectile)Instantiate(WeaponProjectile, new Vector2(gameObject.transform.position.x - 1, gameObject.transform.position.y), gameObject.transform.rotation);
					spawnedProjectile1.Init(Damage, Speed);

					var spawnedProjectile2 = (Projectile)Instantiate(WeaponProjectile, new Vector2(gameObject.transform.position.x + 1, gameObject.transform.position.y), gameObject.transform.rotation);
					spawnedProjectile2.Init(Damage, Speed);
				}else{
					
					/*var spawnedProjectile = (Projectile)Instantiate(WeaponProjectile, gameObject.transform.position, gameObject.transform.rotation);
					spawnedProjectile.Init(UpgradedDamage, UpgradedSpeed);
					
					var spawnedProjectileLeft = (Projectile)Instantiate(UpgradedWeaponProjectile, gameObject.transform.position, gameObject.transform.rotation);
					spawnedProjectileLeft.transform.Rotate(new Vector3(0, 0, -45));
					spawnedProjectileLeft.Init(UpgradedDamage, UpgradedSpeed);
					
					var spawnedProjectileRight = (Projectile)Instantiate(UpgradedWeaponProjectile, gameObject.transform.position, gameObject.transform.rotation);
					spawnedProjectileRight.transform.Rotate(new Vector3(0, 0, 45));
					spawnedProjectileRight.Init(UpgradedDamage, UpgradedSpeed);*/
				}
			}
			catch
			{
				Debug.Log("There was an error during creating a projectile");
			}
		}
	}
}