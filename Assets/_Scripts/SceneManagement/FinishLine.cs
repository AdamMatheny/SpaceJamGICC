using UnityEngine;
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
				switch(mPlayerNumber)
				{
				case 1:
					if(ScoreKeeper.instance.mP1Wins == 2)
					{
						ScoreKeeper.instance.mAudioSource.PlayOneShot(ScoreKeeper.instance.mSoundEffects[1]);
					}
					break;

				case 2:
					if(ScoreKeeper.instance.mP2Wins == 2)
					{
						ScoreKeeper.instance.mAudioSource.PlayOneShot(ScoreKeeper.instance.mSoundEffects[1]);
					}
					break;

				default:
					break;

				}

				ScoreKeeper.instance.FinishRound (mPlayerNumber);


			}

		}
		
	}
}
