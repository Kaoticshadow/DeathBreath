using UnityEngine;
using System.Collections;

public class dragonsoul : MonoBehaviour {

	public GameObject target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		updateRotation ();
		Vector3 dir = target.transform.position-this.transform.position;
		if (target != null) {
			this.rigidbody2D.AddForce(dir.normalized * 18f);//dir of player target
				}
		if (dir.magnitude < 1.5f)
						Destroy (this.gameObject);
	}


	void updateRotation(){
		Vector2 targetVector = this.rigidbody2D.velocity;
		float angle = (Mathf.Atan2(targetVector.y, targetVector.x) * Mathf.Rad2Deg);
		angle += 270.0f;
		this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}
