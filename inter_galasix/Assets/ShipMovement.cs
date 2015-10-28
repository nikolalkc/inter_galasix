using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class ShipMovement : MonoBehaviour {
	Rigidbody2D rig;
	public float forceFactor, torqueFactor, forceBoost;
	public Transform direction;
	public float _doubleTapTimeUp;
	public float _doubleTapTimeRight;
	public float zoomout_FOV;
	float original_FOV;
	public GameObject bullet;
	public Transform bulletSpawnPoint;
	Camera pov;
	Camera main;
	bool fps = false;
	//zoomout preko pomeranja kamere po z osi
		//Vector3 original_camera_position = new Vector3();
		//Vector3 zoomout_position = new Vector3();
		//Camera2DFollow camera2DFollow;
		//bool new_zoomout_position_set = false;

	void Start () {
		main = Camera.main;
		original_FOV = Camera.main.fieldOfView;
		rig = GetComponent<Rigidbody2D>();
		pov = GetComponentInChildren<Camera>();
		//zoomout preko pomeranja kamere po z osi
			//original_camera_position = Camera.main.transform.position;
			//zoomout_position = original_camera_position + new Vector3(0, 0, -30);
			//camera2DFollow = Camera.main.GetComponent<Camera2DFollow>();
		
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

		//pucanje
		if (Input.GetButtonDown("Fire")) {
			PhotonNetwork.Instantiate("bullet", bulletSpawnPoint.position, transform.rotation,0);
			
		}

		//ukljuci pov
		if (Input.GetKeyDown(KeyCode.C)) {
			pov.enabled=true;
			main.enabled = false;
			fps = true;
		}
		//iskljuci pov
		if (Input.GetKeyUp(KeyCode.C)) {
			pov.enabled = false;
			main.enabled=true;
			fps = false;
		}



		////tap Left
		//bool doubleTapLeft = false;

		//#region doubleTapLeft

		//if (Input.GetKeyDown(KeyCode.LeftArrow)) {
		//	if (Time.time < _doubleTapTimeLeft + .3f) {
		//		doubleTapLeft = true;
		//	}
		//	_doubleTapTimeLeft = Time.time;
		//}

		//#endregion

		//if (doubleTapLeft) {
		//	//Debug.Log("DoubleTapLeft");
		//	rig.AddForce(transform.right * -forceBoost);
		//}



		////tap Right
		//bool doubleTapRight = false;

		//#region doubleTapRight

		//if (Input.GetKeyDown(KeyCode.RightArrow)) {
		//	if (Time.time < _doubleTapTimeRight + .3f) {
		//		doubleTapRight = true;
		//	}
		//	_doubleTapTimeRight = Time.time;
		//}

		//#endregion

		//if (doubleTapRight) {
		//	//Debug.Log("DoubleTapRight");
		//	rig.AddForce(transform.right * forceBoost);
		//}




		//nitro
		//rig.AddForce(transform.up * forceBoost);

		bool doubleTapUp = false;

		#region doubleTapRight

		if (Input.GetButton("Boost")) {
			if (Time.time < _doubleTapTimeUp + .3f) {
				doubleTapUp = true;
			}
			_doubleTapTimeUp = Time.time;
		}

		#endregion

		if (doubleTapUp) {
			rig.AddForce(transform.up * forceBoost);
		}


		
		//zoomout preko pomeranja kamere po z osi
			//if (Input.GetKey(KeyCode.LeftShift)) {

			//	if (!new_zoomout_position_set) {
			//		zoomout_position = Camera.main.transform.position + new Vector3(0, 0, -30);
			//		new_zoomout_position_set = true;
			//	}

			//	camera2DFollow.enabled = false;
			//	Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position,
			//												  zoomout_position,
			//												  5 * Time.deltaTime);
			//}
			//else {
			//	camera2DFollow.enabled = true;
			//	new_zoomout_position_set = false;
			//}


		//zoomout preko FOV 
		if (!fps) {
			Camera camera = Camera.main;
			if (Input.GetButton("Zoomout")) {
				camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, zoomout_FOV, 5 * Time.deltaTime);
			}
			else {
				camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, original_FOV, 5 * Time.deltaTime);
			}
		}




	}


}
