using UnityEngine;
using System.Collections;

public class wizFus : MonoBehaviour {

	public Transform target;
	public Transform startspot;
	float start = .7f;
	float speed = 50;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		start -= Time.deltaTime;
		if (start <= 0 && start > -0.5f)
						this.rigidbody2D.AddForce ((target.position - this.transform.position).normalized * speed);
				else if (start > 0)
						this.transform.position = startspot.position;
	}
}
