using UnityEngine;
using System.Collections;
using Assets._Scripts.Player;

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
			foreach (PlayerBase potentialTarget in FindObjectsOfType<PlayerBase>())
			{
				if(potentialTarget.mPlayerNumber == mTargetPlayerNumber)
				{
					mTargetPlayer= mTargetPlayer.gameObject;
					mMovementComponent.mPlayer = mTargetPlayer.transform;
					mEFiringComponent.mTargetPlayer = mTargetPlayer;
				}
			}
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