﻿

using UnityEngine;
using System.Collections;

public class LineFire : MonoBehaviour {
	
	
	public bool stoppable;
	public float length;

	Transform m_t;
	public float speed;
	public float fireSpeed;
	public FireBall m_rb;
	public Cursor m_Cursor;
	public LineRenderer fireLine;
	public LineRenderer m_lined;
	public GameObject Ammo;
	Transform ammoTransform;

	float ammoRate = 0.05f;

	float ammoMax = 10f;
	float ammoMin = 0f;

	private Vector3 _direction = new Vector3 (1f, 0f, 0f);
	
	// Use this for initialization
	void Start () {
		m_t = this.transform;
		m_t.position = m_t.position + new Vector3 (0, 0, 0.1f);
		speed = 0.3f;
		fireSpeed = 10.0f;
		//fireSpeed = 1.0f;
		Fire ();
		ammoTransform = Ammo.transform;
		ammoTransform.localScale = new Vector3(ammoMax,1,1);
		
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 baseData = new Vector3 (m_t.position.x, m_t.position.y, -1);
		Vector3 lineData;
		//Vector3 offset = new Vect
		if (Input.GetMouseButton (0)) {
			if(ammoTransform.localScale.x > ammoMin){
				lineData = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, -1));
				
				lineData.z = 0.001220703f;

				if(stoppable){
					if(Vector3.Distance(lineData, baseData)>length)
					{
						Vector3 norm = lineData-baseData;

						lineData = baseData + (norm.normalized*length);
					}
				
				}

				lineData.z = -1;
				m_lined.SetPosition (0, baseData);
				m_lined.SetPosition (1, lineData);
				m_lined.collider2D.transform.position = lineData;
			if(ammoTransform.localScale.x >ammoMin)
				ammoTransform.localScale = new Vector3(ammoTransform.localScale.x - ammoRate, 1, 1);
			}
			else{
			lineData = new Vector3(0,0,0);
			m_lined.SetPosition (0,lineData);
			m_lined.SetPosition (1,lineData);
			}
		} else {
			lineData = new Vector3(0,0,0);
			m_lined.SetPosition (0,lineData);
			m_lined.SetPosition (1,lineData);

			if(ammoTransform.localScale.x < ammoMax)
				ammoTransform.localScale = new Vector3(ammoTransform.localScale.x + 2*ammoRate, 1, 1);
		}
	}
	
	void Fire () 
	{
		LineRenderer fireClone = Instantiate (fireLine, m_t.position, m_t.rotation) as LineRenderer;
		m_lined = fireClone;
	}
}
