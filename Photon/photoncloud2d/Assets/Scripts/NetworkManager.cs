using UnityEngine;
using System.Collections;

public class NetworkManager : Photon.MonoBehaviour {

	public GameObject player;
	public static int flag;
	public GameObject str = null;
	
	void Awake(){
		PhotonNetwork.ConnectUsingSettings ("v0.1");
	}
	
	void Update () {	
	}

	void OnJoinedLobby(){
		PhotonNetwork.JoinRandomRoom ();
		flag = 1;
		Debug.Log ("ロビー参加を確認しました");
	}

	void OnPhotonRandomJoinFailed(){
		Debug.Log ("ルームへの参加に失敗しました");
		PhotonNetwork.CreateRoom (null);
		flag = 0;
		Debug.Log ("flagを0にしました");
	}

	void OnJoinedRoom(){
		Debug.Log ("ルームへの参加に成功しました");
		Vector3 spawnPosition = new Vector3 (0, 2, 0);
		Vector3 CspawnPosition = new Vector3 (0, 0.0001f, -10);

		Debug.Log ("判定を開始します");

		if (flag == 0) {
			var obj = PhotonNetwork.Instantiate ("PlayerPrefab", spawnPosition, Quaternion.identity, 0);
			obj.name = "PlayerPrefab1";
			Debug.Log ("プレイヤーを生成しました");
			flag = 1;
			Debug.Log ("flagを1にしました");

			var cam = PhotonNetwork.Instantiate ("MainCamera", CspawnPosition, Quaternion.identity, 0);
			Debug.Log ("カメラを生成しました");
			cam.name = "MainCamera1";
			Debug.Log ("カメラの名前変更に成功しました");

			PlayerController.pflag = 1;
			Debug.Log ("pflagを1にしました");
			CameraController.cflag = 1;
			Debug.Log ("cflagを1にしました");
			Debug.Log ("ゲーム機です!!操作することができます!");
		} else {
			PlayerController.pflag = 0;
			Debug.Log ("pflagを0にしました");
			CameraController.cflag = 0;
			Debug.Log ("cflagを0にしました");
			Debug.Log ("観客機です!!操作をすることができません!");
		}
	}

	void OnGUI(){
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString ());
	}
}
