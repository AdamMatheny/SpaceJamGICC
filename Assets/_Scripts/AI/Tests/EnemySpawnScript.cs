using UnityEngine;
using System.Collections;

public class EnemySpawnScript : MonoBehaviour {

	public int enemyCount;
	public int maxEnemyCount;

	public Renderer renderer;

	// Variable to store the enemy prefab
	public GameObject enemy;
	
	// Variable to know how fast we should create new enemies
	public float spawnTime = 2;

	public void Start(){

		InvokeRepeating ("addEnemy", spawnTime, spawnTime);
		renderer = gameObject.GetComponent<Renderer> ();
	}

	public void addEnemy(){

		if (enemyCount < maxEnemyCount) {

			float x1 = transform.position.x - renderer.bounds.size.x / 2;
			float x2 = transform.position.x + renderer.bounds.size.x / 2;

			Vector2 spawnPoint = new Vector2 (Random.Range (x1, x2), transform.position.y);

			Instantiate (enemy, spawnPoint, Quaternion.identity);
			enemyCount += 1;
		}
	}
}
