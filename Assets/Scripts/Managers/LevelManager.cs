using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

	public GameObject archer;
	public GameObject dragon;
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
	bool dragonStart = false;
	GameObject player;
	int i;
	Vector2 currentVector;

	
	void Start () {
		
		//Screen.SetResolution (640, 360, false);
		//Screen.SetResolution (1024, 576, false);
		player = GameObject.FindGameObjectWithTag("Player");
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
		//dragon init
		if (time < 2.2f) {
			dragon.transform.position = new Vector3(-13.31006f,0.332745f,0);
				}
		if (time > 2.2f && !dragonStart) {

			dragon.transform.position = Vector3.Lerp(dragon.transform.position,new Vector3(-4.307484f,0.332745f,0),0.03f);
		}
		if (time > 3f)
						dragonStart = true;



		if(Input.GetKey(KeyCode.P))
		{
			disableControls();
		}
		if(Input.GetKey (KeyCode.O))
		{
			enableControls();
		}






	}

	void GameOver(){
		player.GetComponent<DragonMove>().disableControls = true;
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

	public void endLevel(Vector2 myVec)
	{
		Vector2 endVec = myVec;
		StartCoroutine (endLevelCoroutine (myVec));
	}

	public IEnumerator endLevelCoroutine(Vector2 myVec2)
	{
		currentVector = new Vector2(this.transform.position.x, this.transform.position.y);
		player.GetComponent<DragonMove> ().disableControls = true;
		player.GetComponent<DragonShoot> ().disableFire = true;
		//Application.loadlevel
		yield return new WaitForSeconds (3.0f);
		player.rigidbody2D.AddForce (myVec2);
		player.rigidbody2D.AddTorque (10f);
		yield return new WaitForSeconds (0.5f);
		player.rigidbody2D.AddTorque (-10f);
		i = Application.loadedLevel;
		Application.LoadLevel(i + 1);

	}





	public void disableControls()
	{
		Time.timeScale = 0.0f;
		player.GetComponent<DragonMove>().disableControls = true;
		player.GetComponent<DragonShoot> ().disableFire = true;
	}

	public void enableControls()
	{
		Time.timeScale = 1.0f;
		player.GetComponent<DragonMove>().disableControls = false;
		player.GetComponent<DragonShoot> ().disableFire = false;

	}
}
