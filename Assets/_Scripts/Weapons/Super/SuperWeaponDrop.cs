using UnityEngine;
using System.Collections;
using Assets._Scripts.Player;
using Assets._Scripts.Weapons;
using Assets._Scripts.Managers;

public class SuperWeaponDrop : MonoBehaviour {
	public Weapon[] SuperScripts = new Weapon[5];
	
	public float speed;
	
	public enum SuperWeapons{
		
		InvertControls,
		EnemyDisplacement,
		SlowMotion,
		WeaponDisable,
		VisionTween
	}
	
	public SuperWeapons superWeapon;
	
	public void Update(){
		
		transform.position = new Vector2 (transform.position.x, transform.position.y - speed / 10);
	}
	
	public void OnTriggerEnter2D(Collider2D other){
		
		if(other.tag == "Player"){
			
			switch(superWeapon){
				
			case SuperWeapons.InvertControls:
				other.GetComponent<PlayerWeapons> ().SuperWeapon1 = SuperScripts[0];
				break;
			case SuperWeapons.EnemyDisplacement:
				other.GetComponent<PlayerWeapons> ().SuperWeapon1 = SuperScripts[1];
				break;
			case SuperWeapons.SlowMotion:
				other.GetComponent<PlayerWeapons> ().SuperWeapon1 = SuperScripts[2];
				break;
			case SuperWeapons.WeaponDisable:
				other.GetComponent<PlayerWeapons> ().SuperWeapon1 = SuperScripts[3];
				break;
			case SuperWeapons.VisionTween:
				other.GetComponent<PlayerWeapons> ().SuperWeapon1 = SuperScripts[4];
				break;
			default:
				other.GetComponent<PlayerWeapons> ().SuperWeapon1 = null;
				break;
			}
			Destroy(gameObject);
		}
	}
}