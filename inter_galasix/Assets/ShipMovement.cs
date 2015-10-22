using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour {
	Rigidbody2D rig;
	public float forceFactor, torqueFactor;
	public Transform direction;


	void Start () {
		rig = GetComponent<Rigidbody2D>();
	}
	

	void Update () {
		if (Input.GetAxis("Vertical") > 0) {

			rig.AddForce(transform.up * forceFactor * Time.deltaTime * Input.GetAxis("Vertical"));
		
		 }

		if (Input.GetAxis("Horizontal") != 0) {
			rig.AddTorque(Input.GetAxis("Horizontal") * torqueFactor * -1 * Time.deltaTime);
		}

	}
}
