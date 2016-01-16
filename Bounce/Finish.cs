using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Finish : MonoBehaviour {
	public bool finished = false;
	bool afterFinish = false;
	float score;
	float time;
	int deaths = 0;
	const float minScore = 500f;

	public GameObject finish;
	public GameObject FinalScore;
	public GameObject FinalTime;
	public GameObject totalScore;
	public GameObject totalTime;
	public GameObject menuButton;

	public onStart starter;

	private float sec;
	private int min;
	private float ms;
	string msS;
	string secS;
	string minS;
	
	private GameObject player;
	public float FinalScores;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").gameObject;
		finish.SetActive(false);
		FinalScore.SetActive(false);
		FinalTime.SetActive(false);
		totalScore.SetActive(false);
		totalTime.SetActive(false);
		menuButton.GetComponent<Image>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (finished) {
			finish.SetActive(true);
			menuButton.GetComponent<Image>().enabled = true;

			deaths = player.GetComponent<PlayerController>().totalDeaths;
			time = Time.time - 3 - starter.onStartTime;
			score = (int)((240*60) - (time*60) - (deaths * 25));

			ms += time*60;
			min = (int)ms/3600;
			minS = min.ToString();
			ms = ms - (min*3600);
			sec = (int)ms/60;
			secS = sec.ToString();
			ms = (int)(ms - (sec*60));
			msS = ms.ToString();

			totalTime.GetComponent<Text>().text = (minS + ":" + secS+ ":" + msS);

			FinalScore.SetActive(true);
			FinalTime.SetActive(true);
			totalTime.SetActive(true);
			totalScore.SetActive(true);

			totalScore.GetComponent<Text>().text = score.ToString();

			finished = false;
			afterFinish = true;
		}
		if (afterFinish) {
			if (player.GetComponent<PlayerController>().eventSystem.currentSelectedGameObject == menuButton) {
				player.GetComponent<PlayerController>().eventSystem.SetSelectedGameObject(null);
				Application.Quit();
				//end the game
			}
		}
	}
}
