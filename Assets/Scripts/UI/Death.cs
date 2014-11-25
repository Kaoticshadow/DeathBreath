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
			if(GameObject.FindGameObjectWithTag("PersistentInformationManager") == null){
				Application.LoadLevel("StartMenu");
			}
			else{
				Application.LoadLevel(GameObject.FindGameObjectWithTag("PersistentInformationManager").GetComponent<PersistentInformation>().levelToLoad);
			}
            //load whatever level you failed. 
        }
    }

}
