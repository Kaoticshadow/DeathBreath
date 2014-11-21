using UnityEngine;
using System.Collections;

public class dragonsoul : MonoBehaviour {

	public GameObject target;
	public float accel = 100f;
	public float targetSpeed = 5f;
	public float targetDistance = 0.5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		updateRotation ();

		if (target != null) {
			Vector3 dir = target.transform.position - this.transform.position;
			this.rigidbody2D.velocity = Vector3.Lerp(this.rigidbody2D.velocity,dir.normalized * targetSpeed,0.05f);
			this.rigidbody2D.AddForce (dir * accel * Time.deltaTime);//dir of player target
			if (dir.magnitude < targetDistance){
					Destroy (this.gameObject);
			}
		}

	}


	void updateRotation(){
		Vector2 targetVector = this.rigidbody2D.velocity;
		float angle = (Mathf.Atan2(targetVector.y, targetVector.x) * Mathf.Rad2Deg);
		angle += 270.0f;
		this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}
