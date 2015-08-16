﻿using UnityEngine;
using System.Collections;
using Assets._Scripts.Player;
using Assets._Scripts.AI;
using Assets._Scripts.Managers;
using Assets._Scripts.UI;
using Assets._Scripts.Audio;

namespace Assets._Scripts.Weapons
{
	public class SuperVisualHindrance : Weapon
	{

		public GameObject cameraManager;

		public GameObject[] players = new GameObject[1];
		public GameObject activatingPlayer;
		
		public override void Shoot(GameObject playerToAffect){

			cameraManager = GameObject.FindGameObjectWithTag ("CameraManager");

			AudioManager.instance.PlayMegaWeaponSound(MegaWeaponType.VisionHindrance);
			
			//try
			//{
				players = GameObject.FindGameObjectsWithTag("Player");
				
				foreach(GameObject player in players){
					
					if(player.gameObject != playerToAffect.gameObject){
						
						activatingPlayer = player;
					}
				}

				//Debug.Log("Used Visual Fuck");

				//CameraManager.instance.SetVisualHindranceForPlayer(playerIndex);
			int playerIndexToAffect = playerToAffect.GetComponent<PlayerBase> ().mPlayerNumber;
			//Debug.Log (playerIndexToAffect);
			//CameraManager.instance.SetVisualHindranceForPlayer(playerIndexToAffect);
			cameraManager.GetComponent<CameraManager> ().SetVisualHindranceForPlayer (playerIndexToAffect);

				GUIManager.instance.GetGUIScreen(ScreenType.PlayScreen).GetComponent<PlayScreenControler> ().UnsetUpWeaponImageForPlayer(activatingPlayer.GetComponent<PlayerBase> ().mPlayerNumber);    
			//}
			//catch
			//{
			//	Debug.Log("There was an error during creating a projectile");
			//}
		}
	}
}