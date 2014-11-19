﻿using UnityEngine;
using System.Collections;

public class lightningFlash : MonoBehaviour {
	float flashcooldown = 5f;
	float flashaway = .2f;
	SpriteRenderer s;
	// Use this for initialization
	void Start () {
		s = this.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		flashcooldown -= Time.deltaTime;
		flashaway -= Time.deltaTime;
		if (flashcooldown <= 0) {
			flashcooldown = Random.Range(0,15f);
			s.color = new Color (1,1,1,0.75f);

			//play sound
				}

		if (flashaway <= 0) {
			flashaway = .2f;
			
			s.color = new Color (0,0,0,0);
				}
	}
}
