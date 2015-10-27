using UnityEngine;
using System.Collections;

public class CrateBehavior : MonoBehaviour {
	public float magnetic_distance, magnet_speed;
	GameObject closer_player = null;
	bool magnetActive = false;

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			PhotonNetwork.Destroy(gameObject);
		}
	}

	void Start() {
		Physics2D.IgnoreLayerCollision(0, 8);
	}


	void FixedUpdate() {
		float distance = Mathf.Infinity;


		foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player")) {
			float current_distance = (transform.position - player.transform.position).sqrMagnitude;
			if (current_distance < distance) {
				distance = current_distance;
				closer_player = player;
			}
		}



		if ((distance < magnetic_distance && closer_player) || magnetActive) {
			magnetActive = true;
			transform.position = Vector3.Lerp(transform.position, closer_player.transform.position, magnet_speed * Time.deltaTime);
		}
	}
}
