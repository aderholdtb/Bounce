using UnityEngine;
using System.Collections;

public class ReachTheEnd : MonoBehaviour {
	bool reachTheEnd = false;
	private Transform player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
	if (reachTheEnd == true) {
			//Do something with the score
			//Do something with the time
			//wait for the other players to finish or die from the map
			Debug.Log("Ended");
			//Time.timeScale = 0;
			player.GetComponent<PlayerController>().currentState = 3;
				}
	}

	void OnCollisionEnter2D(Collision2D col) { 
		if (col.gameObject.tag == "Player") {
			reachTheEnd = true;
				}
	}
}
