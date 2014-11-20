using UnityEngine;
using System.Collections;

public class dragonBorne : MonoBehaviour {
	int stage;
	GameObject player;
	public GameObject rain;
	public GameObject fusruda;
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

	void spitforce(){
		GameObject g = (GameObject)Instantiate (fu, fusorigin.transform.position, Quaternion.identity);
		Vector2 dir = (Vector2)fusorigin.transform.position - (Vector2)player.transform.position;
		g.GetComponent<Rigidbody2D> ().AddForce (-dir.normalized * 800f);
	}

	void phase2(){
						phase2start ();
		if (phase2ready) {

				}

	}


	void phase2start(){
		returnctr -= Time.deltaTime;
		Debug.Log (returnctr);
		if (this.transform.position != exitSpot.transform.position && returnctr > 0)
				this.transform.position = Vector3.Lerp (this.transform.position, exitSpot.transform.position, 0.01f);
		else {
				this.transform.position = Vector3.Lerp (this.transform.position, entry.transform.position, 0.01f);
				phase2ready = true;
				this.transform.localScale = new Vector3(-1,1,1);
		}

		
	}

	void phase1(){
		this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(this.transform.position.x, Mathf.Min( 4.5f,player.transform.position.y + verticaloffset),.1f),0.05f);
		phasectr -= Time.deltaTime;
		if (phasectr < 0) {
			phasectr = phase2Dur;
			stage = 2;
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
			spitforce();
			shtcd = shoutfrequ - Random.Range(-1,-.5f);
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
