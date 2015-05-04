using UnityEngine;
using System.Collections;

public class StalactiteScript : MonoBehaviour {

	GameObject go;
	Vector2 newVec;
	Vector2 originalVec;
	Vector2 storageVec;
	Vector2 oldVec;
	float jiggleCounter;
	bool jiggling;
	bool noMoreJiggling;
	float jiggleDist;
	float jiggleTime;


	// Use this for initialization
	void Start () {
		jiggleCounter = 0;
		jiggling = false;
		noMoreJiggling = false;
		originalVec = this.transform.position;
		newVec = new Vector2 (originalVec.x + 0.1f, originalVec.y);
		oldVec = originalVec;
		jiggleDist = Random.Range (1f, 6f);
		jiggleTime = Random.Range (0.5f, 1f);

	}
		

	
	// Update is called once per frame
	void Update () {

		jiggleCounter += Time.deltaTime * 10;

		go = GameObject.FindGameObjectWithTag ("Player");


		if(Mathf.Abs (this.transform.position.x - go.transform.position.x) < jiggleDist && noMoreJiggling == false)
		{

			jiggling = true;
		}

		if(jiggling == true)
		{
			this.transform.position = Vector2.Lerp (oldVec, newVec, jiggleCounter);

			
			
			if(jiggleCounter >= 1)
			{
				jiggleCounter = 0;
				storageVec = oldVec;
				oldVec = newVec;
				newVec = storageVec;
			}

			jiggleTime -= Time.deltaTime;

		}
		if(jiggleTime <= 0)
		{
			noMoreJiggling = true;
			jiggling = false;
			fall ();
		}



	}

	public void fall()
	{
		if(Random.value >= 0.5)
		{
			this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -300.0f));
		}

	}

	


}
