using UnityEngine;
using System.Collections;

public class SinWind : MonoBehaviour {

	float startSpeed;
	// Use this for initialization
	void Start () {
		startSpeed = 2*this.GetComponent<ParticleSystem>().startSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<ParticleSystem>().startSpeed = startSpeed * Mathf.Abs(Mathf.Sin (Time.time));
	}
}
