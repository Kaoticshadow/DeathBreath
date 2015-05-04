using UnityEngine;
using System.Collections;

public class DragonMove : MonoBehaviour {

	Transform dragonTrans;

	public float moveRate = 1.0f;
	public bool disableControls;
	//public float topLevelEdgeMovementPadding;
	//public float bottomLevelEdgeMovementPadding;
	//public float leftLevelEdgeMovementPadding;
	//public float rightLevelEdgeMovementPadding;
	//GameObject top,bottom,left,right;
	public float moveForce = 100f;

	bool turned = false;
	// Use this for initialization
	void Start () {
	
		dragonTrans = this.transform;
		disableControls = false;
		//top = GameObject.Find ("Top Level Edge");
		//bottom = GameObject.Find ("Bottom Level Edge");
		//left = GameObject.Find ("Left Level Edge");
		//right = GameObject.Find ("Right Level Edge");
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.L)) {
			GameObject.Find ("Health Bar").SendMessage ("AddScale");
		}
		if (disableControls == false) 
		{
			//move (getDir ());
			forceMove();
		}
	}

	void move(Vector2 direction)
	{
		dragonTrans.position += new Vector3(direction.x * moveRate,direction.y * moveRate);
	}

	void forceMove(){
		Quaternion q;// = Quaternion.AngleAxis (-20.0f, Vector3.forward);

		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
			this.GetComponent<Rigidbody2D>().AddForce(new Vector2(-moveForce * Time.deltaTime, 0f ));
			q = Quaternion.AngleAxis (20.0f, Vector3.forward);
			dragonTrans.rotation = Quaternion.Slerp (dragonTrans.rotation, q, Time.deltaTime * 4.0f);
		}
		if (Input.GetKey (KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
			this.GetComponent<Rigidbody2D>().AddForce(new Vector2(moveForce * Time.deltaTime, 0f));
			q = Quaternion.AngleAxis (-20.0f, Vector3.forward);
			dragonTrans.rotation = Quaternion.Slerp (dragonTrans.rotation, q, Time.deltaTime * 4.0f);
		}
		if (Input.GetKey (KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
			this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,moveForce * Time.deltaTime));
		}
		if (Input.GetKey (KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
			this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,-moveForce * Time.deltaTime));
		}
		
		//rotate back
		q = Quaternion.AngleAxis (0.0f, Vector3.forward);
		dragonTrans.rotation = Quaternion.Lerp(dragonTrans.rotation,q,Time.deltaTime*3.0f);
		//}

	}

	/*
	Vector2 getDir(){
		Vector2 dir = new Vector2 ();
		Quaternion q;// = Quaternion.AngleAxis (-20.0f, Vector3.forward);

		if (Mathf.Abs(left.transform.localPosition.x - this.transform.localPosition.x) > leftLevelEdgeMovementPadding) {
			if(Input.GetKey(KeyCode.A)){

			dir.x -= 0.8f;
			//dragonTrans.rotation = Quaternion.Euler (0f, 0f, 20.0f);
			 q = Quaternion.AngleAxis (20.0f, Vector3.forward);
				dragonTrans.rotation = Quaternion.Slerp (dragonTrans.rotation, q, Time.deltaTime * 1.0f);}
			resetVelc();
		}
		if (Input.GetKey (KeyCode.D)  && Mathf.Abs(right.transform.localPosition.x - this.transform.localPosition.x) > rightLevelEdgeMovementPadding) {
			if(Input.GetKey(KeyCode.D)){
			dir.x += 1.0f;
			//dragonTrans.rotation = Quaternion.Euler (0f, 0f, -20.0f);
			 q = Quaternion.AngleAxis (-20.0f, Vector3.forward);
				dragonTrans.rotation = Quaternion.Slerp (dragonTrans.rotation, q, Time.deltaTime * 1.0f);}
			resetVelc();
		}
		if (Input.GetKey (KeyCode.W)  && Mathf.Abs(top.transform.localPosition.y - this.transform.localPosition.y) > topLevelEdgeMovementPadding) {
			dir.y += 1.0f;
		}
		if (Input.GetKey (KeyCode.S) && Mathf.Abs (bottom.transform.localPosition.y - this.transform.localPosition.y) > bottomLevelEdgeMovementPadding) {
			dir.y -= 1.0f;
		}

		if (!Input.anyKey) {
			q = Quaternion.AngleAxis (0.0f, Vector3.forward);
			dragonTrans.rotation = Quaternion.Slerp (dragonTrans.rotation, q, Time.deltaTime * 5.0f);
		}

		return dir;
	}
	*/

	void resetVelc(){
		Debug.Log ("stopped");
	//	this.rigidbody2D.velocity = new Vector2 (0, 0);
	}
}
