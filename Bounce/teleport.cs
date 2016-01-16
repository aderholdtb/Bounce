using UnityEngine;
using System.Collections;

public class teleport : MonoBehaviour {
	private Transform player;
	public bool teleportActive = false;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (teleportActive && transform.position.y < 0) {
			transform.position = new Vector2(player.position.x + player.GetComponent<PlayerController> ().offset.x - 1f, player.position.y + player.GetComponent<PlayerController> ().offset.y);
		}
	}

	void OnCollisionEnter2D(Collision2D col) { 
		if (teleportActive && col.gameObject.tag == "block") {
			teleportActive = false;
			Debug.Log ("teleport");
			rigidbody2D.collider2D.enabled = false;
			player.GetComponent<PlayerController> ().teleColliderCheck = true;
		}
	}
}
