using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	// 速度
	public Vector2 SPEED = new Vector2(0.05f, 0.05f);
	public static int pflag = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (pflag == 1) {
			PlayerMove ();
		}
	}
	
	// 移動関数
	void PlayerMove(){
		// 現在位置をPositionに代入
		Vector2 Position = transform.position;
		// 左キーを押し続けていたら
		if(Input.GetKey("left")){
			// 代入したPositionに対して加算減算を行う
			Position.x -= SPEED.x;
		} else if(Input.GetKey("right")){ // 右キーを押し続けていたら
			// 代入したPositionに対して加算減算を行う
			Position.x += SPEED.x;
		}
		// 現在の位置に加算減算を行ったPositionを代入する
		transform.position = Position;
	}
	
	
}