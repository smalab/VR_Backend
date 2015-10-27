using UnityEngine;
using System.Collections;

//
// カメラの四隅を取得する。
// カメラにアタッチ
//
[RequireComponent(typeof(Camera))]
public class TransformViewportToWorld : MonoBehaviour {
	
	Vector3 lb, rt, lt, rb;
	public Transform center; // 四隅の深さを設定する用のオブジェクト
	
	void Update () 
	{
		var distance = Vector3.Distance(transform.position, center.position);
		lb = GetComponent<Camera>().ViewportToWorldPoint( new Vector3(0, 0, distance));
		rt = GetComponent<Camera>().ViewportToWorldPoint( new Vector3(1, 1, distance));
		lt = new Vector3( lb.x, rt.y, lb.z);
		rb = new Vector3( rt.x, lb.y, rt.z);
	}

	void OnDrawGizmos()
	{
		Gizmos.DrawSphere(lb, 0.3f);
		Gizmos.DrawSphere(rt, 0.3f);
		Gizmos.DrawSphere(rb, 0.3f);
		Gizmos.DrawSphere(lt, 0.3f);
	}
}
