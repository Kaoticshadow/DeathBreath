using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {	
	int lifeTime;
	public int currentLife;
	GameObject m_go;
	Transform m_t;
	
	// Use this for initialization
	void Start () {
		lifeTime = 100;
		m_go = this.gameObject;
		m_t  = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		currentLife++;
		if (currentLife > lifeTime)
			Destroy (m_go);
	}
}
