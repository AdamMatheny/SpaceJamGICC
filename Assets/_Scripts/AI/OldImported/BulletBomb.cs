using UnityEngine;
using System.Collections;
using Assets._Scripts.Player;
using Assets._Scripts.Weapons;

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
					other.GetComponent<Enemy>().EnemyShipDie();
			}
			if(other.GetComponent<Projectile>() != null || other.GetComponent<EnemyBulletController>() != null)
			{
				Destroy (other.gameObject);
			}
			if(other.GetComponent<PlayerBase>() != null)
			{
				other.GetComponent<PlayerBase>().mHitPlayer();
			}
		}
	}
}