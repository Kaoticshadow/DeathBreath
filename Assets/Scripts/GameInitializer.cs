using UnityEngine;
using System;
using System.Collections;

public class GameInitializer : MonoBehaviour {

    //Assign your managers that you want to setup on game init
    //This allows for non cluttering of the scene file (DeathBreath.unity)
    //public MenuManager menuManager;
 
    void Awake()
    {
        //if (!MenuManager.Instance)
        //{
        //    MenuManager menuMger = Instantiate(menuManager) as MenuManager;
        //    DontDestroyOnLoad(menuMger);
        //}
    }

    void Update()
    {
        //Remove this initializer when everything else is created in the scene
        Destroy(this);
    }
}
