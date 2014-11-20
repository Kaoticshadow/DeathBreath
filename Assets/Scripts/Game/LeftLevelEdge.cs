using UnityEngine;
using System.Collections;

public class LeftLevelEdge : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (!(coll.gameObject.tag == "Player")) 
		{
			if(coll.gameObject.GetComponent<ExtraTags>() != null && coll.gameObject.GetComponent<ExtraTags>().tagList.Contains("Unbounded")){
				//Don't do anything
			}
			else{
				Destroy(coll.gameObject);
			}
		}
	}
}
