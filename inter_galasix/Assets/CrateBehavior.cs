using UnityEngine;
using System.Collections;

public class CrateBehavior : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			PhotonNetwork.Destroy(gameObject);
		}
	}
}
