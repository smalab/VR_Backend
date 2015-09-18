using UnityEngine;
using System.Collections;

public class NetworkManager : Photon.MonoBehaviour {
	
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
	}

	void OnGUI(){
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString ());
	}
}
