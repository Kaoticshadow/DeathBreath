﻿using UnityEngine;
using System.Collections;

public class smokeplacer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (Application.loadedLevelName == "Sky") {
			
			GameObject g = GameObject.FindGameObjectWithTag ("Level Center");
			this.transform.localPosition = g.transform.position+ new Vector3(1.4f, -2.7f, 0f);
			this.transform.parent = g.transform;
			
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
