using UnityEngine;
using System.Collections;

public class throneroom : MonoBehaviour {
	public Camera mc;
	bool started = false;
	float firstTimer = 2f;
	float endTimer= 3f;
	public GameObject part;
	ParticleSystem p;
	float ntime = 0.1f;
	int particles = 1;

	public GameObject cloud;
	SpriteRenderer sr;

	Vector3 basepos;

	float alphactr = 0f;

	int offset = 1;
	// Use this for initialization
	void Start () {
		basepos = mc.transform.position;
		p = part.GetComponent<ParticleSystem> ();
		sr = cloud.GetComponent<SpriteRenderer> ();
		sr.color = new Color (1, 1, 1, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (started) {

			firstTimer-= Time.deltaTime;
			if(firstTimer<0){
				endTimer-= Time.deltaTime;
				ntime-= Time.deltaTime;
					mc.transform.position = Vector3.Lerp(mc.transform.position, basepos + new Vector3(offset,0,0), 0.1f);
					if(ntime<0)
						swap();
				if(endTimer<0){
					if(p.particleCount<p.maxParticles)
						p.Emit (particles);
					sr.color = new Color(1,1,1,alphactr);
					alphactr += 0.003f;
				
				}
			}
		}
		if (endTimer < -8f) {
			Application.LoadLevel("final destination");
			//load next scene
				}
	}

	void hit(){
		started = true;
	}

	void swap(){
		offset= -offset;
		ntime = 0.1f;
	}
}
