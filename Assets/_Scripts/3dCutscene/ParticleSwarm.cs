using UnityEngine;
using System.Collections;

public class ParticleSwarm : MonoBehaviour 
{
	public GameObject mShuttle;
	public GameObject[] mSwarms;
	public GameObject mAltSwarm;
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (mShuttle != null)
		{
			transform.position = new Vector3(0,30,0)+ mShuttle.transform.position;

			if(mShuttle.transform.position.y > 300)
			{
			}
		}
		else
		{
			mAltSwarm.SetActive (true);
		//	transform.position = new Vector3(0,36,5);
//			foreach (GameObject swarm in mSwarms)
//			{
//				swarm.GetComponent<ParticleSystem>().Stop();
//				swarm.SetActive (false);
//			}
//			foreach (GameObject swarm in mSwarms)
//			{
//				swarm.SetActive (true);
//				swarm.GetComponent<ParticleSystem>().Stop();
//				swarm.GetComponent<ParticleSystem>().Play();
//			}
		}

		if(transform.position.y > 300)
		{
			foreach (GameObject swarm in mSwarms)
			{
				swarm.SetActive (true);
			}

		}
	}
}
