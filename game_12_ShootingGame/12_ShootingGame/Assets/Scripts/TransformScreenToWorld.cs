using UnityEngine;
using System.Collections;

//
// マウスの座標をオブジェクトが追跡する。
// カメラにアタッチ
//
[RequireComponent(typeof(Camera))]
public class TransformScreenToWorld : MonoBehaviour {
	
	public Transform target; // 追跡させるオブジェクト
	public Transform center; // targetとカメラの距離を設定する用のオブジェクト
	
	void Update () 
	{
		if( target == null )
			return;
		
		var pos = Vector3.forward * Vector3.Distance(transform.position, center.position);
		target.position = GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition + pos);
	}
}