using UnityEngine;
using System.Collections;

public class DragonMoveScript : MonoBehaviour {
	
	public float speed;
	
	Transform m_t;
	
	// Use this for initialization
	void Start () {
		m_t = this.transform;
		speed = 0.2f;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKey(KeyCode.A) && (m_t.localPosition.x > -9 ) )
			m_t.localPosition = new Vector3(m_t.localPosition.x - speed,
			                                m_t.localPosition.y,
			                                m_t.localPosition.z);
		
		if(Input.GetKey(KeyCode.D) && (m_t.localPosition.x < 9 ) )
			m_t.localPosition = new Vector3(m_t.localPosition.x + speed,
			                                m_t.localPosition.y,
			                                m_t.localPosition.z);
		
		if(Input.GetKey(KeyCode.S) && (m_t.localPosition.y > -3.5f ) )
			m_t.localPosition = new Vector3(m_t.localPosition.x,
			                                m_t.localPosition.y - speed,
			                                m_t.localPosition.z);
		
		if(Input.GetKey(KeyCode.W) && (m_t.localPosition.y < 3.5f ) )
			m_t.localPosition = new Vector3(m_t.localPosition.x,
			                                m_t.localPosition.y + speed,
			                                m_t.localPosition.z);
		
	}
}

