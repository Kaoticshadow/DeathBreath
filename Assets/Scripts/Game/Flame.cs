using UnityEngine;
using System.Collections;

public class Flame : MonoBehaviour {

	float lifetime = 1f;
	float counter = 0;
	public float power;
	public GameObject smoke;
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
		if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Destructable") {
				col.gameObject.SendMessage ("takeDamage", power);
				//create splosions
				GameObject x = (GameObject)Instantiate(smoke,this.transform.position,Quaternion.identity);
				x.renderer.sortingLayerName = "Middle_player";
				Destroy(this.gameObject);
		}
		if (col.gameObject.tag == "FireResist") {
			GameObject x = (GameObject)Instantiate(smoke,this.transform.position,Quaternion.identity);
			x.renderer.sortingLayerName = "Middle_player";
			Destroy(this.gameObject);
		}
	}
}
