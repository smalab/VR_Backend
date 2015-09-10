using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float jumpPower = 300f;
	public float movePower = 10f;
	
	void Start () {
	}
	
	void Update () {
		if (GetComponent<PhotonView>().isMine) {
			float inputX = Input.GetAxis ("Horizontal");
			float inputY = Input.GetAxis ("Vertical");
			Vector2 force = new Vector2 (inputX, inputY) * movePower;
			GetComponent<Rigidbody2D> ().AddForce (force);
		
			if (Input.GetButtonDown ("Jump")) {
				GetComponent<Rigidbody2D> ().AddForce (Vector2.up * jumpPower);
			}
		}
	}
}
