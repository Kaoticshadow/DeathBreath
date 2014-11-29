using UnityEngine;
using System.Collections;

public class xwisedeath : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.x < -78)
						Destroy (this.gameObject);
	}
}
