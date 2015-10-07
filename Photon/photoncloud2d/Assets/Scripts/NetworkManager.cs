using UnityEngine;
using System.Collections;

public class NetworkManager : Photon.MonoBehaviour {

	public GameObject player;
	public int flag = 0;
	public GameObject str = null;
	
	void Awake(){
		PhotonNetwork.ConnectUsingSettings ("v0.1");
	}
	
	void Update () {	
	}

	void OnJoinedLobby(){
		PhotonNetwork.JoinRandomRoom ();
	}

	void OnPhotonRandomJoinFailed(){
		Debug.Log ("ルームへの参加に失敗しました");
		PhotonNetwork.CreateRoom (null);
	}

	void OnJoinedRoom(){
		Debug.Log ("ルームへの参加に成功しました");
		Vector3 spawnPosition = new Vector3 (0, 2, 0);

		if(str == GameObject.Find ("PlayerPrefab1")){
			flag = 1;
		}

		if (flag == 0) {
			var obj = PhotonNetwork.Instantiate ("PlayerPrefab", spawnPosition, Quaternion.identity, 0);
			obj.name = "PlayerPrefab1";
			Debug.Log ("ゲーム機です!!プレイヤーの生成に成功しました!");
			flag = 1;
		} else {
			Debug.Log ("観客機です!!");
		}
	}

	void OnGUI(){
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString ());
	}
}
