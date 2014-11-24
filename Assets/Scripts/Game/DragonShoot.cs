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
	public int pepperLevel = 0;
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
		Flame bp; //stands for bonus projectile. My fingers hurt today and I don't want to type the long variable name.
		switch (pepperLevel) {
		case 0:
			break;
		case 1:
			//small bonus shot
			bp = (Flame)Instantiate (o_smallFire, startloc.transform.position, Quaternion.identity);
			bp.transform.localScale = new Vector2(bp.transform.localScale.x*fireScale,bp.transform.localScale.y*fireScale);
			bp.rigidbody2D.AddForce (new Vector2 (fireForce, 0));
			bp.power = fireScale / 5f;
			break;
		case 2:
			Vector3 bonusShotOffset = new Vector3(0f,0.7f,0f);
			//bonus shot 1 (small)
			bp = (Flame)Instantiate (smallFire, startloc.transform.position + bonusShotOffset, Quaternion.identity);
			bp.transform.localScale = new Vector2(bp.transform.localScale.x*fireScale,bp.transform.localScale.y*fireScale);
			bp.rigidbody2D.AddForce (new Vector2 (fireForce, 0));
			bp.power = fireScale / 5f;
			//bonus shot 2 (small)
			bp = (Flame)Instantiate (smallFire, startloc.transform.position - bonusShotOffset, Quaternion.identity);
			bp.transform.localScale = new Vector2(bp.transform.localScale.x*fireScale,bp.transform.localScale.y*fireScale);
			bp.rigidbody2D.AddForce (new Vector2 (fireForce, 0));
			bp.power = fireScale / 5f;
			break;
		case 3:
			//regular bonus shot
			bp = (Flame)Instantiate (of, startloc.transform.position, Quaternion.identity);
			bp.transform.localScale = new Vector2(bp.transform.localScale.x,bp.transform.localScale.y*fireScale);
			bp.rigidbody2D.AddForce (new Vector2 (fireForce, 0));
			bp.power = fireScale;
			break;
		case 4: 
			//triple shot
			//bonus shot upwards
			bp = (Flame)Instantiate (f, startloc.transform.position, Quaternion.identity);
			bp.transform.localScale = new Vector2(bp.transform.localScale.x,bp.transform.localScale.y*fireScale);
			bp.rigidbody2D.AddForce (new Vector2 (fireForce, fireForce*0.7f));
			bp.power = fireScale;
			//bonus shot downwards
			bp = (Flame)Instantiate (f, startloc.transform.position, Quaternion.identity);
			bp.transform.localScale = new Vector2(bp.transform.localScale.x,bp.transform.localScale.y*fireScale);
			bp.rigidbody2D.AddForce (new Vector2 (fireForce, -fireForce*0.7f));
			bp.power = fireScale;
			break;
		case 5: 
			//triple shot with bonus small shot
			//bonus shot upwards
			bp = (Flame)Instantiate (f, startloc.transform.position, Quaternion.identity);
			bp.transform.localScale = new Vector2(bp.transform.localScale.x,bp.transform.localScale.y*fireScale);
			bp.rigidbody2D.AddForce (new Vector2 (fireForce, fireForce*0.7f));
			bp.power = fireScale;
			//bonus shot downwards
			bp = (Flame)Instantiate (f, startloc.transform.position, Quaternion.identity);
			bp.transform.localScale = new Vector2(bp.transform.localScale.x,bp.transform.localScale.y*fireScale);
			bp.rigidbody2D.AddForce (new Vector2 (fireForce, -fireForce*0.7f));
			bp.power = fireScale;
			//bonus small shot
			bp = (Flame)Instantiate (o_smallFire, startloc.transform.position, Quaternion.identity);
			bp.transform.localScale = new Vector2(bp.transform.localScale.x,bp.transform.localScale.y*fireScale);
			bp.rigidbody2D.AddForce (new Vector2 (fireForce, 0));
			bp.power = fireScale / 5f;

			break;
		default:
			//triple shot with bonus small shot
			//bonus shot upwards
			bp = (Flame)Instantiate (f, startloc.transform.position, Quaternion.identity);
			bp.transform.localScale = new Vector2(bp.transform.localScale.x,bp.transform.localScale.y*fireScale);
			bp.rigidbody2D.AddForce (new Vector2 (fireForce, fireForce*0.7f));
			bp.power = fireScale;
			//bonus shot downwards
			bp = (Flame)Instantiate (f, startloc.transform.position, Quaternion.identity);
			bp.transform.localScale = new Vector2(bp.transform.localScale.x,bp.transform.localScale.y*fireScale);
			bp.rigidbody2D.AddForce (new Vector2 (fireForce, -fireForce*0.7f));
			bp.power = fireScale;
			//bonus small shot
			bp = (Flame)Instantiate (o_smallFire, startloc.transform.position, Quaternion.identity);
			bp.transform.localScale = new Vector2(bp.transform.localScale.x,bp.transform.localScale.y*fireScale);
			bp.rigidbody2D.AddForce (new Vector2 (fireForce, 0));
			bp.power = fireScale / 5f;
			break;
		}

	}

	public void addFireScale(float bonus){
		fireScale += bonus;
		GameObject.Find ("Spicy Chicken Text").SendMessage ("addChicken");

	}

	public void addPepperLevel(){
		pepperLevel++;
		GameObject.Find ("Hot Pepper Text").SendMessage ("addPepper");
	}


}
