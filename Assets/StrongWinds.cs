using UnityEngine;
using System.Collections;

public class StrongWinds : MonoBehaviour {

	public GameObject player;
	public float windForce = 10f;
	public float playerMaxY = 10f;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		player.rigidbody2D.AddForce (new Vector2(-Mathf.Abs(Mathf.Sin (Time.time) * windForce * Time.deltaTime), Mathf.Sin (Time.time) * Time.deltaTime));
		if (player.transform.position.y > playerMaxY) {
			player.rigidbody2D.AddForce(new Vector2(-windForce * Time.deltaTime,0f));
		}
	}
}
