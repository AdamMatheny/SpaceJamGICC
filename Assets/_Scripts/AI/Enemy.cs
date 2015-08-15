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
		public EnemyFiring mFiringComponent;
		public EnemyVisuals mVisualsComponent;

		public ScoreKeeper mScoreKeeper;

		public GameObject mDeathEffect;

		// Use this for initialization
		void Start () 
		{
			mScoreKeeper = FindObjectOfType<ScoreKeeper>();

			foreach (PlayerBase potentialTarget in FindObjectsOfType<PlayerBase>())
			{
				Debug.Log ("Looking for Player");
				if(potentialTarget.mPlayerNumber == mTargetPlayerNumber)
				{
					Debug.Log ("Found a player to target!");
					mTargetPlayer= potentialTarget.gameObject;
					mMovementComponent.mPlayer = potentialTarget.transform;
					mFiringComponent.mTargetPlayer = potentialTarget.gameObject;
				}
			}
		}
		
		// Update is called once per frame
		void Update () 
		{
			
		}

		public void EnemyShipDie()
		{
			if(mTargetPlayerNumber == 1)
			{
				mScoreKeeper.mP1Score ++;
				mScoreKeeper.mP1RoundKills++;
			}
			else if(mTargetPlayerNumber == 2)
			{
				mScoreKeeper.mP2Score ++;
				mScoreKeeper.mP2RoundKills++;
			}
			if(mDeathEffect != null)
			{
				Instantiate(mDeathEffect, Vector3.zero, Quaternion.identity);
			}
			Destroy(this.gameObject);
		}

		void OnTriggerEnter2D(Collider2D other)
		{
			//Get Shot)
			if(other.tag == "PlayerBullet")
			{
				Destroy(other.gameObject);
				EnemyShipDie();

			}
		}
	}
}