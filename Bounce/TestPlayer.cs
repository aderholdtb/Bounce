using UnityEngine;
using System.Collections;

public class TestPlayer : MonoBehaviour {
	public float speed = 10f;
	
	void Update()
	{
		InputMovement();
	}
	
	void InputMovement()
	{
		if (Input.GetKey(KeyCode.W))
			rigidbody2D.MovePosition(rigidbody2D.position + Vector2.right * speed * Time.deltaTime);
		
		if (Input.GetKey(KeyCode.S))
			rigidbody2D.MovePosition(rigidbody2D.position - Vector2.right * speed * Time.deltaTime);
		
		if (Input.GetKey(KeyCode.D))
			rigidbody2D.MovePosition(rigidbody2D.position + Vector2.right * speed * Time.deltaTime);
		
		if (Input.GetKey(KeyCode.A))
			rigidbody2D.MovePosition(rigidbody2D.position - Vector2.right * speed * Time.deltaTime);
	}
}
