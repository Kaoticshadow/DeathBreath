﻿using UnityEngine;
using System.Collections;

public class OdinWindSpawner : MonoBehaviour {

	public Animator odinAnimator;
	public GameObject spawnWind;
	public GameObject spawnTrigger;
	public GameObject spawnlightning;
	public float cooldownDuration = 1f;
	public int cycleFireballcount = 3;
	public bool hackupIgnoreFirstFireball = true;
	GameObject spawnedWind;
	int balls = 0;
	float cooldown = 0;
	bool firstshot = true;
	// Use this for initialization
	void Start () {
		odinAnimator = GameObject.Find ("Odin").GetComponent<Animator> ();
	
	}

	// Update is called once per frame
	void Update () {
		cooldown -= Time.deltaTime;
		//hackupIgnoreFirstFireball -= Time.deltaTime;

		//check animation state

		//if
		if (spawnTrigger.transform.position.x < this.transform.position.x && cooldown <= 0f && odinAnimator.GetCurrentAnimatorStateInfo(0).IsName("odin pew pew")) {

			if(hackupIgnoreFirstFireball && (balls % cycleFireballcount == 0) ){
				//hackupIgnoreFirstFireball = cycleDuration;
				cooldown = cooldownDuration;
			}
			else{
				float x = Random.Range(0f,1f);
				if(x<0.1f){				
					spawnedWind = Instantiate(spawnlightning,spawnTrigger.transform.position,Quaternion.identity) as GameObject;
					spawnedWind.GetComponent<Rigidbody2D>().AddForce(new Vector2(-600f,400f));
					//spawnedWind.rigidbody2D.AddTorque(-1000f);
				}
				else{
					spawnedWind = Instantiate(spawnWind,spawnTrigger.transform.position,Quaternion.identity) as GameObject;
					spawnedWind.GetComponent<Rigidbody2D>().AddForce(new Vector2(-600f,400f));
					spawnedWind.GetComponent<Rigidbody2D>().AddTorque(-1000f);
				}
				
				x = Random.Range(0f,1f);
				if(x<0.1f){				
					spawnedWind = Instantiate(spawnlightning,spawnTrigger.transform.position,Quaternion.identity) as GameObject;
					spawnedWind.GetComponent<Rigidbody2D>().AddForce(new Vector2(-600f,150f));
					//spawnedWind.rigidbody2D.AddTorque(-1000f);
				}
				else{
					spawnedWind = Instantiate(spawnWind,spawnTrigger.transform.position,Quaternion.identity) as GameObject;
					spawnedWind.GetComponent<Rigidbody2D>().AddForce(new Vector2(-600f,150f));
					spawnedWind.GetComponent<Rigidbody2D>().AddTorque(-1000f);
				}



				
				x = Random.Range(0f,1f);
				if(x<0.1f){				
					spawnedWind = Instantiate(spawnlightning,spawnTrigger.transform.position,Quaternion.identity) as GameObject;
					spawnedWind.GetComponent<Rigidbody2D>().AddForce(new Vector2(-600f,-100f));
					//spawnedWind.rigidbody2D.AddTorque(-1000f);
				}
				else{
					spawnedWind = Instantiate(spawnWind,spawnTrigger.transform.position,Quaternion.identity) as GameObject;
					spawnedWind.GetComponent<Rigidbody2D>().AddForce(new Vector2(-600f,-100f));
					spawnedWind.GetComponent<Rigidbody2D>().AddTorque(-1000f);
				}

				cooldown = cooldownDuration;
			}
			balls++;
		}
	}
}
