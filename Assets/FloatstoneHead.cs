using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FloatstoneHead : MonoBehaviour {

	Vector2 destination;
	public float speed = 0.04f;
	public float destinationMoveSpeed = 0.08f;
	List<Vector2> destinations;
	int destinationIndex;


	// Use this for initialization
	void Start () {
		destinationIndex = 0;
		destination = new Vector2 (15f, 0f);	
		destinations = new List<Vector2> ();
		//Right to left
		destinations.Add(new Vector2 (-15f,0f));

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

	}
	
	// Update is called once per frame
	void Update () {
		//destination = GameObject.Find ("TestDest").transform.position;
		destination = Vector2.MoveTowards (destination, destinations [destinationIndex], destinationMoveSpeed);
		this.transform.position = Vector2.MoveTowards (this.transform.position, destination, speed);
		if (Vector2.Distance (this.transform.position, destination) < 2.0f) {
			chooseNextDestination();
		}
	
	}

	void chooseNextDestination(){
		destinationIndex++;
		if (destinationIndex >= destinations.Count) {
			destinationIndex = 0;
		}
		destination = destinations[destinationIndex];
	}
}
