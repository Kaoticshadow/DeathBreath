using UnityEngine;
using System.Collections;

public class SinWind : MonoBehaviour {

	float startSpeed;
	// Use this for initialization
	void Start () {
		startSpeed = 2*this.particleSystem.startSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		this.particleSystem.startSpeed = startSpeed * Mathf.Abs(Mathf.Sin (Time.time));
	}
}
