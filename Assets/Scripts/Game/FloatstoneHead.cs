using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FloatstoneHead : MonoBehaviour {

	public Vector2 destination;
	public Vector2 targetVector;
	public Vector2 originalVector;
	public float turnFraction;
	public float speed = 0.04f;
	public float destinationMoveSpeed = 0.08f;
	List<Vector2> destinations;
	int destinationIndex;


	// Use this for initialization
	void Start () {
		destinationIndex = 0;
		destinations = new List<Vector2> ();
		//Right to left
		destinations.Add(new Vector2 (-30f,0f));

		//top to bottom
		destinations.Add (new Vector2 (-15f, 15f));
		destinations.Add (new Vector2 (5f, 15f));
		destinations.Add (new Vector2 (5f, -15f));

		//Right into loop to top
		destinations.Add (new Vector2 (15f, -15f));
		destinations.Add (new Vector2 (15f, 5f));
		destinations.Add (new Vector2 (5f, 5f));
		destinations.Add (new Vector2 (5f, -5f));
		destinations.Add (new Vector2 (10f, -5f));
		destinations.Add (new Vector2 (10f, 15f));

		//top to bottom, curve right
		destinations.Add (new Vector2 (-5f, 15f));
		destinations.Add (new Vector2 (-5f, -5f));
		destinations.Add (new Vector2 (15f, -5f));

		//start destination
		destination = destinations[0];
		Vector2 newVelocity = ((Vector2)destinations [destinationIndex] - (Vector2)this.transform.position);
		newVelocity.Normalize();
		this.GetComponent<Rigidbody2D>().velocity = newVelocity * 3;
		targetVector = newVelocity;
		originalVector = newVelocity;

	}
	
	// Update is called once per frame
	void Update () {
		//destination = GameObject.Find ("TestDest").transform.position;
		//destination = Vector2.MoveTowards (destination, destinations [destinationIndex], destinationMoveSpeed);
		//this.rigidbody2D.velocity = Vector2.MoveTowards
		//this.transform.position = Vector2.MoveTowards (this.transform.position, destination, speed);

		if (Vector2.Distance (this.transform.position, destination) < 2.0f) {
			chooseNextDestination();
		}
		turnFraction+= Time.deltaTime;
		this.GetComponent<Rigidbody2D>().velocity = Vector2.Lerp(originalVector,targetVector,turnFraction) * 4.0f;
	
	}

	void chooseNextDestination(){
		Vector2 prevDestination = destinations [destinationIndex];
		destinationIndex++;
		if (destinationIndex >= destinations.Count) {
			destinationIndex = 0;
		}
		destination = destinations[destinationIndex];
		//targetVector = new Vector3(destination.x,destination.y,0) - new Vector3(prevDestination.x, prevDestination.y, 0);
		targetVector = new Vector3 (destination.x, destination.y, 0) - gameObject.transform.localPosition;
		targetVector.Normalize ();
		turnFraction = 0;
	}
}
