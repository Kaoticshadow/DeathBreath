using UnityEngine;
using System.Collections;

public class ChampionEnemy : MonoBehaviour {

	public GameObject spicy_chicken;
	public GameObject dragon_fruit;
	public GameObject hot_pepper;
	GameObject spawnObject;
	SpriteRenderer sprite;
	SpriteRenderer[] childSprites;
	LevelManager levelManager;


	// Use this for initialization
	void Start () {

		levelManager = GameObject.FindGameObjectWithTag ("LevelManager").GetComponent<LevelManager>();
		spicy_chicken = levelManager.spicy_chicken;
		dragon_fruit = levelManager.dragon_fruit;
		hot_pepper = levelManager.hot_pepper;

		this.GetComponent<Enemy> ().health = this.GetComponent<Enemy> ().health * 2;
		childSprites = this.GetComponentsInChildren<SpriteRenderer>();
		sprite = this.GetComponent<SpriteRenderer> ();

		if (sprite != null) {
			sprite.color = new Color(1f,0.5f,0.5f,1f);
		}
		for (int i = 0; i < childSprites.Length; i++) {                
			childSprites[i].color = new Color(1f,0.5f,0.5f,1f);
		}

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
		default:
			spawnObject = dragon_fruit;
			break;
		}
		this.GetComponent<Enemy> ().drop = spawnObject;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
