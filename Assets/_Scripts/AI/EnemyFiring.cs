using UnityEngine;
using System.Collections;
using Assets._Scripts.Player;

namespace Assets._Scripts.AI
{
	public class EnemyFiring : MonoBehaviour 
	{
		public float mShootTimerDefault = 4f;
		public GameObject mBullet;
		public GameObject mTargetPlayer;
		public ScoreKeeper mScoreKeeper;

		float mBulletTimer = 4f;
		public float mSBulletTimerDefault = 4f;
		// Use this for initialization
		void Start () 
		{
			mScoreKeeper = FindObjectOfType<ScoreKeeper>();
			ScaleBulletTime();


		}
		
		// Update is called once per frame
		void Update () 
		{
			mBulletTimer -= Time.deltaTime;
			
			if(mBulletTimer <= 0f)
			{
				
				FireEnemyBullet();
				
				ScaleBulletTime();
				
			}

		}


		public void FireEnemyBullet()
		{
			GameObject newBullet = Instantiate(mBullet, transform.position, Quaternion.identity) as GameObject;
			newBullet.GetComponent<EnemyBulletController>().mPlayer = mTargetPlayer;
		}

		void ScaleBulletTime()
		{
			//Scale firing speed based on who is winning `Adam
			if(mScoreKeeper != null && GetComponent<Enemy>().mTargetPlayerNumber == 1)
			{
				mBulletTimer = mShootTimerDefault/( (mScoreKeeper.mP1Wins+1f)/(mScoreKeeper.mP2Wins+1f) * (mScoreKeeper.mP1Score+1f)/(mScoreKeeper.mP2Score+1f) );
			}
			else if(mScoreKeeper != null && GetComponent<Enemy>().mTargetPlayerNumber == 2)
			{
				mBulletTimer = mShootTimerDefault/( (mScoreKeeper.mP2Wins+1f)/(mScoreKeeper.mP1Wins+1f) * (mScoreKeeper.mP2Score+1f)/(mScoreKeeper.mP1Score+1f) );
			}

		}
	}
}
