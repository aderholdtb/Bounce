using UnityEngine;
using System.Collections;

public class speedBlock : MonoBehaviour {
	const float switchTime = 1f;
	const float turnOff = .5f;
	bool on = false;
	float currentTime = 0f;
	public float startTime;

	int count = 0;
	// Use this for initialization
	void Start () {
		currentTime = Time.time + startTime;
	}
	
	// Update is called once per frame
	void Update () {
		if ((currentTime < Time.time) && !on) {
				transform.renderer.enabled = true;
				on = true;
				currentTime = Time.time + turnOff;
		} else if ((currentTime < Time.time) && on) {
				transform.renderer.enabled = false;
				on = false;
				currentTime = Time.time + switchTime;
		}
	}
}
