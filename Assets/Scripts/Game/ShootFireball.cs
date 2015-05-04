

using UnityEngine;
using System.Collections;

public class ShootFireball : MonoBehaviour {
	
	
	Transform m_t;
	public float projectileSpeed = 0.6f;
	public float cooldown = 0.2f;
	public FireBall m_rb;
	FireBall clone;
	
	private Vector2 _direction = new Vector3 (1f, 0f);
	private float nextFireTime = 0f;
	
	// Use this for initialization
	void Start () {
		m_t = this.transform;
	}
	
	// Update is called once per frame
	void Update () {	
		
		if (Input.GetMouseButtonDown(0))
		{
			if (Time.time >= nextFireTime){
				clone = Instantiate (m_rb, m_t.position, m_t.rotation) as FireBall;
				Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), GetComponent<Collider2D>());
				clone.veloc = _direction*projectileSpeed;
				nextFireTime = Time.time + cooldown;
			}
		}		
	}
}

