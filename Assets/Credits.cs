using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

    public float linesPerSec = 1.0f;
    public string[] scrollText;
    public Font textFont;
    public float off;
    public float speed = 0.5f;

    GUIStyle gui = new GUIStyle();

	void Start () {
        gui.font = textFont;
        gui.fontStyle = FontStyle.Normal;
        gui.fontSize = 36;
        gui.normal.textColor = Color.white;
        gui.wordWrap = true;
    }

    void OnGUI()
    {
        off -= Time.deltaTime * speed;
        for (int i = 0; i < scrollText.Length; i++)
        {
            float roff = (scrollText.Length * 20) + (i * 20 + off);
            float alpha = Mathf.Sin((roff / Screen.height) * 180 * Mathf.Deg2Rad);
            GUI.color = new Color(1, 1, 1, alpha);
            GUI.Label(new Rect(Screen.width/4, (roff +Screen.height/4), Screen.width / 2, 1000), scrollText[i], gui);
            GUI.color = new Color(1, 1, 1, 1);
        }
    }
}
