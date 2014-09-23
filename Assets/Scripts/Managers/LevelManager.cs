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

    void Awake()
    {
        Instance = this;
    }
	
	// Update is called once per frame
	void Update () {
        CheckEnemyHealth();
        CheckTowerPosition();
        if (_knightUnits.Count < 2)
        {
            _knightUnits.Add(Instantiate(KnightUnit, new Vector2(UnityEngine.Random.Range(13f,23f), UnityEngine.Random.Range(-1.00f, -5.0f)), Quaternion.identity) as KnightScript);
        }

        if (_towerUnits.Count < 2)
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
	            }
			}
			else
			{
				_knightUnits.RemoveAt(i);
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
}
