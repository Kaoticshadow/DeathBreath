using UnityEngine;
using System.Collections;

public class DragonShoot : MonoBehaviour {

	public KeyCode firekey = KeyCode.Space;
	public bool disableFire;

	public Flame f;
	public float fireForce = 3600f;

	public float cooldown = 0.2f;
	float cooldownctr = 0;
	bool coolingdown = false;
	bool letgo = true;

	public int fireCount = 4;
	int firectr = 0;

	public float fireScale = 1;

	bool firemode1on = true;

	public GameObject startloc;

	// Use this for initialization
	void Start () {
		coolingdown = false;
		disableFire = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (firemode1on)
						firemode1 ();
	}

	void firemode1(){
		if (!Input.GetKey (firekey)) {
			letgo = true;
			firectr=0;
		}
		if (!coolingdown){
			if (Input.GetKey (firekey)&&letgo && disableFire == false) {
				Flame x = (Flame)Instantiate (f, startloc.transform.position, Quaternion.identity);
				x.transform.localScale = new Vector2(x.transform.localScale.x,x.transform.localScale.y*fireScale);
				x.rigidbody2D.AddForce (new Vector2 (fireForce, 0));
				coolingdown = true;
				x.power = fireScale;
				
				firectr++;
				if(firectr>=fireCount)
				{
					letgo=false;
					firectr = 0;
				}
				
			}
		} else {
			cooldownctr += Time.deltaTime;
			if(cooldownctr>cooldown)
			{
				coolingdown = false;
				cooldownctr = 0;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		//dragon enters a col

		if (col.gameObject.tag == "firebonus")
						fireScale += 0.2f;

	}
}
