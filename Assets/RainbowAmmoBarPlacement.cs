using UnityEngine;
using System.Collections;

public class RainbowAmmoBarPlacement : MonoBehaviour {

	Camera mainCamera;
	// Use this for initialization
	void Start () {
		mainCamera = GameObject.Find ("Main Camera").GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate(){
		Vector3 p = mainCamera.ScreenToWorldPoint(new Vector3(50, mainCamera.pixelHeight - 50, mainCamera.orthographicSize));
		this.transform.position = p;
	}
}
