using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IAmARainbow : MonoBehaviour {

	SpriteRenderer[] childSprites;
	Vector3 currentColor;
	Vector3 targetColor;
	List<Vector3> colors;
	int colorIndex;
	public float rateOfChange = 0.25f;

	// Use this for initialization
	void Start () {
		childSprites = this.GetComponentsInChildren<SpriteRenderer>();
		currentColor = new Vector3 (1f, 1f, 1f);
		colors = new List<Vector3> ();
		colorIndex = 0;

		/*
		colors.Add(new Vector3(1f,1f,1f));
		colors.Add(new Vector3(1f,0f,1f));
		colors.Add(new Vector3(1f,0f,0f));
		colors.Add(new Vector3(0f,0f,0f));
		colors.Add(new Vector3(0f,1f,0f));
		colors.Add(new Vector3(0f,0f,1f));
		colors.Add(new Vector3(1f,0f,0f));
		colors.Add(new Vector3(1f,1f,1f));
		colors.Add(new Vector3(1f,1f,1f));
		colors.Add(new Vector3(1f,1f,1f));
		colors.Add(new Vector3(1f,1f,1f));
		colors.Add(new Vector3(1f,1f,1f));
		colors.Add(new Vector3(1f,1f,1f));
		colors.Add(new Vector3(1f,1f,1f));
		colors.Add(new Vector3(1f,1f,1f));
		*/

		colors.Add (new Vector3 (Color.red.r, Color.red.g, Color.red.b));
		colors.Add (new Vector3 (Color.magenta.r, Color.magenta.g, Color.magenta.b));
		colors.Add (new Vector3 (Color.blue.r, Color.blue.g, Color.blue.b));
		colors.Add (new Vector3 (Color.cyan.r, Color.cyan.g, Color.cyan.b));
		colors.Add (new Vector3 (Color.green.r, Color.green.g, Color.green.b));
		colors.Add (new Vector3 (Color.gray.r, Color.gray.g, Color.gray.b));
		colors.Add (new Vector3 (Color.yellow.r, Color.yellow.g, Color.yellow.b));
		colors.Add (new Vector3 (Color.white.r, Color.white.g, Color.white.b));
		//colors.Add (new Vector3 (Color.black.r, Color.black.g, Color.black.b));
		//colors.Add (new Vector3 (Color.clear.r, Color.clear.g, Color.clear.b));



	


		//targetColor = new Vector3(Random.Range(0.3f,1.0f),Random.Range(0.3f,1.0f),Random.Range(0.3f,1.0f));
		targetColor = colors [0];

	}
	
	// Update is called once per frame
	void Update () {
		currentColor = Vector3.Lerp (currentColor, targetColor, rateOfChange);
		if (Vector3.Distance(currentColor, targetColor) < 0.05f) {
			//targetColor = new Vector3(Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f));
			colorIndex = (colorIndex+1) % colors.Count;
			targetColor = colors[colorIndex];
		}
		for (int i = 0; i < childSprites.Length; i++) {                
			childSprites[i].color = new Color(currentColor.x,currentColor.y,currentColor.z,1f);
		}
	}
}
