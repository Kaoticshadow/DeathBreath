using UnityEngine;
using System.Collections;

public class EggOfDestiny : MonoBehaviour {

	public GameObject eggHatching;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			PlayWinningAnimation ();
		}		
	}

	void PlayWinningAnimation(){
		GameObject DragonOfDestiny = Instantiate (eggHatching, this.transform.position, Quaternion.identity) as GameObject;
	}


}
