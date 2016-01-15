using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {

	public static int SB;

	// Use this for initialization
	void Start () {
		SB = 0;
	}

	public void ButtonPush(){
		SB = 1;
	}
}
