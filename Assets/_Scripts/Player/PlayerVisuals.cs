using UnityEngine;

namespace Assets._Scripts.Player
{
	public enum VehicleType { RedShip, BlueShip, PinkShip, WhiteShip, GreenShip}
	
	public class PlayerVisuals : MonoBehaviour
	{
		public Animator PlayerAnimator;
		
		public VehicleType type;
		
		public Sprite DefaultSprite;
	}
}
