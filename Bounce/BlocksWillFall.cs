using UnityEngine;
using System.Collections;

public class BlocksWillFall : MonoBehaviour {
	public float fallTime = 100000000000;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (Time.time);
		if (fallTime < Time.time) {
			rigidbody2D.isKinematic = false;
		}
	}
}
