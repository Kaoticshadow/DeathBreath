using UnityEngine;
using System.Collections;

public class MiniKnight : MonoBehaviour {
	float lifetime = 5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = this.transform.position + new Vector3 (Time.deltaTime*7, 0,0);
		lifetime= lifetime-Time.deltaTime;
		if (lifetime < 0)
						Destroy (this.gameObject);
	}
}
