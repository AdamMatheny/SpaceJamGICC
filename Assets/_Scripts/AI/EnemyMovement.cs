using UnityEngine;
using System.Collections;
using Assets._Scripts.Player;

namespace Assets._Scripts.AI
{
	public class EnemyMovement : MonoBehaviour 
	{

		//Used for telling the ship which way to go
		[HideInInspector] public Vector2 mVel= new Vector2(0, 1);
		
		//The player's avatar ~Adam
		public Transform mPlayer;

		public bool mUsesSwarm = false;

		public bool mRushPlayer = false;
		public Vector3 mFinalDestPoint;
		Vector3 mOriginPoint;
		float mDistToTarget;


		//Whether or not the ship has flown in a circle ~Adam
		public bool mHasLooped = false;
		public bool mUsesLoop = false;
		//The point thta the ship will fly in a circle around on its way to the swarm if it isn't null ~Adam
		public Vector3 mLoopPoint;
		//How tight of a circle the ship will fly in when it makes a loop.  Smaller absolute value == bigger loop.  Negative makes loop counter-clockwise ~Adam
		public float mLoopCircleTightness = 1.0f;
		
		//Minimum amount of time to spend on loops. ~Adam
		public float mLoopTime = 1f;
		
		//The speed of the ship ~Adam
		public float mSpeed = 5.0f;
		//For having the speed used to make formations be faster than the regular speed `Adam
		public float mFormSpeed = 5.0f;
		public float mDefaultSpeed = 5.0f;
		//Timer for changing AI states
		public float mSwitchCoolDown;
		
		//The swarm this unit will be joining ~Adam
		public SwarmGrid mSwarmGrid;
		//Where to hover in the swarm grid ~Adam
		public GameObject mSwarmGridPosition;


		//Enums for the current AI behavior state
		public enum AIState { FlightLooping, ApproachingSwarm, Swarming};
		public AIState mCurrentAIState = AIState.ApproachingSwarm;


		// Use this for initialization
		void Start () 
		{
			if(mUsesSwarm)
			{
				mSpeed = mFormSpeed;
				mSwarmGridPosition = mSwarmGrid.GetGridPosition();

			}
			else
			{
				mSpeed = mDefaultSpeed;
			}
			mUsesLoop = !mHasLooped;
			mOriginPoint = transform.position;
		}
		
		// Update is called once per frame
		void Update () 
		{
			mSwitchCoolDown -= Time.deltaTime;

			//Do Swarming behavior ~Adam
			if(mUsesSwarm)
			{
				switch(mCurrentAIState)
				{
				case AIState.ApproachingSwarm:
				
					FlyAtPoint(mSwarmGridPosition.transform.position);
					mDistToTarget = Vector3.Distance (transform.position, mSwarmGridPosition.transform.position);

					if(mDistToTarget <= 1f)
					{
						mCurrentAIState = AIState.Swarming;
					}
					break;
				case AIState.Swarming:
					Swarm();
					break;
				
				default:
					break;

				}
			}

			//Do Behavior for just flying across the Screen ~Adam
			else
			{
				//Fly towards the loop point ~Adam
				if(mUsesLoop && !mHasLooped && mCurrentAIState == AIState.ApproachingSwarm && !mRushPlayer)
				{
					FlyAtPoint(mLoopPoint);
					mDistToTarget = Vector3.Distance (transform.position, mLoopPoint);

				}
				//Fly towards the player ~Adam
				else if (mRushPlayer && !mHasLooped && mCurrentAIState == AIState.ApproachingSwarm)
				{
					FlyAtPoint (mPlayer.transform.position);
					mDistToTarget = Vector3.Distance(transform.position, mPlayer.transform.position);
				}
				//Fly towards final destination point ~Adam
				else if (mCurrentAIState == AIState.ApproachingSwarm)
				{
					FlyAtPoint (mFinalDestPoint);
					mDistToTarget = Vector3.Distance (transform.position, mFinalDestPoint);
				}
				//Fly in a loop ~Adam
				else if (mCurrentAIState == AIState.FlightLooping)
				{
					DoFlightLoop();
				}


				//Do a loop once it reaches the loop point (if going for loop point) or it reaches the player (if rushing the palyer ~Adam
				if(mDistToTarget <= 3 && mCurrentAIState == AIState.ApproachingSwarm && !mHasLooped)
				{
					mHasLooped = true;
					mCurrentAIState = AIState.FlightLooping;
					mSwitchCoolDown = mLoopTime;

				}
				//Go back to the origin point once it reahces the final target destination ~Adam
				else if(mDistToTarget <= 3 && mCurrentAIState == AIState.ApproachingSwarm)
				{
					mHasLooped = false;
					transform.position = mOriginPoint;

				}

			}
		}


		public void FlyAtPoint(Vector3 targetPoint)
		{
			//Variables for the direciton  this unit has to go 
			Vector3 toSwarm = new Vector3();


			toSwarm = targetPoint - transform.position;

			
			//Fly in the appriate direction
			toSwarm.Normalize();
			
			transform.up += toSwarm;
			transform.up.Normalize();
			
			GetComponent<Rigidbody2D>().velocity = transform.up * mSpeed;
		}

		void DoFlightLoop()
		{
			//Set up the directional angle to fly in a circle
			mVel += new Vector2(transform.right.x*mLoopCircleTightness, transform.right.y*mLoopCircleTightness) * Time.deltaTime;
			
			mVel.Normalize();
			transform.up += new Vector3(mVel.x, mVel.y, 0);
			transform.up.Normalize();
			//Set the velocity to move in the cicle
			GetComponent<Rigidbody2D>().velocity = transform.up * mSpeed;

	

			//Go back to flying in a line
			if(mSwitchCoolDown <= 0f)
			{
				mCurrentAIState = AIState.ApproachingSwarm;
				mDistToTarget = Vector3.Distance (transform.position, mFinalDestPoint);
			}

		}

		void Swarm()
		{
			//Stop using the speed for the alternate speed for making the formation
			if(mSpeed == mFormSpeed && mFormSpeed != mDefaultSpeed)
			{
				mSpeed = mDefaultSpeed;
			}

			transform.position = mSwarmGridPosition.transform.position;
			transform.up = mSwarmGridPosition.transform.up;


		}
	}
}