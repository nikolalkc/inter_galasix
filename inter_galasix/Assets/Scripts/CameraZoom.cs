using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {

	public Camera cam;
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//cam.orthographicSize = Mathf.Lerp (camera.orthographicSize, 2.24f, 0.5f*Time.deltaTime);
		transform.position = Vector3.Lerp (transform.position, new Vector3 (transform.position.x,transform.position.y, -5f), 0.5f*Time.deltaTime);
	}
}
