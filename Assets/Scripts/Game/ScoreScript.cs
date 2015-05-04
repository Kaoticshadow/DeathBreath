using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	public int Score;


	// Use this for initialization
	void Start () {
	
		this.GetComponent<GUIText>().text = "Score: 0";

	}
	
	// Update is called once per frame
	void Update () {
	
		this.GetComponent<GUIText>().text = "Score: " + Score;
	}


	public void increaseScore(int addScore)
	{
		Score += addScore;
	}


}
