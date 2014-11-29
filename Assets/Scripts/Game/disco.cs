using UnityEngine;
using System.Collections;

public class disco : MonoBehaviour {
	float r, g, b;
	SpriteRenderer s;
	// Use this for initialization
	void Start () {
		r = g = b = 0;
		s = this.GetComponent<SpriteRenderer> ();
		//this.rigidbody2D.angularVelocity = Random.Range(550,600);// (-300f);
	}
	
	// Update is called once per frame
	void Update () {
		
		this.rigidbody2D.AddTorque (100f * Time.deltaTime);
		if (r > 1)
						r = 0;
		if (g > 1)
						g = 0;
		if (b > 1)
						b = 0;
		
		r += Random.Range (0, 0.1f);
		g += Random.Range (0, 0.1f);
		b += Random.Range (0, 0.1f);

		s.color = new Color (r, g, b);
	}
}
