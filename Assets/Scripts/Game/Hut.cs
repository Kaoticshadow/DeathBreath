using UnityEngine;
using System.Collections;

public class Hut : MonoBehaviour {
	//health
	public float health = 3;
	public GameObject spicy_chicken;

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
			Instantiate(spicy_chicken,this.transform.localPosition,Quaternion.identity);
			//	GameObject.FindGameObjectWithTag("PopupScore").GetComponent<PopupScore>().popScore(this.transform.position);
			Destroy (this.gameObject);
			//	GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript>().increaseScore(100);
			
		}
		//score++;
	}

}
