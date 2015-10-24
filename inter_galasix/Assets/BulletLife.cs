using UnityEngine;
using System.Collections;

public class BulletLife : MonoBehaviour {
	public float bulletLife;


	void Start () {

		GetComponent<Rigidbody2D>().AddForce(transform.up * 300);
	}
	

	void DestroySelf() {
		Destroy(gameObject);
	}
}
