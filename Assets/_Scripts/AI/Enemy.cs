using UnityEngine;
using System.Collections;

namespace Assets._Scripts.AI
{
	public class Enemy : MonoBehaviour 
	{
		public int mTargetPlayerNumber;
		public GameObject mTargetPlayer;
		public EnemyMovement mMovementComponent;
		public EnemyFiring mEFiringComponent;
		public EnemyVisuals mVisualsComponent;

		// Use this for initialization
		void Start () 
		{
			
		}
		
		// Update is called once per frame
		void Update () 
		{
			
		}

		public void EnemyShipDie()
		{

			Destroy(this.gameObject);
		}
	}
}