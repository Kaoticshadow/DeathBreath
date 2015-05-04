using UnityEngine;
using System.Collections;

public class cutefire : MonoBehaviour {

	public float lifetime = 5f;
	// Use this for initialization
	void Start () {
		this.GetComponent<Rigidbody2D>().AddTorque (Random.Range (2000f, 5000f));
	
	}
	
	// Update is called once per frame
	void Update () {
		lifetime -= Time.deltaTime;
		if (lifetime <= 0) {
			Destroy(this.gameObject);
		}
	
	}
}
