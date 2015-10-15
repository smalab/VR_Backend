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

		Debug.Log ("判定を開始します");

		if (flag == 0) {
			var obj = PhotonNetwork.Instantiate ("PlayerPrefab", spawnPosition, Quaternion.identity, 0);
			obj.name = "PlayerPrefab1";
			flag = 1;
			Debug.Log ("flagを1にしました");

			PlayerController.pflag = 1;
			Debug.Log ("pflagを1にしました");
			CameraController.cflag = 1;
			Debug.Log ("cflagを1にしました");
			Debug.Log ("ゲーム機です!!プレイヤーの生成に成功しました!");
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
