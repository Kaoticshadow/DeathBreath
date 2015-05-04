using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RainbowAmmo : MonoBehaviour {

	LineRenderer rainbowRenderer;
	Color c1;
	Color c2;
	Color c1target;
	Color c2target;
	float counter;
	List<Color> colors;
	int colorIndex1;
	int colorIndex2;
	RainbowBeam f;
	Vector3 originalPosition;
	Camera mainCamera;
	
	
	// Use this for initialization
	void Start () {
		mainCamera = GameObject.Find ("Main Camera").GetComponent<Camera> ();

		originalPosition = this.transform.position;		
		colors = new List<Color> ();
		f = GameObject.FindGameObjectWithTag ("Player").GetComponentInChildren<RainbowBeam> ();
		Debug.Log (f);
		
		
		colors.Add (Color.red);
		colors.Add (new Color (0.2f, 0.3f, 0.4f)); //orange?
		colors.Add (Color.yellow);
		colors.Add (Color.green);
		colors.Add (Color.blue);
		colors.Add (new Color(75f/255f,0,130f/255f)); //indigo?
		colors.Add (new Color (138f / 255f, 43f / 255f, 226f / 255f)); //violet?
		
		rainbowRenderer = this.GetComponent<LineRenderer> ();
		rainbowRenderer.sortingLayerName = "UI";
		rainbowRenderer.sortingOrder = 0;
		
		c1 = Color.blue;
		c2 = Color.red;
		c1target = Color.red;
		c2target = Color.blue;
		colorIndex1 = 0;
		colorIndex2 = 1;
		counter = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 p1 = mainCamera.ScreenToWorldPoint(new Vector3(50, mainCamera.pixelHeight - 50, mainCamera.orthographicSize));
		Vector3 p2 = p1 + new Vector3 ((f.ammo) * 10f, 0, 0);
		counter += Time.deltaTime * 15f;		
		
		if (counter >= 1) {
			counter = 0;
			colorIndex1 = (colorIndex1 + 1) % (colors.Count);
			colorIndex2 = (colorIndex2 + 1) % (colors.Count);
			c1target = colors[colorIndex1];
			c2target = colors[colorIndex2];
		}
		
		c1 = Color.Lerp (c1, c1target, counter);
		c2 = Color.Lerp (c2, c2target, counter);
		c1 = new Color (c1.r, c1.g, c1.b, 1);
		c2 = new Color (c2.r, c2.g, c2.b, 1);
		
		rainbowRenderer.SetColors(c2,c1);
		rainbowRenderer.SetPosition(0, p1);
		rainbowRenderer.SetPosition(1, p2);
	}
}
