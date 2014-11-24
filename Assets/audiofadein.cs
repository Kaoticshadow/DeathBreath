using UnityEngine;
using System.Collections;

public class audiofadein : MonoBehaviour {
	float volume = 0;
	AudioSource a;
	// Use this for initialization
	void Start () {
		a = this.GetComponent<AudioSource> ();
		a.volume = volume;
	}
	
	// Update is called once per frame
	void Update () {
		a.volume = volume;
		if (volume < 1)
						volume += 0.01f;
	}
}
