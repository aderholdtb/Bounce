using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class onStart : MonoBehaviour {
	private GameObject player;
	public EventSystem eventSystem;

	public GameObject canvasBalls;
	public GameObject canvasActives;
	public GameObject canvasPassive;
	public GameObject mainCanvas;

	public GameObject skin1Button;
	public GameObject skin2Button;
	public GameObject skin3Button;
	public GameObject skin4Button;
	public GameObject skin5Button;
	public GameObject skin6Button;
	public GameObject skin7Button;

	public GameObject ActiveButton1;
	public GameObject ActiveButton2;
	public GameObject ActiveButton3;

	public GameObject passiveButton1;
	public GameObject passiveButton2;

	public GameObject backActive;
	public GameObject backPassive;

	public Transform skin1;
	public Transform skin2;
	public Transform skin3;
	public Transform skin4;
	public Transform skin5;
	public Transform skin6;
	public Transform skin7;

	bool active = false;
	bool balls = true;
	bool passive = false;
	public bool start = false;

	public float onStartTime;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		canvasBalls.SetActive (true);
		canvasActives.SetActive (false);
		canvasPassive.SetActive (false);
		mainCanvas.SetActive (false);
		skin1.renderer.enabled = false;
		skin2.renderer.enabled = false;
		skin3.renderer.enabled = false;
		skin4.renderer.enabled = false;
		skin5.renderer.enabled = false;
		skin6.renderer.enabled = false;
		skin7.renderer.enabled = false;
	}

	void Update(){
		if (balls) {
			pickBalls ();
		} 
		else if (active) {
			pickActive();
		}
		else if (passive) {
			pickPassive();
		}
	}

	void pickActive(){
		if (eventSystem.currentSelectedGameObject == backActive) {
			balls = true;
			active = false;
			canvasBalls.SetActive (true);
			canvasActives.SetActive (false);

			skin1.renderer.enabled = false;
			skin2.renderer.enabled = false;
			skin3.renderer.enabled = false;
			skin4.renderer.enabled = false;
			skin5.renderer.enabled = false;
			skin6.renderer.enabled = false;
			skin7.renderer.enabled = false;
		}
		if (eventSystem.currentSelectedGameObject == ActiveButton1) {
			eventSystem.SetSelectedGameObject (null);
			player.GetComponent<PlayerController>().currentActive = 1;
			active = false;
			passive = true;
			canvasActives.SetActive (false);
			canvasPassive.SetActive (true);
		}
		else if (eventSystem.currentSelectedGameObject == ActiveButton2) {
			eventSystem.SetSelectedGameObject (null);
			player.GetComponent<PlayerController>().currentActive = 2;
			active = false;
			passive = true;
			canvasActives.SetActive (false);
			canvasPassive.SetActive (true);
		}
		else if (eventSystem.currentSelectedGameObject == ActiveButton3) {
			eventSystem.SetSelectedGameObject (null);
			player.GetComponent<PlayerController>().currentActive = 3;
			active = false;
			passive = true;
			canvasActives.SetActive (false);
			canvasPassive.SetActive (true);
		}
	}

	void pickPassive(){
		if (eventSystem.currentSelectedGameObject == backPassive) {
			passive = false;
			active = true;
			canvasPassive.SetActive (false);
			canvasActives.SetActive (true);
		}
		if (eventSystem.currentSelectedGameObject == passiveButton1) {
			eventSystem.SetSelectedGameObject (null);
			player.GetComponent<PlayerController>().currentPassive = 0;
			passive = false;
			start = true;
			mainCanvas.SetActive (true);
			onStartTime = Time.time;
			canvasPassive.SetActive (false);
		}
		else if (eventSystem.currentSelectedGameObject == passiveButton2) {
			eventSystem.SetSelectedGameObject (null);
			player.GetComponent<PlayerController>().currentPassive = 1;
			passive = false;
			start = true;
			mainCanvas.SetActive (true);
			onStartTime = Time.time;
			canvasPassive.SetActive (false);
		}
	}

	void pickBalls(){
		if (eventSystem.currentSelectedGameObject == skin1Button) {
			eventSystem.SetSelectedGameObject (null);
			skin1.renderer.enabled = true;
			balls = false;
			active = true;
			canvasBalls.SetActive (false);
			canvasActives.SetActive (true);
		}
		else if (eventSystem.currentSelectedGameObject == skin2Button) {
			eventSystem.SetSelectedGameObject (null);
			skin2.renderer.enabled = true;
			balls = false;
			active = true;
			canvasBalls.SetActive (false);
			canvasActives.SetActive (true);
		}
		else if (eventSystem.currentSelectedGameObject == skin3Button) {
			eventSystem.SetSelectedGameObject (null);
			skin3.renderer.enabled = true;
			balls = false;
			active = true;
			canvasBalls.SetActive (false);
			canvasActives.SetActive (true);
		}
		else if (eventSystem.currentSelectedGameObject == skin4Button) {
			eventSystem.SetSelectedGameObject (null);
			skin4.renderer.enabled = true;
			balls = false;
			active = true;
			canvasBalls.SetActive (false);
			canvasActives.SetActive (true);
		}
		else if (eventSystem.currentSelectedGameObject == skin5Button) {
			eventSystem.SetSelectedGameObject (null);
			skin5.renderer.enabled = true;
			balls = false;
			active = true;
			canvasBalls.SetActive (false);
			canvasActives.SetActive (true);
		}
		else if (eventSystem.currentSelectedGameObject == skin6Button) {
			eventSystem.SetSelectedGameObject (null);
			skin6.renderer.enabled = true;
			balls = false;
			active = true;
			canvasBalls.SetActive (false);
			canvasActives.SetActive (true);
		}
		else if (eventSystem.currentSelectedGameObject == skin7Button) {
			eventSystem.SetSelectedGameObject (null);
			skin7.renderer.enabled = true;
			balls = false;
			active = true;
			canvasBalls.SetActive (false);
			canvasActives.SetActive (true);
		}
	}
}
