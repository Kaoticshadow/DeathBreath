using UnityEngine;
using System.Collections;
using System;

public class KnightScript : MonoBehaviour {
	
	public float speed;
	public float dragonDistance;
	
	Transform m_t;
	Transform DragonTransform;
	Transform MidpointY;
	
	// Use this for initialization
	void Start () {
		m_t = this.transform;
		speed = 0.05f;
		dragonDistance = 5.0f;

		DragonTransform = GameObject.Find("Dargon Character").transform;
		MidpointY = GameObject.Find ("Midpoint Y").transform;

	}

	//collisions
	void OnCollisionEnter(Collision collision)
	{
		if (collider.gameObject.name == "Knight") 
		{
			Destroy (collision.gameObject);
		}
	}


	// Update is called once per frame
	void Update () {

		//X axis movement
		if ( (DragonTransform.localPosition.x < m_t.localPosition.x && !IsDragonTooClose() )
		    || (DragonTransform.localPosition.x > m_t.localPosition.x && IsDragonTooClose() )) {
						m_t.localPosition = new Vector3 (m_t.localPosition.x - speed,
			                                m_t.localPosition.y,
			                                m_t.localPosition.z);

		} else if ( (DragonTransform.localPosition.x > m_t.localPosition.x && !IsDragonTooClose() )
		           || (DragonTransform.localPosition.x < m_t.localPosition.x && IsDragonTooClose() )){

						m_t.localPosition = new Vector3 (m_t.localPosition.x + speed,
		                                m_t.localPosition.y,
		                                m_t.localPosition.z);
				}

		//Y axis movement
		if (m_t.localPosition.y < DragonTransform.localPosition.y && m_t.localPosition.y < MidpointY.localPosition.y) {
				
						m_t.localPosition = new Vector3 (m_t.localPosition.x,
			                                 m_t.localPosition.y + speed,
			                                 m_t.localPosition.z);

		} else if((m_t.localPosition.y > DragonTransform.localPosition.y && m_t.localPosition.y == MidpointY.localPosition.y) || (m_t.localPosition.y > DragonTransform.localPosition.y)){
						m_t.localPosition = new Vector3 (m_t.localPosition.x,
			                                 m_t.localPosition.y - speed,
			                                 m_t.localPosition.z);
				}

		
	}

	bool IsDragonTooClose() {
		return Math.Abs (DragonTransform.localPosition.x - m_t.localPosition.x) < dragonDistance;
	}
	
}
