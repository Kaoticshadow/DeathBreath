using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class firerainbow : MonoBehaviour {

	LineRenderer rainbowRenderer;
	Color c1;
	Color c2;
	Color c1target;
	Color c2target;
	float counter;
	List<Color> colors;
	int colorIndex1;
	int colorIndex2;
	FlameBreath f;
	
	
	// Use this for initialization
	void Start () {

		colors = new List<Color> ();
		f = GameObject.FindGameObjectWithTag ("Player").GetComponentInChildren<FlameBreath> ();
		Debug.Log (f);

		
		colors.Add (Color.red);
		colors.Add (new Color (0.5f, 0.3f, 0.4f)); //orange?
		colors.Add (Color.yellow);
		
		rainbowRenderer = this.GetComponent<LineRenderer> ();
		rainbowRenderer.sortingLayerName = "UI";
		rainbowRenderer.sortingOrder = 12;

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
		rainbowRenderer.SetPosition(0, this.transform.position);
		rainbowRenderer.SetPosition(1, this.transform.position+new Vector3(f.ammo-0.2f,0,0));
	}
}
