using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {
	
	public Cloud m_cloud;
	float xStart = 12;
	float yStart = 2;


	// Use this for initialization
	void Start () {
	//create 5 clouds
		float offset = 0.1f;
		//set their layer + speed
		Cloud mCloud1 = Instantiate (m_cloud, new Vector2 (getX (), getY ()), Quaternion.identity) as Cloud;
		mCloud1.transform.localScale = new Vector3 (Random.value + offset, Random.value + offset, 1);
		mCloud1.depth = 1;
		mCloud1.max = 5;

		Cloud mCloud2 = Instantiate (m_cloud, new Vector2 (getX (), getY ()), Quaternion.identity) as Cloud;
		mCloud2.transform.localScale = new Vector3 (Random.value + offset, Random.value + offset, 1);
		mCloud2.depth = 2;
		mCloud2.max = 5;

		Cloud mCloud3 = Instantiate (m_cloud, new Vector2 (getX (), getY ()), Quaternion.identity) as Cloud;
		mCloud3.transform.localScale = new Vector3 (Random.value + offset, Random.value + offset, 1);
		mCloud3.depth = 3;
		mCloud3.max = 5;

		Cloud mCloud4 = Instantiate (m_cloud, new Vector2 (getX (), getY ()), Quaternion.identity) as Cloud;
		mCloud4.transform.localScale = new Vector3 (Random.value + offset, Random.value + offset, 1);
		mCloud4.depth = 4;
		mCloud4.max = 5;

		Cloud mCloud5 = Instantiate (m_cloud, new Vector2 (getX (), getY ()), Quaternion.identity) as Cloud;
		mCloud5.transform.localScale = new Vector3 (Random.value + offset, Random.value + offset, 1);
		mCloud5.depth = 5;
		mCloud5.max = 5;

	}
	
    float getY(){
			return	yStart + (Random.value*3);
	}

	float getX(){
		return 2* xStart * Random.value  -12;
		}

	// Update is called once per frame
	void Update () {
	
	}
}
