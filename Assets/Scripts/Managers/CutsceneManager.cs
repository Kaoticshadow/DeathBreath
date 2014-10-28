using UnityEngine;
using System.Collections;

public class CutsceneManager : MonoBehaviour {

    public GameObject Scene1;
    public GameObject Scene2;
    public TextMesh TextMesh;

    float timeKeeper;
     float sceneChange = 25;
    int stage = 0;
    Transform _transform;

    void Awake()
    {
        _transform = transform;

    }

    void Start()
    {
        timeKeeper = 0;
        SpriteRenderer s = Scene1.GetComponent<SpriteRenderer>();
        s.color = new Color(s.color.r, s.color.g, s.color.b, 1); 
        s = Scene2.GetComponent<SpriteRenderer>();
        s.color = new Color(s.color.r, s.color.g, s.color.b, 0);
    }

	// Update is called once per frame
	void Update () {
        timeKeeper += Time.deltaTime;
        //stage 0
        if (timeKeeper < 3 && stage == 0)
        {
            TextMesh.text = "In King Odin's kingdom";
            TextMesh.transform.position = new Vector3(-6.090187f, -3.3503f, -2);
        }
        if (timeKeeper > 3 && stage == 0)
            stage = 1;
        //stage 1
        if (timeKeeper < 6 && stage == 1)
        {
            TextMesh.text = "A dragon spreads\nTERROR";
            TextMesh.transform.position = new Vector3(-7.757954f, -1.814198f, -2);
        }
        if (timeKeeper > 6 && stage == 1)
            stage = 2;
        //stage 2
        if (timeKeeper < 9 && stage == 2)
        {
            TextMesh.text = "The peasants cry out\n in BURNINATION";
            TextMesh.transform.position = new Vector3(-9.16239f, -2.033642f, -2);
        }
        if (timeKeeper > 9 && stage == 2)
            stage = 3;
        //stage 3
        if (timeKeeper < 12 && stage == 3)
        {
            TextMesh.text = "Merciful King Odin\nsends his knights...";
            TextMesh.transform.position = new Vector3(-8.372395f, -2.033642f, -2);
        }
        if (timeKeeper > 12 && stage == 3)
            stage = 4;
        //stage 4
        if (timeKeeper < 15 && stage == 4)
        {
            SpriteRenderer s = Scene1.GetComponent<SpriteRenderer>();
            s.color = new Color(s.color.r, s.color.g, s.color.b, 0);
            s = Scene2.GetComponent<SpriteRenderer>();
            s.color = new Color(s.color.r, s.color.g, s.color.b, 1);
            TextMesh.text = "...to raid the dragon's lair\nand steal its treasure";
            TextMesh.transform.position = new Vector3(-8.372395f, -2.033642f, -2);
        }
        if (timeKeeper > 15 && stage == 4)
            stage = 5;
         //stage 5
        if (timeKeeper < 16 && stage == 5)
        {
            SpriteRenderer s = Scene2.GetComponent<SpriteRenderer>();
            s.color = new Color(s.color.r, s.color.g, s.color.b, 0);
            TextMesh.text = "";
        }
        if (timeKeeper > 16 && stage == 5)
            stage = 6;
        //stage 6
        if (timeKeeper < 17 && stage == 6)
        {
            TextMesh.text = "GET";
            TextMesh.transform.position = new Vector3(-7.275179f, 3.013549f, -2);
        }
        if (timeKeeper > 17 && stage == 6)
            stage = 7;        
        //stage 7
        if (timeKeeper < 18 && stage == 7)
        {
            TextMesh.text = "YOUR";
            TextMesh.transform.position = new Vector3(-1.789103f, 4.461872f, -2);
        }
        if (timeKeeper > 18 && stage == 7)
            stage = 8;
        //stage 8
        if (timeKeeper < 19 && stage == 8)
        {
            TextMesh.text = "EGG";
            TextMesh.transform.position = new Vector3(4.618633f, 1.98541f, -2);
        }
        if (timeKeeper > 19 && stage == 8)
            stage = 9;
        //stage 9
        if (timeKeeper < 20 && stage == 9)
        {
            TextMesh.text = "BACK";
            TextMesh.transform.position = new Vector3(-1.701325f, 1.126338f, -2);
        }
        if (timeKeeper > 20 && stage == 9)
        {
            Application.LoadLevel("Town");
        }
	
	}
}
