using UnityEngine;
using System.Collections;

//
// GUIText（もしくはGUITexture）が対象のオブジェクトの上に来るようにする
// カメラにアタッチ
//
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class TransformWorldToScreen : MonoBehaviour {
	
	public Transform target; // 対象のオブジェクト
	public Transform gui; // GUITextureもしくはGUIText
	
	void Update () 
	{
		if( gui == null || target == null )
			return;
		
		gui.position = GetComponent<Camera>().WorldToViewportPoint(target.position);
	}
}