using UnityEngine;
using System.Collections;

public class looktowards : MonoBehaviour {
	GameObject player;
	float followRate = 1f;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Quaternion q = Quaternion.AngleAxis (getAngle (player.transform.position), Vector3.forward);//positive rotates down, negative up
		this.transform.rotation = Quaternion.Slerp (this.transform.rotation, q, Time.deltaTime * followRate);

	}


	float getAngle(Vector3 targetpos){
		Vector3 dir = this.transform.position - targetpos;
		
		float a =  Vector3.Angle( dir,new Vector3(0,1,0))-85f;
		return -a;
	}
}
