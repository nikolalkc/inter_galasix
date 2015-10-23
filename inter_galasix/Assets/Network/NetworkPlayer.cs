using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class NetworkPlayer : Photon.MonoBehaviour {

	bool isAlive = true;
	Vector3 position;
	Quaternion rotation;
	float lerpSmoothing = 5f;
	public GameObject cameraMain;
	void Start () {
		if (photonView.isMine) {
			GetComponent<ShipMovement>().enabled = true;
			Camera.main.GetComponent<Camera2DFollow>().target = transform;
		}
		else {
			StartCoroutine("Alive");
		}
	}

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
		if (stream.isWriting) {
			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);
		}
		else {
			position = (Vector3)stream.ReceiveNext();
			rotation = (Quaternion)stream.ReceiveNext();
		}
	}

	IEnumerator Alive() {
		while (isAlive) {
			transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * lerpSmoothing);
			transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * lerpSmoothing);

			yield return null;
		}
	}

}
