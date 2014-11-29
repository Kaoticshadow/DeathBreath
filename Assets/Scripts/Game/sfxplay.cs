using UnityEngine;
using System.Collections;

public class sfxplay : MonoBehaviour {
	public AudioSource a;
	// Use this for initialization
	void Start () {
		a = this.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void pplay(){
		Debug.Log ("fusrodah!");
		a.Play ();
	}
}
