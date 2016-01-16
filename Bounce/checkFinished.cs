using UnityEngine;
using System.Collections;

public class checkFinished : MonoBehaviour {
	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.rigidbody2D.position.x > transform.position.x) {
			player.GetComponent<PlayerController> ().cantControl = true;
			player.GetComponent<PlayerController> ().finishScreen1.GetComponent<Finish> ().finished = true;
			player.GetComponent<PlayerController> ().currentState = 1;
			Destroy (this);
				}
		}
}
