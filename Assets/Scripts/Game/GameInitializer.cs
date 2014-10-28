using UnityEngine;
using System;
using System.Collections;

public class GameInitializer : MonoBehaviour {

    //Assign your managers that you want to setup on game init
    //This allows for non cluttering of the scene file (DeathBreath.unity)
    public GameFlowManager GameFlowManager;
 
    void Awake()
    {
        // EXAMPLE
        //if (!MenuManager.Instance)
        //{
        //    MenuManager menuMger = Instantiate(menuManager) as MenuManager;
        //    DontDestroyOnLoad(menuMger);
        //}

        if (!GameFlowManager)
        {
            GameFlowManager gameFlow = Instantiate(GameFlowManager) as GameFlowManager;
            DontDestroyOnLoad(gameFlow);
        }
    }

    void Update()
    {
        //Remove this initializer when everything else is created in the scene
        Destroy(this);
    }
}
