using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTest : MonoBehaviour {

	public GameObject zombiePrefab;
	public Transform player;

	void Start() {
		InvokeRepeating("spawnZombies", 0f, 4f);
	}
	
	private void spawnZombies() {
		Vector3 randomDist = new Vector3(player.position.x + Random.Range(-20f, 20f), -5f, player.position.z + Random.Range(-20f, 20f));
		GameObject zombie = (GameObject) Instantiate(zombiePrefab, randomDist, Quaternion.identity);
	}
}
