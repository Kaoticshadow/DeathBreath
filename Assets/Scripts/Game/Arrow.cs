using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	float lifetime = 5.0f;
	float life = 0;

	// Use this for initialization
	void Start () {
	//	this.rigidbody2D.AddForce (new Vector2(-180, 350));
	}
	
	// Update is called once per frame
	void Update () {
		//point @ velocity
		life += Time.deltaTime;
		Quaternion q = Quaternion.AngleAxis (getAngle (this.rigidbody2D.velocity), getv(this.rigidbody2D.velocity.x));//positive rotates down, negative up
		this.transform.rotation = q;//Quaternion.Slerp (this.transform.rotation, q, Time.deltaTime * 1.0f);
		if (life > lifetime)
						Destroy (this.gameObject);
	}

	float getAngle(Vector2 vel){;
		if(vel.x < 0)
			return Vector2.Angle(vel.normalized,Vector2.up)-90;
		else
			return Vector2.Angle(Vector2.up,vel.normalized)+90;
	}

	Vector3 getv(float x){
		if (x > 0)
						return Vector3.back;
				else
						return Vector3.forward;

	}
}
