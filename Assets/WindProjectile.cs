using UnityEngine;
using System.Collections;

public class WindProjectile : MonoBehaviour {

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
	                
	                
}
