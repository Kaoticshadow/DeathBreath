using UnityEngine;
using System.Collections;

public class Wizard : MonoBehaviour {

	ArrayList m_path;
	int currentIdx = 0;
	float speed = .01f;

	public wizFus sht;
	public float shootctr = 5f;
	float currentShootCtr;
	public GameObject shotsource;
	GameObject player;

	Animator anim;

	// Use this for initialization
	void Start () {
		m_path = path1 ();
		currentShootCtr = shootctr;
		anim = this.GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	ArrayList path1(){
		ArrayList l_path = new ArrayList ();
		l_path.Add (new Vector3 (-1,  0, 0));
		l_path.Add (new Vector3 ( 1,  0, 0));
		l_path.Add (new Vector3 ( 1,  1, 0));
		l_path.Add (new Vector3 (-1,  1, 0));
		l_path.Add (new Vector3 ( 0,  0, 0));
		l_path.Add (new Vector3 ( 2,  2, 0));
		l_path.Add (new Vector3 (-1,  2, 0));
		l_path.Add (new Vector3 (-1, -1, 0));
		return l_path;
	}
	
	// Update is called once per frame
	void Update () {
		move ();
		shoot ();
	}

	void shoot(){
		currentShootCtr -= Time.deltaTime;

		if (currentShootCtr <= 0) {
			currentShootCtr = shootctr;
			wizFus x = Instantiate(sht, shotsource.transform.position, Quaternion.identity) as wizFus;
			x.target = player.transform;
			x.startspot = shotsource.transform;
			anim.Play("Wiz");
		}

	}

	void move() {
		if (player.transform.position.x > this.transform.position.x)
			this.transform.localScale = new Vector3 (-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
		else
			this.transform.localScale = new Vector3 (Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
		
		
		
		Vector3 go = (Vector3)m_path [currentIdx];

		this.transform.position = Vector3.MoveTowards(this.transform.position,
              	                                        go,
              	                                        speed);

		if(this.transform.position == go)
			currentIdx++;
		if(currentIdx>=m_path.Count)
			currentIdx=0;
	}
}
