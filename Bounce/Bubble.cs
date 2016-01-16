using UnityEngine;
using System.Collections;

public class Bubble : MonoBehaviour {
	private Transform player;
	public Transform bubbleSpawner;
	bool hit = false;
	float maxY = 5f;
	Vector3 constantVelocity = new Vector3(0, 1.5f, 0);

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		//bubbleSpawner = GameObject.FindGameObjectWithTag("bubbleSpawner").transform;
		transform.position = bubbleSpawner.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += constantVelocity * Time.deltaTime;

		if (transform.position.y > maxY) {
			if(hit){
				transform.renderer.enabled = true;
				hit = false;
			}

			transform.position = bubbleSpawner.position;
		}
	}

	void OnCollisionEnter2D(Collision2D col) { 
		if (col.gameObject.tag == "Player"){
			if((player.GetComponent<PlayerController>().shieldActivated == false) && (player.GetComponent<PlayerController>().immunePassiveActive == false)){
				player.GetComponent<PlayerController>().hitByBubble = true;
				player.GetComponent<PlayerController>().hitByBubbleStart = Time.time;
				hit = true;
				transform.renderer.enabled = false;
			}
			else if(player.GetComponent<PlayerController>().immunePassiveActive == true){
				player.GetComponent<PlayerController>().immunePassiveActive = false;
				player.GetComponent<PlayerController>().currentPassiveCooldown = player.GetComponent<PlayerController>().cooldownImmune + Time.time;
			}
			else{
				player.GetComponent<PlayerController>().shieldActivated = false;
				player.GetComponent<PlayerController>().shield.renderer.enabled = false;
			}
		}
	}
}
