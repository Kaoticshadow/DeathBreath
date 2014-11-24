using UnityEngine;
using System.Collections;

public class floatstoneSubcomponentTakeDamage : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void takeDamage(float damage){
		this.transform.parent.SendMessage("takeDamage",damage);
		//this.transform.parent.parent.SendMessage("takeDamage",damage);
	}
}
