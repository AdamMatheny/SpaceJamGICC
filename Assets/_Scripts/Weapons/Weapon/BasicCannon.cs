using UnityEngine;

namespace Assets._Scripts.Weapons
{
	public class BasicCannon : Weapon
	{
		public override void Shoot(GameObject playerToAffect){
			
			try
			{

				if(!isUpgraded){
					
					//Debug.Log("Created a basic bullet.");
					var spawnedProjectile = (Projectile)Instantiate(WeaponProjectile, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 3, gameObject.transform.position.z), gameObject.transform.rotation);
					spawnedProjectile.Init(Damage, Speed);
				}else{
					
					//Debug.Log("Created an upgraded triple bullet.");
					
					var spawnedProjectile = (Projectile)Instantiate(WeaponProjectile, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 3, gameObject.transform.position.z), gameObject.transform.rotation);
					spawnedProjectile.Init(UpgradedDamage, UpgradedSpeed);
					
					var spawnedProjectileLeft = (Projectile)Instantiate(UpgradedWeaponProjectile, new Vector3(gameObject.transform.position.x + 2f, gameObject.transform.position.y + 2.5f, gameObject.transform.position.z), gameObject.transform.rotation);
					spawnedProjectileLeft.transform.Rotate(new Vector3(0, 0, -45));
					spawnedProjectileLeft.Init(UpgradedDamage, UpgradedSpeed);
					
					var spawnedProjectileRight = (Projectile)Instantiate(UpgradedWeaponProjectile, new Vector3(gameObject.transform.position.x - 2f, gameObject.transform.position.y + 2.5f, gameObject.transform.position.z), gameObject.transform.rotation);
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