using UnityEngine;
using System.Collections;

public class NetworkManager : Photon.MonoBehaviour {

	public GameObject player;
	public static int flag;
	public GameObject str = null;
	
	void Awake(){
		PhotonNetwork.ConnectUsingSettings ("v0.1");
		PlayerController.pflag = 2;
	}
	
	void Update () {	
	}

	void OnJoinedLobby(){
		PhotonNetwork.JoinRandomRoom ();
		flag = 1;
	}

	void OnPhotonRandomJoinFailed(){
		PhotonNetwork.CreateRoom (null);
		flag = 0;
	}

	void OnJoinedRoom(){
		Vector3 spawnPosition = new Vector3 (0, 2, 0);
		Vector3 CspawnPosition = new Vector3 (0, 0.0001f, -10);

		if (flag == 0) {
			var obj = PhotonNetwork.Instantiate ("PlayerPrefab", spawnPosition, Quaternion.identity, 0);
			obj.name = "PlayerPrefab1";
			flag = 1;

			var cam = PhotonNetwork.Instantiate ("MainCamera", CspawnPosition, Quaternion.identity, 0);
			cam.name = "MainCamera1";

			PlayerController.pflag = 1;
			CameraController.cflag = 1;
		} else {
			PlayerController.pflag = 0;
			CameraController.cflag = 0;
		}
	}

	void OnGUI(){
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString ());

		if (PlayerController.pflag == 1) {
			GUILayout.Label ("プレイヤーです。→または←キーで移動。AまたはDキーでカメラの移動が可能です。");
		} else if (PlayerController.pflag == 0) {
			GUILayout.Label ("観客機です。操作することができません。");
		} else if (PlayerController.pflag == 2) {
			GUILayout.Label ("待機中...");
		}
	}
}
