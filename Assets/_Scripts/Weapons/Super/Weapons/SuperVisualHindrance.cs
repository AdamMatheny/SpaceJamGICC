using UnityEngine;
using System.Collections;
using Assets._Scripts.Player;
using Assets._Scripts.AI;
using Assets._Scripts.Managers;
using Assets._Scripts.UI;

namespace Assets._Scripts.Weapons
{
	public class SuperVisualHindrance : Weapon
	{

		public int playerIndex;
		
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

				playerIndex = playerToAffect.GetComponent<PlayerBase> ().mPlayerNumber;
                

				CameraManager.instance.SetVisualHindranceForPlayer(playerIndex);

				GUIManager.instance.GetGUIScreen(ScreenType.PlayScreen).GetComponent<PlayScreenControler> ().UnsetUpWeaponImageForPlayer(activatingPlayer.GetComponent<PlayerBase> ().mPlayerNumber);    
			}
			catch
			{
				Debug.Log("There was an error during creating a projectile");
			}
		}
	}
}