using UnityEngine;
using System.Collections;

public class RandomMoveScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public float maxX = 5.1f;
	public float minX = -10.1f;
	public float maxY = 2.2f;
	public float minY = -4.2f;
	public float moveSpeed = 1.5f;
	
	private float tChange = 0f; // force new direction in the first Update
	private float randomX;
	private float randomY;
	
	void Update () {
		// change to random direction at random intervals
		if (Time.time >= tChange){
			randomX = Random.Range(-2.0f,2.0f); // with float parameters, a random float
			randomY = Random.Range(-2.0f,2.0f); // between -2.0 and 2.0 is returned
			// set a random interval between 0.5 and 1.5
			tChange = Time.time + Random.Range(0.5f,1.5f);
		}
		transform.Translate(new Vector2(randomX,randomY) * moveSpeed * Time.deltaTime);
		// if object reached any border, revert the appropriate direction
		if (transform.position.x >= maxX || transform.position.x <= minX) {
			randomX = -randomX;
		}
		if (transform.position.y >= maxY || transform.position.y <= minY) {
			randomY = -randomY;
		}
		// make sure the position is inside the borders
		transform.localPosition = new Vector2(Mathf.Clamp(transform.position.x, minX, maxX),Mathf.Clamp(transform.position.y, minY, maxY));
	}
}
