using UnityEngine;
using System.Collections;

public class dragonbornedeath : MonoBehaviour {

	Enemy e;
	GameObject player;
	public dragonsoul ds;
	float cd = 1;
	bool start = false;
	// Use this for initialization
	void Start () {
		e = this.GetComponent<Enemy> ();
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		checkDeath ();
		if (start) {
			cd-=Time.deltaTime;
			if(cd<0)
				Destroy(this.gameObject);
			//spawn a ton of particles that arc towards player
			dragonsoul temp = Instantiate(ds, this.transform.position,Quaternion.identity) as dragonsoul;
			temp.target = player;
			Vector3 dir = player.transform.position-this.transform.position ;
			temp.rigidbody2D.AddForce((dir.normalized + new Vector3(Random.Range(-dir.normalized.x,dir.normalized.x)*.5f,
			                                                       Random.Range(-dir.normalized.y,dir.normalized.y)*3,
			                                                        0)*50)*10);


		}
	}

	void checkDeath(){
		if (e.health <= 0)
						beginAnimation ();
	}

	void beginAnimation(){
		start = true;

	}
}
