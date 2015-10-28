using UnityEngine;
using System.Collections;

public class RandomScaleRange : MonoBehaviour {
	public float min, max;
	// Use this for initialization
	void Start () {
		transform.localScale = Vector3.one * Random.RandomRange(min, max);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
