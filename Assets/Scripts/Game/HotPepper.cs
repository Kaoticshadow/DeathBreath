﻿using UnityEngine;
using System.Collections;

public class HotPepper : MonoBehaviour {

	public float duration = 10.0f;

	// Use this for initialization
	void Start () {	
	}
	
	// Update is called once per frame
	void Update () {
		duration -= Time.deltaTime;
		if (duration <= 0) {
			Destroy(this.gameObject);
		}	

	}

	void OnTriggerEnter2D(Collider2D coll) {
		Debug.Log ("Player entered HotPepper");
		if (coll.gameObject.tag == "Player") {
			coll.gameObject.SendMessage("addPepperLevel");
			Destroy(this.gameObject);
		}
	}
}
