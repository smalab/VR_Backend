using UnityEngine;
using System.Collections;

public class RightMove : MonoBehaviour {
	
	void Start () {
	}

	public void ButtonPush(){
		Debug.Log ("おされた");
		RMove ();
	}

	void Update(){

	}

	void RMove(){
		Vector2 pos = transform.position;
		pos.x += 0.2f;
		transform.position = pos;
	}
}
