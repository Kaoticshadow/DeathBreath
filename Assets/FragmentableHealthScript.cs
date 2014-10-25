﻿using UnityEngine;
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
		
		for(int i=0;i<3;i++)
		{
			scale = Instantiate(fragmentableScalePrefab,m_t.localPosition + new Vector3(i/2.0f,0f,0f),Quaternion.identity) as FragmentableHealthScale;
			HealthScaleList.Add(scale);
			//scale.setSortOrder(i);
		}

		for(int i=0;i<3;i++)
		{
			HealthScaleList[i].setSortOrder(i);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void DropScale(){
		FragmentableHealthScale scale = HealthScaleList[HealthScaleList.Count-1];
		scale.DropFragment();
		if(scale.getHP () <= 0){
			HealthScaleList.Remove(scale);
		}
		//scale.rigidbody2D.gravityScale = 1.0f;
		//scale.rigidbody2D.AddForce(new Vector2(100.0f,100.0f));
	}
}
