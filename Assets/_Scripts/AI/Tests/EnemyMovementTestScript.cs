using UnityEngine;
using System.Collections;
using Assets._Scripts.Managers;
using Assets._Scripts.Weapons;

namespace Assets._Scripts.Player{
	public class EnemyMovementTestScript : MonoBehaviour 
	{

		public GameObject ScoreKeeper;

		// Public variable that contains the speed of the enemy
		public int speed = -5;

		public Rigidbody2D rgbd2D;
	
		// Function called when the enemy is created
		public void Start()
		{

			rgbd2D = gameObject.GetComponent<Rigidbody2D> ();
			rgbd2D.velocity = new Vector2 (rgbd2D.velocity.x, speed);
			ScoreKeeper = FindObjectOfType<ScoreKeeper>().gameObject;
			Destroy (gameObject, 10);
		}

		public void Update()
		{

			gameObject.transform.parent = ObjectManager.instance.EnemyTransform;
		}

		public void OnTriggerEnter2D(Collider2D other){

			if (other.tag == "Bullet") 
			{

				if(other.gameObject.GetComponent<BasicProjectile> ().isPlayerOne){

					ScoreKeeper.GetComponent <ScoreKeeper> ().mPlayer1Kills += 1;
				}
				else
				{

					ScoreKeeper.GetComponent <ScoreKeeper> ().mPlayer2Kills += 1;
				}

				Destroy(gameObject);
				Destroy(other.gameObject);
				//Debug.Log("Hit Bullet");
			}

			if (other.tag == "Player") 
			{

				Destroy(gameObject);
				//other.gameObject.GetComponent<PlayerControl> ().finishMarker.GetComponent<FinishLineController> ().SlowDown(1);
			}
		}
	}
}