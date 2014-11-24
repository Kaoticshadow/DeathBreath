using UnityEngine;
using System.Collections;

public class OdinWindSpawner : MonoBehaviour {

	public Animator odinAnimator;
	public GameObject spawnWind;
	public GameObject spawnTrigger;
	public float cooldownDuration = 1f;
	public int cycleFireballcount = 3;
	public bool hackupIgnoreFirstFireball = true;
	GameObject spawnedWind;
	int balls = 0;
	float cooldown = 0;
	bool firstshot = true;
	// Use this for initialization
	void Start () {
		odinAnimator = GameObject.Find ("Odin").GetComponent<Animator> ();
	
	}

	// Update is called once per frame
	void Update () {
		cooldown -= Time.deltaTime;
		//hackupIgnoreFirstFireball -= Time.deltaTime;

		//check animation state

		//if
		if (spawnTrigger.transform.position.x < this.transform.position.x && cooldown <= 0f && odinAnimator.GetCurrentAnimatorStateInfo(0).IsName("odin pew pew")) {

			if(hackupIgnoreFirstFireball && (balls % cycleFireballcount == 0) ){
				//hackupIgnoreFirstFireball = cycleDuration;
				cooldown = cooldownDuration;
			}
			else{
				spawnedWind = Instantiate(spawnWind,spawnTrigger.transform.position,Quaternion.identity) as GameObject;
				spawnedWind.rigidbody2D.AddForce(new Vector2(-750f,150f));
				spawnedWind.rigidbody2D.AddTorque(1000f);
				spawnedWind = Instantiate(spawnWind,spawnTrigger.transform.position,Quaternion.identity) as GameObject;
				spawnedWind.rigidbody2D.AddForce(new Vector2(-750f,0f));
				spawnedWind.rigidbody2D.AddTorque(1000f);
				spawnedWind = Instantiate(spawnWind,spawnTrigger.transform.position,Quaternion.identity) as GameObject;
		        spawnedWind.rigidbody2D.AddForce(new Vector2(-750f,-150f));
		        spawnedWind.rigidbody2D.AddTorque(1000f);
				cooldown = cooldownDuration;
			}
			balls++;
		}
	}
}
