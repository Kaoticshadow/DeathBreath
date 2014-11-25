using UnityEngine;
using System.Collections;

public class talkinghead : MonoBehaviour {
	public TextMesh blurb;

	ArrayList texts;

	public float stringduration;
	float counter;
	public Vector3 destination;
	public float entryspeed;
	float startTime = 3f;
	int idx = 0;

	// Use this for initialization
	void Start () {
		blurb.text = "";
		texts = new ArrayList ();
		texts.Add ("string1");
		texts.Add ("string2");
		texts.Add ("");
		counter = stringduration;

	}
	
	// Update is called once per frame
	void Update () {
		startTime -= Time.deltaTime;
		this.transform.position = Vector3.Lerp (this.transform.position, destination, Time.deltaTime * entryspeed);
		if (startTime < 0) {
			blurb.text = (string)texts[idx];
			counter-=Time.deltaTime;
			if(counter<0){

				idx++;
				if(idx == texts.Count-1)
					Destroy(this.gameObject);
				counter = stringduration;
			}



		}
	}
}
