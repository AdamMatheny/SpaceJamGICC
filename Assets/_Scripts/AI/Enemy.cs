using UnityEngine;
using System.Collections;
using Assets._Scripts.Player;
using Assets._Scripts.Managers;

namespace Assets._Scripts.AI
{
	public class Enemy : MonoBehaviour 
	{
		public Transform enemyDisplace1;
		public Transform enemyDisplace2;

		public GameObject otherTarget;

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

			mScoreKeeper = FindObjectOfType<ScoreKeeper>();

			foreach (PlayerBase potentialTarget in FindObjectsOfType<PlayerBase>())
			{
				//Debug.Log ("Looking for Player");
				if(potentialTarget.mPlayerNumber == mTargetPlayerNumber)
				{
					//Debug.Log ("Found a player to target!");
					mTargetPlayer= potentialTarget.gameObject;
					mMovementComponent.mPlayer = potentialTarget.transform;
					mFiringComponent.mTargetPlayer = potentialTarget.gameObject;
				}else{

					otherTarget = potentialTarget.gameObject;
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

				if(!mTargetPlayer.GetComponent<PlayerControl> ().displace){

					Destroy(other.gameObject);
					EnemyShipDie();
				}else{


					if(mTargetPlayer.GetComponent<PlayerBase> ().mPlayerNumber == 1){

						Vector3 displacePosition = new Vector3(100, 0, 0);

						transform.position = transform.position + displacePosition;
						gameObject.GetComponent<EnemyMovement> ().mOriginPoint = gameObject.GetComponent<EnemyMovement> ().mOriginPoint + displacePosition;
						gameObject.GetComponent<EnemyMovement> ().mFinalDestPoint = gameObject.GetComponent<EnemyMovement> ().mFinalDestPoint + displacePosition;
					}else{

						Vector3 displacePosition = new Vector3(-100, 0, 0);
						
						transform.position = transform.position + displacePosition;
						gameObject.GetComponent<EnemyMovement> ().mOriginPoint = gameObject.GetComponent<EnemyMovement> ().mOriginPoint + displacePosition;
						gameObject.GetComponent<EnemyMovement> ().mFinalDestPoint = gameObject.GetComponent<EnemyMovement> ().mFinalDestPoint + displacePosition;
					}

					Debug.Log("Displaced!");
					mTargetPlayer = otherTarget;
					mMovementComponent.mPlayer = otherTarget.transform;
					mFiringComponent.mTargetPlayer = otherTarget.gameObject;

					GetComponent<EnemyMovement> ().mRushPlayer = true;
					GetComponent<EnemyMovement> ().mHasLooped = false;
					GetComponent<EnemyMovement> ().mUsesSwarm = false;
					GetComponent<EnemyMovement> ().mCurrentAIState = EnemyMovement.AIState.ApproachingSwarm;
				}

				Destroy(other);

			}

			//Hit Player
			if(other.GetComponent<PlayerBase>() != null)
			{
				other.GetComponent<PlayerBase>().mHitPlayer();
			}
		}
	}
}