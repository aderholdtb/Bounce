using UnityEngine;
using System.Collections;

public class CannonMove : MonoBehaviour {
	float speed = 15;
	bool rotatingForward = false;
	public bool start = false;
	bool pause = false;
	private Transform player;
	public Transform cannonPosition;
	float stopTime = .5f;
	float currentTime;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	// Update is called once per frame
	void Update () {
		if (start == true) {//check if cannon needs to rotate back
			if (transform.rotation.eulerAngles.z >= 359 && rotatingForward) {
				rotatingForward = false;
			} else if ((transform.rotation.eulerAngles.z <= 315) && !rotatingForward){
				rotatingForward = true;
				currentTime = Time.time;
				pause = true;
				start = false;
			}//rotate the cannon forward
			if (rotatingForward){
				transform.Rotate (Vector3.forward * speed * Time.deltaTime);
			}
			else 
				transform.Rotate (Vector3.back * speed * Time.deltaTime);
		}
		//player is in the cannon
		if (currentTime + stopTime < Time.time && pause) {
			player.rigidbody2D.isKinematic = false;
			pause = false;
			player.GetComponent<PlayerController>().inCannon = true;
		}
	}
}
