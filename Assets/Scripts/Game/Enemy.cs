using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float health = 1;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void takeDamage(float damage){
		health -= damage;
		if (health < 0)
		{
			Destroy (this.gameObject);
		}
	}
}
