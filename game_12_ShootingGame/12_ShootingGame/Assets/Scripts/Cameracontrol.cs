using UnityEngine;
using System.Collections;

public class Cameracontrol : MonoBehaviour {

	int xMoveLimitMin = -4;
	int xMoveLimitMax = 4;
	int yMoveLimitMin = -3;
	int yMoveLimitMax = 3;

	void Start () {
	}
	
	void Update () {
		CameraMove ();
		CameraMoveArea ();
	}
	
	void CameraMove (){
		
		// カメラの座標を取得
		Vector3 cpos = transform.position;
		
		if(Input.GetKey("left")){
			// 代入したPositionに対して加算減算を行う
			cpos.x -= 0.2f;
		}

		if(Input.GetKey("right")){ // 右キーを押し続けていたら
			// 代入したPositionに対して加算減算を行う
			cpos.x += 0.2f;
		}
		
		if(Input.GetKey("up")){ // 右キーを押し続けていたら
			// 代入したPositionに対して加算減算を行う
			cpos.y += 0.2f;
		}
		
		if(Input.GetKey("down")){ // 右キーを押し続けていたら
			// 代入したPositionに対して加算減算を行う
			cpos.y -= 0.2f;
		}
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