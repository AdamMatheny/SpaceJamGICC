using UnityEngine;
using System.Collections;
using Assets._Scripts.Player;
using Assets._Scripts.Managers;

namespace Assets._Scripts.AI
{
	public class MiniBoss : MonoBehaviour 
	{
		//Which player to target ~Adam
		public int mTargetPlayerNumber = 1;
		public GameObject mPlayer;

		[SerializeField] private SpriteRenderer mSprite;

		//Using this timer to sync boss behavior up with music ~Adam
		public float mBossTimer = 0f;
		//	0-8: Enter, 0
		//8-16: Shoot, 1
		//16-25: Stab, 2
		//25-33: Enemies fly around, 3
		//33-57: Shoot while enemies flying, 4
		//57-73: Stab while enemies flying, 5
		//73-97: Enemies Die, Teleport, shoot, and stab, 6
		//97-101: Die, 7
		[SerializeField] private int mBossStage = 0;

		//Where to hover at while idle~Adam
		public Vector3 mHoverPoint = Vector3.zero;
		//Where to stab at ~Adam
		Vector3 mStabPoint;


		//Where to spawn bullets from (these will be empty child object ~Adam
		[SerializeField] private Transform[] mBulletSpawnPoints;
		//What type of bullets to shoot ~Adam
		[SerializeField] private GameObject mBossBullets;

		//Count down to shooting~Adam
		[SerializeField] private float mBulletTimer = 4f;
		//Count down to stabbing~Adam
		[SerializeField] private float mStabTimer = 5f;

		//Whether or not this is currently trying to stab the player ~Adam
		[SerializeField] private bool mStabbing = false;

		//Spawners for regular enemies ~Adam
		[SerializeField] private GameObject[] mMinionSpawners;

		//For spawning/killing enemies ~Adam
		bool mEnemySet1Up = false;
		bool mEnemySet2Up = false;
		bool mEnemySet3Up = false;
		bool mKilledEnemies = false;

		public GameObject mMiniBossDeath;
		// Use this for initialization
		void Start () 
		{
			StartSetup();
		}
		
		// Update is called once per frame ~Adam
		void Update () 
		{
			mBossTimer += Time.deltaTime;
			//Un-red the boss after it's been shot ~Adam
			mSprite.color = Color.Lerp(mSprite.color, Color.white, 0.2f);

			//Set to stab at the player ~Adam
			if(!mStabbing)
			{
				mStabPoint = mPlayer.transform.position;
			}

			//	0-8: Enter ~Adam
			if(mBossTimer <8f)
			{
				if(Vector3.Distance(transform.position,mHoverPoint) >1f)
				{
					MoveToPoint (5f,mHoverPoint);
				}
				else
				{
					transform.position = mHoverPoint;
				}
			}
			//8-16: Shoot ~Adam
			else if (mBossTimer <16f)
			{
				mBossStage = 1;
				if(Vector3.Distance(transform.position,mHoverPoint) >1f)
				{
					MoveToPoint (5f,mHoverPoint);
				}
				else
				{
					SetRandomHoverPoint ();
				}

				mBulletTimer -= Time.deltaTime;
				if(mBulletTimer <= 0f)
				{
					mBulletTimer = 4f;
					BossShoot ();
				}
			}
			//16-25: Stab ~Adam
			else if (mBossTimer <25f)
			{
				mBossStage = 2;
				TurnToStab ();
				if(!mStabbing)
				{
					mStabTimer -= Time.deltaTime;
					if(mStabTimer <= 0f)
					{
						mStabbing = true;
					}
				}
				else
				{
					BossStab ();
				}
			}
			//25-33: Enemies fly around ~Adam
			else if (mBossTimer <33f)
			{
				mBossStage = 3;
				TurnToStab ();
				mHoverPoint = transform.parent.transform.position;
				if(Vector3.Distance(transform.position,mHoverPoint) >1f)
				{
					MoveToPoint (7f,mHoverPoint);
				}
				else
				{
					transform.position = mHoverPoint;
				}
				//Spawn first set of minions ~Adam
				if(!mEnemySet1Up)
				{
					mEnemySet1Up = true;
					for(int i = 0; i <=1; i++)
					{
						mMinionSpawners[i].SetActive (true);
					}
				}
			}
			//33-57: Shoot while enemies fly ~Adam
			else if (mBossTimer <57)
			{
				mBossStage = 4;
				//Hover in center
				mHoverPoint = transform.parent.transform.position;

				
				
				if(Vector3.Distance(transform.position,mHoverPoint) >1f)
				{
					MoveToPoint (5f,mHoverPoint);
				}
				else
				{
					transform.position = mHoverPoint;
				}

				//Spawn second set of minions ~Adam
				if(!mEnemySet2Up)
				{
					mEnemySet2Up = true;
					for(int i = 2; i <=6; i++)
					{
						mMinionSpawners[i].SetActive (true);
					}
				}

			}
			//55-73: Stab while enemies fly ~Adam
			else if (mBossTimer <73f)
			{
				mBossStage = 5;
				TurnToStab ();
				//Spawn second set of minions ~Adam
				if(!mEnemySet3Up)
				{
					mEnemySet3Up = true;
					for(int i = 7; i <=9; i++)
					{
						mMinionSpawners[i].SetActive (true);
					}
				}

				if(!mStabbing)
				{
					mStabTimer -= Time.deltaTime;
					if(mStabTimer <= 0f)
					{
						mStabbing = true;
					}
				}
				else
				{
					BossStab ();
				}
			}
			//73-97: Enemies Die, Teleport, shoot, and stab ~Adam
			else if (mBossTimer <97f)
			{
				mBossStage = 6;
				TurnToStab ();
				if(!mStabbing)
				{
					mStabTimer -= Time.deltaTime;
					if(mStabTimer <= 0f)
					{
						mStabbing = true;
					}
				}
				else
				{
					BossStab ();
				}
				//Kill off minions ~Adam
				if(!mKilledEnemies)
				{
					foreach(Enemy minion in FindObjectsOfType<Enemy>())
					{
						minion.EnemyShipDie ();
					}
				}
			}
			//97-101: Die ~Adam
			else if (mBossTimer <101f)
			{
				mBossStage = 7;
				//Make explosions

			}
			//End game ~Adam
			else
			{
				mBossStage = 8;
				EndBossFight();
			}


		}

		void BossShoot()
		{

			for(int i = 0; i < mBulletSpawnPoints.Length; i++)
			{
				GameObject newBullet = Instantiate(mBossBullets, mBulletSpawnPoints[i].transform.position, Quaternion.identity) as GameObject;
				newBullet.GetComponent<EnemyBulletController>().mPlayer = mPlayer;
				//newBullet.GetComponent<EnemyBulletController>().mBulletTargetNumber = mTargetPlayerNumber;

			}
		}

		void BossStab()
		{
			MoveToPoint(75f, mStabPoint);

			if(Vector3.Distance (transform.position, mStabPoint)< 3f)
			{
				mStabbing = false;
				SetRandomHoverPoint ();
				if(mBossStage == 2)
				{
					mStabTimer = 3f;
				}
				else if(mBossStage == 5)
				{
					mStabTimer = 4f;
				}
				else if(mBossStage == 6)
				{
					BossTeleport();
					mStabTimer = 4f;
				}
			}
		}

		void BossTeleport()
		{

			//Mess up screen as teleport visual ~Adam
			CameraManager.instance.SetBossTeleportVisual(mTargetPlayerNumber);
			//Set position to hover poitn to teleport ~Adam
			transform.position = mHoverPoint;
			BossShoot();
		}

		void SetRandomHoverPoint()
		{
			//Set a new hover point ~Adam
			mHoverPoint = new Vector3(Random.Range (-16f,16f), Random.Range (-12f,20f), 1f);
			//Adjust hover point for which side of the screen we're on ~Adam
			switch(mTargetPlayerNumber)
			{
			case 1:
				mHoverPoint += new Vector3(-50f,0f,0f);
				break;
			case 2:
				mHoverPoint += new Vector3(50f,0f,0f);
				break;
			default:
				mHoverPoint += new Vector3(-50f,0f,0f);
				break;
			}
		}

		void MoveToPoint(float speed, Vector3 movePoint)
		{

//			//Variables for the direciton  this unit has to go 
//			Vector3 moveDir = new Vector3();
//			
//			
//			moveDir = movePoint - transform.position;
//			
//			
//			//Fly in the appriate direction
//			moveDir.Normalize();
//			
//			transform.up += moveDir*Vector3.down;;
//			transform.up.Normalize();
//			
//			GetComponent<Rigidbody2D>().velocity = transform.up*Vector3.down * speed;

			transform.position = Vector3.Lerp(transform.position, movePoint, 0.001f*speed);
		}

		void TurnToStab()
		{
			if(mBossStage == 2 || mBossStage == 5 || mBossStage == 6)
			{
				//Variables for the direciton  this unit has to go  ~Adam
				Vector3 moveDir = new Vector3();
							
							
				moveDir = mStabPoint - transform.position;
						
						
				//Fly in the appriate direction ~Adam
				moveDir.Normalize();
							
				transform.up += moveDir*-1f;
				transform.up.Normalize();
			}
			else
			{
				transform.rotation = Quaternion.Euler (0f,0f,0f);
			}

		}

		void OnTriggerEnter2D(Collider2D other)
		{
			if(other.tag == "PlayerBullet")
			{
				//Make a small explosion effect ~Adam
				mSprite.color = Color.red;
				Destroy(other.gameObject);
				if(mBossStage == 7)
				{
					EndBossFight();
				}
			}

		}

		public void StartSetup()
		{
			//Find the target Player ~Adam
			switch (mTargetPlayerNumber)
			{
			case 1:
				mPlayer = VehiclesManager.instance.Player1Ship.gameObject;
				break;
			case 2:
				mPlayer = VehiclesManager.instance.Player2Ship.gameObject;
				
				break;
			default:
				mPlayer = VehiclesManager.instance.Player1Ship.gameObject;
				break;
			}
			
			//Set where to initially stab at ~Adam
			mStabPoint = mPlayer.transform.position;
			
			//Set all the minion spawning to the proper player number to target ~Adam
			for(int i = 0; i < mMinionSpawners.Length; i++)
			{
				mMinionSpawners[i].GetComponent<EnemyShipSpawner>().mTargetPlayerNumber = mTargetPlayerNumber;
			}
		}

		public void EndBossFight()
		{
			switch(mTargetPlayerNumber)
			{
			case 1:
				ScoreKeeper.instance.mP1RoundKills = 999;
				ScoreKeeper.instance.mP1Wins=4;
				break;
			case 2:
				ScoreKeeper.instance.mP2RoundKills = 999;
				ScoreKeeper.instance.mP2Wins=4;
				break;
			default:
				ScoreKeeper.instance.mP1RoundKills = 999;
				ScoreKeeper.instance.mP1Wins=4;
				break;
			}
			Instantiate (mMiniBossDeath,transform.position,Quaternion.identity);
			Destroy (this.gameObject);
		}

	}
}