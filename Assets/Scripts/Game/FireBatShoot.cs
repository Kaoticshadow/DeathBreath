using UnityEngine;
using System.Collections;

public class FireBatShoot : MonoBehaviour {

	GameObject go;
	public cutefire cf_pf;
	float myRand;
	public float fireDelay = 1.0f;
	float fireCounter;


	// Use this for initialization
	void Start () {
	
		go = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		fireCounter += Time.deltaTime;
		if(fireCounter >= fireDelay){
			fire();		
		}
	}

	void fire(){
		
		cutefire c = Instantiate (cf_pf, go.transform.position, Quaternion.identity) as cutefire;
		c.GetComponent<Rigidbody2D>().AddForce (new Vector2 (-300f, 0));
		fireCounter = 0;

	}
}
