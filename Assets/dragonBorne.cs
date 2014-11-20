using UnityEngine;
using System.Collections;

public class dragonBorne : MonoBehaviour {
	int stage;
	GameObject player;
	public GameObject rain;
	public GameObject fusruda;
	public GameObject fusrudaback;
	public float openingcd= 3f;
	Vector3 phase0Target;
	float verticaloffset = 0;
	public float shoutfrequ = 3f;
	public float axfrequency = 2f;
	float shtcd;
	float axcd;
	public GameObject fu;
	public GameObject fusorigin;
	public float phase1Dur = 10f;
	public float phase2Dur = 10f;
	public GameObject exitSpot;
	public GameObject entry;
	float returnctr = 3f;
	bool phase2ready = false;
	float phasectr;
	bool ready2enter = false;
	
	float p3ctr = 3.5f;

	float reboundctr = 1f;
	bool rebound = true;


	// Use this for initialization
	void Start () {
		stage = 0;
		phase0Target = new Vector3 (5, 0, 0);
		axcd = axfrequency;
		shtcd = shoutfrequ;
		phasectr = phase1Dur;
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	
	// Update is called once per frame
	void Update () {
		switch (stage) {
			case 0: phase0 ();
				break;
			case 1: phase1 ();
				break;
		case 2: phase2();
			break;
		case 3: phase3();
			break;
			default:
				break;
		}
	}
	void destroyeverything(){
		GameObject[] x = GameObject.FindGameObjectsWithTag ("Lightning");
		foreach (GameObject y in x)
						Destroy (y);
		Destroy(rain);
	}

	void phase3(){
		p3ctr -= Time.deltaTime;
		Debug.Log ("doing phase 3");
		Debug.Log (p3ctr);
		this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(5, player.transform.position.y,0),.01f);
		if (p3ctr < 0) {
			stage = 1;
			p3ctr = 3f;
		}
	}

	void spitforce(){
		GameObject g = (GameObject)Instantiate (fu, fusorigin.transform.position, Quaternion.identity);
		Vector2 dir = (Vector2)player.transform.position - (Vector2)fusorigin.transform.position;
		Debug.Log (dir);
		g.GetComponent<Rigidbody2D> ().AddForce (dir.normalized * 800f);
	}

	void phase2(){
						phase2start ();
		if (phase2ready) {
						phase2Dur -= Time.deltaTime;
						if (phase2Dur < 0) {
								stage = 3;
								phase1Dur = 25f;
								phase2Dur = 12f;
						}
						shtcd -= Time.deltaTime;
					//	Debug.Log(shtcd);
						if (shtcd < 0) {
								spitforce ();
								shtcd = shoutfrequ - Random.Range (2f, 2.5f);
						}

			if(player.transform.position.x < -1.9f&& rebound)
			{
				rebound = false;
				fusrudaback.GetComponent<ParticleSystem>().Emit(200);
				player.rigidbody2D.AddForce(new Vector2(1000,0));
			}
			if (!rebound) {
				reboundctr-= Time.deltaTime;
				if(reboundctr<0){
					reboundctr = 1f;
					rebound = true;
				}
			}
			}
	}
	

	void phase2start(){
		returnctr -= Time.deltaTime;
	//	Debug.Log (returnctr);
		if (this.transform.position != exitSpot.transform.position && returnctr > 0)
				this.transform.position = Vector3.Lerp (this.transform.position, exitSpot.transform.position, 0.01f);
		else {
			if(!phase2ready)
				shtcd = 3f;

				this.transform.position = Vector3.Lerp (this.transform.position, entry.transform.position, 0.01f);
				phase2ready = true;
				this.transform.localScale = new Vector3(1,1,1);

		}

		
	}

	void phase1(){
		Debug.Log ("doing phase 1");
		this.transform.localScale = new Vector3 (-1, 1, 1);
		this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(5, Mathf.Min( 4.5f,player.transform.position.y + verticaloffset),0),0.08f);
		phasectr -= Time.deltaTime;
		if (phasectr < 0) {
			phasectr = phase2Dur;
			phase2ready = false;
			stage = 2;
			returnctr = 3f;
				}
		shtcd -= Time.deltaTime;
		axcd -= Time.deltaTime;
		if (axcd < 0) {
			axcd = axfrequency - Random.Range(-2,-.5f);
			this.gameObject.SendMessage("shoot",Random.Range(1.9f,2.5f));
			this.gameObject.SendMessage("shoot",Random.Range(2.8f,3.2f));
			this.gameObject.SendMessage("shoot",Random.Range(1.4f,1.6f));
			verticaloffset = Random.Range(-2,1.5f);
				}
		if (shtcd < 0) {
		//	Debug.Log ("spit");
			spitforce();
			shtcd = shoutfrequ - Random.Range(-1,-.5f);
		}

		if(player.transform.position.x > 3f&&rebound)
		{
			rebound = false;
			fusruda.GetComponent<ParticleSystem>().Emit(200);
			player.rigidbody2D.AddForce(new Vector2(-1000,0));
		}

		if (!rebound) {
			reboundctr-= Time.deltaTime;
			if(reboundctr<0){
				reboundctr = 1f;
				rebound = true;
			}
		}
		
	}
	
	void phase0(){
		openingcd -= Time.deltaTime;
		if(openingcd<0&&rain!=null){
			fusruda.GetComponent<ParticleSystem>().Emit(200);
			rain.GetComponent<ParticleSystem>().Stop();
			if(openingcd<0){
				destroyeverything();
				stage = 1;
			}
		}
				this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(5, player.transform.position.y,0),.01f);
	}
}
