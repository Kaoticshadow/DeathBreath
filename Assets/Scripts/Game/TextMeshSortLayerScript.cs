﻿using UnityEngine;
using System.Collections;

public class TextMeshSortLayerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//textmesh.renderer.sortingLayerName = "UI";
		this.GetComponent<Renderer>().sortingLayerName = "UI";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
