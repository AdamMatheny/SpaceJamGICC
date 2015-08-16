﻿using UnityEngine;
using System.Collections;
using Assets._Scripts.Player;
using Assets._Scripts.Managers;

public class FinishLine : MonoBehaviour 
{
	public int mPlayerNumber = 1;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f, 0f);
	}


	void OnTriggerEnter2D(Collider2D other) 
	{
		if(other.GetComponent<PlayerBase>() != null)
		{
			if(ScoreKeeper.instance.mRoundWinner == 0)
			{
				ScoreKeeper.instance.FinishRound (mPlayerNumber);
			}
		}
		
	}
}
