using UnityEngine;
using System.Collections;

public class Synchronizer : Photon.MonoBehaviour {

	private Vector3 receivePosition = Vector3.zero;
	private Quaternion receiveRotation = Quaternion.identity;
	private Vector2 receiveVelocity = Vector2.zero;

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
		if(stream.isWriting){

			stream.SendNext (GetComponent<Transform>().position);
			stream.SendNext (GetComponent<Transform>().rotation);
			stream.SendNext (GetComponent<Rigidbody2D>().velocity);
		}else{

			GetComponent<Transform>().position = (Vector3)stream.ReceiveNext ();
			GetComponent<Transform>().rotation = (Quaternion)stream.ReceiveNext ();
			GetComponent<Rigidbody2D>().velocity = (Vector2)stream.ReceiveNext ();
		}
	}

	void Update(){
		if (!GetComponent<PhotonView>().isMine) {
			GetComponent<Transform>().position = Vector3.Lerp (GetComponent<Transform>().position, receivePosition, Time.deltaTime * 10);
			GetComponent<Transform>().rotation = Quaternion.Lerp (GetComponent<Transform>().rotation, receiveRotation, Time.deltaTime * 10);
			GetComponent<Rigidbody2D>().velocity = Vector2.Lerp (GetComponent<Rigidbody2D>().velocity, receiveVelocity, Time.deltaTime * 10);
		}
	}
}
