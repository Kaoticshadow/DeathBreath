using UnityEngine;
using System.Collections;

public class DragonShoot : MonoBehaviour {

	public KeyCode firekey = KeyCode.Space;
	public bool disableFire;

	public Flame f;
	public Flame of;
	public Flame smallFire;
	public Flame o_smallFire;
	public float fireForce = 3600f;

	public float cooldown = 0.2f;
	int pepperLevel = 0;
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
				fireExtraBalls();
				
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

	void fireExtraBalls(){
		switch (pepperLevel) {
		case 0:
			break;
		case 1:
			Flame x = (Flame)Instantiate (smallFire, startloc.transform.position, Quaternion.identity);
			x.transform.localScale = new Vector2(x.transform.localScale.x,x.transform.localScale.y*fireScale);
			x.rigidbody2D.AddForce (new Vector2 (fireForce, 0));
			//coolingdown = true;
			x.power = fireScale / 5f;
			break;
		case 2:
			Flame x3 = (Flame)Instantiate (of, startloc.transform.position, Quaternion.identity);
			x3.transform.localScale = new Vector2(x3.transform.localScale.x,x3.transform.localScale.y*fireScale);
			x3.rigidbody2D.AddForce (new Vector2 (fireForce, 0));
			//coolingdown = true;
			x3.power = fireScale;
			break;
		case 3: 
			Flame x1 = (Flame)Instantiate (f, startloc.transform.position, Quaternion.identity);
			x1.transform.localScale = new Vector2(x1.transform.localScale.x,x1.transform.localScale.y*fireScale);
			x1.rigidbody2D.AddForce (new Vector2 (fireForce, fireForce*0.7f));
			//coolingdown = true;
			x1.power = fireScale;
			Flame x2 = (Flame)Instantiate (f, startloc.transform.position, Quaternion.identity);
			x2.transform.localScale = new Vector2(x2.transform.localScale.x,x2.transform.localScale.y*fireScale);
			x2.rigidbody2D.AddForce (new Vector2 (fireForce, -fireForce*0.7f));
			//coolingdown = true;
			x2.power = fireScale;
			break;
		case 4: 
			break;
		default:
			break;


		}

	}

	public void addFireScale(float bonus){
		fireScale += bonus;
	}

	public void addPepperLevel(){
		pepperLevel++;
	}


}
