using UnityEngine;
using System.Collections;
using Assets._Scripts.Player;
using Assets._Scripts.AI;
using Assets._Scripts.Managers;
using Assets._Scripts.UI;
using Assets._Scripts.Audio;

namespace Assets._Scripts.Weapons
{
	public class SuperMegaWeapon : Weapon
	{
		
		public GameObject[] players = new GameObject[1];
		public GameObject activatingPlayer;
		
		public override void Shoot(GameObject playerToAffect){
			
			try
			{
				//AudioManager.instance.PlayMegaWeaponSound(MegaWeaponType.Deflect);
				
				players = GameObject.FindGameObjectsWithTag("Player");
				
				foreach(GameObject player in players){
					
					if(player.gameObject != playerToAffect.gameObject){
						
						activatingPlayer = player;
					}
				}
				
				//activatingPlayer.GetComponent<PlayerControl> ().deflect = true;
				activatingPlayer.GetComponent<PlayerWeapons> ().MegaTimer();
				
				//GUIManager.instance.GetGUIScreen(ScreenType.PlayScreen).GetComponent<PlayScreenControler>().UnsetUpWeaponImageForPlayer(int playerIndex)
				GUIManager.instance.GetGUIScreen(ScreenType.PlayScreen).GetComponent<PlayScreenControler> ().UnsetUpWeaponImageForPlayer(activatingPlayer.GetComponent<PlayerBase> ().mPlayerNumber);    
			}
			catch
			{
				Debug.Log("There was an error during creating a projectile");
			}
		}
	}
}