using UnityEngine;
using System.Collections;

using Assets._Scripts.AI;

public class DamoclesSwordSwarmAttackLoop : SwarmSpecialMovement 
{
	[SerializeField] private float mStateTimer = -10f;
	//Timer value states: ~Adam
//		/*
//		 * <=10: Idle
//		 * 11-12: Drop
//		 * 13-14: Sweep left
//		 * 14-16: Sweep right
//		 * 16-18: Swing up to center
//		 * 18-20: Spin and lift to start
//		 * >20: Reset
//		 */

	//Positions and rotations to move to as the sword swings around ~Adam
	[SerializeField] private Vector3 mIdlePos;
	[SerializeField] private Vector3 mIdleRot;

	[SerializeField] private Vector3 mDropPos;
	[SerializeField] private Vector3 mLeftSweepPos;
	[SerializeField] private Vector3 mRightSweepPos;

	[SerializeField] private Vector3 mSwingUpPos;
	[SerializeField] private Vector3 mSwingUpRot;


	
	// Update is called once per frame
	void Update () 
	{
		mStateTimer += Time.deltaTime;


		#region Changing attack state based on timer
		//>20: Reset ~Adam
		if(mStateTimer > 20f)
		{
			mStateTimer = 0f;
		}
		//18-10: Spin and lift to start ~Adam
		else if (mStateTimer > 18f)
		{
			transform.position = Vector3.Lerp(transform.position, mIdlePos, 0.05f);
			transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler (transform.localRotation.eulerAngles+ Vector3.back*40f), 0.05f);
		}
		//16-18: Swing up to center ~Adam
		else if (mStateTimer > 16f)
		{
			transform.position = Vector3.Lerp(transform.position, mSwingUpPos, 0.1f);
			transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler (mSwingUpRot), 0.1f);
		}
		//14-16: Sweep right ~Adam
		else if (mStateTimer > 14f)
		{
			transform.position = Vector3.Lerp(transform.position, mRightSweepPos, 0.05f);
		}
		//13-14: Sweep left ~Adam
		else if (mStateTimer > 12f)
		{
			transform.position = Vector3.Lerp(transform.position, mLeftSweepPos, 0.05f);

		}
		//10-12: Drop ~Adam
		else if (mStateTimer > 10f)
		{
			transform.position = Vector3.Lerp(transform.position, mDropPos, 0.1f);
		}
		// <=10: Idle ~Adam
		else
		{
			transform.position = mIdlePos;
			//transform.localRotation = Quaternion.Euler (mIdleRot);
			transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler (mIdleRot), 0.1f);
		}
		#endregion


		//Keep swarm grid slots all facing the same way ~Adam
		foreach(SwarmGridSlot gridSlot in FindObjectsOfType<SwarmGridSlot>())
		{
			gridSlot.gameObject.transform.rotation = Quaternion.Euler(Vector3.zero);
		}
	}//END of Update()
}
