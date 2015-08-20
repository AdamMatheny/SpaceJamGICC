using UnityEngine;
using System.Collections;
using Assets._Scripts.Player;
using Assets._Scripts.Managers;

namespace Assets._Scripts.AI
{
	public class Enemy : MonoBehaviour 
	{
		public GameObject[] players = new GameObject[1];
		public GameObject otherPlayer;

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

			switch (mTargetPlayerNumber)
			{
			case 1:
				mTargetPlayer = VehiclesManager.instance.Player1Ship.gameObject;
				break;
			case 2:
				mTargetPlayer = VehiclesManager.instance.Player2Ship.gameObject;
				
				break;
			default:
				mTargetPlayer = VehiclesManager.instance.Player1Ship.gameObject;
				break;
			}


			mMovementComponent.mPlayer = mTargetPlayer.transform;
			mFiringComponent.mTargetPlayer = mTargetPlayer.gameObject;

			players = GameObject.FindGameObjectsWithTag ("Player");
			
			foreach (GameObject player in players) {
				
				if(player != mTargetPlayer){

					otherPlayer = player;
				}
			}
		
		}
		
		// Update is called once per frame
		void Update () 
		{
			
		}

		public void EnemyShipDie()
		{

			if (mTargetPlayer.GetComponent<PlayerControl> ().displace) {


				//Debug.Log ("Displace Enemies");
				if(mTargetPlayerNumber == 1){

					transform.position += new Vector3(100, 0, 0);
					mScoreKeeper.mP2RoundKills -= 1;
				}else{

					transform.position -= new Vector3(100, 0, 0);
					mScoreKeeper.mP2RoundKills -= 1;
				}

				mTargetPlayer = otherPlayer;
				
				mMovementComponent.mPlayer = otherPlayer.transform;
				mFiringComponent.mTargetPlayer = otherPlayer.gameObject;
				
				mMovementComponent.mUsesSwarm = false;
				mMovementComponent.mUsesLoop = false;
				mMovementComponent.mRushPlayer = true;
				mMovementComponent.mHasLooped = false;
				mMovementComponent.mCurrentAIState = EnemyMovement.AIState.ApproachingSwarm;
				mMovementComponent.mIsDisplaced = true;

			} else {

				if(mDeathEffect != null)
				{
					//Debug.Log("Create Death Effect");
					
					Instantiate(mDeathEffect, transform.position, Quaternion.identity);
				}
				Destroy(this.gameObject);
			}

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