using UnityEngine;
using System.Collections;

public class audiofadein : MonoBehaviour {
	float volume = 0;
	AudioSource a;
	public float max;
	// Use this for initialization
	void Start () {
		a = this.GetComponent<AudioSource> ();
		a.volume = volume;
		if (max == 0)
						max = 1;
	}
	
	// Update is called once per frame
	void Update () {
		a.volume = volume;
		if (volume < max)
						volume += 0.01f;
	}
}
