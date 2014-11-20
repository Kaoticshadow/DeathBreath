using UnityEngine;
using System.Collections;

public class lightningObstacle : MonoBehaviour {
	bool begin = false;
	Color c;
	bool shock = false;
	float shockcountermax = .2f;
	float shockcounter;
	SpriteRenderer s;
	AudioSource asrc;
	Vector3 orgn;
	public float cooldown;
	float currentcd;

	Animator a;

	GameObject flash;

	public int type;

	ParticleSystem p;
	float counter;
	// Use this for initialization
	void Start () {
		orgn = this.transform.position;
		c = new Color (1, 1, 1, 0);
		s = this.GetComponent<SpriteRenderer> ();
		s.color = c;
		shockcounter = shockcountermax;
		asrc = this.GetComponent<AudioSource> ();
		currentcd = cooldown;
		p = this.GetComponent<ParticleSystem> ();
		a = this.GetComponent<Animator> ();
		flash = GameObject.FindGameObjectWithTag ("Flash");
	}
	
	// Update is called once per frame
	void Update () {

		counter += Time.deltaTime;
		switch (type) {
		case 0 :		this.transform.Rotate (new Vector3 (0, 0, 0.2f));
			break;
		case 1:			this.transform.position = orgn + new Vector3 (Mathf.Sin (counter),0, 0)*7;
			break;
		case 2: 	this.transform.position = orgn + new Vector3 (0,Mathf.Sin (counter), 0)*7;
			break;
		default: break;
				}





		currentcd -= Time.deltaTime;
		if (currentcd < 0 && !begin)
						beginlight ();

		if (begin&&!shock) {
			c = new Color (1,1,1,c.a+Time.deltaTime*0.18f);
			s.color = c;
			if(c.a>=0.25f)
			{
				shock = true;
				c = new Color(1,1,1,0);
				asrc.Play();
			}
		}
		if (shock) {
			s.color = new Color (1,1,1,1);
			p.Emit(25);
			shockcounter-=Time.deltaTime;
			if(shockcounter<=0){
				flash.SendMessage("flash");
				s.color = new Color(1,1,1,0);
			//	a.enabled = false;
				shockcounter = shockcountermax;
				shock = false;
				begin = false;
				currentcd=cooldown;
			//	this.gameObject.SetActive(false);
			}
		}
	}

	void beginlight(){
		begin = true;
	}

	void OnTriggerStay2D(Collider2D col){
		if (s.color.a == 1) {
						if (col.gameObject.tag == "Player") {
								col.gameObject.SendMessage ("takeDamage");
						}
				}
	}
}
