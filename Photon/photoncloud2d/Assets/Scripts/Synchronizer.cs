using UnityEngine;
using System.Collections;

public class Synchronizer : Photon.MonoBehaviour {
	
	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
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
