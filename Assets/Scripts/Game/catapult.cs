using UnityEngine;
using System.Collections;

public class catapult : MonoBehaviour {
	float firingtime;
	public GameObject boulder;
	public float xFireForce = -270f;
	public float yFireForce = 400f;
	bool shot = false;
	// Use this for initialization
	void Start () {
		firingtime = Random.Range (2.3f, 2.8f);
		this.gameObject.GetComponent<Animator>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		firingtime -= Time.deltaTime;

		if (firingtime < 0) {
			this.gameObject.GetComponent<Animator>().enabled = true;
						if (this.gameObject.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("shootcatapult") && !shot) {
								Debug.Log ("hi");
								shot = true;
								boulder.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (xFireForce, yFireForce));
								boulder.GetComponent<Rigidbody2D> ().gravityScale = 1f;

						}

				}
	}
}
