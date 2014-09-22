using UnityEngine;
using System;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

    public KnightScript KnightUnit;
    public Tower TowerUnit;

    private List<KnightScript> _levelObjects = new List<KnightScript>();

    private static LevelManager Instance;

    void Awake()
    {
        Instance = this;
    }
	
	// Update is called once per frame
	void Update () {
	    
        

	}
}
