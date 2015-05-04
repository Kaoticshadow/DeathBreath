using UnityEngine;
using System.Collections;

public class PopupScore : MonoBehaviour {
	
	public PopupScore pop;
	public Vector3 scoreScaling;


	// Use this for initialization
	void Start () {
	
		scoreScaling = new Vector3 (0, 1, 0);
		this.GetComponent<GUIText>().text = "";
	
	}
	
	// Update is called once per frame
	void Update () {


	
	}

	IEnumerator Wait()
	{
		this.GetComponent<GUIText>().text = "+100!";
		Debug.Log ("before 2 second wait");
		yield return new WaitForSeconds(2);
		Debug.Log ("Waited 2 seconds");
		Destroy (this.gameObject);
	}

	public void popScore(Vector3 myVec)
	{
		Instantiate (pop, (myVec + scoreScaling), Quaternion.identity);
		this.GetComponent<GUIText>().text = " +100!";
		StartCoroutine (Wait ());

	}
}
