

using UnityEngine;
using System.Collections;

public class ForwardFire : MonoBehaviour {
	
	
	Transform m_t;
	public float speed;
	public float fireSpeed;
	public FireBall m_rb;
	public Cursor Cursor;
	FireBall clone;
	
	private Vector3 _direction = new Vector3 (1f, 0f, 0f);
	
	// Use this for initialization
	void Start () {
		m_t = this.transform;
		speed = 0.3f;
		fireSpeed = 0.5f;
		//fireSpeed = 1.0f;
		
	}
	
	// Update is called once per frame
	void Update () {

	
		
		if (Input.GetMouseButtonDown(0))
		{
			//_direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - m_t.position;
			//_direction.Normalize();

			clone = Instantiate (m_rb, m_t.position, m_t.rotation) as FireBall;
			Physics2D.IgnoreCollision(clone.collider2D, collider2D);
			clone.veloc = _direction*fireSpeed;
			//fireClone.rigidbody2D.velocity = _direction * fireSpeed;
		}
		
		//clone.transform.position = clone.transform.position + (_direction * fireSpeed);
	}

}

