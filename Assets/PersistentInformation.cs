using UnityEngine;
using System.Collections;

public class PersistentInformation : MonoBehaviour {


	public string levelToLoad;
	// Use this for initialization
	void Start () {
		levelToLoad = Application.loadedLevelName;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
