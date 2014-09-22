

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
		fireSpeed = 25.0f;
		//fireSpeed = 1.0f;
		
	}
	
	// Update is called once per frame
	void Update () {

	
		
		if (Input.GetMouseButtonDown(1))
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

