using UnityEngine;
using System.Collections;

public class FinalDestinationCamera : MonoBehaviour {

	public float initialCameraSize;
	public float minimumCameraSize = 2.5f;
	public float maximumCameraSize = 10.0f;
	public float rateOfChange;
	public float targetSizeRatio;
	public float initialY;
	public float initialParticleRadius;
	float sizeRatio;
	GameObject player;
	GameObject odin;
	GameObject egg;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		egg = GameObject.FindGameObjectWithTag ("egg");
		initialCameraSize = this.camera.orthographicSize;
		initialY = this.transform.position.y;	
	}
	
	// Update is called once per frame
	void Update () {
		//sizeRatio = Mathf.Abs(player.transform.position.x / 8f);
		sizeRatio = Vector3.Distance(player.transform.position,egg.transform.position)/7.5f;
		sizeRatio = Mathf.Clamp(sizeRatio, 0.5f,3f);

		this.camera.orthographicSize = initialCameraSize * sizeRatio;
		this.transform.position = new Vector3(this.transform.position.x,initialY+sizeRatio*2.7f,this.transform.position.z);// + new Vector3 (0f, sizeRatio, 0f);
	}
}
