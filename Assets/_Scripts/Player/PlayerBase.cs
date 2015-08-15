using UnityEngine;

namespace Assets._Scripts.Player
{
	public class PlayerBase : MonoBehaviour {
		
		public PlayerControl PlayerControlComponent;
		public PlayerVisuals PlayerVisualsComponent;
		public PlayerWeapons PlayerWeaponsComponent;
		public PlayerScore PlayerScoreComponent;
		
		public int mPlayerNumber;
	}
}
