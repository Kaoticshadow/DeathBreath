﻿using UnityEngine;
using System.Collections;

public class Ax : MonoBehaviour {
	float lifetime = 5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		lifetime -= Time.deltaTime;
		if (lifetime < 0)
						Destroy (this.gameObject);
	}
}
