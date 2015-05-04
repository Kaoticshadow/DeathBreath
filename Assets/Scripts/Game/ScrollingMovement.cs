using UnityEngine;
using System.Collections;

public class ScrollingMovement : MonoBehaviour {

	public float speed;

	Transform m_t;
	Rigidbody2D m_rb;
	// Use this for initialization
	void Start () {
		m_t = this.transform;
		m_rb = this.GetComponent<Rigidbody2D>();
		m_rb.velocity = new Vector2 (speed, 0);
		
		
	}
	
	// Update is called once per frame
	void Update () {

	}
}
