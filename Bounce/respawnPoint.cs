using UnityEngine;
using System.Collections;

public class respawnPoint : MonoBehaviour {
	private Transform player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
			if (player.position.x > transform.position.x) {
			player.GetComponent<PlayerController>().respawn =  new Vector2(transform.position.x, transform.position.y + transform.renderer.bounds.size.y);
				Destroy(this);
			}
	}
}
