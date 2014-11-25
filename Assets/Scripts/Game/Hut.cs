using UnityEngine;
using System.Collections;

public class Hut : MonoBehaviour {
	//health
	public float health = 3;
	public GameObject spicy_chicken;
	public GameObject dragon_fruit;
	public GameObject hot_pepper;
	public GameObject busted_hut;
	GameObject spawnObject;
	LevelManager levelManager;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindGameObjectWithTag ("LevelManager").GetComponent<LevelManager>();
		spicy_chicken = levelManager.spicy_chicken;
		dragon_fruit = levelManager.dragon_fruit;
		hot_pepper = levelManager.hot_pepper;

		//determine pickup type
		int caseSwitch = Random.Range (0, 9);
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
		default:
			spawnObject = busted_hut;
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void takeDamage(float damage){
		health -= damage;
		GameObject spawnedObject;
		if (health < 0)
		{
			if(spawnObject != null){
				spawnedObject = Instantiate(spawnObject,this.transform.localPosition,Quaternion.identity) as GameObject;
				if(spawnObject == busted_hut){
					spawnedObject.transform.localScale = this.transform.localScale;
				}
			}
			//	GameObject.FindGameObjectWithTag("PopupScore").GetComponent<PopupScore>().popScore(this.transform.position);
			Destroy (this.gameObject);
			//	GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript>().increaseScore(100);
			
		}
		//score++;
	}

}
