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
	public float theDot;
	
	private Vector3 _direction = new Vector3 (1f, 0f, 0f);
	
	// Use this for initialization
	void Start () {
		m_t = this.transform;
		speed = 0.3f;
		fireSpeed = 15.0f;
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

			Fire ();
		}
	}
	
	void Fire () 
	{
		_direction = DragonTransform.position - m_t.position + new Vector3(0f, 1f, 0f);
		_direction.Normalize();
		theDot = Vector3.Dot(_direction, new Vector3(1f,0f,0f));
		Arrow fireClone = Instantiate (m_arrow, m_t.position, m_t.rotation) as Arrow;
		fireClone.rigidbody2D.velocity = _direction * fireSpeed;
		Physics2D.IgnoreCollision(fireClone.collider2D, collider2D);
		if (theDot < 0) {
						fireClone.transform.Rotate (0f, 0f, 180f * -theDot);
				}

		//This seems like some bad math
		if (theDot > 0) {
			fireClone.transform.Rotate (0f, 0f, 180f * (1-theDot));
		}
	}
}
