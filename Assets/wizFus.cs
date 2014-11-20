using UnityEngine;
using System.Collections;

public class wizFus : MonoBehaviour {

	public Transform target;
	public Transform startspot;
	float start = .7f;
	float speed = 12;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		start -= Time.deltaTime;
		if (start <= 0 )
			this.rigidbody2D.AddForce ((target.position - this.transform.position).normalized * speed);
		else if (start > 0)
			this.transform.position = startspot.position;
		if (this.rigidbody2D.velocity.magnitude > speed)
						this.rigidbody2D.velocity = this.rigidbody2D.velocity.normalized * speed;



	
	}

	//collide w/ enemies
	///collide with boundaries and selfdestruct
}
