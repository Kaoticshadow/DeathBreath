using UnityEngine;
using System.Collections;

public class FlameBreath : MonoBehaviour {
	
	public Flame flamePrefab;
	Transform m_t;
	private Vector3 _direction = new Vector3 (1f, 0f, 0f);
	// Use this for initialization
	void Start () {
		m_t = this.transform;
		particleSystem.emissionRate = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Mouse0)) 
		{
			//_direction = Camera.main.ScreenToWorldPoint (Input.mousePosition) - m_t.position;
			//_direction.Normalize ();
			//float theDot = Vector3.Dot(_direction, new Vector3(1f,0f,0f));
			//if(theDot > 0)
			//{
			//	m_t.Rotate(-5f,0f,0f);
			//}
			//else
			//{
			//	m_t.Rotate(5f,0f,0f);
			//}
			
			//_direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - m_t.position;
			//_direction.Normalize();
			//float theDot = Vector3.Dot(_direction, new Vector3(1f,0f,0f));
			
			//if (theDot < 0) {
			//	m_t.Rotate (180f * -theDot, 0f, 0f);
			//}
			
			//This seems like some bad math
			//if (theDot > 0) {
			//	m_t.Rotate (180f * (1-theDot), 0f, 0f);
			//}

			particleSystem.emissionRate = 100;
			
		} 
		else 
		{
			particleSystem.emissionRate = 0;
		}
		if (Input.GetKey(KeyCode.Q)){

			Flame flame = (Flame)Instantiate (flamePrefab, this.transform.position, Quaternion.identity);
			//x.transform.localScale = new Vector2(x.transform.localScale.x,x.transform.localScale.y*fireScale);

			float x = 1;
			float y = Random.Range(-1f, 1f);
			Vector2 direction = new Vector2(x, y);
			direction = direction.normalized;

			flame.rigidbody2D.AddForce (direction * 100f);

		}
	}
}
