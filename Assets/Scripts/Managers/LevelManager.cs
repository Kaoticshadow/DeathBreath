using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

	public GameObject archer;
	public GameObject dragon;
	public GameObject cave_entrance;
	public GameObject cloud_1;
	public GameObject cloud_2;
	public GameObject cutefire;
	public GameObject elite_archer;
	public GameObject fireball;
	public GameObject firebat;
	public GameObject floatstone_wurm;
	public GameObject tower;
	public GameObject knight_boss;
	public GameObject goombat;
	public GameObject hut;
	public GameObject spicy_chicken;
	public GameObject dragon_fruit;
	public GameObject hot_pepper;
	public float levelScrollFactor = 1;
	public float targetLevelScrollFactor = 1;
	public float originLevelScrollFactor = 1;
	float levelScrollFactorRatio = 0;
	float levelScrollChangeDelay = 1;
	float minimumDelay = 0.1f;
	GameObject leftLevelEdge;
	GameObject rightLevelEdge;
	SpawnableEntityContainer m_spawnableEntityCollection;
	Dictionary<string, GameObject> spawnableEntityDictionary; 
	float time;
	bool dragonStart = false;
	GameObject player;
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

		levelScrollFactorRatio += Time.deltaTime / levelScrollChangeDelay;
		levelScrollFactor = Mathf.Lerp(originLevelScrollFactor,targetLevelScrollFactor,levelScrollFactorRatio);

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
		spawnableEntityDictionary.Add("cave_entrance", cave_entrance);
		spawnableEntityDictionary.Add("cloud_1",cloud_1);
		spawnableEntityDictionary.Add("cloud_2",cloud_2);
		spawnableEntityDictionary.Add("cutefire", cutefire);
		spawnableEntityDictionary.Add("dragon",dragon);
		spawnableEntityDictionary.Add("dragon_fruit",dragon_fruit);
		spawnableEntityDictionary.Add("elite_archer",elite_archer);
		spawnableEntityDictionary.Add("fireball",fireball);
		spawnableEntityDictionary.Add("firebat", firebat);
		spawnableEntityDictionary.Add("floatstone_wurm",floatstone_wurm);
		spawnableEntityDictionary.Add("goombat", goombat);
		spawnableEntityDictionary.Add("hot_pepper", hot_pepper);
		spawnableEntityDictionary.Add("hut", hut);
		spawnableEntityDictionary.Add("knight_boss", knight_boss);
		spawnableEntityDictionary.Add("spicy_chicken",spicy_chicken);
		spawnableEntityDictionary.Add("tower",tower);

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
		Application.LoadLevel(Application.loadedLevel + 1);

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

	public void setScrollingSpeed(float newSpeed, float delay)
	{
		levelScrollFactorRatio = 0;
		targetLevelScrollFactor = newSpeed;
		levelScrollChangeDelay = Mathf.Max(minimumDelay,delay);
	}
}
