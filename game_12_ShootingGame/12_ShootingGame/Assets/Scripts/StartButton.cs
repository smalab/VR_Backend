using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {

	public static int SB;

	// Use this for initialization
	void Start () {
		SB = 0;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void ButtonPush(){
		SB = 1;
	}
}
