using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour 
{
	public int mP1Score = 0;
	public int mP2Score = 0;
	public int mP1RoundKills = 0;
	public int mP2RoundKills = 0;
	public int mP1Wins = 0;
	public int mP2Wins = 0;

	public GameObject mFinishLinePrefab; 

	GameObject mP1Ship;
	GameObject mP2Ship;

	public GameObject[] mRoundSuperPrefabs;

	float mRoundEndTimer = 5f;

	bool mRoundOver = false;


	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
