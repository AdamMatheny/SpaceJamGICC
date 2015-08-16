using UnityEngine;
using System.Collections;

public class CutsceneCameraFollowShip : MonoBehaviour 
{
	public GameObject mSpaceShip;
	public GameObject mSwarm;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(mSpaceShip != null)
		{
			transform.LookAt (mSpaceShip.transform.position);
		}
		else
		{
			transform.LookAt (mSwarm.transform.position);
		}
	}
}
