using UnityEngine;
using System.Collections;

namespace Assets._Scripts.AI
{
	public class EnemyShipSpawner : MonoBehaviour 
	{
		public int mPlayerSideNumber = 1;
		public ScoreKeeper mScoreKeeper;


		[SerializeField] private bool mUseSwarm;
		[SerializeField] private bool mRushAtPlayer;


		//The SwarmGrid this spawner is sending enemies to
		public SwarmGrid mTargetSwarmGrid;
		//Whether or not to have the spawned enemies fly to and loop around a specified point
		[SerializeField] private bool mUsingLoopPoint = false;
		//The point that the spawned enemies will loop around if the above is true
		[SerializeField] private GameObject mLoopPoint;
		[SerializeField] private GameObject mFinalTargetPoint;

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
		//Whther or not to ovveride how long is spent in the swarm between making attacks
		[SerializeField] private float mAttackFrequencyOverrideTimeAmount = 10f;
		//How long to make the overriden loops last
		[SerializeField] private float mAttackLengthOverrideTimeAmount = 10f;
		//How often to shoot
		[SerializeField] private float mShootingFrequencyOverrideTimeAmount = 2f;


		[SerializeField] private float mMininumFirstAttackTimeOverride = 0f;



		//*****End of spawned enemy override variables*****

		//Are we currently spawning enemies?
		public bool mSpawning = true;
		//The speed at which enemies are spawned
		public float mDefaultSpawnInterval = 1f;
		private float mSpawnInterval;
		//How long to wait before enemies are first spawned
		public float mWaveStartTime = 2f;
		public int mRequiredKillsToStart = 0;
		//Which type of enemy to spawn
		public GameObject mEnemyToSpawn;
		//How many enemies to spawn per wave
		[SerializeField] private int mMaxEnemySpawn = 5;
		//How many enemies we've spawned so far
		[HideInInspector] public int mSpawnCounter = 0;


		[SerializeField] private SwarmSpecialMovement mSwarmSpecialBehavior;

		// Use this for initialization
		void Start () 
		{
			mSpawnInterval = mDefaultSpawnInterval;

			mScoreKeeper = FindObjectOfType<ScoreKeeper>();
		}//END of Start()
		
		// Update is called once per frame
		void Update () 
		{

			switch (mPlayerSideNumber)
			{
			case 1:
				if(mRequiredKillsToStart <= mScoreKeeper.mPlayer1RoundScore)
				{
					mWaveStartTime -= Time.deltaTime;
				}
				break;
			case 2:
				if(mRequiredKillsToStart <= mScoreKeeper.mPlayer2RoundScore)
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
				if(mSwarmSpecialBehavior != null)
				{
					mSwarmSpecialBehavior.enabled = true;
				}
			}
		}//END of Update()

		public void SpawnEnemies()
		{
			mSpawnInterval -= Time.deltaTime;
			
			if (mSpawnInterval <= 0.0f)
			{
				GameObject NewEnemy = Instantiate(mEnemyToSpawn, transform.position, Quaternion.identity) as GameObject;
				NewEnemy.GetComponent<Enemy>().mTargetPlayerNumber = mPlayerSideNumber;
				NewEnemy.GetComponent<EnemyMovement>().mSwarmGrid = mTargetSwarmGrid;

				NewEnemy.GetComponent<EnemyMovement>().mRushAtPlayer = mRushAtPlayer;
				NewEnemy.GetComponent<EnemyMovement>().mUseSwarm = mUseSwarm;

				//Overriding flight speed
				NewEnemy.GetComponent<EnemyMovement>().mSpeed = mOverriddenFlightSpeed;

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
				if(mFinalTargetPoint != null)
				{
					NewEnemy.GetComponent<EnemyMovement>().mTargetRushPoint = this.mFinalTargetPoint.transform.position;
				}

				NewEnemy.GetComponent<EnemyMovement>().mLoopCircleTightness = mLoopOverrideTightnessAmount;
				NewEnemy.GetComponent<EnemyMovement>().mLoopTime = mLoopOverrideTimeAmount;

				//If statements for overriding attack behavior

					NewEnemy.GetComponent<EnemyMovement>().mAttackFrequencyTimerDefault = mAttackFrequencyOverrideTimeAmount;
					NewEnemy.GetComponent<EnemyMovement>().mAttackLengthTimerDefault = mAttackLengthOverrideTimeAmount;
					NewEnemy.GetComponent<EnemyFiring>().mShootTimerDefault = mShootingFrequencyOverrideTimeAmount;


				//Delete the enemy if it couldn't find a spot in the swarm
				if (NewEnemy.GetComponent<EnemyMovement>().mSwarmGrid == null  && NewEnemy.GetComponent<EnemyMovement>().mUseSwarm)
				{
					Destroy(NewEnemy.gameObject);
				}
			
				mSpawnCounter++;
				mSpawnInterval += mDefaultSpawnInterval;
				
				if (mSpawnCounter >= mMaxEnemySpawn)
				{
					mSpawnCounter = 0;

					mSpawning = false;

				}
			}
		}
	}
}