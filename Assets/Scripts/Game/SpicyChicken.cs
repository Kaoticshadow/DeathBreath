using UnityEngine;
using System.Collections;

public class SpicyChicken : MonoBehaviour {

	public float duration = 10.0f;
	public float bonus = 0.2f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		duration -= Time.deltaTime;
		if (duration <= 0) {
			Destroy(this.gameObject);
		}	
	}

	void OnTriggerEnter2D(Collider2D coll) {
		Debug.Log ("Player entered SpicyChicken");
		if (coll.gameObject.tag == "Player") {
			coll.gameObject.SendMessage("addFireScale",bonus);
			Destroy(this.gameObject);
		}
	}
}
