using UnityEngine;
using System.Collections;

public class NetworkManager : Photon.MonoBehaviour {

	public GameObject player;
	
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
		var obj = PhotonNetwork.Instantiate ("PlayerPrefab", spawnPosition , Quaternion.identity, 0);
		obj.name = "PlayerPrefab";
	}

	void OnGUI(){
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString ());
	}
}
