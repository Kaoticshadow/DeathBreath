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
	public wizFus fu;
	// Use this for initialization
	void Start () {
		stage = 0;
		phase0Target = new Vector3 (6, 0, 0);
		axcd = axfrequency;
		shtcd = shoutfrequ;
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		switch (stage) {
			case 0: phase0 ();
				break;
			case 1: phase1 ();
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

	}

	void phase1(){
		this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(this.transform.position.x, Mathf.Min( 4.5f,player.transform.position.y + verticaloffset),.1f),0.05f);

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
				this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(phase0Target.x, player.transform.position.y,0),.01f);
	}
}
