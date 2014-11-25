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
                            "====SOUND EFFECTS====", "","Tim Smith","", "Louis McLean", "","Tiffany Ip", "", "",
                            "====TESTING====", "", "Marco Sabini", "", "", "", "",
                            "EXTERNAL SOURCES", "","", 
                            "====FONTS====", "","SF Movie Poster Bold (Free)","", "Exocet (Free)", "", "",
                            "====MUSIC====", "", "Figaro Castle (FF6)", "", 
                                                 "Victory Fanfare (FF6)", "",
                                                 "The Unforgiven (FF6)",  "",
                                                 "Omen (FF6)",  "",
                                                 "Birth of A God (FF7)",  "",
                                                 "Area 1 (Power Rangers SNES)",  "",
                                                 "Boss Fight (Chrono Trigger)",  "",
                                                 "Limestone Cavern (Legend of Dragoon)",  "",
                                                 "Title Screen (Myth)",  "",
                                                 "Electroheart (Amaranthe)",  "",
                                                 "Main Theme (Skyrim)",  "",
                                                 "Hunting High and Low (Stratovarius)",  "",
                                                 "Hot Butter (Popcorn)"};
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
        if (off < -3800)
        {
            off = 0.0f;
        }

        if (GUI.Button(new Rect(50f, Screen.height - 50f, 100, 50), "BACK", guiButton))
        {
            Application.LoadLevel("StartMenu");
        }
    }
}
