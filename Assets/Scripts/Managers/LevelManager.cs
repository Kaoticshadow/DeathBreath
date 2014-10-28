using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

	public GameObject archer;
	public GameObject tower;
	public GameObject knight_boss;
	public GameObject goombat;
	public GameObject hut;
	public GameObject spicy_chicken;
	GameObject leftLevelEdge;
	GameObject rightLevelEdge;
	SpawnableEntityContainer m_spawnableEntityCollection;
	Dictionary<string, GameObject> spawnableEntityDictionary; 

	void Start () {
		m_spawnableEntityCollection = SpawnableEntityContainer.Load(Path.Combine(Application.dataPath, "Data/Town.xml"));
		leftLevelEdge = GameObject.Find("Left Level Edge");
		rightLevelEdge = GameObject.Find("Right Level Edge");
		initializeSpawnableEntityDictionary();	
	}
	
	// Update is called once per frame
	void Update () {
		foreach(SpawnableEntity entity in m_spawnableEntityCollection.SpawnableEntities)
		{
			if(!entity.spawned && Time.time >= entity.time)
			{
				entity.spawned = true;
				GameObject spawnedObject = (GameObject)Instantiate (spawnableEntityDictionary[entity.name], rightLevelEdge.transform.position + new Vector3(entity.x,entity.y,0), rightLevelEdge.transform.rotation);
				if(entity.x_scale == 0){entity.x_scale = 1;}
				if(entity.y_scale == 0){entity.y_scale = 1;}
				spawnedObject.transform.localScale = new Vector3(entity.x_scale,entity.y_scale);

			}
		}


		if(Input.GetKey(KeyCode.P))
		{
			Time.timeScale = 0.0f;
			GameObject.FindGameObjectWithTag("Player").GetComponent<DragonMove>().paused = true;
		}
		if(Input.GetKey (KeyCode.O))
		{
			Time.timeScale = 1.0f;
			GameObject.FindGameObjectWithTag("Player").GetComponent<DragonMove>().paused = false;

		}



	}

	void initializeSpawnableEntityDictionary(){
		spawnableEntityDictionary = new Dictionary<string, GameObject>();
		spawnableEntityDictionary.Add("archer",archer);
		spawnableEntityDictionary.Add("tower",tower);
		spawnableEntityDictionary.Add ("knight_boss", knight_boss);
		spawnableEntityDictionary.Add ("goombat", goombat);
		spawnableEntityDictionary.Add("spicy_chicken",spicy_chicken);
		spawnableEntityDictionary.Add ("hut", hut);
	}
}
