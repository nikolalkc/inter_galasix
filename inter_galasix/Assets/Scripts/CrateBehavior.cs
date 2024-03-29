﻿using UnityEngine;
using System.Collections;

public class CrateBehavior : MonoBehaviour {
	public static int pickedCrates;
	public float magnetic_distance, magnet_speed;
	GameObject closer_player = null;
	bool magnetActive = false;
	public bool cratePicked = false;
	bool crateCollected = false;
	Vector3 position;
	Quaternion rotation;
	Transform globalCollector;

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



		if ((distance < magnetic_distance || magnetActive) && !crateCollected) {
			if (magnetActive == false) {
				magnetActive = true;	
				pickedCrates +=1;
				cratePicked = true;
				//print("Picked Crates: " + pickedCrates);
			}
			transform.position = Vector3.Lerp(transform.position, closer_player.transform.position, magnet_speed * Time.deltaTime);
		}

		if (crateCollected) {
			if (transform.position != globalCollector.position)
			transform.position = Vector3.Lerp(transform.position, globalCollector.position, magnet_speed * 2 * Time.deltaTime);
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

	public void OnCrateCollected(Transform collector){
		crateCollected = true;
		globalCollector = collector;
		
	}




}
