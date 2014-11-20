using UnityEngine;
using System.Collections;

public class Hut : MonoBehaviour {
	//health
	public float health = 3;
	public GameObject spicy_chicken;
	public GameObject dragon_fruit;
	public GameObject hot_pepper;
	GameObject spawnObject;
	LevelManager levelManager;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindGameObjectWithTag ("LevelManager").GetComponent<LevelManager>();
		spicy_chicken = levelManager.spicy_chicken;
		dragon_fruit = levelManager.dragon_fruit;
		hot_pepper = levelManager.hot_pepper;

		//determine pickup type
		int caseSwitch = Random.Range (0, 3);
		switch (caseSwitch)
		{
		case 0:
			spawnObject = spicy_chicken;
			break;
		case 1:
			spawnObject = hot_pepper;
			break;
		case 2:
			spawnObject = dragon_fruit;
			break;
		case 3:
			spawnObject = null;
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void takeDamage(float damage){
		health -= damage;
		if (health < 0)
		{
			if(spawnObject != null){
				Instantiate(spawnObject,this.transform.localPosition,Quaternion.identity);
			}
			//	GameObject.FindGameObjectWithTag("PopupScore").GetComponent<PopupScore>().popScore(this.transform.position);
			Destroy (this.gameObject);
			//	GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript>().increaseScore(100);
			
		}
		//score++;
	}

}
