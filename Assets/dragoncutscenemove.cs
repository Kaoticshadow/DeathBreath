using UnityEngine;
using System.Collections;

public class dragoncutscenemove : MonoBehaviour {
	public Vector3 destination;
	public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = Vector3.Lerp (this.transform.position, destination, speed*Time.deltaTime);
	}
}
