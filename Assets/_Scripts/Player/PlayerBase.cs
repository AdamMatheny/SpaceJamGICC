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
			PlayerControlComponent.mSpeedMod = 0.5f;
			PlayerControlComponent.mSpeedModTimer = 3.0f;

			//Once we get multiple weapon levels in, have a chance to reduce weapon level for 6 seconds instead `Adam
		}
	}
}
