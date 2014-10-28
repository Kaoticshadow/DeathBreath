using UnityEngine;
using System.Collections;

public class BatMovement : MonoBehaviour {

	Transform m_t;
	float amplitude;
	float frequency;



	// Use this for initialization
	void Start () {
	
		amplitude = 1.5f;
		frequency = 1.0f;
		m_t = this.transform;
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.position = new Vector3(transform.position.x - .04f, transform.position.y, transform.position.z) + amplitude*(Mathf.Sin(2*Mathf.PI*frequency*Time.time) - Mathf.Sin(2*Mathf.PI*frequency*(Time.time - Time.deltaTime)))*transform.up;


	}
}
