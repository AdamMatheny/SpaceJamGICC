using UnityEngine;
using System.Collections;

public class FinalMessage : MonoBehaviour 
{
	public GameObject mMessage;

	float mTimer = 10f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		mTimer -= Time.deltaTime;

		if(mTimer <= 7f)
		{
			mMessage.SetActive (true);
		}
		if(mTimer <= 0)
		{
			Application.LoadLevel(0);
		}
	}
}
