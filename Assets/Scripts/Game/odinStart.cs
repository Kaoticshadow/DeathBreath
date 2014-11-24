using UnityEngine;
using System.Collections;

public class odinStart : MonoBehaviour {

	float startTimer = 6f;

	// Use this for initialization
	void Start () {
		this.GetComponent<SinHeight> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		startTimer -= Time.deltaTime;

		if (startTimer < 0) {
			this.GetComponent<SinHeight> ().enabled = true;
			
			this.GetComponent<odinStart> ().enabled = false;

				}
	}
}
