using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

    public string[] scrollText;
    public Font textFont;
    public float off;
    public float speed = 10f;

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
            float alpha = Mathf.Sin(((roff+Screen.height/6) / Screen.height) * 180 * Mathf.Deg2Rad);
            GUI.color = new Color(1, 1, 1, alpha);
            GUI.Label(new Rect(Screen.width/4, (roff + Screen.height/2), Screen.width / 2, 1000), scrollText[i], guiScroll);
            GUI.color = new Color(1, 1, 1, 1);
        }
        if (off < -1000)
        {
            off = 0.0f;
        }

        if (GUI.Button(new Rect(50f, Screen.height - 50f, 100, 50), "Back", guiButton))
        {
            Application.LoadLevel("StartMenu");
        }
    }
}
