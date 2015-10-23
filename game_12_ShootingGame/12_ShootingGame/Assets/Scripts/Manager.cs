﻿using UnityEngine;

public class Manager : MonoBehaviour
{
	// Playerプレハブ
	public GameObject player;
	public GameObject MainCamera;
	Vector3 CspawnPosition = new Vector3 (0, -2.5f, -2);


	public bool flag = false;

	// タイトル
	private GameObject title;
	
	void Start ()
	{
		// Titleゲームオブジェクトを検索し取得する
		title = GameObject.Find ("Title");

		flag = false;
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

		var obj = Instantiate (player, player.transform.position, player.transform.rotation);
		obj.name = "Player";

		var cam = Instantiate (MainCamera, CspawnPosition, Quaternion.identity);
		Debug.Log ("カメラを生成しました");
		cam.name = "MainCamera";
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
}