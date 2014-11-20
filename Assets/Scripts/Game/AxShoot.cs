using UnityEngine;
using System.Collections;

public class AxShoot : MonoBehaviour {

	public Ax a; 
	public GameObject startloc;
	float shootCD = 3;
	float currentCD = 3;
	public bool normal = true;

	
	GameObject player;


	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		if (this.gameObject.name == "DragonBorne")
						normal = false;
	}
	

	
	// Update is called once per frame
	void Update () {
		if (normal) {
						currentCD -= Time.deltaTime;
						if (currentCD <= 0) {
								shoot ();
								currentCD = shootCD + Random.Range (0, 0.5f);
						}
				}
	}

	void shoot(float power){
		float factor = -1;
		if (player.transform.position.x > this.transform.position.x)
			factor = 1;
		
		Ax tempA = (Ax)Instantiate (a, startloc.transform.position, Quaternion.identity);
		
		tempA.rigidbody2D.AddTorque (-factor * 120);
		tempA.rigidbody2D.AddForce (new Vector2(-power, 3f) *280);

		}

	void shoot(){
		float factor = -1;
		if (player.transform.position.x > this.transform.position.x)
						factor = 1;

		Ax tempA = (Ax)Instantiate (a, startloc.transform.position, Quaternion.identity);
		
		tempA.rigidbody2D.AddTorque (-factor * 120);
		tempA.rigidbody2D.AddForce (new Vector2(Random.Range(factor,factor-1.5f), 2f) *280);


	}
	

}
