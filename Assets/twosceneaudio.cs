using UnityEngine;
using System.Collections;

public class twosceneaudio : MonoBehaviour {
	bool changed = false;
	public GameObject c;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevelName == "throneroom"&&!changed){
			c = GameObject.FindGameObjectWithTag("MainCamera");
			changed = true;
			this.transform.parent = c.gameObject.transform;
		}
	//	this.transform.position = c.transform.position;
		if (Application.loadedLevelName == "final destination")
						Destroy (this.gameObject);
	}
}
