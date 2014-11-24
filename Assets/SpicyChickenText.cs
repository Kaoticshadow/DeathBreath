using UnityEngine;
using System.Collections;

public class SpicyChickenText : MonoBehaviour {

	int chickens;
	// Use this for initialization
	void Start () {
		chickens = 0;
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<TextMesh>().text = "x" + chickens.ToString();
	}

	public void addChicken(){
		chickens++;
	}
}
