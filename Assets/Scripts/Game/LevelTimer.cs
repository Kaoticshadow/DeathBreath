using UnityEngine;
using System.Collections;

public class LevelTimer : MonoBehaviour {

	LevelManager levelManager;
	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		this.guiText.text = levelManager.time.ToString();	
	}
}
