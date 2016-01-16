using System;
using UnityEngine;
using System.Collections;


public class StartFunction : MonoBehaviour {
	private Transform player;
	public GameObject start3;
	public GameObject start2;
	public GameObject start1;
	public GameObject go;
	public onStart starter;
	float currentTimer;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		player.GetComponent<PlayerController>().cantControl = true;
		start3.SetActive(false);
		start2.SetActive(false);
		start1.SetActive(false);
		go.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (starter.start != true) {
			currentTimer = Time.time + 1;
			Debug.Log ("false");
			return;
		}

		if (currentTimer > Time.time) {
			Debug.Log ("true");
			Start3 ();
				}
		else if (currentTimer + 1 > Time.time)
			Start2 ();
		else if (currentTimer + 2 > Time.time)
			Start1 ();
		else if (currentTimer + 3 > Time.time)
			Go ();
		else
			go.SetActive(false);
	}

	void Start3(){
		start3.SetActive(true);
	}
	void Start2(){
		start3.SetActive(false);
		start2.SetActive(true);
	}
	void Start1(){
		start2.SetActive(false);
		start1.SetActive(true);
	}
	void Go(){
		player.GetComponent<PlayerController>().cantControl = false;
		start1.SetActive(false);
		go.SetActive(true);
	}
}
