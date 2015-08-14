using UnityEngine;
using System.Collections;
using Assets._Scripts.Player;

public class FinishLine : MonoBehaviour 
{
	//Which player this finish line corresponds to ~Adam
	public int mPlayerNumber = 1;


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = new Vector2 (transform.position.x, transform.position.y - 0.1f);

	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if(other.GetComponent<PlayerBase>() != null)
		{
			if(FindObjectOfType<ScoreKeeper>().mRoundWinner == 0)
			{
				FindObjectOfType<ScoreKeeper>().FinishRound (mPlayerNumber);
			}
		}

	}
}