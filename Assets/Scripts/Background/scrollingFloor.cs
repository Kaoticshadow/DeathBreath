using UnityEngine;
using System.Collections;

public class scrollingFloor : MonoBehaviour {

	public float speed;
	Transform m_t;
	// Use this for initialization
	void Start () {
		m_t = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(m_t.localPosition.x < -13)
			m_t.localPosition = new Vector3 (13, m_t.localPosition.y, m_t.localPosition.z);
		m_t.localPosition = new Vector3 (m_t.localPosition.x - speed, m_t.localPosition.y, m_t.localPosition.z);
	}
}
