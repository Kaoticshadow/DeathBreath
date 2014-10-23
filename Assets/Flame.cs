using UnityEngine;
using System.Collections;

public class Flame : MonoBehaviour {

	float lifetime = 1f;
	float counter = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		counter += Time.deltaTime;
		if (counter > lifetime)
						Destroy (this.gameObject);
	}
}
