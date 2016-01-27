using UnityEngine;
using System.Collections;

public class Synchronizer : Photon.MonoBehaviour {
	public static string ddiff;
	public static string Diff;
	public static long oldTicks;
	public static long newTicks;
	public static long diff;
	public static double diffrence;

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){

		oldTicks = System.DateTime.Now.Ticks;
		PlayerPrefs.SetString ("datetime", oldTicks.ToString ());
		string dateString = PlayerPrefs.GetString ("datetime");
		oldTicks = System.Convert.ToInt64 (dateString);
		
		newTicks = System.DateTime.Now.Ticks;	
		diff = newTicks - oldTicks;
		ddiff = diff.ToString();
		diffrence = (double) diff / 100000;
		Diff = diffrence.ToString();

		if (stream.isWriting) {
			stream.SendNext (GetComponent<Transform>().position);
			stream.SendNext (GetComponent<Transform>().rotation);
			stream.SendNext (GetComponent<Rigidbody2D>().velocity);
		} else {
			GetComponent<Transform>().position = (Vector3)stream.ReceiveNext ();
			transform.rotation = (Quaternion)stream.ReceiveNext ();
			GetComponent<Rigidbody2D>().velocity = (Vector2)stream.ReceiveNext ();
		}
	}
}