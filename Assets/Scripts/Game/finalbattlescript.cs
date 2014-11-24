using UnityEngine;
using System.Collections;

public class finalbattlescript : MonoBehaviour {
	
	float startTimer = 3f;
	public GameObject odin;
	bool odinstarted = false;
	// Use this for initialization
	void Start () {
		odin.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		startTimer -= Time.deltaTime;
		if (startTimer < 0 && !odinstarted) {
						odin.SetActive (true);
			odinstarted = true;
		}
	}
}
