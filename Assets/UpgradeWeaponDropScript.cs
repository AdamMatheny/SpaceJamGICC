using UnityEngine;
using System.Collections;

namespace Assets._Scripts.Weapons{

	public class UpgradeWeaponDropScript : MonoBehaviour {
		
		public float FlySpeed;
		
		public void Move(){
			
			gameObject.transform.Translate(Vector3.down * FlySpeed * Time.deltaTime);
		}
		
		public void Update(){
			
			Move ();
		}

		public void OnTriggerEnter2D(Collider2D other){

			if(other.tag == "Player"){

				other.gameObject.GetComponentInChildren<BasicCanon> ().isUpgraded = true;
				Destroy(gameObject);
			}
		}
	}
}