using UnityEngine;
using System.Collections;
using Assets._Scripts.Player;
using Assets._Scripts.Managers;

namespace Assets._Scripts.AI
{
	public class EnemyBulletController : MonoBehaviour 
	{
		
		public GameObject mPlayer = null;
		public float mBulletSpeed = 20.0f;
		public float mSelfDestructTimer = 5.0f;
		private ScoreKeeper mScoreKeeper;
		public bool mShootable;
		public bool mAimAtPlayer = false;
		public bool mFixedFireDir = false;
		public bool mMoveTowardsPlayer = false;
		public Vector3 mFireDir;

		public Vector2 bulletForce;

		public GameObject bulletExplosion;

		public int mBulletTargetNumber = 0;

		public void Start()
		{
            gameObject.transform.parent = MapManager.instance.ParticlesTransform;
			switch (mBulletTargetNumber)
			{
			case 1:
				mPlayer = VehiclesManager.instance.Player1Ship.gameObject;
				break;
			case 2:
				mPlayer = VehiclesManager.instance.Player2Ship.gameObject;
				
				break;
			default:
				//mPlayer = VehiclesManager.instance.Player1Ship.gameObject;
				break;
			}
			mScoreKeeper = ScoreKeeper.instance;

			//Vector2 bulletForce;

			//Used for firing in a particular pattern (i.e. rotational pattern on boss horns)~Adam
			if (mFixedFireDir) 
			{
				bulletForce = mFireDir * mBulletSpeed;
				//transform.rotation = Quaternion.Euler(new Vector3(90f,0f,0f) + transform.rotation.eulerAngles);
			}
			//Used for aiming at the player ~Adam
			else if (mAimAtPlayer) 
			{
				Vector3 directionToPlayer = Vector3.down;
				//fire at the player
				directionToPlayer = mPlayer.transform.position - transform.position;
				bulletForce = Vector3.Normalize (directionToPlayer) * mBulletSpeed;
				transform.LookAt (mPlayer.transform.position);
				transform.rotation = Quaternion.Euler (new Vector3 (90f, 0f, 0f) + transform.rotation.eulerAngles);
			} 
			//For constantly tracking/homing in on the player
			else if (mMoveTowardsPlayer) 
			{
				Vector3 directionToPlayer = Vector3.down;
				//fire at the player
				directionToPlayer = mPlayer.transform.position - transform.position;
				bulletForce = Vector3.Normalize (directionToPlayer) * mBulletSpeed;
				transform.LookAt (mPlayer.transform.position);
				transform.rotation = Quaternion.Euler (new Vector3 (90f, 0f, 0f) + transform.rotation.eulerAngles);
			}
			//Just fire up and down ~Adam
			else
			{
				//Fire straight down

					bulletForce = new Vector2(0.0f,mBulletSpeed * -1.0f);

			}

		
			GetComponent<Rigidbody2D> ().velocity = bulletForce;



			
		}
		
		void Update()
		{
			mSelfDestructTimer -= Time.deltaTime;
			if (mMoveTowardsPlayer) 
			{

				Vector3 directionToPlayer = Vector3.down;

				//fire at the player
				directionToPlayer = mPlayer.transform.position - transform.position;
				bulletForce = Vector3.Normalize (directionToPlayer) * mBulletSpeed;
				transform.LookAt (mPlayer.transform.position);
				transform.rotation = Quaternion.Euler (new Vector3 (90f, 0f, 0f) + transform.rotation.eulerAngles);

				GetComponent<Rigidbody2D> ().velocity = bulletForce;

			}

			//Self-destruct after a certain amount of time
			if(mSelfDestructTimer<0.0f)
			{
				if(mMoveTowardsPlayer)
				{
					if(bulletExplosion != null)
					{
						
						Instantiate(bulletExplosion, transform.position, Quaternion.identity);
					}
				}

				Destroy(gameObject);
			}


			//Detect distance to player and kill the player and destroy self if close enough to "touch" ~Adam
			if (Vector3.Distance(this.transform.position, mPlayer.transform.position) <= 1.5f)
			{
				mPlayer.GetComponent<PlayerBase> ().mHitPlayer();
				Destroy(gameObject);
			}


		}//END of Update()

		void OnTriggerEnter2D (Collider2D other)
		{

			/*if (other.tag == "Enemy" && mMoveTowardsPlayer) 
				other.GetComponent<EnemyShipAI> ().EnemyShipDie ();*/ //Enemy ship doesn't have OnTrigger

			if (other.tag == "Player") {

				other.GetComponent<PlayerBase> ().mHitPlayer();
			}

			if(other.tag == "PlayerBullet")
			{
				if(mShootable)
				{

					if(bulletExplosion != null)
					{

						Instantiate(bulletExplosion, transform.position, Quaternion.identity);
					}

					Destroy(other.gameObject);
					Destroy(this.gameObject);
				}

				//Hit Player
				//if(other.GetComponent<PlayerBase>() != null)
				//{
				//	other.GetComponent<PlayerBase>().mHitPlayer();
				//}
			}

			if(other.GetComponent<BulletBomb>() != null)
			{
				Destroy(this.gameObject);
			}

		}//END of OnTriggerEnter()





	}
}