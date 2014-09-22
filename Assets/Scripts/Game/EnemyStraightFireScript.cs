using UnityEngine;
using System.Collections;

public class EnemyStraightFireScript : MonoBehaviour {
		
		
	Transform m_t;
	Transform DragonTransform;
	public float speed;
	public float fireSpeed;
	public FireBall m_rb;
	public Cursor Cursor;
	public int timerCount;
	public int fireCooldown;
	
	private Vector3 _direction = new Vector3 (1f, 0f, 0f);
	
	// Use this for initialization
	void Start () {
		m_t = this.transform;
		speed = 0.3f;
		fireSpeed = 10.0f;
		timerCount = 0;
		fireCooldown = 120;
		DragonTransform = GameObject.Find("Dargon Character").transform;
		//fireSpeed = 1.0f;
		
	}
	
	// Update is called once per frame
	void Update () {
		timerCount++;
		if (timerCount >= fireCooldown) {
			timerCount = 0;
			_direction = DragonTransform.position - m_t.position;
			_direction.Normalize();
			Fire ();
		}
	}
	
	void Fire () 
	{
		FireBall fireClone = Instantiate (m_rb, m_t.position, m_t.rotation) as FireBall;
		fireClone.rigidbody2D.velocity = _direction * fireSpeed;
	}
}