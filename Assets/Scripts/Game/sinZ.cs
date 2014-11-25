using UnityEngine;
using System.Collections;

public class sinZ : MonoBehaviour {

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = this.transform.position + new Vector3(0.0f,Time.deltaTime,-Time.deltaTime);
		this.camera.orthographicSize += Time.deltaTime;
	}
}
