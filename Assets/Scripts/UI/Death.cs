using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel("StartMenu");
        }
        else if (Input.anyKeyDown)
        {
            //load whatever level you failed. 
        }
    }

}
