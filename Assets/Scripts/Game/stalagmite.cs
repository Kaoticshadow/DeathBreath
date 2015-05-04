using UnityEngine;
using System.Collections;

public class stalagmite : MonoBehaviour {
	GameObject player;
	public float stalagmiteLaunchDistance = 5f;
	public bool loose;
	float actualLaunchDistance;

	// Use this for initialization
	void Start () {
		loose = false;
		player = GameObject.FindGameObjectWithTag("Player");
		actualLaunchDistance = stalagmiteLaunchDistance; //* Random.Range(0.8f,1.2f);
	}
	
	// Update is called once per frame
	void Update () {
		if(Mathf.Abs(player.transform.position.x - this.transform.position.x) < actualLaunchDistance){
			loose = true;
		}
		if(loose){
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,100f*Time.deltaTime));
		}
	}
}
