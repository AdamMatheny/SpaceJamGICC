using UnityEngine;

namespace Assets._Scripts.Weapons
{
    public enum WeaponType { Basic, ControlSwap, EnemyDisplacement, SlowMotion, WeaponDisable, VisualHindrance, SuperDeflect }

	public class Weapon : MonoBehaviour
	{
		
		[Header("Base Weapon Info")]
		public int Damage;
		public float Speed;
		public float FireRate;
        public WeaponType type;
		
		[Header("Projectyles to Shoot")]
		public Projectile WeaponProjectile;
		
		[Header("Upgraded Weapon Info")] // ~ Jonathan
		public bool isUpgraded; 
		public int UpgradedDamage;
		public float UpgradedSpeed;
		//public float UpgradedFireRate;
		public float UpgradedDuration;
		public float UpgradedDurationStart;
		
		public void Start(){
			
			UpgradedDurationStart = UpgradedDuration;
		}
		
		public virtual void Update(){
			
			if (isUpgraded) {
				
				if (UpgradedDuration > 0) {
					
					UpgradedDuration -= Time.deltaTime;
				} else {
					
					isUpgraded = false;
					UpgradedDuration = UpgradedDurationStart;
				}
				
			}
		}
		
		[Header("Upgraded Projectile")] // ~ Jonathan
		public Projectile UpgradedWeaponProjectile;
		
		public virtual void Shoot(GameObject playerToAffect)
		{
			try
			{
				if(!isUpgraded){
					
					Debug.Log("Created a basic bullet.");
					var spawnedProjectile = (Projectile)Instantiate(WeaponProjectile, gameObject.transform.position, gameObject.transform.rotation);
					spawnedProjectile.Init(Damage, Speed);
				}else{
					
					Debug.Log("Created an upgraded bullet.");
					var spawnedProjectile = (Projectile)Instantiate(UpgradedWeaponProjectile, gameObject.transform.position, gameObject.transform.rotation);
					spawnedProjectile.Init(Damage, Speed);
				}
			}
			catch
			{
				Debug.Log("There was an error during creating a projectile");
			}
		}
	}
}
