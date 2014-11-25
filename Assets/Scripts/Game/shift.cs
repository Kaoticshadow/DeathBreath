using UnityEngine;
using System.Collections;

public class shift : MonoBehaviour {
	float countdown = 13;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		countdown -= Time.deltaTime;
		if (countdown < 0) {
			this.GetComponent<ParticleSystem>().startLifetime = 5;
		}
	}
}
