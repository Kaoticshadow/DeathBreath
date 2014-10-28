using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {

	public AudioSource source1;
	public AudioSource source2;




	// Use this for initialization
	void Start () {

		source1.Play ();

	
	}
	
	// Update is called once per frame
	void Update () {
	

	


	}

	public void playMusic()
	{
		if(source2.isPlaying == false)
		{
			source2.Play ();
		}

	}

	public void stopMusic()
	{
		source1.Stop ();
	}


}
