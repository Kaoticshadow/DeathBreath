using UnityEngine;
using System.Collections;

public class HotPepperText : MonoBehaviour {

	int peppers;
	// Use this for initialization
	void Start () {
		peppers = 0;
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<TextMesh>().text = "x" + peppers.ToString();
	}

	public void addPepper(){
		peppers++;
	}
}
