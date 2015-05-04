using UnityEngine;
using System.Collections;

public class Cart : MonoBehaviour {

	public float health = 3;
	public GameObject dragon_fruit;
	GameObject spawnObject;
	LevelManager levelManager;
	
	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindGameObjectWithTag ("LevelManager").GetComponent<LevelManager>();
		dragon_fruit = levelManager.dragon_fruit;
		
		//determine pickup type
		spawnObject = dragon_fruit;
			
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
				spawnedObject = Instantiate(spawnObject,this.transform.localPosition + new Vector3(0f,1f,0f),Quaternion.identity) as GameObject;
			}
			//	GameObject.FindGameObjectWithTag("PopupScore").GetComponent<PopupScore>().popScore(this.transform.position);
			Destroy (this.gameObject);
			//	GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript>().increaseScore(100);
			
		}
		//score++;
	}

}
