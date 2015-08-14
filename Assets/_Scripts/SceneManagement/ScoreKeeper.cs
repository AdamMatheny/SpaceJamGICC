using UnityEngine;
using System.Collections;
using Assets._Scripts.AI;
using Assets._Scripts.Player;
using UnityEngine.UI;


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
	//	DontDestroyOnLoad(this.gameObject);
	}

	//For UI display stuff
	public Image[] mP1WinCounters;
	public Text mP1MessageText;
	public Image[] mP2WinCounters;
	public Text mP2MessageText;


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


		if(mRoundWinner == 1)
		{
			mPlayer1Wins ++;
		}
		else if (mRoundWinner == 2)
		{
			mPlayer2Wins++;
		}

	}

	void EndRound()
	{
		mRoundFinishTimer -= Time.deltaTime;


		//Set message text
		mP1MessageText.enabled = true;
		mP2MessageText.enabled = true;

		if(mPlayer1Wins >= 3)
		{
			mP1MessageText.text = "You Win!";
			mP2MessageText.text = "You Lose!";
		}
		else if(mPlayer2Wins >= 3)
		{
			mP1MessageText.text = "You Lose!";
			mP2MessageText.text = "You Win!";
		}
		else
		{
			mP1MessageText.text = "Round Complete!";
			mP2MessageText.text = "Round Complete!";
		}


		for(int i = 1; i <= mP1WinCounters.Length; i++)
		{
			if(mPlayer1Wins >= i)
			{
				mP1WinCounters[i-1].enabled = true;
			}
		}
		
		for(int i = 1; i <= mP2WinCounters.Length; i++)
		{
			if(mPlayer2Wins >= i)
			{
				mP2WinCounters[i-1].enabled = true;
			}
		}

		if(mRoundFinishTimer < 0f)
		{

			mRoundOver = false;

			mRoundFinishTimer = 5f;

			if(mPlayer1Wins >=3 || mPlayer2Wins >= 3)
			{
				Application.LoadLevel(Application.loadedLevel);
			}



			mCurrentRound ++;
			mP1MessageText.enabled = false;
			mP2MessageText.enabled = false;



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

			if(mPlayer1Wins >=3 || mPlayer2Wins >= 3)
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
}
