using UnityEngine;
using System.Collections;

public class bossmusic : MonoBehaviour {
	float counter = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		counter += Time.deltaTime;
		if(counter>87){
			this.GetComponent<AudioSource>().Play ();
			this.GetComponent<bossmusic>().enabled=false;

		}
	}
}
