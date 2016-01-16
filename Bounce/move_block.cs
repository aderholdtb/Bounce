using UnityEngine;
using System.Collections;

public class move_block : MonoBehaviour {
	float startx, endPosOffset;
	public float offset = 2;
	public bool backing = true;
	public float vel = 1;
	// Use this for initialization
	void Start () {
		if (backing == false) {
			startx = transform.position.x;
			endPosOffset = startx + offset;
		} else {
			startx = transform.position.x + offset;
			transform.position = new Vector2(startx, transform.position.y);
			endPosOffset = startx;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x > endPosOffset)
			backing = true;
		else if (transform.position.x < startx)
			backing = false;
		
		if (backing == false){
			transform.position += new Vector3((vel * Time.deltaTime), 0, 0);
		}
		else{
			transform.position -= new Vector3((vel * Time.deltaTime), 0, 0);
		}
	}
}

