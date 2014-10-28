using UnityEngine;
using System.Collections;

public class KnightBossHealth : MonoBehaviour {

	public float health = 100.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void takeDamage(float damage){
		health -= damage;
		if (health < 0)
		{
			//Instantiate(spicy_chicken,this.transform.localPosition,Quaternion.identity);
			//	GameObject.FindGameObjectWithTag("PopupScore").GetComponent<PopupScore>().popScore(this.transform.position);
			Destroy (this.transform.parent.parent.gameObject);
			GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().stopMusic();
			GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().playMusic2();
			//	GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript>().increaseScore(100);
			
		}
		//score++;
	}
}
