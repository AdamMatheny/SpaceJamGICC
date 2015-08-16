using UnityEngine;
using System.Collections;
using Assets._Scripts.Player;
using Assets._Scripts.Managers;

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
            gameObject.transform.parent = MapManager.instance.EnemiesTransform;

			mScoreKeeper = ScoreKeeper.instance;

			foreach (PlayerBase potentialTarget in FindObjectsOfType<PlayerBase>())
			{
				if(potentialTarget.mPlayerNumber == mTargetPlayerNumber)
				{
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

			//Debug.Log ("Died");
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
				//Debug.Log("Create Death Effect");

				Instantiate(mDeathEffect, transform.position, Quaternion.identity);
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

			//Hit Player
			if(other.GetComponent<PlayerBase>() != null)
			{
				other.GetComponent<PlayerBase>().mHitPlayer();
			}
		}
	}
}