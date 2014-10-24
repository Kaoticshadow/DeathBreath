using UnityEngine;
using System.Collections;
using System;

public class Archer : MonoBehaviour {
	//animation vars
	public GameObject headHinge;
	public GameObject armHinge;
	public GameObject arrowStart;
	GameObject target;
	
	public float followRate = 3f;

	public bool canFlip = false;
	int flipFactor = 1;
	bool facingLeft = true;


	public Arrow  arrow;

	//firing
	public float arrowForce = 1f;
	public float decayFactor = 300f;
	float fireRate;
	bool canfire;

	public int mode = 1;
	// 0 is slow tracking, faces forward only

	//health
	public float health = 3;







	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player");
		canfire = true;
	}
	
	// Update is called once per frame
	void Update () {

		flip ();

		if (mode == 0)
				updateMode0 ();
		else if (mode == 1)
				updateMode1 ();
	}

	void flip(){
		if (canFlip) {
			if ((target.transform.position.x > this.transform.position.x) && facingLeft) 
				performFlip ();
			if ((target.transform.position.x < this.transform.position.x) && !facingLeft) 
				performFlip ();
		}
	}

	void performFlip(){
		flipFactor *= -1;
		facingLeft = !facingLeft;
		this.transform.localScale = new Vector2 (this.transform.localScale.x * -1, this.transform.localScale.y);
	}


	float calcDecay(float distance){
		float var = 3;
		float result = (decayFactor*var / distance) * (decayFactor*(var/distance));
		return 1/ (1/distance*1);
	}

	void fire(int offset){
		Arrow x = (Arrow)Instantiate (arrow, arrowStart.transform.position, arrowStart.transform.rotation);
		Vector3 dir = target.transform.position - this.transform.position + new Vector3(0,offset,0);
		Vector3 dirn = dir.normalized;

		x.rigidbody2D.AddForce (new Vector2 (dirn.x, dirn.y) * arrowForce*calcDecay(dir.magnitude));
		canfire = false;
	}
	
	void updateMode0(){
		Quaternion q = Quaternion.AngleAxis (getAngle (target.transform.position), Vector3.forward);//positive rotates down, negative up
		armHinge.transform.rotation = Quaternion.Slerp (armHinge.transform.rotation, q, Time.deltaTime * followRate);
		headHinge.transform.rotation = Quaternion.Slerp (headHinge.transform.rotation, q, Time.deltaTime * followRate);
	
		if(this.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Shoot 0")&&canfire)
						fire (0);
		if (this.gameObject.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("archerIdle"))
						canfire = true;	   
	}

	void updateMode1(){
		Quaternion q = Quaternion.AngleAxis (getAngle (target.transform.position), Vector3.forward);//positive rotates down, negative up
		armHinge.transform.rotation = Quaternion.Slerp (armHinge.transform.rotation, q, Time.deltaTime * followRate);
		headHinge.transform.rotation = Quaternion.Slerp (headHinge.transform.rotation, q, Time.deltaTime * followRate);

		if(this.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Shoot 0")&&canfire)
			fire (1);
		if (this.gameObject.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("archerIdle"))
			canfire = true;
	}

	float getAngle(Vector3 targetpos){
		Vector3 dir = this.transform.position - targetpos;

		float a =  Vector3.Angle( dir,new Vector3(0,1,0))-85f;
		return -a;
	}

	void takeDamage(float damage){
		health -= damage;
		if (health < 0)
			Destroy (this.gameObject);

		//score++;
	}
}
