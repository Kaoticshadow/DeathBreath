

using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {
	
	int lifeTime;
	public int currentLife;
	GameObject m_go;
	Transform m_t;
	public Vector3 veloc;
	
	// Use this for initialization
	void Start () {
		lifeTime = 300;
		m_go = this.gameObject;
		m_t  = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		currentLife++;
		m_t.position = m_t.position + veloc*0.5f;
		if (currentLife > lifeTime)
			Destroy (m_go);
	}

	void OnEnterCollision2D (Collider2D col){
		Debug.Log ("fireballDead");
		Destroy (m_go);
	}
}

