using UnityEngine;
using System.Collections;

public class MenuButtons : MonoBehaviour {

    public Texture StartButton;
    public Texture CreditButton;
    public Texture ControlsButton;

    void OnGUI()
    {
        if (!StartButton || !CreditButton)
        {
            Debug.Log("Please assign a texture for buttons.");
        }

        if (GUI.Button(new Rect((Screen.width/2) - (StartButton.width / 2), (Screen.height / 2) + (StartButton.height/2), 206, 61), StartButton, GUIStyle.none))
        {
            Application.LoadLevel("Cutscene1");
        }

        if (GUI.Button(new Rect((Screen.width/2) - (CreditButton.width / 2), (Screen.height / 2) + (CreditButton.height*4), 206, 61), CreditButton, GUIStyle.none))
        {
            Application.LoadLevel("Credits");
        }

        if (GUI.Button(new Rect(((Screen.width/2) - (ControlsButton.width/2)), (Screen.height / 2) + (ControlsButton.height * 2), 206, 61), ControlsButton, GUIStyle.none))
        {
            Application.LoadLevel("Controls");
        }
    }
}
