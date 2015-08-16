using UnityEngine;
using System.Collections;

public class ShuttleLauncher : MonoBehaviour 
{
	public float mTimer = 0f;
	float mMoveAmount = 0f;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		mTimer += Time.deltaTime;

		if(mTimer > 5f)
		{
			mMoveAmount += 0.01f;
			transform.position += new Vector3(0, mMoveAmount, 0);
		}
		if(transform.position.y >1000)
		{
			Destroy(this.gameObject);
		}
	}
}
