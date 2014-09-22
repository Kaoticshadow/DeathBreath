using UnityEngine;
using System;
using System.Collections;

public class GameInitializer : MonoBehaviour {

    MenuManager menuManager;
 
    void Awake()
    {
        if (!MenuManager.Instance)
        {
            MenuManager menuMger = Instantiate(menuManager) as MenuManager;
            DontDestroyOnLoad(menuMger);
        }
    }

    void Update()
    {
        Destroy(this);
    }
}
