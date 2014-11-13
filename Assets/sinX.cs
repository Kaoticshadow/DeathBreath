using UnityEngine;
using System.Collections;

public class sinX : MonoBehaviour {

	public float position = 0.10f;
	public float speed = 4;
	float originalPosition;
	float counter;
	
	// Use this for initialization
	void Start () {
		originalPosition = this.transform.localPosition.x;	
	}

	// Update is called once per frame
	void Update () {
		counter += Time.deltaTime * speed;
		this.transform.position = new Vector3 (originalPosition + ((Mathf.Sin (counter))*position),this.transform.position.y, 0);	
	}

}
