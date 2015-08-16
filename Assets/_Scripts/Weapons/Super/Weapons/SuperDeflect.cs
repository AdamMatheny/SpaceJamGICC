using UnityEngine;
using System.Collections;
using Assets._Scripts.Player;
using Assets._Scripts.AI;

namespace Assets._Scripts.Weapons
{
	public class SuperDeflect : Weapon
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

				activatingPlayer.GetComponent<PlayerControl> ().deflect = true;
				//activatingPlayer.GetComponent<PlayerControl> ().Deflect();
			}
			catch
			{
				Debug.Log("There was an error during creating a projectile");
			}
		}
	}
}