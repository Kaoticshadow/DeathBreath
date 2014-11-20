using UnityEngine;
using System.Collections;

public class skyway : MonoBehaviour {
	public float maxHigh = 3.2f;
	public float maxLow = -3.2f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.W) && this.transform.position.y < maxHigh){
			this.transform.position += new Vector3(0,.1f,0);
		}
		if(Input.GetKey(KeyCode.S) && this.transform.position.y >maxLow){
			this.transform.position += new Vector3(0,-.1f,0);
		}
	}
}
