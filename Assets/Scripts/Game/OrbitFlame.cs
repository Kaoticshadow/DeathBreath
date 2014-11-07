using UnityEngine;
using System.Collections;

public class OrbitFlame : MonoBehaviour {

	public float height = 0.10f;
	public float speed = 4;
	float originalHeight;
	float counter;
	SpriteRenderer[] sprites;
	bool ascending;
	
	// Use this for initialization
	void Start () {
		originalHeight = this.transform.localPosition.y;	
		sprites = GetComponentsInChildren<SpriteRenderer>();
		ascending = true;
	}
	
	// Update is called once per frame
	void Update () {

		counter += Time.deltaTime * speed;
		this.transform.position = new Vector3 (this.transform.position.x, originalHeight + ((Mathf.Sin (counter))*height), 0);

		counter += Time.deltaTime * speed;
		if (Mathf.Sin (counter) > 0.9 && ascending) {
			ascending = false;
			foreach(SpriteRenderer sprite in sprites){
				sprite.sortingOrder = 0;
			}
		}
		if (Mathf.Sin (counter) < -0.9 && !ascending) {
			ascending = true;
			foreach(SpriteRenderer sprite in sprites){
				sprite.sortingOrder = 1;
			}
		}

		this.transform.position = new Vector3 (this.transform.position.x, originalHeight + ((Mathf.Sin (counter))*height), 0);	
	}
}

