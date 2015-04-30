using UnityEngine;
using System.Collections;

public class ParticleSortLayerScript : MonoBehaviour {

	public string sortingLayerName = "Foreground";
	public int sortingLayerOrder = 1;
	public float lifeTime = 10.0f;
	
	// Use this for initialization
	void Start () {
		//Change Foreground to the layer you want it to display on
		//You could prob. make a public variable for this
		particleSystem.renderer.sortingLayerName = sortingLayerName;
		particleSystem.renderer.sortingOrder = sortingLayerOrder;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
