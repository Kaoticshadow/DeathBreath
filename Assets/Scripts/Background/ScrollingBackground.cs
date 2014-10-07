using UnityEngine;
using System.Collections;

public class ScrollingBackground : MonoBehaviour {
	
	public float speed;
	public float leftedge;
	public float rightedge;

	Transform m_t;
	Rigidbody2D m_rb;
	// Use this for initialization
	void Start () {
		m_t = this.transform;
		m_rb = this.rigidbody2D;
		m_rb.velocity = new Vector2 (speed, 0);


	}
	
	// Update is called once per frame
	void Update () {
		if(m_t.localPosition.x < leftedge)
			m_t.localPosition = new Vector2 (rightedge, m_t.localPosition.y);
		//m_t.localPosition = new Vector3 (m_t.localPosition.x - speed, m_t.localPosition.y, m_t.localPosition.z);
	}
}
