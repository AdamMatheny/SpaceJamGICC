using UnityEngine;
using System.Collections;
using Assets._Scripts.Player;

namespace Assets._Scripts.AI
{
	public class EnemyShipSpawner : MonoBehaviour 
	{

		public int mTargetPlayerNumber = 1;
		public ScoreKeeper mScoreKeeper;

		[SerializeField] private bool mUseSwarm;
		[SerializeField] private bool mRushPlayer;


		//The SwarmGrid this spawner is sending enemies to
		public SwarmGrid mTargetSwarmGrid;
		//Whether or not to have the spawned enemies fly to and loop around a specified point
		[SerializeField] private bool mUsingLoopPoint = false;
		//The point that the spawned enemies will loop around if the above is true
		[SerializeField] private GameObject mLoopPoint;
		[SerializeField] private GameObject mFinalRushPoint;


		//*****Values for overriding spawned enemy properties******

		//Overriden flight speed value
		[SerializeField] private float mOverriddenFlightSpeed = 15f;
		[SerializeField] private float mOverriddenFormSpeed = 15f;
		//Whether or not the spawned enemies skip the looping step on their way to the swarm for the first time
		[SerializeField] private bool mDontDoFirstLoop = false;
		//How tight to make the overriden loops
		[SerializeField] private float mLoopOverrideTightnessAmount = 1f;
		//How long to make the overriden loops last
		[SerializeField] private float mLoopOverrideTimeAmount = 0.5f;
		//How long to make the overriden loops last
		[SerializeField] private float mAttackFrequencyOverrideTimeAmount = 10f;

		[SerializeField] private float mShootingFrequencyOverrideTimeAmount = 2f;



		//*****End of spawned enemy override variables*****

		//Are we currently spawning enemies?
		public bool mSpawning = true;
		//The speed at which enemies are spawned
		public float mDefaultSpawnInterval = 1f;
		private float mSpawnInterval;
		//How long to wait before enemies are first spawned
		public float mWaveStartTime = 2f;
		public int mStartKillNumber = 0;
		//Which type of enemy to spawn
		public GameObject mEnemyToSpawn;
		//How many enemies to spawn per wave
		[SerializeField] private int mMaxEnemySpawn = 5;
		//How many enemies we've spawned so far
		[HideInInspector] public int mSpawnCounter = 0;


		public SwarmSpecialBehavior mSwarmSpecial;
		// Use this for initialization
		void Start () 
		{
			mSpawnInterval = mDefaultSpawnInterval;
			mScoreKeeper = FindObjectOfType<ScoreKeeper>();


		

		}//END of Start()
		
		// Update is called once per frame
		void Update () 
		{


			//Start counting down to spawn if enough enemies have been killed Adam
			switch (mTargetPlayerNumber)
			{
			case 1:
				if(mStartKillNumber <= mScoreKeeper.mP1RoundKills)
				{
					mWaveStartTime -= Time.deltaTime;
				}
				break;
			case 2:
				if(mStartKillNumber <= mScoreKeeper.mP2RoundKills)
				{
					mWaveStartTime -= Time.deltaTime;
				}
				break;
			default:
				mWaveStartTime -= Time.deltaTime;
				break;
			}

			if (mWaveStartTime <= 0.0f && mSpawning)
			{
				SpawnEnemies();
				if(mSwarmSpecial != null)
				{
					mSwarmSpecial.enabled = true;
				}
			}
		}//END of Update()

		public void SpawnEnemies()
		{
			mSpawnInterval -= Time.deltaTime;
			
			if (mSpawnInterval <= 0.0f)
			{
				GameObject NewEnemy = Instantiate(mEnemyToSpawn, transform.position, Quaternion.identity) as GameObject;
				NewEnemy.GetComponent<Enemy>().mTargetPlayerNumber = mTargetPlayerNumber;
				NewEnemy.GetComponent<EnemyMovement>().mSwarmGrid = mTargetSwarmGrid;
				NewEnemy.GetComponent<EnemyMovement>().mUsesSwarm = mUseSwarm;
				NewEnemy.GetComponent<EnemyMovement>().mRushPlayer = mRushPlayer;



				//Override flight speeds ~Adam
				NewEnemy.GetComponent<EnemyMovement>().mDefaultSpeed = mOverriddenFlightSpeed;

				NewEnemy.GetComponent<EnemyMovement>().mFormSpeed = mOverriddenFormSpeed;

				//If statements for overriding the Loop behavior for the spawned enemies
				if(mDontDoFirstLoop)
				{
					NewEnemy.GetComponent<EnemyMovement>().mHasLooped = true;
				}
				if (mUsingLoopPoint && mLoopPoint != null)
				{
					NewEnemy.GetComponent<EnemyMovement>().mLoopPoint = this.mLoopPoint.transform.position;
				}
				NewEnemy.GetComponent<EnemyMovement>().mLoopCircleTightness = mLoopOverrideTightnessAmount;

				NewEnemy.GetComponent<EnemyMovement>().mLoopTime = mLoopOverrideTimeAmount;

				if(mFinalRushPoint != null)
				{
					NewEnemy.GetComponent<EnemyMovement>().mFinalDestPoint = mFinalRushPoint.transform.position;
				}

				//Override Shooting frequency
				NewEnemy.GetComponent<EnemyFiring>().mBulletTimerDefault = mShootingFrequencyOverrideTimeAmount;



				//Delete the enemy if it couldn't find a spot in the swarm
				if (NewEnemy.GetComponent<EnemyMovement>().mSwarmGrid == null && mUseSwarm)
				{
					Destroy(NewEnemy.gameObject);
				}
			
				mSpawnCounter++;
				mSpawnInterval += mDefaultSpawnInterval;
				
				if (mSpawnCounter >= mMaxEnemySpawn)
				{
					mSpawning = false;
				}
			}
		}
	}
}