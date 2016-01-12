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
	public static string LagTime;
	public static string parenttime;
	public static long diff;
	public static string Sdiff;

	// タイトル
	public GameObject title;

	void Awake(){
		PhotonNetwork.ConnectUsingSettings ("v0.1");

	}

	void OnJoinedLobby(){
		PhotonNetwork.JoinRandomRoom ();
		mainflag = 1;
	}

	void OnPhotonRandomJoinFailed(){
		PhotonNetwork.CreateRoom (null);
		mainflag = 0;
	}

	void OnJoinedRoom(){
		if (mainflag == 0) {
			title = GameObject.Find ("Title");

			Player.pflag = 1;
			Cameracontrol.cflag = 1;
		
			var cam = PhotonNetwork.Instantiate ("MainCamera", CspawnPosition, MainCamera.transform.rotation, 0);
			cam.name = "Camera";
			flag = false;
		} else {
		}
	}
	
	void Update (){
		if (IsPlaying () == false && flag == true) {
			Application.LoadLevel ("Stage");
		}

		if (IsPlaying () == false && StartButton.SB == 1 ) {
			GameStart ();
			flag = true;
			StartButton.SB = 0;
		}

		parenttime = PhotonNetwork.time.ToString ();

		long oldTicks = System.DateTime.Now.Ticks;
		PlayerPrefs.SetString ("datetime", oldTicks.ToString ());
		string dateString = PlayerPrefs.GetString ("datetime");
		oldTicks = System.Convert.ToInt64 (dateString);
		long newTicks = System.DateTime.Now.Ticks;
		diff = ((newTicks - oldTicks) / (1000 * 1000 * 10));
		Sdiff = diff.ToString();

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
		GUILayout.Space (20);
		GUILayout.Label ("Photon時間  " + PhotonNetwork.time.ToString());
		GUILayout.Label ("プレイヤー機移動時間  " + Player.pushtime);
		GUILayout.Label ("観客機移動時間  " + Cameracontrol.cctime);
		GUILayout.Label (Sdiff);
	}
}