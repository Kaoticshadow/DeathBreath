using UnityEngine;
using System.Collections;

public class enemyHealth : MonoBehaviour {


	public int health;
	public int stdDamage;
	public int fireBallDamage;
	public int laserDamage;
	GameObject m_go;


	// Use this for initialization
	void Start () {
		m_go = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	if (health <= 0)
		Destroy (m_go);
	}

	void OnCollisionEnter2D(Collision2D col){
				if (col.gameObject.name == "FireBall(Clone)")
			health -= fireBallDamage;
		if (col.gameObject.name == "laser")
			health -= laserDamage;
		}
	void OnCollisionStay2D(Collision2D col){
		//Debug.Log (col.gameObject.name);
		//Debug.Log ("h");

		if (col.gameObject.name == "Fire Line Renderer(Clone)")
						health -= stdDamage;
	}
}
