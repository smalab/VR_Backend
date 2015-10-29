using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	// Spaceshipコンポーネント
	Spaceship spaceship;
	int xMoveLimitMin = -4;
	int xMoveLimitMax = 4;
	int yMoveLimitMin = -3;
	int yMoveLimitMax = 3;
	
	IEnumerator Start ()
	{
		// Spaceshipコンポーネントを取得
		spaceship = GetComponent<Spaceship> ();
		
		while (true) {
			
			// 弾をプレイヤーと同じ位置/角度で作成
			spaceship.Shot (transform);
			
			// ショット音を鳴らす
			GetComponent<AudioSource>().Play();
			
			// shotDelay秒待つ
			yield return new WaitForSeconds (spaceship.shotDelay);
		}
	}
	
	void Update ()
	{
		// 移動
		Move ();

		// 移動制限
		MoveArea ();
		
	}

	// 機体の移動
	void Move (){

		// プレイヤーの座標を取得
		Vector2 pos = transform.position;
		Debug.Log ("posを取得");

		if(Input.GetKey("left")){
			// 代入したPositionに対して加算減算を行う
			pos.x -= 0.2f;
		}

		if(Input.GetKey("right")){ // 右キーを押し続けていたら
			// 代入したPositionに対して加算減算を行う
			pos.x += 0.2f;
		}

		if(Input.GetKey("up")){ // 右キーを押し続けていたら
			// 代入したPositionに対して加算減算を行う
			pos.y += 0.2f;
		}

		if(Input.GetKey("down")){ // 右キーを押し続けていたら
			// 代入したPositionに対して加算減算を行う
			pos.y -= 0.2f;
		}
		// 現在の位置に加算減算を行ったPositionを代入する
		transform.position = pos;

	}

	// 移動制限
	void MoveArea (){
		Vector2 pos = transform.position;
		pos.x = Mathf.Clamp (pos.x, xMoveLimitMin, xMoveLimitMax);
		pos.y = Mathf.Clamp (pos.y, yMoveLimitMin, yMoveLimitMax);
	}

	// ぶつかった瞬間に呼び出される
	void OnTriggerEnter2D (Collider2D c)
	{
		// レイヤー名を取得
		string layerName = LayerMask.LayerToName(c.gameObject.layer);
		
		// レイヤー名がBullet (Enemy)の時は弾を削除
		if( layerName == "Bullet (Enemy)")
		{
			// 弾の削除
			Destroy(c.gameObject);
		}

		// レイヤー名がBullet (Enemy)またはEnemyの場合は爆発
		if( layerName == "Bullet (Enemy)" || layerName == "Enemy")
		{
			// Managerコンポーネントをシーン内から探して取得し、GameOverメソッドを呼び出す
			FindObjectOfType<Manager>().GameOver();

			// 爆発する
			spaceship.Explosion();
		
			// プレイヤーを削除
			Destroy (gameObject);

		}
	}
}