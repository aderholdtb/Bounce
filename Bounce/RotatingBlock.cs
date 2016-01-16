using UnityEngine;
using System.Collections;

public class RotatingBlock : MonoBehaviour {
	float speed = 15;
	// Update is called once per frame
	void Start(){
		//transform.Rotate(Vector3.back*Random.Range(0, 360));
	}
	void FixedUpdate () {
		transform.Rotate(Vector3.back*speed*Time.deltaTime);
	}
}
