using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	float xMargin = -250f;		// Distance in the x axis the player can move before the camera follows.
	float yMargin = 1f;		// Distance in the y axis the player can move before the camera follows.
	float xSmooth = 3f;		// How smoothly the camera catches up with it's target movement in the x axis.
	float ySmooth = .1f;		// How smoothly the camera catches up with it's target movement in the y axis.
	public Vector2 maxXAndY = new Vector2(1000f, 10f);		// The maximum x and y coordinates the camera can have.
	Vector2 minXAndY = new Vector2(3.306663f, 2f);		// The minimum x and y coordinates the camera can have.
	//float offsetz = 1.39f;
	float offset = .1f;
	
	private Transform player;		// Reference to the player's transform.
	
	
	void Awake ()
	{
		// Setting up the reference.
		player = GameObject.FindGameObjectWithTag("Player").transform;
		transform.position = new Vector3(3.306663f, 2.039025f, -3.89f);
	}
	
	
	bool CheckXMargin()
	{
		// Returns true if the distance between the camera and the player in the x axis is greater than the x margin.
		return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
	}
	
	
	bool CheckYMargin()
	{
		// Returns true if the distance between the camera and the player in the y axis is greater than the y margin.
		return Mathf.Abs(transform.position.y - player.position.y) > yMargin;
	}
	
	
	void FixedUpdate ()
	{
		TrackPlayer();
	}
	
	
	void TrackPlayer ()
	{
		// By default the target x and y coordinates of the camera are it's current x and y coordinates.
		float targetX = transform.position.x;
		float targetY = transform.position.y;
		
		// If the player has moved beyond the x margin...
		if(CheckXMargin())
			// ... the target x coordinate should be a Lerp between the camera's current x position and the player's current x position.
			targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.deltaTime);
		
		// If the player has moved beyond the y margin...
		if(CheckYMargin())
			// ... the target y coordinate should be a Lerp between the camera's current y position and the player's current y position.
			targetY = Mathf.Lerp(transform.position.y, player.position.y, ySmooth * Time.deltaTime);
		
		// The target x and y coordinates should not be larger than the maximum or smaller than the minimum.
		targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
		targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);
		
		// Set the camera's position to the target position with the same z component.
		transform.position = new Vector3(targetX + offset, targetY, transform.position.z);
	}
}
