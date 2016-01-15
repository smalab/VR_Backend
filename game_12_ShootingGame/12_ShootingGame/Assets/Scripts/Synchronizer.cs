using UnityEngine;
using System.Collections;

public class Synchronizer : Photon.MonoBehaviour {
	
	public static string Sdiff;
	public static string ddiff;
	public static long oldTicks;
	public static long newTicks;
	public static long diff;

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
		if (stream.isWriting) {
			stream.SendNext (GetComponent<Transform>().position);
			stream.SendNext (GetComponent<Transform>().rotation);
			stream.SendNext (GetComponent<Rigidbody2D>().velocity);

			oldTicks = System.DateTime.Now.Ticks;
			PlayerPrefs.SetString ("datetime", oldTicks.ToString ());
			string dateString = PlayerPrefs.GetString ("datetime");
			oldTicks = System.Convert.ToInt64 (dateString);

			newTicks = System.DateTime.Now.Ticks;	
			diff = newTicks - oldTicks;
			ddiff = diff.ToString();
			diff = diff / 100;
			Sdiff = diff.ToString();

		} else {
			GetComponent<Transform>().position = (Vector3)stream.ReceiveNext ();
			transform.rotation = (Quaternion)stream.ReceiveNext ();
			GetComponent<Rigidbody2D>().velocity = (Vector2)stream.ReceiveNext ();
		}
	}
}