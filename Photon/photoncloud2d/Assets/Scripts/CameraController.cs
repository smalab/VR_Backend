using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Vector3 SPEED = new Vector3(0.05f, 0.05f, 0);
	public static int cflag = 0;

	void Start () {
	}

	void Update () {
		if (cflag == 1) {
			CameraMove ();
		}
	}

	void CameraMove(){
		// 現在位置をPositionに代入
		Vector3 Position = transform.position;
		// 左キーを押し続けていたら
		if (Input.GetKey (KeyCode.A)) {
			// 代入したPositionに対して加算減算を行う
			Position.x -= SPEED.x;
		} else if (Input.GetKey (KeyCode.D)) { // 右キーを押し続けていたら
			// 代入したPositionに対して加算減算を行う
			Position.x += SPEED.x;
		}
		// 現在の位置に加算減算を行ったPositionを代入する
		transform.position = Position;
	}
}