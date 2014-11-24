using UnityEngine;
using System.Collections;

public class soundDelay : MonoBehaviour {
	public float timer;
	bool played = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer < 0 && !played) {
			played = true;
			this.gameObject.GetComponent<AudioSource>().Play();

				}
	}
}
