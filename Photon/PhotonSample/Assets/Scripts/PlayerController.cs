using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float jumpPower = 300f;
	public float movePower = 10f;

	void Start () {
	}

	void Update () {
	
		float inputX = Input.GetAxis ("Horizontal");
		float inputY = Input.GetAxis ("Vertical");
		Vector2 force = new Vector2 (inputX, inputY) * movePower;
		rigidbody2D.AddForce (force);

		if (Input.GetButtonDown ("Jump")) {
			rigidbody2D.AddForce (Vector2.up * jumpPower);
		}
	}
}
