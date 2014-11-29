using UnityEngine;
using System.Collections;

public class PersistentInformation : MonoBehaviour {


	public string levelToLoad = "Cave";
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this.gameObject);
		//levelToLoad = Application.loadedLevelName;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
