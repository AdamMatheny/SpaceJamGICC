using UnityEngine;
using Assets._Scripts.Player;
using Assets._Scripts.Managers;

namespace Assets._Scripts.AI
{
    public class Enemy : MonoBehaviour
    {
        public EnemyMovement EnemyMovementComponent;
        public EnemyVisuals EnemyVisualsComponent;
        public EnemyFiring EnemyFireComponent;


		public int mTargetPlayerNumber;
		public PlayerBase mTargetPlayer;

		public ScoreKeeper mScoreKeeper;

		public GameObject mDeathEffect;

		void Start()
		{
			gameObject.transform.parent = ObjectManager.instance.EnemyTransform;

			mScoreKeeper = FindObjectOfType<ScoreKeeper>();
			//Assign what player to be trying to attack ~Adam
			foreach(PlayerBase player in FindObjectsOfType<PlayerBase>())
			{
				if(player.mPlayerNumber == mTargetPlayerNumber)
				{
					mTargetPlayer = player;
					EnemyMovementComponent.mPlayer = mTargetPlayer.transform;
				}
			}

		}


		void OnCollisionEnter(Collision other)
		{
			//Get shot by player bullets ~Adam



			//Hit the player on touch ~Adam


		}


		public void EnemyShipDie()
		{
			if(mTargetPlayerNumber == 1)
			{
				mScoreKeeper.mPlayer1Kills++;
				mScoreKeeper.mPlayer1RoundScore++;
			}
			else if(mTargetPlayerNumber == 2)
			{
				mScoreKeeper.mPlayer2Kills++;
				mScoreKeeper.mPlayer2RoundScore++;
			}
			if(mDeathEffect!=null)
			{
				Instantiate(mDeathEffect, transform.position, Quaternion.identity);
			}
			Destroy(this.gameObject);
		}

    }
}
