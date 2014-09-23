using UnityEngine;
using System;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

    public KnightScript KnightUnit;
    public Tower TowerUnit;

    private List<KnightScript> _knightUnits = new List<KnightScript>();
    private List<Tower> _towerUnits = new List<Tower>();

    private static LevelManager Instance;
    private enemyHealth healthScript;
    private float towerEndXLocation = -13.0f;
	private int knightSpawnTimer = 0;
	private int remainingKnights = 15;

    void Awake()
    {
        Instance = this;
    }
	
	// Update is called once per frame
	void Update () {
        CheckEnemyHealth();
        CheckTowerPosition();
		if (knightSpawnTimer > 0) 
		{
			knightSpawnTimer--;
		}

		if (_knightUnits.Count < 3 && knightSpawnTimer <= 0 && _knightUnits.Count < remainingKnights)
        {
            _knightUnits.Add(Instantiate(KnightUnit, new Vector2(UnityEngine.Random.Range(13f,23f), UnityEngine.Random.Range(-2.00f, -6.0f)), Quaternion.identity) as KnightScript);
			knightSpawnTimer = UnityEngine.Random.Range (50,500);
        }

        if (_towerUnits.Count < 1)
        {
            Debug.Log("Spawning tower units");
            _towerUnits.Add(Instantiate(TowerUnit, new Vector2(13.0f, UnityEngine.Random.Range(-1.00f, -5.0f)), Quaternion.identity) as Tower);
        }
	}

    void CheckEnemyHealth()
    {
        for (int i = 0; i < _knightUnits.Count; i++)
        {
			if(_knightUnits[i])
			{
	            healthScript = _knightUnits[i].GetComponent<enemyHealth>();
	            if (healthScript.health <= 0)
	            {
	                _knightUnits.RemoveAt(i);
					remainingKnights--;
					UpdateKnightsRemaining();
	            }
			}
			//wait... why is this here
			else
			{
				_knightUnits.RemoveAt(i);
				remainingKnights--;
				UpdateKnightsRemaining();
			}
        }
    }

    void CheckTowerPosition()
    {
        for (int i = 0; i < _towerUnits.Count; i++)
        {
            if (_towerUnits[i].TowerPosition.x <= towerEndXLocation)
            {
                Destroy(_towerUnits[i].gameObject);
                _towerUnits.RemoveAt(i);
            }
        }
    }

	void UpdateKnightsRemaining()
	{
		GameObject.Find ("KnightsRemaining").guiText.text  = "Knights Remaining: "+remainingKnights;

		if (remainingKnights <= 0) {
			GameObject.Find ("LosingText").guiText.text = "A winner is you!!";
			GameObject.Find ("LosingText").guiText.color = Color.white;
		}

	}
}
