using UnityEngine;
using System.Collections;

public class RotateSelf : MonoBehaviour {
	public float rotateFactor = 2;
	public Vector3 direction = Vector3.up;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(direction * rotateFactor * Time.deltaTime);
	}
}
