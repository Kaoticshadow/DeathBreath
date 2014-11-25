using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

    public Font textFont;
    public float off;
    public float speed = 10f;

    string[] scrollText = { "CREDITS", "","", "====PROGRAMMERS====","", "Louis McLean","", "Tim Smith","","Tiffany Ip","", "Marco Sabini", "", "",
                            "====CREATIVE WRITER====", "","Louis McLean", "", "",
                            "====VECTOR ART====","", "Tim Smith","", "Tiffany Ip", "", "",
                            "====PIXEL ART====","", "Tiffany Ip", "", "",
                            "====ANIMATIONS & CUTSCENES====","", "Tim Smith", "", "",
                            "====SOUND EFFECTS====", "","Tim Smith","", "Louis McLean", "","Tiffany Ip", "", "", "", "",
                            "EXTERNAL SOURCES", "","", 
                            "====FONTS====", "","SF Movie Poster Bold (Free)","", "EXOCET (Free)", "", "",
                            "====MUSIC====", "", "", 
                            "====SOUND EFFECTS====", "" };
    GUIStyle guiScroll = new GUIStyle();
    GUIStyle guiButton = new GUIStyle();

	void Start () {
        guiScroll.font = textFont;
        guiScroll.fontStyle = FontStyle.Normal;
        guiScroll.fontSize = 36;
        guiScroll.normal.textColor = Color.white;
        guiScroll.wordWrap = true;

        guiButton.font = textFont;
        guiButton.fontSize = 36;
        guiButton.normal.textColor = Color.white;
    }

    void OnGUI()
    {
        off -= Time.deltaTime * speed;
        for (int i = 0; i < scrollText.Length; i++)
        {
            float roff = (scrollText.Length * 20) + (i * 20 + off);
            float alpha = Mathf.Sin((roff / Screen.height) * 180 * Mathf.Deg2Rad);
            GUI.color = new Color(1, 1, 1, alpha);
            GUI.Label(new Rect(Screen.width/4, roff, Screen.width / 2, 1000), scrollText[i], guiScroll);
            GUI.color = new Color(1, 1, 1, 1);
        }
        if (off < -5000)
        {
            off = 0.0f;
        }

        if (GUI.Button(new Rect(50f, Screen.height - 50f, 100, 50), "BACK", guiButton))
        {
            Application.LoadLevel("StartMenu");
        }
    }
}
