using UnityEngine;
using System.Collections;

public class FlameBreath : MonoBehaviour {
	TextMesh t;
	public bool canfire = true;
	float ammomax = 1f;
	public float ammo;
	public Flame flamePrefab;
	Transform m_t;
	private Vector3 _direction = new Vector3 (1f, 0f, 0f);
	// Use this for initialization
	void Start () {
		m_t = this.transform;
		ammo = ammomax;
		t = GameObject.FindGameObjectWithTag ("peppertext").GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
		string s = t.text;
		s = s.Substring (1, s.Length-1);
		ammomax = (float.Parse (s)/4 )+1;
		if ((Input.GetKey (KeyCode.R) || Input.GetKey (KeyCode.RightControl) ) &&( ammo > 0.1f )&& canfire) {
			if(ammo<0.2f){
				canfire= false;
			}

						Flame flame = (Flame)Instantiate (flamePrefab, this.transform.position, Quaternion.identity);
						//x.transform.localScale = new Vector2(x.transform.localScale.x,x.transform.localScale.y*fireScale);

						float x = 1;
						float y = Random.Range (-0.8f, 0.8f);
						Vector2 direction = new Vector2 (x, y);
						direction = direction.normalized;
						float angle = (Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg);
						flame.transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
						flame.rigidbody2D.AddForce (direction * 100f);
						flame.power = 0.15f;
						ammo -= 0.01f;
				} else if(ammo<ammomax) {
					ammo+=Time.deltaTime*0.1f;
					if(ammo>0.5f)
						canfire = true;
						}
	}
}
