using UnityEngine;
using System.Collections;
using Assets._Scripts.Player;

//For regulating having this enemy fire bullets `Adam

namespace Assets._Scripts.AI
{
	public class EnemyFiring : MonoBehaviour 
	{
		public GameObject mBullet;

		public ScoreKeeper mScoreKeeper;

		[SerializeField] private float mBulletTimer;
		public float mShootTimerDefault = 3f;

		// Use this for initialization
		void Start () 
		{
			mScoreKeeper = FindObjectOfType<ScoreKeeper>();
			mBulletTimer = mShootTimerDefault;

			//Scale firing speed based on who is winning `Adam
			if(mScoreKeeper != null && GetComponent<Enemy>().mTargetPlayerNumber == 1)
			{
				mBulletTimer = mShootTimerDefault/( (mScoreKeeper.mPlayer1Wins+1f)/(mScoreKeeper.mPlayer2Wins+1f) * (mScoreKeeper.mPlayer1Kills+1f)/(mScoreKeeper.mPlayer2Kills+1f) );
			}
			else if(mScoreKeeper != null && GetComponent<Enemy>().mTargetPlayerNumber == 2)
			{
				mBulletTimer = mShootTimerDefault/( (mScoreKeeper.mPlayer2Wins+1f)/(mScoreKeeper.mPlayer1Wins+1f) * (mScoreKeeper.mPlayer2Kills+1f)/(mScoreKeeper.mPlayer1Kills+1f) );
			}

		}
		
		// Update is called once per frame
		void Update () 
		{
			mBulletTimer -= Time.deltaTime;

			if(mBulletTimer <= 0f)
			{

				FireEnemyBullet();

				mBulletTimer = mShootTimerDefault;

			}
		}

		public void FireEnemyBullet()
		{
			GameObject newBullet = Instantiate(mBullet, transform.position, Quaternion.identity) as GameObject;
			newBullet.GetComponent<EnemyBulletController>().mPlayer = GetComponent<Enemy>().mTargetPlayer.gameObject;
		}
	}
}