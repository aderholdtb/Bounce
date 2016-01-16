using UnityEngine;
using System.Collections;

public class grounded : MonoBehaviour {
	Transform target;
	public float distancey;
	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector2 (target.position.x, target.position.y - distancey);
		}
}
