using UnityEngine;
using System.Collections;

public class FinishLineController : MonoBehaviour {

	public float speed;
	public float slowDownTime;	

	public GameObject otherFinish;

	public bool isPlayer1;
	public bool canMove;
	public bool slowDown;

	void Update () {

		if (slowDown) {

			canMove = false;

			if(slowDownTime > 0)
				slowDownTime -= Time.deltaTime;
			else{

				slowDown = false;
				canMove = true;
			}
		}
	
		if (canMove) {

			transform.position = new Vector2 (transform.position.x, transform.position.y - speed / 100);
		}

		if (transform.position.y <= 0) {

			if(isPlayer1){

				Debug.Log("Player 1 has won!");
				Destroy(otherFinish);
				Destroy(gameObject);
			}else{

				Debug.Log("Player 2 has won!");
				Destroy(otherFinish);
				Destroy(gameObject);
			}
		}
	}

	public void SlowDown(float time){

		slowDown = true;
		slowDownTime += time;
	}
}
