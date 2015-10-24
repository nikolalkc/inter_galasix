using UnityEngine;
using System.Collections;

public class BulletLife : MonoBehaviour {
	public float bulletLife;


	void Start () {
		Invoke("DestroySelf", 1f);
		GetComponent<Rigidbody2D>().AddForce(transform.up * 300);
	}
	

	void DestroySelf() {
		PhotonNetwork.Destroy(gameObject);
	}
}
