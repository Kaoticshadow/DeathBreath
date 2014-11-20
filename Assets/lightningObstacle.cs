using UnityEngine;
using System.Collections;

public class lightningObstacle : MonoBehaviour {
	bool begin = false;
	Color c;
	bool shock = false;
	float shockcountermax = .3f;
	float shockcounter;
	SpriteRenderer s;
	AudioSource asrc;
	Vector3 orgn;
	public float cooldown;
	float currentcd;

	Animator a;

	ParticleSystem p;
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
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = orgn + new Vector3 (Mathf.Sin (currentcd), Mathf.Cos (currentcd), 0)*3;
		this.transform.Rotate (new Vector3 (0, 0, 0.2f));
		currentcd -= Time.deltaTime;
		if (currentcd < 0 && !begin)
						beginlight ();

		if (begin&&!shock) {
			c = new Color (1,1,1,c.a+Time.deltaTime*0.13f);
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

	void OnTriggerEnter2D(Collider2D col){
		if (s.color.a == 1) {
						if (col.gameObject.tag == "Player") {
								col.gameObject.SendMessage ("takeDamage");
						}
				}
	}
}
