using UnityEngine;
using System.Collections;

public class Flame : MonoBehaviour {

	float lifetime = 1f;
	float counter = 0;
	public float power;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		counter += Time.deltaTime;
		if (counter > lifetime)
						Destroy (this.gameObject);
	}

	void OnTriggerEnter2D (Collider2D col){
		if (col.gameObject.tag == "Enemy") {
				col.gameObject.SendMessage ("takeDamage", power);
				//create splosions
				Destroy(this.gameObject);
		}
	}
}
