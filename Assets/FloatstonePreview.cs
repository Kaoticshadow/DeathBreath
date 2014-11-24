using UnityEngine;
using System.Collections;

public class FloatstonePreview : MonoBehaviour {

	public float xPositionTrigger;
	public float triggerForce = -100f;
	public bool triggered;

	// Use this for initialization
	void Start () {
		triggered = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(this.transform.position.x <= xPositionTrigger && !triggered){
			this.rigidbody2D.AddForce(new Vector2(0f,triggerForce));
			triggered = true;
		}
	}
}
