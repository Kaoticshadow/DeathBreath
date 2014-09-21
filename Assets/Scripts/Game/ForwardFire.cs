

using UnityEngine;
using System.Collections;

public class ForwardFire : MonoBehaviour {
	
	
	Transform m_t;
	public float speed;
	public float fireSpeed;
	public FireBall m_rb;
	public Cursor Cursor;
	
	private Vector3 _direction = new Vector3 (1f, 0f, 0f);
	
	// Use this for initialization
	void Start () {
		m_t = this.transform;
		speed = 0.3f;
		fireSpeed = 10.0f;
		//fireSpeed = 1.0f;
		
	}
	
	// Update is called once per frame
	void Update () {
		//if (Input.GetKeyDown (KeyCode.Space)) {
		//	Fire ();
		//}
		
		if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.W))
		{
			m_t.localRotation = Quaternion.identity;
			//_direction = new Vector3(1f, 0f, 0f);
		}
		
		if (Input.GetKeyDown(KeyCode.S))
		{
			m_t.Rotate(0f, 0f, -35f);
			//_direction = new Vector3(1f, -1f, 0f);
		}
		
		if (Input.GetKeyDown(KeyCode.W))
		{
			m_t.Rotate(0f, 0f, 35f);
			//_direction = new Vector3(1f, 1f, 0f);
		}
		
		if (Input.GetMouseButtonDown(0))
		{
			_direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - m_t.position;
			if (_direction != Vector3.zero)
			{
			    _direction.Normalize();
			}
			Fire();
		}
	}
	
	void Fire () 
	{
		FireBall fireClone = Instantiate (m_rb, m_t.position, m_t.rotation) as FireBall;
		fireClone.rigidbody2D.velocity = _direction * fireSpeed;
	}
}

