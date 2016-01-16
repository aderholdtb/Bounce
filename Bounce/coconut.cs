using UnityEngine;
using System.Collections;

public class coconut : MonoBehaviour {
	public GameObject cocoSpawner;
	private GameObject player;
	float respawnTime = 3;
	float dropCooldown;

	// Use this for initialization
	void Start () {
		transform.renderer.enabled = false;
		rigidbody2D.isKinematic = true;
		transform.position = cocoSpawner.transform.position;
		player = GameObject.FindGameObjectWithTag("Player").gameObject;
		dropCooldown = Random.Range (0f, 3f) + Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (dropCooldown < Time.time) {
			transform.renderer.enabled = true;
			rigidbody2D.isKinematic = false;
			}
	}

	void OnCollisionEnter2D(Collision2D col) { 
		if (col.gameObject.tag == "Player"){
			if((player.GetComponent<PlayerController>().shieldActivated == false) && (player.GetComponent<PlayerController>().immunePassiveActive == false)){
				player.GetComponent<PlayerController>().isDead = true;
				Debug.Log("Hit by coconut");
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
		if (col.gameObject.tag == "block") {
			transform.renderer.enabled = false;
			rigidbody2D.isKinematic = true;
			dropCooldown = respawnTime + Time.time;
			transform.position = cocoSpawner.transform.position;
			}
	}
}
