﻿using UnityEngine;
using System.Collections;

public class RotateSelf : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up * 2 * Time.deltaTime);
	}
}
