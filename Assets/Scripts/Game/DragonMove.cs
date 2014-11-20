using UnityEngine;
using System.Collections;

public class DragonMove : MonoBehaviour {

	Transform dragonTrans;

	public float moveRate = 1.0f;
	public bool disableControls;
	public float topLevelEdgeMovementPadding;
	public float bottomLevelEdgeMovementPadding;
	public float leftLevelEdgeMovementPadding;
	public float rightLevelEdgeMovementPadding;
	GameObject top,bottom,left,right;

	bool turned = false;
	// Use this for initialization
	void Start () {
	
		dragonTrans = this.transform;
		disableControls = false;
		top = GameObject.Find ("Top Level Edge");
		bottom = GameObject.Find ("Bottom Level Edge");
		left = GameObject.Find ("Left Level Edge");
		right = GameObject.Find ("Right Level Edge");
	}
	
	// Update is called once per frame
	void Update () {

		if (disableControls == false) 
		{
			move (getDir ());
		}
	}

	void move(Vector2 direction)
	{
		dragonTrans.position += new Vector3(direction.x * moveRate,direction.y * moveRate);
	}

	Vector2 getDir(){
		Vector2 dir = new Vector2 ();
		Quaternion q;// = Quaternion.AngleAxis (-20.0f, Vector3.forward);

		if (Input.GetKey (KeyCode.A) && Mathf.Abs(left.transform.localPosition.x - this.transform.localPosition.x) > leftLevelEdgeMovementPadding) {
			dir.x -= 0.8f;
			//dragonTrans.rotation = Quaternion.Euler (0f, 0f, 20.0f);
			 q = Quaternion.AngleAxis (20.0f, Vector3.forward);
			dragonTrans.rotation = Quaternion.Slerp (dragonTrans.rotation, q, Time.deltaTime * 1.0f);
		}
		if (Input.GetKey (KeyCode.D)  && Mathf.Abs(right.transform.localPosition.x - this.transform.localPosition.x) > rightLevelEdgeMovementPadding) {
			dir.x += 1.0f;
			//dragonTrans.rotation = Quaternion.Euler (0f, 0f, -20.0f);
			 q = Quaternion.AngleAxis (-20.0f, Vector3.forward);
			dragonTrans.rotation = Quaternion.Slerp (dragonTrans.rotation, q, Time.deltaTime * 1.0f);
		}
		if (Input.GetKey (KeyCode.W)  && Mathf.Abs(top.transform.localPosition.y - this.transform.localPosition.y) > topLevelEdgeMovementPadding) {
			dir.y += 1.0f;
		}
		if (Input.GetKey (KeyCode.S) && Mathf.Abs (bottom.transform.localPosition.y - this.transform.localPosition.y) > bottomLevelEdgeMovementPadding) {
			dir.y -= 1.0f;
		}

		if (!Input.anyKey) {
			q = Quaternion.AngleAxis (0.0f, Vector3.forward);
			dragonTrans.rotation = Quaternion.Slerp (dragonTrans.rotation, q, Time.deltaTime * 1.0f);
		}

		return dir;
	}
}
