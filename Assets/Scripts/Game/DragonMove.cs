using UnityEngine;
using System.Collections;

public class DragonMove : MonoBehaviour {

	Transform dragonTrans;

	public float moveRate = 1.0f;
	public bool paused;

	bool turned = false;
	// Use this for initialization
	void Start () {
	
		dragonTrans = this.transform;
		paused = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (paused == false) 
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

		if (Input.GetKey (KeyCode.A)) {
			dir.x -= 0.8f;
			//dragonTrans.rotation = Quaternion.Euler (0f, 0f, 20.0f);
			 q = Quaternion.AngleAxis (20.0f, Vector3.forward);
			dragonTrans.rotation = Quaternion.Slerp (dragonTrans.rotation, q, Time.deltaTime * 1.0f);
		}
		if (Input.GetKey (KeyCode.D)) {
			dir.x += 1.0f;
			//dragonTrans.rotation = Quaternion.Euler (0f, 0f, -20.0f);
			 q = Quaternion.AngleAxis (-20.0f, Vector3.forward);
			dragonTrans.rotation = Quaternion.Slerp (dragonTrans.rotation, q, Time.deltaTime * 1.0f);
		}
		if (Input.GetKey (KeyCode.W)) {
			dir.y += 1.0f;
		}
		if(Input.GetKey(KeyCode.S))
			dir.y -= 1.0f;

		if (!Input.anyKey) {
			q = Quaternion.AngleAxis (0.0f, Vector3.forward);
			dragonTrans.rotation = Quaternion.Slerp (dragonTrans.rotation, q, Time.deltaTime * 1.0f);
				}

		return dir;
	}
}
