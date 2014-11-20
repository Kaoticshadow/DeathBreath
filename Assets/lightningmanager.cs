using UnityEngine;
using System.Collections;

public class lightningmanager : MonoBehaviour {
	public ArrayList list;

	float cd = 12f;
	float crnt;

	// Use this for initialization
	void Start () {
		foreach (Transform child in transform)
		{

			list.Add(child);//child is your child transform
			child.gameObject.SetActive(false);
		}
		crnt = cd;
	}
	
	// Update is called once per frame
	void Update () {
		crnt -= Time.deltaTime;
		if (crnt < 0) {
			crnt = cd;
			GameObject g = (GameObject)list[(int)Random.Range(0,list.Count)];
			g.SetActive(true);
		}
	}
}
