﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FragmentableHealthScale : MonoBehaviour {

	public HealthScaleFragment m_tl;
	public HealthScaleFragment m_tr;
	public HealthScaleFragment m_bl;
	public HealthScaleFragment m_br;
	List<HealthScaleFragment> HealthScaleFragmentList;
	int hp;
	Transform m_t;
	bool fragmentsInitialized;


	// Use this for initialization
	void Start () {
		hp = 4;
		HealthScaleFragmentList = new List<HealthScaleFragment>();
		m_t = this.transform;
		fragmentsInitialized = false;
		if(!fragmentsInitialized){
			InitializeFragments();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void InitializeFragments(){
		//todo: not like this
		HealthScaleFragmentList = new List<HealthScaleFragment>();
		m_t = this.transform;

		HealthScaleFragment fragment = Instantiate(m_tl,m_t.localPosition,Quaternion.identity) as HealthScaleFragment;
		fragment.transform.localScale = new Vector3(2,2,1);
		HealthScaleFragmentList.Add(fragment);
		fragment = Instantiate(m_tr,m_t.localPosition,Quaternion.identity) as HealthScaleFragment;
		fragment.transform.localScale = new Vector3(2,2,1);
		HealthScaleFragmentList.Add(fragment);
		fragment = Instantiate(m_bl,m_t.localPosition,Quaternion.identity) as HealthScaleFragment;
		fragment.transform.localScale = new Vector3(2,2,1);
		HealthScaleFragmentList.Add(fragment);
		fragment = Instantiate(m_br,m_t.localPosition,Quaternion.identity) as HealthScaleFragment;
		fragment.transform.localScale = new Vector3(2,2,1);
		HealthScaleFragmentList.Add(fragment);
		fragmentsInitialized = true;
	}

	public void DropFragment(){
		HealthScaleFragment fragment = HealthScaleFragmentList[HealthScaleFragmentList.Count-1];
		HealthScaleFragmentList.Remove(fragment);
		fragment.rigidbody2D.gravityScale = 1.0f;
		fragment.rigidbody2D.AddForce(new Vector2(100.0f,100.0f));
		fragment.rigidbody2D.AddTorque(100f);
		hp--;
	}

	public int getHP(){
		return hp;
	}

	public void setSortOrder(int i){
		if(!fragmentsInitialized){
			InitializeFragments();
		}
		foreach(HealthScaleFragment fragment in HealthScaleFragmentList){
			fragment.renderer.sortingOrder = i;
		}
	}
}
