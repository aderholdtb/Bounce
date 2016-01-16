using UnityEngine;
using System.Collections;

public class tnt : MonoBehaviour {
	//private GameObject player;
	//Vector2 offset = new Vector2(-.5f, .05f);
	//float timeTillExpload;
	//bool active = false;

	// Use this for initialization
	void Start () {
		//player = GameObject.FindGameObjectWithTag("Player").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if(player.GetComponent<PlayerController>().plantedBomb == true){
			transform.position = new Vector2(player.transform.position.x + offset.x, player.transform.position.y + offset.y);
			timeTillExpload = Time.time + 1;
			active = true;
			transform.renderer.enabled = true;
			player.GetComponent<PlayerController>().plantedBomb = false;
		}
		if ((active == true) && (timeTillExpload < Time.time)){
			float distance = Vector3.Distance(player.transform.position, transform.transform.position);

			if(distance < 1.25f){
				if((player.GetComponent<PlayerController>().shieldActivated == false) && (player.GetComponent<PlayerController>().immunePassiveActive == false)){
					player.GetComponent<PlayerController>().isDead = true;
					Debug.Log("Hit by Bomb");
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

			active = false;
			transform.renderer.enabled = false;
			transform.position = new Vector2(0f, 0f);
		}
		*/
	}
}
