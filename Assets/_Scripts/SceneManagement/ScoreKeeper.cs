using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets._Scripts.AI;
using Assets._Scripts.Managers;

public class ScoreKeeper : Singleton<ScoreKeeper> 
{
	public int mP1Score = 0;
	public int mP2Score = 0;
	public int mP1RoundKills = 0;
	public int mP2RoundKills = 0;
	public int mP1Wins = 0;
	public int mP2Wins = 0;

	public int mRoundWinner = 0;

	public int mRoundNumber = 1;

	public GameObject mFinishLinePrefab; 
	bool mP1FinishLineOut;
	bool mP2FinishLineOut;


	GameObject mP1Ship;
	GameObject mP2Ship;

	public int[] mRoundRequiredKills;

	public GameObject[] mRoundSuperPrefabs;

	float mRoundEndTimer = 5f;

	bool mRoundOver = false;

	public Image[] mP1WinCounters;
	public Image[] mP2WinCounters;
	public Text mP1Messages;
	public Text mP2Messages;



	// Use this for initialization
	void Start () 
	{
		if(mRoundSuperPrefabs[0] != null)
		{
			Instantiate(mRoundSuperPrefabs[0], Vector3.zero, Quaternion.identity);
		}
		MapManager.instance.ShowBackground(mRoundNumber);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(mP1RoundKills >= mRoundRequiredKills[mRoundNumber-1] && !mP1FinishLineOut)
		{
			GameObject p1Finish = Instantiate(mFinishLinePrefab, new Vector3(-50,25,0), Quaternion.identity) as GameObject;
			p1Finish.GetComponent<FinishLine>().mPlayerNumber = 1;
			mP1FinishLineOut = true;
		}
		
		if(mP2RoundKills >= mRoundRequiredKills[mRoundNumber-1] && !mP2FinishLineOut)
		{
			GameObject p2Finish = Instantiate(mFinishLinePrefab, new Vector3(50,25,0), Quaternion.identity) as GameObject;
			p2Finish.GetComponent<FinishLine>().mPlayerNumber = 2;
			mP2FinishLineOut = true;
		}
		
		if(mRoundOver)
		{
			EndRound();
		}
	}


	public void FinishRound(int winnerNumber)
	{
		
		mRoundWinner = winnerNumber;
		mRoundOver = true;
		
		
		if(mRoundWinner == 1)
		{
			mP1Wins ++;
		}
		else if (mRoundWinner == 2)
		{
			mP2Wins++;
		}
		
	}

	void EndRound()
	{
		mRoundEndTimer -= Time.deltaTime;
		
		
		//Set message text
		mP1Messages.enabled = true;
		mP2Messages.enabled = true;
		
		if(mP1Wins >= 3)
		{
			mP1Messages.text = "You Win!";
			mP2Messages.text = "You Lose!";
		}
		else if(mP2Wins >= 3)
		{
			mP1Messages.text = "You Lose!";
			mP2Messages.text = "You Win!";
		}
		else
		{
			mP1Messages.text = "Round Complete!";
			mP2Messages.text = "Round Complete!";
		}
		
		
		for(int i = 1; i <= mP1WinCounters.Length; i++)
		{
			if(mP1Wins >= i)
			{
				mP1WinCounters[i-1].enabled = true;
			}
		}
		
		for(int i = 1; i <= mP2WinCounters.Length; i++)
		{
			if(mP2Wins >= i)
			{
				mP2WinCounters[i-1].enabled = true;
			}
		}
		
		if(mRoundEndTimer < 0f)
		{
			
			mRoundOver = false;
			
			mRoundEndTimer = 5f;
			
			if(mP1Wins >=3 || mP2Wins >= 3)
			{
				Application.LoadLevel(Application.loadedLevel);
			}
			
			
			
			mRoundNumber ++;
			mP1Messages.enabled = false;
			mP2Messages.enabled = false;
			
			
			
			mP1RoundKills = 0;
			mP2RoundKills = 0;
			
			mP1FinishLineOut = false;
			mP2FinishLineOut = false;
			
			//Clean up objects from this last round `Adam
			foreach(FinishLine goal in FindObjectsOfType<FinishLine>())
			{
				Destroy (goal.gameObject);
			}
			foreach(Enemy leftoverEnemy in FindObjectsOfType<Enemy>())
			{
				Destroy (leftoverEnemy.gameObject);
			}
			foreach(SwarmGrid leftoverSwarm in FindObjectsOfType<SwarmGrid>())
			{
				Destroy (leftoverSwarm.gameObject);
			}
			foreach(EnemyShipSpawner leftoverSpawner in FindObjectsOfType<EnemyShipSpawner>())
			{
				Destroy (leftoverSpawner.gameObject);
			}
			
			//Instantiate new super-prefabs for spawning things for the new round `Adam
			if(mRoundNumber <= mRoundSuperPrefabs.Length && mRoundSuperPrefabs[mRoundNumber-1] != null)
			{
				Instantiate(mRoundSuperPrefabs[mRoundNumber-1], Vector3.zero, Quaternion.identity);
				MapManager.instance.ShowBackground(mRoundNumber);

			}
			mRoundWinner = 0;
			
			if(mP1Wins >=3 || mP2Wins >= 3)
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
}
