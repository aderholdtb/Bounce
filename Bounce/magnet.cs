using UnityEngine;
using System.Collections;

public class magnet : MonoBehaviour {
	private Transform player;
	Vector2 startingGravity;
	float speed = 2f;
	bool startMagnet = false;
	float activeTime = 2f;
	float startingTimeInactive;
	float inactiveTime = 10f;
	float startingTime;
	bool inactive = false;
	bool inRange = false;
	bool forward;
	public bool dropArea = false; 
	public GameObject dropZone;
	public GameObject magnetObject;
	public bool deathMagnet;

	// Use this for initialization
	void Start () {
		magnetObject = GameObject.FindGameObjectWithTag("magnet").gameObject;
		dropZone = GameObject.FindGameObjectWithTag("dropArea").gameObject;
		player = GameObject.FindGameObjectWithTag("Player").transform;
		//startingGravity = Physics2D.gravity;
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector2.Distance(player.position, rigidbody2D.transform.position);

		if (startMagnet == true) {
			magnetObject.GetComponent<move_block>().enabled = false;
			float step = speed * Time.deltaTime;
			player.rigidbody2D.isKinematic = true;
			player.position = transform.position;

			if(forward == false)
		 		magnetObject.transform.position -= new Vector3((speed * Time.deltaTime), 0, 0);
			else
				magnetObject.transform.position += new Vector3((speed * Time.deltaTime), 0, 0);

			if(((magnetObject.transform.position.x < dropZone.transform.position.x) && (forward == false)) ||
			   ((magnetObject.transform.position.x > dropZone.transform.position.x) && (forward == true))){
				player.rigidbody2D.isKinematic = false;
				startMagnet = false;
				inactive = true;
				startingTimeInactive = Time.time + inactiveTime;
				magnetObject.GetComponent<move_block>().enabled = true;
			}
		}
		if ((distance < .5f) && (!startMagnet) && (!inactive)) {
			//Physics2D.gravity = Vector2.zero;
			float step = speed * Time.deltaTime;
			player.position = Vector3.MoveTowards(transform.position, player.position, step);
			inRange = true;
		}

		if (inactive && startingTimeInactive < Time.time) {
			inactive = false;
			}
	}

	void OnCollisionEnter2D(Collision2D col){
		if ((inRange) && (!startMagnet)) {
			if(magnetObject.transform.position.x < dropZone.transform.position.x)
				forward = true;
			else
				forward = false;

			startMagnet = true;
			if(deathMagnet)
				player.GetComponent<PlayerController>().cantControl = true;
		}
	}
}
