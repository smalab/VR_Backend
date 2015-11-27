using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour
{

	public int mainflag;
	public GameObject player;
	public GameObject MainCamera;
	public static Vector3 CspawnPosition = new Vector3 (0.0f, -1.5f, -4.0f);
	public static bool flag = false;

	// タイトル
	public GameObject title;

	void Awake(){
		PhotonNetwork.ConnectUsingSettings ("v0.1");
	}

	void OnJoinedLobby(){
		PhotonNetwork.JoinRandomRoom ();
		Debug.Log ("ロビー参加を確認しました");
	}

	void OnPhotonRandomJoinFailed(){
		Debug.Log ("ルームへの参加に失敗しました");
		PhotonNetwork.CreateRoom (null);
		mainflag = 0;
		Debug.Log ("mainflagを0にしました");
	}

	void OnJoinedRoom(){
		mainflag = 1;
		Debug.Log ("mainflagを1にしました");
		Player.pflag = 1;
		Debug.Log ("pflagを1にしました");

		title = GameObject.Find ("Title");
		Debug.Log ("titleを探しました");
		
		var cam = PhotonNetwork.Instantiate ("MainCamera", CspawnPosition, MainCamera.transform.rotation, 0);
		cam.name = "Camera";
		Debug.Log ("Cameraを生成しました");
		flag = false;
		Debug.Log ("flagをfalseにしました");
	}
	
	void Update ()
	{
		if (IsPlaying () == false && flag == true) {
			Application.LoadLevel("Stage");
		}

		// ゲーム中ではなく、Xキーが押されたらtrueを返す。
		if (IsPlaying () == false && Input.GetKeyDown (KeyCode.X)) {
			GameStart ();
			flag = true;
		}

	}
	
	void GameStart ()
	{
		// ゲームスタート時に、タイトルを非表示にしてプレイヤーを作成する
		title.SetActive (false);

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
	}
}