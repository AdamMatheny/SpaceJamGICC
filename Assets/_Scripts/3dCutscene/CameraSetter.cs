using UnityEngine;
using System.Collections;

public class CameraSetter : MonoBehaviour 
{
	public Camera mGroundCam;
	public Camera mShipCamUp;
	public Camera mShipCamDown;

	public float mTimer = 0f;

	public GameObject mShuttle;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		mTimer+=Time.deltaTime;

		if(mShuttle != null)
		{
			if(mShuttle.transform.position.y <=60f)
			{
				mGroundCam.depth = 5;
				mShipCamUp.depth = -5;
				mShipCamDown.depth = -5;
			}
			else if(mShuttle.transform.position.y <=250f)
			{
				mGroundCam.depth = -5;
				mShipCamUp.depth = -5;
				mShipCamDown.depth = 5;
			}
			else
			{
				mGroundCam.depth = -5;
				mShipCamUp.depth = 5;
				mShipCamDown.depth = -5;
			}

		}
		else
		{
			mGroundCam.depth = 5;
		}
	}
}
