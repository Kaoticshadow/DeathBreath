using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {

    public Font textFont;

    GUIStyle guiButton = new GUIStyle();

    void Awake()
    {
        guiButton.font = textFont;
        guiButton.fontSize = 64;
        guiButton.normal.textColor = Color.white;
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(50f, Screen.height - 50f, 100, 50), "BACK", guiButton))
        {
            Application.LoadLevel("StartMenu");
        }


    }
}
