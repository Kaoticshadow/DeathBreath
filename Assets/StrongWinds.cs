using UnityEngine;
using System.Collections;

public class StrongWinds : MonoBehaviour {

	public GameObject player;
	public float windForce = 10f;
	public float playerMaxY = 10f;
	public float startDelay = 3f;
	public bool started;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		player.GetComponent<DragonMove>().disableControls = true;
	}
	
	// Update is called once per frame
	void Update () {
		startDelay -= Time.deltaTime;
		if (startDelay < 0f) {
			started = true;
			player.GetComponent<DragonMove>().disableControls = false;
		}						

		if (started) {
			player.rigidbody2D.AddForce (new Vector2 (-Mathf.Abs (Mathf.Sin (Time.time) * windForce * Time.deltaTime), Mathf.Sin (Time.time) * Time.deltaTime));
			if (player.transform.position.y > playerMaxY) {
					player.rigidbody2D.AddForce (new Vector2 (-windForce * Time.deltaTime, 0f));
			}
		}
	}
}
