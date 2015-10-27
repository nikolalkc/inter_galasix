using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MissileTrajectory : MonoBehaviour {
	List<GameObject> player = new List<GameObject>();
	GameObject target_player;
	public float speedFactor;
	float randomSpeedVariation = 2;
	Rigidbody2D rig;

	void Start () {
		rig = GetComponent<Rigidbody2D>();

		//brzina rakete
		randomSpeedVariation = Random.Range(-randomSpeedVariation, randomSpeedVariation);
		speedFactor += randomSpeedVariation;

		//izbor random igraca kojeg ce raketa da prati
		foreach (GameObject element in GameObject.FindGameObjectsWithTag("Player")) {
			player.Add(element);
		}


		if (player.Count > 0) {
			int random_index = Random.Range(0, player.Count);
			target_player = player[random_index];
		}
		
	}

	void FixedUpdate () {
		//prati igraca
		if (target_player) {
			Vector3 dir = target_player.transform.position - transform.position;
			float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			rig.velocity = transform.right * speedFactor;

			
		}
	
	}
}
