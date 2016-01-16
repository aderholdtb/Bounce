using UnityEngine;
using System.Collections;

public class LavaSpawner : MonoBehaviour {
	Vector2 spawnPosition;
	public GameObject lava;
	float nextSpawnTime;
	const float lavaSpawnInterval = .1f;
	float maxTime = 3f;

	// Use this for initialization
	void Start () {
		spawnPosition = new Vector2(transform.position.x, transform.position.y + lava.renderer.bounds.size.y);
		nextSpawnTime = Time.time + lavaSpawnInterval;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > maxTime)
			Destroy (gameObject);
		if (nextSpawnTime < Time.time) {
			Vector2 position = spawnPosition;
			Instantiate(lava, new Vector3(position.x, position.y, 0), Quaternion.identity);
			nextSpawnTime = Time.time + lavaSpawnInterval;
		}
	}
}
