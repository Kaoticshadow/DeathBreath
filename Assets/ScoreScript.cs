using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	public int Score;


	// Use this for initialization
	void Start () {
	
		this.guiText.text = "Score: 0";

	}
	
	// Update is called once per frame
	void Update () {
	
		this.guiText.text = "Score: " + Score;
	}


	public void increaseScore(int addScore)
	{
		Score += addScore;
	}


}
