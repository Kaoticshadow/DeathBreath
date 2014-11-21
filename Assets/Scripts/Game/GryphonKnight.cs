using UnityEngine;
using System.Collections;

public class GryphonKnight : MonoBehaviour {
	
	ArrayList m_path;
	int currentIdx = 0;
	float speed = .05f;
	public int mode;
	Vector3 offset;
	
	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");

		offset = this.transform.position.normalized * 1.5f;

		if (this.transform.position.x > 0)
						mode = 1;
				else
						mode = 0;

		switch (mode) {
			case 0:
				m_path = path1 ();
				break;
			case 1:
				m_path = path2();
				break;
			default:
				break;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		
		move ();
	}

	ArrayList path1(){
		ArrayList l_path = new ArrayList ();
		l_path.Add (new Vector3 (-13,  -4, 0));
		l_path.Add (new Vector3 ( 3.5f,  -.5f, 0));
		l_path.Add (new Vector3 ( 3.5f,  3, 0));
		l_path.Add (new Vector3 (-3,  4, 0));
		l_path.Add (new Vector3 ( 0,  0, 0));
		l_path.Add (new Vector3 ( 5,  3, 0));
		l_path.Add (new Vector3 (4,  4, 0));
	//	l_path.Add (new Vector3 (-9, -6, 0));
	//	l_path.Add (new Vector3 (5, -6, 0));
		l_path.Add (new Vector3 (1, 0, 0));
		l_path.Add (new Vector3 (0, 12, 0));
		return l_path;
	}	
	ArrayList path2(){
		ArrayList l_path = new ArrayList ();
		l_path.Add (new Vector3 (-13,  -4, 0)* -1f);
		l_path.Add (new Vector3 ( 3.5f,  -.5f, 0)* -1f);
		l_path.Add (new Vector3 ( 3.5f,  3, 0)* -1f);
		l_path.Add (new Vector3 (-3,  4, 0)* -1f);
		l_path.Add (new Vector3 ( 0,  0, 0)* -1f);
		l_path.Add (new Vector3 ( 5,  3, 0)* -1f);
		l_path.Add (new Vector3 (4,  4, 0)* -1f);
		l_path.Add (new Vector3 (-9, -6, 0)* -1f);
	//	l_path.Add (new Vector3 (5, -6, 0)* -1f);
		l_path.Add (new Vector3 (-1, 0, 0));
		l_path.Add (new Vector3 (0, 12, 0)* -1f);
		return l_path;
	}

	void move() {
		if (player.transform.position.x > this.transform.position.x)
			this.transform.localScale = new Vector3 (-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
		else
			this.transform.localScale = new Vector3 (Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

		Vector3 go = (Vector3)m_path [currentIdx]+offset;
		
		this.transform.position = Vector3.MoveTowards(this.transform.position,
		                                              go,
		                                              speed);
		
		if(this.transform.position == go)
			currentIdx++;
		if (currentIdx >= m_path.Count)
						Destroy (this.gameObject);//currentIdx=0;
	}
}
