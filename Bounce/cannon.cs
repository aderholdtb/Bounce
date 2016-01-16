using UnityEngine;
using System.Collections;

public class cannon : MonoBehaviour {
	private Transform player;
	public Transform cannonObject;
	public Transform newPosition;
	Vector2 offset = new Vector2(.092f, -.1f);
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col) { 
		if (col.gameObject.tag == "Player"){
			cannonObject.GetComponent<CannonMove>().start = true;
			player.rigidbody2D.position = new Vector2(newPosition.transform.position.x, newPosition.transform.position.y);
			player.rigidbody2D.isKinematic = true;
			Destroy(this.gameObject);
		}
	}
}
