using UnityEngine;
using System.Collections;

public class wizFus : MonoBehaviour {

	public Transform target;
	public Transform startspot;
	float start = .7f;
	float speed = 7f;
	Vector2 targetVelocity;
	float velocityChangeFactor = 0.05f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		start -= Time.deltaTime;
		if (start <= 0){
			//this.rigidbody2D.AddForce ((target.position - this.transform.position).normalized * speed)
			targetVelocity = (target.position - this.transform.position).normalized * speed;
			this.rigidbody2D.velocity = Vector2.Lerp(this.rigidbody2D.velocity,targetVelocity,velocityChangeFactor);
		}
		else if (start > 0){
			this.transform.position = startspot.position;
		}



		//if (this.rigidbody2D.velocity.magnitude > speed){
			//this.rigidbody2D.velocity = this.rigidbody2D.velocity.normalized * speed;
		//}

		//Vector3 dir = this.rigidbody2D.velocity;
		//dir = dir.normalized;

		updateRotation ();

	
	}

	void updateRotation(){
		Vector2 targetVector = this.rigidbody2D.velocity;
		float angle = (Mathf.Atan2(targetVector.y, targetVector.x) * Mathf.Rad2Deg);
		angle += 180.0f;
		this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

	//collide w/ enemies
	///collide with boundaries and selfdestruct
}
