using UnityEngine;
using Assets._Scripts.Player;
using Assets._Scripts.Weapons;

namespace Assets._Scripts.AI
{
    public class EnemyMovement : MonoBehaviour
    {
		public Transform mPlayer;

        public float Speed;

		public bool mUseSwarm;

		//Used for telling the ship which way to go
		[HideInInspector] public Vector2 mVel= new Vector2(0, 1);

		//Variables for the direciton and distance this unit has to go to reach whereever it is currently going
		float targetDist;

		Vector3 mOriginPoint;
		public Vector3 mTargetRushPoint; //Were to end up if just flying across the screen
		public bool mRushAtPlayer;


		//Whether or not the ship has flown in a circle ~Adam
		public bool mHasLooped = false;
		bool mUsesLoop;
		//The point thta the ship will fly in a circle around on its way to the swarm if it isn't null ~Adam
		public Vector3 mLoopPoint;
		//How tight of a circle the ship will fly in when it makes a loop.  Smaller absolute value == bigger loop.  Negative makes loop counter-clockwise ~Adam
		public float mLoopCircleTightness = 1.0f;
		
		//Minimum amount of time to spend on loops. ~Adam
		public float mLoopTime = 1f;
		
		//The current speed of the ship ~Adam
		public float mSpeed = 5.0f;
		//For having the speed used to make formations be faster than the regular speed `Adam
		public float mFormSpeed = 5.0f;
		//Default movement speed ~Adam
		public float mDefaultSpeed = 5.0f;

		//Timer for changing AI states
		public float mSwitchCoolDown;



		//The swarm this unit will be joining ~Adam
		public SwarmGrid mSwarmGrid;
		//Where to hover in the swarm grid ~Adam
		public GameObject mSwarmGridPosition;
		//How long this unit hovers in the swarm before trying to attack ~Adam
		public float mAttackFrequencyTimerDefault = 8.0f;
		public float mAttackLengthTimerDefault = 8.0f;
		private float mAttackFrequencyTimer;
		//Whether or not this unit will break from swarm formation to chase the player ~Ada,
		public bool mCanAttack = false;




		//Enums for the current AI behavior state
		public enum AIState { FlightLooping, ApproachingSwarm, Swarming, Attacking };
		public AIState mCurrentAIState = AIState.ApproachingSwarm;


		void Start()
		{
			mOriginPoint = transform.position;
			if(mUseSwarm)
			{
				mSpeed = mFormSpeed;

				mSwarmGridPosition = mSwarmGrid.GetGridPosition();

			
			}
			else
			{
				mSpeed = mDefaultSpeed;
			}
			mUsesLoop = !mHasLooped;
		}

		void Update()
		{
			mSwitchCoolDown -= Time.deltaTime;

			//For enemies that stay in a swarm ~Adam
			if(mUseSwarm)
			{

				if(mSwarmGrid != null && mSwarmGridPosition != null)
				{
					//Act based on what state we are currently in
					switch (mCurrentAIState)
					{
					case AIState.ApproachingSwarm:
						ApproachSwarm();
						break;
						
					case AIState.FlightLooping:
						break;
						
					case AIState.Swarming:
						Swarm();
						break;
						
					case AIState.Attacking:
						AttackPlayer();
						break;
						
					default:
						break;
					}
				}
				//Delete self if the swarm is full `Adam
				else
				{
					Destroy(this.gameObject);
				}

			}


			//For enemies that just fly accross the screen ~Adam
			else
			{

				//Fly towards the loop point ~Adam
				if(!mHasLooped && mCurrentAIState == AIState.ApproachingSwarm)
				{
					if(mRushAtPlayer)
					{
						mLoopPoint = mPlayer.position;
					}

					FlyToPoint(mLoopPoint);

					targetDist = Vector3.Distance(mLoopPoint,transform.position);

					if(targetDist <= 3f)
					{
						mCurrentAIState = AIState.FlightLooping;
						mSwitchCoolDown = mLoopTime;
					}



				}
				//Fly in a circle ~Adam
				else if(!mHasLooped && mCurrentAIState == AIState.FlightLooping)
				{
					DoRushLoop();

				}
				//Fly to the rush point ~Adam
				else
				{
					FlyToPoint (mTargetRushPoint);
					targetDist = Vector3.Distance(mTargetRushPoint, transform.position);
					if(targetDist <= 1f)
					{
						transform.position = mOriginPoint;
						mHasLooped = !mUsesLoop;
					}
				}
			}
		}//END of Update()

		public void OnTriggerEnter2D(Collider2D other)
		{
			
			if (other.tag == "Bullet") 
			{
				

				Destroy(other.gameObject);
				//Debug.Log("Hit Bullet");

				GetComponent<Enemy>().EnemyShipDie ();
			}

			if(other.GetComponent<PlayerBase>() != null)
			{
				other.GetComponent<PlayerBase>().PlayerControlComponent.ReduceSpeed ();
			}
		}

		void ApproachSwarm()
		{
			targetDist = Vector3.Distance(mSwarmGridPosition.transform.position, transform.position);

			FlyToPoint (mSwarmGridPosition.transform.position);

			if(targetDist <0.5f)
			{
				mCurrentAIState = AIState.Swarming;
				mSwitchCoolDown = mAttackFrequencyTimerDefault;
			}
		}

		void Swarm()
		{

			//Stop using the speed for the alternate speed for making the formation
			if(mSpeed == mFormSpeed && mFormSpeed != mDefaultSpeed)
			{
				mSpeed = mDefaultSpeed;
			}
			

			//Stay in position with the SwarmGrid `Adam
			transform.position = mSwarmGridPosition.transform.position;
			transform.up = mSwarmGridPosition.transform.up;
			

			//Attack after a while `Adam
			if (mSwitchCoolDown <= 0.0f && mCanAttack)
			{
				mCurrentAIState = AIState.Attacking;
				mSwitchCoolDown = mAttackLengthTimerDefault;
			}
		}


		void FlyToPoint(Vector3 targetPoint)
		{
			//Variable for the direciton  this unit has to go to reach its SwarmGridSlot
			Vector3 flightDirection = new Vector3();

			//Find direction to  the target point ~Adam
			flightDirection = targetPoint - transform.position;
								
			//Fly in the appriate direction
			flightDirection.Normalize();

			transform.up += flightDirection;
			transform.up.Normalize();

			GetComponent<Rigidbody2D>().velocity = transform.up * mSpeed;



		}

		void AttackPlayer()
		{
			FlyToPoint (mPlayer.position);

			if(mSwitchCoolDown <= 0)
			{
				mCurrentAIState = AIState.ApproachingSwarm;
			}
		}

		void DoRushLoop()
		{
			//Set up the directional angle to fly in a circle
			mVel += new Vector2(transform.right.x*mLoopCircleTightness, transform.right.y*mLoopCircleTightness) * Time.deltaTime;
			
			mVel.Normalize();
			transform.up += new Vector3(mVel.x, mVel.y, 0);
			transform.up.Normalize();

			//Set the velocity to move in the cicle
			GetComponent<Rigidbody2D>().velocity = transform.up * mSpeed;
			

			//Transitions to ApproachingSwarm AI state if the timer has run out and this unit is pointed towards its grid slot
			if (mSwitchCoolDown <= 0.0f)
			{
				mHasLooped = true;
				mCurrentAIState = AIState.ApproachingSwarm;
				mSwitchCoolDown = 0.5f;
			}
		}//END of DoRushLoop()

        //TODO
    }
}
