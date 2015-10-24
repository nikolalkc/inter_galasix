﻿using UnityEngine;
using System.Collections;

public class RotateSelf : MonoBehaviour {
	public float rotateFactor = 2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up * rotateFactor * Time.deltaTime);
	}
}
