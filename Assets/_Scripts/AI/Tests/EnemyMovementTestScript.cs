using UnityEngine;
using System.Collections;

namespace Assets._Scripts.Player{
	public class EnemyMovementTestScript : MonoBehaviour {

		// Public variable that contains the speed of the enemy
		public int speed = -5;

		public Rigidbody2D rgbd2D;
	
		// Function called when the enemy is created
		public void Start(){

			rgbd2D = gameObject.GetComponent<Rigidbody2D> ();
			rgbd2D.velocity = new Vector2 (rgbd2D.velocity.x, speed);
			Destroy (gameObject, 10);
		}

		public void OnTriggerEnter2D(Collider2D other){

			if (other.tag == "Bullet") {

				Destroy(gameObject);
				Destroy(other.gameObject);
				//Debug.Log("Hit Bullet");
			}

			if (other.tag == "Player") {

				Destroy(gameObject);
				other.gameObject.GetComponent<PlayerControl> ().finishMarker.GetComponent<FinishLineManager> ().SlowDown(1);
			}
		}
	}
}