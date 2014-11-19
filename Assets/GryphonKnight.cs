using UnityEngine;
using System.Collections;

public class GryphonKnight : MonoBehaviour {
	
	ArrayList m_path;
	int currentIdx = 0;
	float speed = .01f;
	
	
	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		m_path = path1 ();
	
	}
	
	// Update is called once per frame
	void Update () {
		
		move ();
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

	void move() {
		if (player.transform.position.x > this.transform.position.x)
			this.transform.localScale = new Vector3 (-1, 1, 1);
		else
			this.transform.localScale = new Vector3 (1, 1, 1);
		
		
		
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
