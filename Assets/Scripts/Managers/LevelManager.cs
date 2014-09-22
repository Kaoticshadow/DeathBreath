using UnityEngine;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

    public KnightScript KnightUnit;
    public Tower TowerUnit;

    private List<KnightScript> _knightUnits = new List<KnightScript>();
    private List<Tower> _towerUnits = new List<Tower>();

    private static LevelManager Instance;

    void Awake()
    {
        Instance = this;
    }
	
	// Update is called once per frame
	void Update () {

        if (_knightUnits.Count < 2)
        {
            _knightUnits.Add(Instantiate(KnightUnit, new Vector2(Random.Range(-13f, 13f), Random.Range(-0.01f, -5.0f)), Quaternion.identity) as KnightScript);
        }

        if (_towerUnits.Count < 2)
        {
            _towerUnits.Add(Instantiate(TowerUnit, new Vector2(Random.Range(-13f, 13f), Random.Range(-0.01f, -5.0f)), Quaternion.identity) as Tower);
        }
	}
}
