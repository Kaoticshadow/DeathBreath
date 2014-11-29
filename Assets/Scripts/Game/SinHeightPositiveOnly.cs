using UnityEngine;
using System.Collections;

public class SinHeightPositiveOnly : MonoBehaviour {

	public float height = 0.10f;
	public float speed = 4;
	float originalHeight;
	float counter;
	
	// Use this for initialization
	void Start () {
		originalHeight = this.transform.localPosition.y;	
	}
	
	// Update is called once per frame
	void Update () {
		counter += Time.deltaTime * speed;
		this.transform.position = new Vector3 (this.transform.position.x, originalHeight + ((Mathf.Abs(Mathf.Sin (counter)))*height), 0);	
	}
}
