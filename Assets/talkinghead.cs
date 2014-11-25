﻿using UnityEngine;
using System.Collections;

public class talkinghead : MonoBehaviour {
	public TextMesh blurb;

	ArrayList texts;

	public float stringduration;
	float counter;
	public Vector3 destination;
	public float entryspeed;
	float startTime = 3f;
	int idx = 0;

	// Use this for initialization
	void Start () {
		blurb.text = "";
		texts = new ArrayList ();
		texts.Add ("Deathy!");
		texts.Add ("You've freed the souls...");
		texts.Add ("...of all the dragons Odin has enslaved!");	
		texts.Add("We will give you all of our power...");
		texts.Add ("...to defeat the lightning lord!");
		counter = stringduration;

	}
	
	// Update is called once per frame
	void Update () {
		startTime -= Time.deltaTime;
		this.transform.position = Vector3.Lerp (this.transform.position, destination, Time.deltaTime * entryspeed);
		if (startTime < 0) {
			blurb.text = (string)texts[idx];
			counter-=Time.deltaTime;
			if(counter<0){

				idx++;
				if(idx == texts.Count){
					Application.LoadLevel("Cutscene4");
					Destroy(this.gameObject);

				}
				counter = stringduration;
			}



		}
	}
}
