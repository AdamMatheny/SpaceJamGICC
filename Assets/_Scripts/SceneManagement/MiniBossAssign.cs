using UnityEngine;
using System.Collections;
using Assets._Scripts.AI;

namespace Assets._Scripts.Managers
{
	public class MiniBossAssign : MonoBehaviour 
	{
		public MiniBoss mBoss;
		// Use this for initialization
		void Start () 
		{
			if(ScoreKeeper.instance.mP1Wins >= ScoreKeeper.instance.mP2Wins)
			{
				transform.position = new Vector3(-50f,0f,0f);
				mBoss.mTargetPlayerNumber =1;
				mBoss.mHoverPoint = transform.position;
				mBoss.StartSetup ();
			}
			else
			{
				transform.position = new Vector3(50f,0f,0f);
				mBoss.mTargetPlayerNumber =2;
				mBoss.mHoverPoint = transform.position;
				mBoss.StartSetup ();
			}
		}
		
		// Update is called once per frame
		void Update () {
		
		}
	}
}