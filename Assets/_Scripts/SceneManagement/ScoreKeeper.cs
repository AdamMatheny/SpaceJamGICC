using UnityEngine;
using System.Collections;
using Assets._Scripts.AI;
using Assets._Scripts.Player;

public class ScoreKeeper : MonoBehaviour 
{

	public int mPlayer1Kills = 0;
	public int mPlayer2Kills = 0;

	public int mPlayer1RoundScore = 0;
	public int mPlayer2RoundScore = 0;

	public int mPlayer1Wins = 0;
	public int mPlayer2Wins = 0;

	public float mPlayer1InvincibleTime = 0f;
	public float mPlayer2InvincibleTime = 0f;


	public int mCurrentRound = 1;
	public int[] mRoundRequiredKills;
	public int mRoundWinner = 0;

	[SerializeField] private GameObject mFinishLine;
	bool mP1FinishLineOut = false;
	bool mP2FinishLineOut = false;

	float mRoundFinishTimer = 5f;
	bool mRoundOver = false;

	[SerializeField] private GameObject[] mRoundSuperPrefabs;

	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
	}

	// Use this for initialization
	void Start () 
	{
		if(mRoundSuperPrefabs[0] != null)
		{
			Instantiate(mRoundSuperPrefabs[0], Vector3.zero, Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		if(mPlayer1RoundScore >= mRoundRequiredKills[mCurrentRound-1] && !mP1FinishLineOut)
		{
			GameObject p1Finish = Instantiate(mFinishLine, new Vector3(-50,25,0), Quaternion.identity) as GameObject;
			p1Finish.GetComponent<FinishLine>().mPlayerNumber = 1;
			mP1FinishLineOut = true;
		}

		if(mPlayer2RoundScore >= mRoundRequiredKills[mCurrentRound-1] && !mP2FinishLineOut)
		{
			GameObject p2Finish = Instantiate(mFinishLine, new Vector3(50,25,0), Quaternion.identity) as GameObject;
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

	}

	void EndRound()
	{
		mRoundFinishTimer -= Time.deltaTime;

		if(mRoundFinishTimer < 0f)
		{
			if(mRoundWinner == 1)
			{
				mPlayer1Wins ++;
			}
			else if (mRoundWinner == 2)
			{
				mPlayer2Wins++;
			}

			mRoundOver = false;

			mRoundFinishTimer = 5f;

			if(mPlayer1Wins >= 3 || mPlayer2Wins >= 3)
			{
				if(mPlayer1Wins >= 3)
				{
					//Display Player 1 wins message `Adam
				}
				else if (mPlayer2Wins >= 3)
				{
					//Display Player 2 wins message `Adam
				}


			}

			mCurrentRound ++;

			mPlayer1RoundScore = 0;
			mPlayer2RoundScore = 0;

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
			if(mRoundSuperPrefabs[mCurrentRound-1] != null)
			{
				Instantiate(mRoundSuperPrefabs[mCurrentRound-1], Vector3.zero, Quaternion.identity);
			}
			mRoundWinner = 0;
		}
	}
}
