using UnityEngine;
using System.Collections;

public class Synchronizer : Photon.MonoBehaviour {

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
		if(stream.isWriting){

			stream.SendNext (Transform.position);
			stream.SendNext (Transform.rotation);
			stream.SendNext (Rigidbody2D.velocity);
		}else{

			Transform.position = (Vector3)stream.ReceiveNext ();
			Transform.rotation = (Quaternion)stream.ReceiveNext ();
			Rigidbody2D.velocity = (Vector2)stream.ReceiveNext ();
		}
	}
}
