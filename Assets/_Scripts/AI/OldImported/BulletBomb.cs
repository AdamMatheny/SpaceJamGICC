using UnityEngine;
using System.Collections;

namespace Assets._Scripts.AI
{
	public class BulletBomb : MonoBehaviour 
	{

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}

		void OnTriggerEnter(Collider other)
		{
			if(other.GetComponent<Enemy>() != null)
			{
				if(!other.name.Contains("Red"))
				{
					other.GetComponent<Enemy>().EnemyShipDie();
				}
			}
			//Destroy player bullets


			//Hit the player ship to slow it down for a couple of seconds

		}
	}
}