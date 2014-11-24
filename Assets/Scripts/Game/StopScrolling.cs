using UnityEngine;
using System.Collections;

public class StopScrolling : MonoBehaviour {

	public float scrollingStopSpeed = 1f;
	bool triggered;
	public bool timeTriggered;
	public float triggerTime;
	public bool playerLocationTriggered;
	public bool thisLocationTriggered;
	public float thisXtrigger;
	GameObject player;
	float timer;

	// Use this for initialization
	void Start () {
		triggered = false;
		player = GameObject.FindGameObjectWithTag("Player");
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(!timeTriggered && !triggered && player.transform.position.x > this.transform.position.x){
			GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>().setScrollingSpeed(0f,scrollingStopSpeed);
			triggered = true;
		}
		else if(timeTriggered && !triggered && timer > triggerTime){
			GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>().setScrollingSpeed(0f,scrollingStopSpeed);
			triggered = true;
		}
		else if(thisLocationTriggered && !triggered && this.transform.position.x <= thisXtrigger){
			GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>().setScrollingSpeed(0f,scrollingStopSpeed);
			triggered = true;
		}
	}
}
