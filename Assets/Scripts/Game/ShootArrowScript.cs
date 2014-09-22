using UnityEngine;
using System.Collections;

public class ShootArrowScript : MonoBehaviour {
	
	
	Transform m_t;
	Transform DragonTransform;
	public float speed;
	public float fireSpeed;
	public Arrow m_arrow;
	public Cursor Cursor;
	public int timerCount;
	public int fireCooldown;
	
	private Vector3 _direction = new Vector3 (1f, 0f, 0f);
	
	// Use this for initialization
	void Start () {
		m_t = this.transform;
		speed = 0.3f;
		fireSpeed = 20.0f;
		timerCount = 0;
		fireCooldown = 80;
		DragonTransform = GameObject.Find("Dargon Character").transform;
		//fireSpeed = 1.0f;
		
	}
	
	// Update is called once per frame
	void Update () {
		timerCount++;
		if (timerCount >= fireCooldown) {
			timerCount = 0;
			_direction = DragonTransform.position - m_t.position + new Vector3(0f, 1f, 0f);
			_direction.Normalize();
			Fire ();
		}
	}
	
	void Fire () 
	{
		Arrow fireClone = Instantiate (m_arrow, m_t.position, m_t.rotation) as Arrow;
		fireClone.rigidbody2D.velocity = _direction * fireSpeed;
		Physics2D.IgnoreCollision(fireClone.collider2D, collider2D);
	}
}
