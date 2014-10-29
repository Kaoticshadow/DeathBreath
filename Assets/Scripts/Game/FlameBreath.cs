using UnityEngine;
using System.Collections;

public class FlameBreath : MonoBehaviour {
	
	public Flame flamePrefab;
	Transform m_t;
	private Vector3 _direction = new Vector3 (1f, 0f, 0f);
	// Use this for initialization
	void Start () {
		m_t = this.transform;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.Q)){

			Flame flame = (Flame)Instantiate (flamePrefab, this.transform.position, Quaternion.identity);
			//x.transform.localScale = new Vector2(x.transform.localScale.x,x.transform.localScale.y*fireScale);

			float x = 1;
			float y = Random.Range(-0.8f, 0.8f);
			Vector2 direction = new Vector2(x, y);
			direction = direction.normalized;
			float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
			flame.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			flame.rigidbody2D.AddForce (direction * 100f);
			flame.power = 1;
		}
	}
}
