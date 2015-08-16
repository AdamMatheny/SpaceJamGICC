using UnityEngine;
using System.Collections;
using Assets._Scripts.Player;
using Assets._Scripts.UI;
using Assets._Scripts.Managers;
using Assets._Scripts.Audio;

namespace Assets._Scripts.Weapons
{
	public class SuperWeaponDisable : Weapon
	{
		public GameObject[] players = new GameObject[1];
		public GameObject activatingPlayer;

		public override void Shoot(GameObject playerToAffect){
			
			try
			{
				AudioManager.instance.PlayMegaWeaponSound(MegaWeaponType.WeaponDisable);

				players = GameObject.FindGameObjectsWithTag("Player");
				
				foreach(GameObject player in players){
					
					if(player.gameObject != playerToAffect.gameObject){
						
						activatingPlayer = player;
					}
				}


				if(!playerToAffect.gameObject.GetComponent<PlayerControl> ().deflect){
					
					playerToAffect.gameObject.GetComponent<PlayerWeapons> ().canShoot = false;
					playerToAffect.gameObject.GetComponent<PlayerControl> ().DisableWeapon();
				}else{
					
					playerToAffect.gameObject.GetComponent<PlayerControl> ().deflect = false;
				}
				GUIManager.instance.GetGUIScreen(ScreenType.PlayScreen).GetComponent<PlayScreenControler> ().UnsetUpWeaponImageForPlayer(activatingPlayer.GetComponent<PlayerBase> ().mPlayerNumber);    

			}
			catch
			{
				Debug.Log("There was an error during creating a projectile");
			}
		}
	}
}