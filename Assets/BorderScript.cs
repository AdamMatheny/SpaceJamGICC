using UnityEngine;
using System.Collections;

public class BorderScript : MonoBehaviour {

	public enum Borders
	{
		Left, Right, Up, Down
	}
	public Borders border;

	void OnTriggerStay2D(Collider2D other){

		if (other.tag == "Player") {

			if(border == Borders.Right){

				other.transform.position = new Vector3(transform.position.x - 1.56f, other.transform.position.y);
			}

			if(border == Borders.Up){

				other.transform.position = new Vector3(other.transform.position.x, transform.position.y - 1.56f);
			}

			if(border == Borders.Left){

				other.transform.position = new Vector3(transform.position.x + 1.56f, other.transform.position.y);
			}

			if(border == Borders.Down){

				other.transform.position = new Vector3(other.transform.position.x, transform.position.y + 1.56f);
			}
		}
	}
}