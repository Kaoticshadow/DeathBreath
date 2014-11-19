using UnityEngine;
using System.Collections;

public class AxShoot : MonoBehaviour {

	public Ax a; 
	public GameObject startloc;
	float shootCD = 3;
	float currentCD = 3;

	
	GameObject player;


	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	

	
	// Update is called once per frame
	void Update () {
		currentCD -= Time.deltaTime;
		if (currentCD <= 0) {
						shoot ();
						currentCD = shootCD;
				}
	}

	void shoot(){
		float factor = -1;
		if (player.transform.position.x > this.transform.position.x)
						factor = 1;

		Ax tempA = (Ax)Instantiate (a, startloc.transform.position, Quaternion.identity);
		
		tempA.rigidbody2D.AddTorque (-factor * 90);
		tempA.rigidbody2D.AddForce (new Vector2(factor, 2f) *280);


	}
	

}
