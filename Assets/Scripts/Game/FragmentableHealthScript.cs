using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FragmentableHealthScript : MonoBehaviour {

	public FragmentableHealthScale fragmentableScalePrefab;
	List<FragmentableHealthScale> HealthScaleList;
	Transform m_t;
	
	// Use this for initialization
	void Start () {
		HealthScaleList = new List<FragmentableHealthScale>();
		m_t = this.transform;
		FragmentableHealthScale scale;
		
		for(int i=0;i<5;i++)
		{
			scale = Instantiate(fragmentableScalePrefab,m_t.localPosition + new Vector3(i/2f,0f,0f),Quaternion.identity) as FragmentableHealthScale;
			scale.transform.parent = this.transform;
			HealthScaleList.Add(scale);
			scale.setSortOrder(i);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void DropScale(){
		FragmentableHealthScale scale = HealthScaleList[HealthScaleList.Count-1];
		scale.DropFragments();
		if(scale.getHP () <= 0){
			HealthScaleList.Remove(scale);
		}
		//scale.rigidbody2D.gravityScale = 1.0f;
		//scale.rigidbody2D.AddForce(new Vector2(100.0f,100.0f));
		if(HealthScaleList.Count == 0){
			GameObject.Find("Level Manager").SendMessage("GameOver");
		}
	}

	public void AddScale(){
		FragmentableHealthScale scale;
		int i = HealthScaleList.Count;
		scale = Instantiate(fragmentableScalePrefab,HealthScaleList[HealthScaleList.Count-1].transform.position + new Vector3(i/2f,0f,0f),Quaternion.identity) as FragmentableHealthScale;
		scale.transform.parent = this.transform;
		scale.transform.position = HealthScaleList[HealthScaleList.Count-1].transform.position + new Vector3 (0.5f, 0f, 0f);
		HealthScaleList.Add(scale);
		scale.setSortOrder(i);
	}
}
