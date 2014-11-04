using UnityEngine;
using System.Collections;

public class FloatstoneBody : MonoBehaviour {

	public float distance = 3.0f;
	public float speed = 0.04f;
	public GameObject target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector2.Distance (this.transform.position, target.transform.position) > distance) {
			this.transform.position = Vector2.MoveTowards (this.transform.position, target.transform.position, speed);
		}
	}
}
