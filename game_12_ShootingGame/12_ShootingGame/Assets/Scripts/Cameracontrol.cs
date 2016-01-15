using UnityEngine;
using System.Collections;

public class Cameracontrol : MonoBehaviour {
	
	int xMoveLimitMax = 4;
	int xMoveLimitMin = -4;
	int yMoveLimitMax = 3;
	int yMoveLimitMin = -3;
	public static int cflag;
	public static bool cpush = false;

	void Start () {
	}

	public void PushDown(){
		cpush = true;
	}
	
	public void PushUp(){
		cpush = false;
	}

	void Update () {
		if (Manager.flag == true) {
			if (cflag == 1) {
				if (cpush == true) {
					CameraMove ();
				}
			}
		}
				CameraMoveArea ();
	}
	
	void CameraMove (){
		
		// カメラの座標を取得
		Vector3 cpos = transform.position;
		
		cpos.x += 0.1f;
		// 現在の位置に加算減算を行ったPositionを代入する
		transform.position = cpos;
		
	}

	void CameraMoveArea(){
		Vector3 cpos = transform.position;
		cpos.x = Mathf.Clamp (cpos.x, xMoveLimitMin, xMoveLimitMax);
		cpos.y = Mathf.Clamp (cpos.y, yMoveLimitMin, yMoveLimitMax);
		transform.position = cpos;
	}

}