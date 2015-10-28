﻿using UnityEngine;
using System.Collections;

public class CollectCrates : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTriggerEnter2D (Collider2D col)
	{

		if (col.gameObject.tag == "Player") {
			foreach (GameObject crate in GameObject.FindGameObjectsWithTag("crate")) {
				CrateBehavior c = crate.GetComponent<CrateBehavior>();
				if (c.cratePicked){
					c.OnCrateCollected(gameObject.transform);

				}

			}
				
			
		}
	}


}
