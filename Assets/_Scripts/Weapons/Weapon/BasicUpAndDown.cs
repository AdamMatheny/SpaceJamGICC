using UnityEngine;

namespace Assets._Scripts.Weapons
{
	public class BasicUpAndDown : Weapon
	{
		public override void Shoot(GameObject playerToAffect){
			
			try
			{
				if(!isUpgraded){
					
					//Debug.Log("Created a basic bullet.");
					var spawnedProjectileUp = (Projectile)Instantiate(WeaponProjectile, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 2), new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z, 0));
					spawnedProjectileUp.Init(Damage, Speed);
					
					var spawnedProjectileDown = (Projectile)Instantiate(WeaponProjectile, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 2), new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z, 0));
					spawnedProjectileDown.Init(Damage, -Speed);
				}else{
					
					//Debug.Log("Created an upgraded triple bullet.");
					
					var spawnedProjectile = (Projectile)Instantiate(WeaponProjectile, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 2.3f), gameObject.transform.rotation);
					spawnedProjectile.Init(UpgradedDamage, UpgradedSpeed);
					
					var spawnedProjectileLeft = (Projectile)Instantiate(UpgradedWeaponProjectile, new Vector2(gameObject.transform.position.x - 1.8f, gameObject.transform.position.y + 1.5f), gameObject.transform.rotation);
					//spawnedProjectileLeft.transform.Rotate(new Vector3(0, 0, -45));
					spawnedProjectileLeft.Init(UpgradedDamage, UpgradedSpeed);
					
					var spawnedProjectileRight = (Projectile)Instantiate(UpgradedWeaponProjectile, new Vector2(gameObject.transform.position.x + 1.8f, gameObject.transform.position.y + 1.5f), gameObject.transform.rotation);
					//spawnedProjectileRight.transform.Rotate(new Vector3(0, 0, 45));
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