using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour {

	Transform m_t;
	public int depth;
	public int max;
	float speed;
	public float speedFactor;

	// Use this for initialization
	void Start () {
		max++;
		m_t = this.transform;
		setSpeed (depth);
	}

	void setSpeed(int depth){
		speed = (max-depth) * speedFactor;
	}
	
	// Update is called once per frame
	void Update () {
		m_t.localPosition = m_t.localPosition + new Vector3 (-speed, 0, 0);

		if (m_t.localPosition.x < -15)
						m_t.localPosition = new Vector3 (13, m_t.localPosition.y, m_t.localPosition.z);

	}
}
