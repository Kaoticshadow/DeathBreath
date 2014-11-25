using UnityEngine;
using System.Collections;

public class WindProjectile : MonoBehaviour {

	public bool destroyableByRainbow = false;
	float rainbowTimer = 0f;
	float rainbowLife = 0.07f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Player"){
			other.gameObject.rigidbody2D.AddForce(new Vector2(-1000f,0f));
			Destroy(this.gameObject);
		}
	}

	void HitByARainbow(float t){
		rainbowTimer += t;
		if (destroyableByRainbow && rainbowTimer > rainbowLife) {
			Destroy(this.gameObject);
		}
	}
	                
	                
}
