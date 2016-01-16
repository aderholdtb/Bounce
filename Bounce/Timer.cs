using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	public string timedis;
	private float sec;
	private int min;
	private float ms;
	string msS;
	string secS;
	string minS;
	public GameObject text;
	public bool startime = false;
	const float startTime = 3f;
	public onStart starter;

	void Start() 
	{
		sec = 0;
		min = 0;
	}
	void Update () 
	{   
		if (starter.start == true) {
						if (gameObject.GetComponent<Finish> ().finished == true) {
								text.SetActive (false);
								Destroy (this);
						}
						if (startTime + starter.onStartTime < Time.time)
								startime = true;
						//Count time only whent this is true
						if (startime == true) {
								//Adding seconds
								//sec += Time.deltaTime;
								ms += (float)Time.deltaTime * 60;

								//Adding minutes
								if (Mathf.Floor (ms) >= 60) {
										ms = 0; 
										sec = sec + 1;
								}
								if (Mathf.Floor (sec) >= 60) {
										sec = 0; 
										min = min + 1;
								}

								msS = Mathf.Floor (ms).ToString ();
								//Display time
								if (msS.Length < 2)
										msS = "0" + msS;

								secS = Mathf.Floor (sec).ToString ();
								//Display time
								if (secS.Length < 2)
										secS = "0" + secS;

								minS = min.ToString ();
								//Display time
								if (minS.Length < 2)
										minS = "0" + minS;

								timedis = (minS + ":" + secS + ":" + msS);
								text.GetComponent<Text> ().text = timedis;
						}
				}
	}
}
