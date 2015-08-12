using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour 
{
	public int mCurrentRound;

	public int mPlayer1Kills = 0;
	public int mPlayer2Kills = 0;
	public int mPlayer1Wins = 0;
	public int mPlayer2Wins = 0;

	public float mPlayer1InvincibleTime = 0f;
	public float mPlayer2InvincibkeTime = 0f;

	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

}
