using UnityEngine;
using System.Collections;

public class tntSpawn : MonoBehaviour {
	private Transform player;
	public Transform tntSpawner;
	const float waitTime = 2f;
	public float TimeTillExplode = 2f;
	bool didExplode = true;
	bool falling = false;
	float currentTime;
	public bool startOverride = false;
	public GameObject start;
	float delayDrop = .5f;
	bool delay = false;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		transform.position = tntSpawner.position;
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance(player.transform.position, start.transform.position);
		if(distance < 2)
			startOverride = true;

		if (startOverride) {
			transform.position = tntSpawner.position;
			delay = true;
			currentTime = Time.time + delayDrop;
			startOverride = false;
		} else if (delay && currentTime < Time.time) {
			rigidbody2D.isKinematic = false;
			transform.renderer.enabled = true;
			didExplode = false;
			falling = true;
			currentTime = Time.time + TimeTillExplode;
			delay = false;
		}
		else if (didExplode && currentTime < Time.time) {
			rigidbody2D.isKinematic = false;
			transform.renderer.enabled = true;
			didExplode = false;
			falling = true;
			currentTime = Time.time + TimeTillExplode;
		}
		else if (falling && currentTime < Time.time) {
			falling = false;
			detonate ();
		}
	}
	
	void detonate(){
		gameObject.renderer.enabled = false;
		rigidbody2D.isKinematic = true;
		float distance = Vector3.Distance(player.transform.position, transform.position);

		if (distance < .75f) {
			if((player.GetComponent<PlayerController>().shieldActivated == false) && (player.GetComponent<PlayerController>().immunePassiveActive == false)){
				player.GetComponent<PlayerController>().isDead = true;
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
		transform.position = tntSpawner.position;
		didExplode = true;
		currentTime = Time.time + waitTime;
	}
}
