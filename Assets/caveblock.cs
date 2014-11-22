using UnityEngine;
using System.Collections;

public class caveblock : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D col){
		if(col.gameObject.tag == "Player"){
			col.rigidbody.AddForce(new Vector2(0f,-col.transform.position.y/col.transform.position.y * 250f));
		}
		Debug.Log ("you hit the wall. wow");
	}
}
