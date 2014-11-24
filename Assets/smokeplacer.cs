using UnityEngine;
using System.Collections;

public class smokeplacer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (Application.loadedLevelName == "Sky") {
			
			GameObject g = GameObject.FindGameObjectWithTag ("Level Center");
			this.transform.parent = g.transform;
			this.transform.localPosition = g.transform.position + new Vector3(4f, -3.9f, 0f);
			
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
