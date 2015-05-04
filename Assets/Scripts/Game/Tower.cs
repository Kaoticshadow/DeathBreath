using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tower : MonoBehaviour {

	public TowerFragment m_tl;
	public TowerFragment m_tr;
	public TowerFragment m_mid;
	public TowerFragment m_bl;
	public TowerFragment m_br;
	List<TowerFragment> TowerFragmentList;
	public float health;
	Transform m_t;
	
	// Use this for initialization
	void Start () {
		//this.rigidbody2D.AddForce(new Vector2(-100f,0f));
		
	}
	
	void Awake() {
		TowerFragmentList = new List<TowerFragment>();
		m_t = this.transform;
		InitializeFragments();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void InitializeFragments(){

		TowerFragment[] fragmentPrefabs = new TowerFragment[]{m_tl,m_tr,m_bl,m_br,m_mid};
		
		foreach(TowerFragment fragmentPrefab in fragmentPrefabs){
			TowerFragment fragment = Instantiate(fragmentPrefab,m_t.localPosition,Quaternion.identity) as TowerFragment;
			fragment.GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.None;
			fragment.transform.parent = this.transform;
			TowerFragmentList.Add(fragment);
		}
	}
	
	public void DropFragments(){
		foreach(TowerFragment fragment in TowerFragmentList){
			fragment.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
			fragment.GetComponent<Rigidbody2D>().AddForce(new Vector2(100.0f * Random.Range(-1f,1f),100.0f * Random.Range(0.5f,2.0f)));
			//fragment.rigidbody2D.AddTorque(100f * Random.Range(0.5f,2.0f));
		}
	}

	void takeDamage(float damage){
		health -= damage;
		if (health < 0){
			DropFragments();
			this.gameObject.tag = "Untagged";
		}
			
		
		//score++;
	}
	
	public float getHP(){
		return health;
	}
}
