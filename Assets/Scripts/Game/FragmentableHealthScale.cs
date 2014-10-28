using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FragmentableHealthScale : MonoBehaviour {

	public HealthScaleFragment m_tl;
	public HealthScaleFragment m_tr;
	public HealthScaleFragment m_bl;
	public HealthScaleFragment m_br;
	List<HealthScaleFragment> HealthScaleFragmentList;
	int hp;
	int sortOrder;
	Transform m_t;

	// Use this for initialization
	void Start () {

	}

	void Awake() {
		hp = 4;
		sortOrder = 0;
		HealthScaleFragmentList = new List<HealthScaleFragment>();
		m_t = this.transform;
		InitializeFragments();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void InitializeFragments(){
		//todo: not like this

		HealthScaleFragment[] fragmentPrefabs = new HealthScaleFragment[]{m_tl,m_tr,m_bl,m_br};

		foreach(HealthScaleFragment fragmentPrefab in fragmentPrefabs){
			HealthScaleFragment fragment = Instantiate(fragmentPrefab,m_t.localPosition,Quaternion.identity) as HealthScaleFragment;
			fragment.transform.localScale = new Vector3(1.5f,1.5f,1);
			fragment.renderer.sortingLayerName = "UI";
			HealthScaleFragmentList.Add(fragment);
		}

		/*
		HealthScaleFragment fragment = Instantiate(m_tl,m_t.localPosition,Quaternion.identity) as HealthScaleFragment;
		fragment.transform.localScale = new Vector3(1.5f,1.5f,1);
		HealthScaleFragmentList.Add(fragment);
		fragment = Instantiate(m_tr,m_t.localPosition,Quaternion.identity) as HealthScaleFragment;
		fragment.transform.localScale = new Vector3(1.5f,1.5f,1);
		HealthScaleFragmentList.Add(fragment);
		fragment = Instantiate(m_bl,m_t.localPosition,Quaternion.identity) as HealthScaleFragment;
		fragment.transform.localScale = new Vector3(1.5f,1.5f,1);
		HealthScaleFragmentList.Add(fragment);
		fragment = Instantiate(m_br,m_t.localPosition,Quaternion.identity) as HealthScaleFragment;
		fragment.transform.localScale = new Vector3(1.5f,1.5f,1);
		HealthScaleFragmentList.Add(fragment);
		*/
		applySortOrder();
	
	}

	public void DropFragment(){
		HealthScaleFragment fragment = HealthScaleFragmentList[HealthScaleFragmentList.Count-1];
		HealthScaleFragmentList.Remove(fragment);
		fragment.rigidbody2D.gravityScale = 1.0f;
		fragment.rigidbody2D.AddForce(new Vector2(100.0f,100.0f));
		fragment.rigidbody2D.AddTorque(100f);
		hp--;
	}

	public void DropFragments(){
		foreach(HealthScaleFragment fragment in HealthScaleFragmentList){
			//HealthScaleFragmentList.Remove(fragment);
			fragment.rigidbody2D.gravityScale = 1.0f;
			fragment.rigidbody2D.AddForce(new Vector2(100.0f * Random.Range(-1f,1f),100.0f * Random.Range(0.5f,2.0f)));
			fragment.rigidbody2D.AddTorque(100f * Random.Range(0.5f,2.0f));
			hp = 0;
		}
	}

	public int getHP(){
		return hp;
	}

	public void setSortOrder(int i){
		sortOrder = i;
		applySortOrder();
	}

	void applySortOrder(){
		foreach(HealthScaleFragment fragment in HealthScaleFragmentList){
			fragment.renderer.sortingOrder = sortOrder;
		}
	}

}
