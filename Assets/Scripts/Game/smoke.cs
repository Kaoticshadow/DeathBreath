using UnityEngine;
using System.Collections;

public class smoke : MonoBehaviour {
	float lifetime=3;
	float current=0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		current += Time.deltaTime;
		if (current > lifetime)
						Destroy (this.gameObject);
	}
}
