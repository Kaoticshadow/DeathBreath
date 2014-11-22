using UnityEngine;
using System.Collections;

public class bossfus : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		updateRotation ();
	}

	void updateRotation(){
		Vector2 targetVector = this.rigidbody2D.velocity;
		float angle = (Mathf.Atan2(targetVector.y, targetVector.x) * Mathf.Rad2Deg);
		angle += 180.0f;
		this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}
