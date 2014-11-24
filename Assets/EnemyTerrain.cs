using UnityEngine;
using System.Collections;

public class EnemyTerrain : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D col){
		if(col.gameObject.tag == "Player"){
			col.gameObject.SendMessage("takeDamage");
		}
		Debug.Log ("you hit the wall. wow");
	}
	void OnTriggerEnter2D (Collider2D col){
		if(col.gameObject.tag == "Player"){
			col.gameObject.SendMessage("takeDamage");
		}
		Debug.Log ("you hit the wall. wow");
	}
}
