using UnityEngine;
using System.Collections;

public class kingmanager : MonoBehaviour {
	public GameObject manager;
	public smoke sm;
	bool hit = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (hit) {
			Vector3 offset = new Vector3 (Random.Range(0,1.4f),Random.Range(-2,1.4f),0);
			smoke x = Instantiate(sm,this.transform.position+offset,Quaternion.identity) as smoke;

		}
	}

	void takeDamage(){
		manager.SendMessage ("hit");
		hit = true;

	}
}
