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
	float time;

	void Start () {
		
		//Screen.SetResolution (640, 360, false);
		//Screen.SetResolution (1024, 576, false);
		m_spawnableEntityCollection = SpawnableEntityContainer.Load(Path.Combine(Application.dataPath, "Data/Town.xml"));
		leftLevelEdge = GameObject.Find("Left Level Edge");
		rightLevelEdge = GameObject.Find("Right Level Edge");
		initializeSpawnableEntityDictionary();
		time = 0;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		foreach(SpawnableEntity entity in m_spawnableEntityCollection.SpawnableEntities)
		{
			if(!entity.spawned && time >= entity.time)
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

	void GameOver(){
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		player.GetComponent<DragonMove>().paused = true;
		player.rigidbody2D.gravityScale = 1.0f;
		player.rigidbody2D.AddForce(new Vector2(100f,50f));
		player.rigidbody2D.AddTorque(-50f);
		StartCoroutine(WaitAndLoadLevel(2.0f,"Town"));
	}

	IEnumerator WaitAndLoadLevel(float waitTime, string levelName){
		yield return new WaitForSeconds(waitTime);
		//todo: figure out where to go on game over
		Application.LoadLevel(Application.loadedLevel);
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
