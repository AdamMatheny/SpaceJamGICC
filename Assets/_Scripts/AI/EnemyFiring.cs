using UnityEngine;
using System.Collections;
using Assets._Scripts.Player;
using Assets._Scripts.Managers;

namespace Assets._Scripts.AI
{
	public class EnemyFiring : MonoBehaviour 
	{
		public float mBulletTimerDefault = 4f;
		public GameObject mBullet;
		public GameObject mTargetPlayer;
		public ScoreKeeper mScoreKeeper;

		public bool mRandomFire = false;

		float mBulletTimer = 4f;
		// Use this for initialization
		void Start () 
		{
			mScoreKeeper = ScoreKeeper.instance;
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
				mBulletTimer = mBulletTimerDefault/( (mScoreKeeper.mP1Wins+1f)/(mScoreKeeper.mP2Wins+1f) * (mScoreKeeper.mP1Score+1f)/(mScoreKeeper.mP2Score+1f) );
			}
			else if(mScoreKeeper != null && GetComponent<Enemy>().mTargetPlayerNumber == 2)
			{
				mBulletTimer = mBulletTimerDefault/( (mScoreKeeper.mP2Wins+1f)/(mScoreKeeper.mP1Wins+1f) * (mScoreKeeper.mP2Score+1f)/(mScoreKeeper.mP1Score+1f) );
			}

			if(mRandomFire)
			{
				mBulletTimer *= Random.Range (0.5f,1.5f);
			}

		}
	}
}
