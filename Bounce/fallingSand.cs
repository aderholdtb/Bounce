using UnityEngine;
using System.Collections;

public class fallingSand : MonoBehaviour {
	const float fallDelay = .1f;
	float currentTime;
	bool fallen = false;
	bool playerTouched = false;
	Vector2 startPosition;
	Quaternion startRotation;
	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").gameObject;
		startPosition = transform.position;
		startRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerTouched && currentTime < Time.time) {
			rigidbody2D.isKinematic = false;

			if(transform.position.y < -5){
				rigidbody2D.isKinematic = true;
				fallen = true;
				playerTouched = false;
			}
		}

		if (player.GetComponent<PlayerController> ().isDead == true && (fallen || playerTouched)) {
			rigidbody2D.isKinematic = true;
			transform.position = startPosition;
			transform.rotation = startRotation;
			fallen = false;
			playerTouched = false;
		}
	}

	void OnCollisionEnter2D(Collision2D col) { 
		if (col.gameObject.tag == "Player") {
			playerTouched = true;
			currentTime = Time.time + fallDelay;
		}
	}
}
