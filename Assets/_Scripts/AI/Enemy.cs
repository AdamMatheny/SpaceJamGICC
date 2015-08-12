using UnityEngine;
using Assets._Scripts.Player;

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
			}
			else if(mTargetPlayerNumber == 2)
			{
				mScoreKeeper.mPlayer2Kills++;
			}
			Instantiate(mDeathEffect, transform.position, Quaternion.identity);

			Destroy(this.gameObject);
		}

    }
}
