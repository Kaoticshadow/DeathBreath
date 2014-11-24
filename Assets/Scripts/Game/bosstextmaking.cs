using UnityEngine;
using System.Collections;

public class bosstextmaking : MonoBehaviour {
	public bosstext b;
	public string bossname;
	// Use this for initialization
	void Start () {
		bosstext x = (bosstext)Instantiate (b, this.transform.position, Quaternion.identity);
		x.name = bossname;


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
