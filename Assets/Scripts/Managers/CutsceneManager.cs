using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CutsceneManager : MonoBehaviour {

    public GameObject Scene1;
    public GameObject Scene2;
    public TextMesh TextMesh;

    float timeKeeper;
    float sceneChange = 25;
    int stage = 0;
    Transform _transform;

	//WIP automate cutscene transitions
	List<GameObject> images;
	List<float> imageTimeIndices;
	List<string> texts;
	List<float> textTimeIndices;
	int imageIndex;
	int textIndex;

    void Awake()
    {
        _transform = transform;

    }

    void Start()
    {
		//Screen.SetResolution (1024, 576, false);
        timeKeeper = 0;
        SpriteRenderer s = Scene1.GetComponent<SpriteRenderer>();
        s.color = new Color(s.color.r, s.color.g, s.color.b, 1); 
        s = Scene2.GetComponent<SpriteRenderer>();
        s.color = new Color(s.color.r, s.color.g, s.color.b, 0);
    }

	//WIP automate cutscene transitions
	void initializeIntroCutscene(){

	}

	// Update is called once per frame
	void Update () {
        timeKeeper += Time.deltaTime;
        Debug.Log(timeKeeper);
        //stage 0
        if (timeKeeper < 5 && stage == 0)
        {
            TextMesh.text = "In King Odin's kingdom";
            //TextMesh.transform.position = new Vector3(-8.44f, -3.3503f, -2);
        }
        if (timeKeeper > 5 && stage == 0)
            stage = 1;
        //stage 1
        if (timeKeeper < 10 && stage == 1)
        {
            TextMesh.text = "A dragon spreads terror";
            //TextMesh.transform.position = new Vector3(-7.757954f, -1.814198f, -2);
        }
        if (timeKeeper > 10 && stage == 1)
            stage = 2;
        //stage 2
        if (timeKeeper < 15 && stage == 2)
        {
            TextMesh.text = "Burninating all the peasants!";
            //TextMesh.transform.position = new Vector3(-8.47f, -2.033642f, -2);
        }
        if (timeKeeper > 15 && stage == 2)
            stage = 3;
        //stage 3
        if (timeKeeper < 20 && stage == 3)
        {
			SpriteRenderer s = Scene1.GetComponent<SpriteRenderer>();
			s.color = new Color(s.color.r, s.color.g, s.color.b, 0);
			s = Scene2.GetComponent<SpriteRenderer>();
			s.color = new Color(s.color.r, s.color.g, s.color.b, 1);
            TextMesh.text = "Wise King Odin sends his knights...";
            //TextMesh.transform.position = new Vector3(-8.372395f, -2.033642f, -2);
        }
        if (timeKeeper > 20 && stage == 3)
            stage = 4;
        //stage 4
        if (timeKeeper < 25 && stage == 4)
        {

            TextMesh.text = "...to raid the dragon lair...";
            //TextMesh.transform.position = new Vector3(-8.372395f, -2.033642f, -2);
        }
        if (timeKeeper > 25 && stage == 4)
            stage = 5;

		//stage 5
        if (timeKeeper < 30 && stage == 5)
        {
            TextMesh.text = "and steal its precious treasure!";
            
        }
        if (timeKeeper > 30 && stage == 5)
            stage = 6;
        
		//stage 6
        if (timeKeeper < 31 && stage == 6)
        {
            SpriteRenderer s = Scene2.GetComponent<SpriteRenderer>();
            s.color = new Color(s.color.r, s.color.g, s.color.b, 0);
            TextMesh.text = "";
        }
        if (timeKeeper > 31 && stage == 6)
            stage = 7;
        
		//stage 7
        if (timeKeeper < 32 && stage == 7)
        {
			TextMesh.fontSize = 100;
            TextMesh.text = "GET";
            TextMesh.transform.position = new Vector3(-5.275179f, 2.013549f, -2);
        }
        if (timeKeeper > 32 && stage == 7)
            stage = 8;        
        
		//stage 8
        if (timeKeeper < 33 && stage == 8)
        {
            TextMesh.text = "YOUR";
            TextMesh.transform.position = new Vector3(-0.789103f, 3.461872f, -2);
        }
        if (timeKeeper > 33 && stage == 8)
            stage = 9;
        //stage 9
        if (timeKeeper < 34 && stage == 9)
        {
            TextMesh.text = "EGG";
            TextMesh.transform.position = new Vector3(5.618633f, 0.98541f, -2);
        }
        if (timeKeeper > 34 && stage == 9)
            stage = 10;
        //stage 10
        if (timeKeeper < 35 && stage == 10)
        {
            TextMesh.text = "BACK";
            TextMesh.transform.position = new Vector3(-0.701325f, 0.126338f, -2);
        }
        if (timeKeeper > 35 && stage == 10)
        {
            Application.LoadLevel("Town");
        }
	
	}
}
