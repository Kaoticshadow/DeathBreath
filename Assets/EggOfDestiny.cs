using UnityEngine;
using System.Collections;

public class EggOfDestiny : MonoBehaviour {

	public GameObject eggHatching;
	public GameObject explosionPrefab;
	GameObject odin;
	bool winning = false;
	// Use this for initialization
	void Start () {
		odin = GameObject.Find ("OdinParent");
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
		StartCoroutine ("playDeathAnimation");
	}

	IEnumerator playDeathAnimation(){
		//this.GetComponent<Animator>().enabled = false;

		yield return new WaitForSeconds(4.0f);
		Instantiate (explosionPrefab, odin.transform.position, Quaternion.identity);
		yield return new WaitForSeconds(0.5f);
		Destroy (odin);


		//GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().stopMusic();
		//GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().playMusic2();
		yield return new WaitForSeconds(5f);
		Application.LoadLevel ("Credits");
//		GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>().endLevel(new Vector2(900.0f, 300.0f));
		//this.transform.parent.rigidbody2D.AddForce(new Vector2(0f,-100f));
		//yield return new WaitForSeconds(10.0f);

		//Destroy (this.transform.parent.parent.gameObject);
	}


}
