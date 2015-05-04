using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

	public string levelName; //nasty hack to know which level we're on. Set on each prefab in the editor
	public GameObject persistentInformationManager;
	public GameObject playerBoundaries;
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
	public GameObject wizard;
	public GameObject gryphon_rider;
	public GameObject dragonborne;
	public GameObject catapult;
	public PersistentInformation persistentInformation;

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
	public float time;
	bool dragonStart = false;
	GameObject player;
	//Vector2 currentVector;
	
	void Start () {

		if(GameObject.FindGameObjectWithTag("PersistentInformationManager") == null){
			GameObject infoManager = Instantiate(persistentInformationManager) as GameObject;
			persistentInformation = infoManager.GetComponent<PersistentInformation>();
		}
		else{
			persistentInformation = GameObject.FindGameObjectWithTag("PersistentInformationManager").GetComponent<PersistentInformation>();
		}

		playerBoundaries.SetActive (false);
		
		//Screen.SetResolution (640, 360, false);
		//Screen.SetResolution (1024, 576, false);
		player = GameObject.FindGameObjectWithTag("Player");
		//player.layer = 0; //default; no collision with player boundaries
		//m_spawnableEntityCollection = SpawnableEntityContainer.Load(Path.Combine(Application.dataPath, "Town.xml"));
		if (levelName != "Throne")
			m_spawnableEntityCollection = SpawnableEntityContainer.Load(Path.Combine(Application.dataPath, levelName +".xml"));
		leftLevelEdge = GameObject.Find("Left Level Edge");
		rightLevelEdge = GameObject.Find("Right Level Edge");
		initializeSpawnableEntityDictionary();
		time = 0;
		//if(levelName == "Cave"){
		//		levelScrollFactor = 0;
		//	targetLevelScrollFactor = 1;
		//	originLevelScrollFactor = 0;
		//}

	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

		levelScrollFactorRatio += Time.deltaTime / levelScrollChangeDelay;
		levelScrollFactor = Mathf.Lerp(originLevelScrollFactor,targetLevelScrollFactor,levelScrollFactorRatio);

		if (levelName != "Throne") {
						foreach (SpawnableEntity entity in m_spawnableEntityCollection.SpawnableEntities) {
								if (!entity.spawned && time >= entity.time) {
										entity.spawned = true;
										Debug.Log (entity.name);
										GameObject spawnedObject = (GameObject)Instantiate (spawnableEntityDictionary [entity.name], rightLevelEdge.transform.position + new Vector3 (entity.x, entity.y, 0), rightLevelEdge.transform.rotation);

										//gameObject scaling from script
										if (entity.x_scale > 0 && entity.y_scale > 0) {
												spawnedObject.transform.localScale = new Vector3 (entity.x_scale, entity.y_scale);
										}

										//set enemy as champion
										if (entity.champion > 0) {
												spawnedObject.AddComponent <ChampionEnemy>();
										}
								}
						}
				}

		//dragon init town
		if(levelName == "Town"||levelName == "Throne"||levelName == "Sky"){
			if (time < 2.2f) {
				player.transform.position = new Vector3(-13.31006f,0.332745f,0);
					}
			if (time > 2.2f && !dragonStart) {

				player.transform.position = Vector3.Lerp(player.transform.position,new Vector3(-3.307484f,0.332745f,0),0.05f);
			}
			if (time > 3f && !dragonStart){
				dragonStart = true;
				playerBoundaries.SetActive (true); //collision with player boundaries
			}
		}

		//dragon init town
		if(levelName == "Cave"){
			if (time < 0.5f) {
				dragon.transform.position = new Vector3(-13.31006f,-1.0f,0);
				//setScrollingSpeed(0.0f,0.2f);
			}
			if (time > 0.5f && !dragonStart) {
				
				dragon.transform.position = Vector3.Lerp(dragon.transform.position,new Vector3(-3.307484f,-1.0f,0),0.05f);

			}
			if (time > 1.3f && !dragonStart){
				dragonStart = true;
				playerBoundaries.SetActive (true); //collision with player boundaries
				//setScrollingSpeed(10.0f,0.2f);
			}
		}

		//sky has its own fancy init, no worries

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
		playerBoundaries.SetActive (false);
		player.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
		player.GetComponent<Rigidbody2D>().AddForce(new Vector2(100f,50f));
		player.GetComponent<Rigidbody2D>().AddTorque(-50f);
		persistentInformation.levelToLoad = levelName;
		//StartCoroutine(WaitAndLoadLevel(2.0f,levelName));
		StartCoroutine(WaitAndLoadLevel(2.0f,"Death"));
	}

	IEnumerator WaitAndLoadLevel(float waitTime, string levelName){
		yield return new WaitForSeconds(waitTime);
		//todo: figure out where to go on game over
		Application.LoadLevel(levelName);
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
		spawnableEntityDictionary.Add("wizard",wizard);
		spawnableEntityDictionary.Add("gryphon_rider",gryphon_rider);
		spawnableEntityDictionary.Add("dragonborne", dragonborne);
		spawnableEntityDictionary.Add ("catapult", catapult);
	}

	public void endLevel(Vector2 myVec)
	{
		Vector2 endVec = myVec;
		StartCoroutine (endLevelCoroutine (myVec));
	}

	public IEnumerator endLevelCoroutine(Vector2 myVec2)
	{
		//currentVector = new Vector2(this.transform.position.x, this.transform.position.y);
		player.GetComponent<DragonMove> ().disableControls = true;
		player.GetComponent<DragonShoot> ().disableFire = true;
		playerBoundaries.SetActive (false); //collision with player boundaries
		//Application.loadlevel
		//yield return new WaitForSeconds (3.0f);
		//player.rigidbody2D.AddForce (myVec2);
		player.GetComponent<Rigidbody2D>().velocity = new Vector2(10f,0f);
		//player.rigidbody2D.AddTorque (10f);
		//yield return new WaitForSeconds (0.5f);
		//player.rigidbody2D.AddTorque (-10f);
		yield return new WaitForSeconds (1.5f);
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
		originLevelScrollFactor = levelScrollFactor;
		levelScrollFactorRatio = 0;
		targetLevelScrollFactor = newSpeed;
		levelScrollChangeDelay = Mathf.Max(minimumDelay,delay);
	}
}
