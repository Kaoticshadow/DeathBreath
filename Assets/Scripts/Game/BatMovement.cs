﻿using UnityEngine;
using System.Collections;

public class BatMovement : MonoBehaviour {

	Transform m_t;
	float amplitude;
	float frequency;
	public float speed = -0.04f;



	// Use this for initialization
	void Start () {
	
		amplitude = Random.Range (0.5f, 1.0f);//1.5f;
		frequency = Random.Range (0.5f, 2.0f);//1.0f
		m_t = this.transform;
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z) + amplitude*(Mathf.Sin(2*Mathf.PI*frequency*Time.time) - Mathf.Sin(2*Mathf.PI*frequency*(Time.time - Time.deltaTime)))*transform.up;


	}
}
