using UnityEngine;
using System.Collections;

public class setToBall : MonoBehaviour {
	Transform player;
	public float offset;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z - offset);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
