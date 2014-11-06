using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FloatstoneWurmSegment : MonoBehaviour {

	public Vector2 destination;
	public Vector2 targetVector;
	public Vector2 originalVector;
	public float turnFraction;
	public float speed = 0.04f;
	public string hackType = "body"; // eww
	//public float destinationMoveSpeed = 0.08f;
	List<Vector2> destinations;
	int destinationIndex;
	Quaternion q1;
	Quaternion q2;
	
	
	// Use this for initialization
	void Start () {
		destinationIndex = 0;
		destinations = new List<Vector2> ();

		initializePath ();



		q1 = Quaternion.identity;
		q2 = Quaternion.identity;


		/*
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
		*/
		
		//start destination
		destination = destinations[0];
		Vector2 newVelocity = ((Vector2)destinations [destinationIndex] - (Vector2)this.transform.position);
		newVelocity.Normalize();
		this.rigidbody2D.velocity = newVelocity * speed;
		targetVector = newVelocity;
		originalVector = newVelocity;
		
	}
	
	// Update is called once per frame
	void Update () {
		//destination = GameObject.Find ("TestDest").transform.position;
		//destination = Vector2.MoveTowards (destination, destinations [destinationIndex], destinationMoveSpeed);
		//this.rigidbody2D.velocity = Vector2.MoveTowards
		//this.transform.position = Vector2.MoveTowards (this.transform.position, destination, speed);

		//Quaternion q = Quaternion.AngleAxis (Vector2.Angle(this.rigidbody2D.velocity), Vector3.forward);//positive rotates down, negative up

		this.transform.rotation = Quaternion.Slerp(q1,q2,turnFraction);

		if (Vector2.Distance (this.transform.position, destination) < 2.0f) {
			chooseNextDestination();
		}
		turnFraction+= Time.deltaTime * 3;
		//this.rigidbody2D.velocity = Vector2.Lerp(originalVector,targetVector,turnFraction) * speed;
		//this.rigidbody2D.velocity = Vector2.MoveTowards (this.transform.localPosition, destinations [destinationIndex],0.001f);
		
	}
	
	void chooseNextDestination(){
		q1 = q2;
		Vector2 prevDestination = destinations [destinationIndex];
		destinationIndex++;
		if (destinationIndex >= destinations.Count) {
			destinationIndex = 0;
		}
		destination = destinations[destinationIndex];
		//targetVector = new Vector3(destination.x,destination.y,0) - new Vector3(prevDestination.x, prevDestination.y, 0);
		targetVector = new Vector3 (destination.x, destination.y, 0) - gameObject.transform.localPosition;
		targetVector.Normalize ();
		this.rigidbody2D.velocity = targetVector * speed;
		turnFraction = 0;

		float angle = Vector2.Angle (Vector2.right, this.rigidbody2D.velocity);
		if(hackType == "head")
		{
			angle += 90.0f;
		}
		q2 = Quaternion.AngleAxis (angle, Vector3.forward);
	}

	void initializePath(){

		int i=0;
		bool cont = true;
		GameObject obj;
		while (cont) {
			obj = GameObject.Find ("d"+i);
			if(obj == null){
				cont = false;
			}
			else{
				destinations.Add (obj.transform.localPosition);
			}
			i++;
		}

		/*
		destinations.Add (GameObject.Find ("d1").transform.localPosition);
		destinations.Add (GameObject.Find ("d2").transform.localPosition);
		destinations.Add (GameObject.Find ("d3").transform.localPosition);
		destinations.Add (GameObject.Find ("d4").transform.localPosition);
		*/
	}


}
