using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour {
	Rigidbody2D rig;
	public float forceFactor, torqueFactor, forceBoost;
	public Transform direction;
	public float _doubleTapTimeLeft;
	public float _doubleTapTimeRight;


	void Start () {
		rig = GetComponent<Rigidbody2D>();
	}
	

	void Update () {
		//gas
		if (Input.GetAxis("Vertical") > 0) {

			rig.AddForce(transform.up * forceFactor * Time.deltaTime * Input.GetAxis("Vertical"));
		
		 }
		//rotiranje
		if (Input.GetAxis("Horizontal") != 0) {
			rig.AddTorque(Input.GetAxis("Horizontal") * torqueFactor * -1 * Time.deltaTime);
		}

		//nitro
		if (Input.GetKeyDown(KeyCode.Space)) {
			rig.AddForce(transform.up * forceBoost);
		}


		//tap Left
		bool doubleTapLeft = false;

		#region doubleTapLeft

		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			if (Time.time < _doubleTapTimeLeft + .3f) {
				doubleTapLeft = true;
			}
			_doubleTapTimeLeft = Time.time;
		}

		#endregion

		if (doubleTapLeft) {
			//Debug.Log("DoubleTapLeft");
			rig.AddForce(transform.right * -forceBoost);
		}



		//tap Right
		bool doubleTapRight = false;

		#region doubleTapRight

		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			if (Time.time < _doubleTapTimeRight + .3f) {
				doubleTapRight = true;
			}
			_doubleTapTimeRight = Time.time;
		}

		#endregion

		if (doubleTapRight) {
			//Debug.Log("DoubleTapRight");
			rig.AddForce(transform.right * forceBoost);
		}
	}
}
