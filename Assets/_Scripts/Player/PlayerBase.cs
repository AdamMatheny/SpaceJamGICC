using UnityEngine;

namespace Assets._Scripts.Player
{
	public class PlayerBase : MonoBehaviour 
	{
		
		public PlayerControl PlayerControlComponent;
		public PlayerVisuals PlayerVisualsComponent;
		public PlayerWeapons PlayerWeaponsComponent;
		public PlayerScore PlayerScoreComponent;
		
		public int mPlayerNumber;



		public void mHitPlayer()
		{
			//Slow down the player for 3 seconds `Adam

			int rand = Random.Range (1, 4);

			switch(rand){

			case 1:
				Debug.Log("SlowDown");
				PlayerControlComponent.mSpeedMod = 0.5f;
				PlayerControlComponent.mSpeedModTimer = 3.0f;
				break;
			case 2:
				Debug.Log("BadShoot");
				PlayerControlComponent.mFireRateMod = 2f;
				PlayerWeaponsComponent.fireRate *= 2;
				PlayerControlComponent.mFireRateModTimer = 3.0f;
				break;
			case 3:
				//DowngradeWeapon
				break;
			default:
				Debug.Log("Bing It");
				break;
			}

			//Once we get multiple weapon levels in, have a chance to reduce weapon level for 6 seconds instead `Adam
		}
	}
}
