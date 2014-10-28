using UnityEngine;
using System.Collections;

public class Knight : MonoBehaviour {

	Animator anim;
	Transform location;
	public GameObject child;

	public float xStart;
	public float xMid;
	public float xEnd;
	Vector3 vStart;
	Vector3 vMid;
	Vector3 vEnd;
	float y;
	public float duration;
	float fastDuration;
	// Use this for initialization
	void Start () {
		anim = child.GetComponent<Animator> ();
		location = this.transform;
		y = location.position.y;
		vStart = new Vector3 (xStart, y, location.position.z);
		vMid = new Vector3 (xMid, y, location.position.z);
		vEnd = new Vector3 (xEnd, y, location.position.z);
		fastDuration =  duration*3f;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.boss Idle"))
			location.position = Vector3.Lerp(location.position,vStart,duration);
		else if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.boss swing"))
			location.position = Vector3.Lerp(location.position,vEnd,duration);
		else if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.boss Idle 1"))
			location.position = Vector3.Lerp(location.position,vStart,fastDuration);
		else if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.peek"))
			location.position = Vector3.Lerp(location.position,vStart,duration);
		else if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.boss attack 2"))
			location.position = Vector3.Lerp(location.position,vMid,duration);
		else if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.boss Idle 0"))
			location.position = Vector3.Lerp(location.position,vStart,fastDuration);

		//this.location.position = new Vector3 (location.position.x, y, location.position.z);

	}
}
