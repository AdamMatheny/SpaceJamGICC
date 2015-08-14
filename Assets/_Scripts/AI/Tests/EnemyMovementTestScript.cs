using UnityEngine;
using System.Collections;
using Assets._Scripts.Managers;
using Assets._Scripts.Weapons;
using Assets._Scripts.Player;

namespace Assets._Scripts.Player{
	public class EnemyMovementTestScript : MonoBehaviour {

		public GameObject ScoreKeeper;

		// Public variable that contains the speed of the enemy
		public int speed = -5;

		public Rigidbody2D rgbd2D;
	
		// Function called when the enemy is created
		public void Start(){

			rgbd2D = gameObject.GetComponent<Rigidbody2D> ();
			rgbd2D.velocity = new Vector2 (rgbd2D.velocity.x, speed);
			ScoreKeeper = GameObject.Find ("ScoreKeeper");
			Destroy (gameObject, 10);
		}

		public void Update(){
				
			ScoreKeeper = GameObject.Find ("ScoreKeeper");
			gameObject.transform.parent = ObjectManager.instance.EnemyTransform;
		}

		public void OnTriggerEnter2D(Collider2D other){

			if (other.tag == "Bullet") {

				if(other.gameObject.GetComponent<BasicProjectile> ().isPlayerOne){

					ScoreKeeper.GetComponent <ScoreKeeper> ().mPlayer1Kills += 1;
				}else{

					ScoreKeeper.GetComponent <ScoreKeeper> ().mPlayer2Kills += 1;
				}

				Destroy(gameObject);
				Destroy(other.gameObject);
				//Debug.Log("Hit Bullet");
			}

			if (other.tag == "Player") {
				if(other.gameObject.GetComponent<PlayerControl> ().HorizontalAxisName == "Horizontal2"){

					if(ScoreKeeper.gameObject.GetComponent<ScoreKeeper> ().mPlayer1Kills >= 5){
					
						ScoreKeeper.gameObject.GetComponent<ScoreKeeper> ().mPlayer1Kills -= 5;
					}else{

						ScoreKeeper.gameObject.GetComponent<ScoreKeeper> ().mPlayer1Kills = 0;
					}
				}else{

					if(ScoreKeeper.gameObject.GetComponent<ScoreKeeper> ().mPlayer2Kills >= 5){
						
						ScoreKeeper.gameObject.GetComponent<ScoreKeeper> ().mPlayer2Kills -= 5;
					}else{
						
						ScoreKeeper.gameObject.GetComponent<ScoreKeeper> ().mPlayer2Kills = 0;
					}
				}

				Destroy(gameObject);
			}
		}
	}
}