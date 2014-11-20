using UnityEngine;
using System.Collections;

public class blackCard : MonoBehaviour {
	float duration = 2f;//5f;
	SpriteRenderer s;
	Color c;
	// Use this for initialization
	void Start () {
		s = this.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		duration -= Time.deltaTime;
		if (duration <= 0)
						s.color = new Color (0, 0, 0, s.color.a - 0.01f);
		Debug.Log (c.a);
		if (s.color.a <= 0)
						Destroy (this.gameObject);
	}
}
