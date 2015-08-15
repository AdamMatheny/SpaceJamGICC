﻿using UnityEngine;
using Assets._Scripts.Weapons;
using Assets._Scripts.Managers;
using Assets._Scripts.Audio;
using Assets._Scripts.AI;

namespace Assets._Scripts.Player
{
	public class PlayerWeapons : MonoBehaviour
	{
		public GameObject[] enemySpawners = new GameObject[1];

		public bool canShoot;

		public float fireRate;
		public float tempFireRate;
		
		public Weapon BaseWeapon;
		
		public Weapon SuperWeapon1 = null;
		
		public void ShootBaseWeapon()
		{
			BaseWeapon.Shoot(null); 

			AudioManager.instance.PlayRedShipSound(ShipRedSoundType.ShootBasic);
		}
		
		public void ShootSuperWeapon1(GameObject playerToAffect)
		{
			SuperWeapon1.Shoot(playerToAffect);
		}
		
		public void Start(){

			fireRate = BaseWeapon.FireRate / 10;
			
			tempFireRate = fireRate;
		}
		
		public void Update(){

			enemySpawners = GameObject.FindGameObjectsWithTag ("Spawner");

			foreach (GameObject spawner in enemySpawners) {

				if(!spawner.GetComponent<EnemyShipSpawner> ().mSpawning){

					canShoot = true;
				}
			}

			if (canShoot) {
			
				if (tempFireRate > 0) {
				
					tempFireRate -= Time.deltaTime;
				} else {
				
					ShootBaseWeapon ();
					tempFireRate = fireRate;
				}
			}
		}
	}
}
