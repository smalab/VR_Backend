using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour
{

	public static int mainflag;
	public GameObject player;
	public GameObject MainCamera;
	public static Vector3 CspawnPosition = new Vector3 (0.0f, -1.5f, -4.0f);
	public static Vector3 PspawnPosition = new Vector3 (0.0f, -1.5f, 0.0f);
	public static bool flag = false;

	// タイトル
	public GameObject title;

	void Awake(){
		PhotonNetwork.ConnectUsingSettings ("v0.1");
	}

	void OnJoinedLobby(){
		PhotonNetwork.JoinRandomRoom ();
		Debug.Log ("ロビー参加を確認しました");
		mainflag = 1;
	}

	void OnPhotonRandomJoinFailed(){
		Debug.Log ("ルームへの参加に失敗しました");
		PhotonNetwork.CreateRoom (null);
		mainflag = 0;
		Debug.Log ("mainflagを0にしました");
	}

	void OnJoinedRoom(){
		if (mainflag == 0) {
			title = GameObject.Find ("Title");
			Debug.Log ("titleを探しました");

			Player.pflag = 1;
			Cameracontrol.cflag = 1;
		
			var cam = PhotonNetwork.Instantiate ("MainCamera", CspawnPosition, MainCamera.transform.rotation, 0);
			cam.name = "Camera";
			Debug.Log ("Cameraを生成しました");
			flag = false;
			Debug.Log ("flagをfalseにしました");
		} else {
		}
	}
	
	void Update ()
	{
		if (IsPlaying () == false && flag == true) {
			Application.LoadLevel("Stage");
		}

		if (IsPlaying () == false && StartButton.SB == 1) {
			GameStart ();
			flag = true;
			StartButton.SB = 0;
		}

	}
	
	void GameStart ()
	{
		// ゲームスタート時に、タイトルを非表示にしてプレイヤーを作成する
		title.SetActive (false);

		if (mainflag == 0) {
			var ply = PhotonNetwork.Instantiate ("Player", PspawnPosition, Quaternion.identity, 0);
			ply.name = "PlayeR";
		}

	}
	
	public void GameOver ()
	{
		FindObjectOfType<Score>().Save();
		// ゲームオーバー時に、タイトルを表示する
		title.SetActive (true);
	}
	
	public bool IsPlaying ()
	{
		// ゲーム中かどうかはタイトルの表示/非表示で判断する
		return title.activeSelf == false;
	}

	void OnGUI(){
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString ());
		if (mainflag == 0) {
			GUILayout.Label ("プレイヤー機です!操作できます!");
		} else if (mainflag == 1) {
			GUILayout.Label ("観客機です!操作できません!");
		}
	}
}