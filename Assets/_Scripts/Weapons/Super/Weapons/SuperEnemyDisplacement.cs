using UnityEngine;
using System.Collections;
using Assets._Scripts.Player;
using Assets._Scripts.AI;

namespace Assets._Scripts.Weapons
{
	public class SuperEnemyDisplacement : Weapon
	{

		public GameObject[] players = new GameObject[1];
		public GameObject activatingPlayer;
		
		public override void Shoot(GameObject playerToAffect){
	
			try
			{
				players = GameObject.FindGameObjectsWithTag("Player");

				foreach(GameObject player in players){

					if(player.gameObject != playerToAffect.gameObject){

						activatingPlayer = player;
					}
				}

				activatingPlayer.GetComponent<PlayerControl> ().displace = true;
				activatingPlayer.GetComponent<PlayerControl> ().EnemyDisplacement();
			}
			catch
			{
				Debug.Log("There was an error during creating a projectile");
			}
		}
	}
}