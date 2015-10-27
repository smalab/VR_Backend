using UnityEngine;
using System.Collections;

public class Cameracontrol : MonoBehaviour {

	void Start () {
		transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
	}
	
	void Update () {
			CameraMove ();
	}
	
	void CameraMove (){
		
		// プレイヤーの座標を取得
		Vector2 cpos = transform.position;
		
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
	
}