using UnityEngine;
using System.Collections;

public class CrateBehavior : MonoBehaviour {
	public float magnetic_distance, magnet_speed;
	GameObject closer_player = null;
	bool magnetActive = false;
	Vector3 position;
	Quaternion rotation;

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			PhotonNetwork.Destroy(gameObject);
		}
	}

	void Start() {
		Physics2D.IgnoreLayerCollision(0, 8);
		position = transform.position;
		rotation = transform.rotation;
	}


	void FixedUpdate() {
		float distance = Mathf.Infinity;


		foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player")) {
			float current_distance = Vector3.SqrMagnitude(transform.position - player.transform.position);
			if (current_distance < distance) {
				distance = current_distance;
				closer_player = player;
			}
		}



		if (distance < magnetic_distance || magnetActive) {
			if (magnetActive == false) {
				magnetActive = true;	
			}
			transform.position = Vector3.Lerp(transform.position, closer_player.transform.position, magnet_speed * Time.deltaTime);
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
}
