using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HealthScript : MonoBehaviour {

	public HealthScale scalePrefab;
	Stack<HealthScale> HealthScaleStack;
	Transform m_t;

	// Use this for initialization
	void Start () {
		HealthScaleStack = new Stack<HealthScale>();
		m_t = this.transform;

		for(int i=0;i<5;i++)
		{
			HealthScale clone = Instantiate(scalePrefab,m_t.localPosition + new Vector3(i/3.0f,0f,0f),Quaternion.identity) as HealthScale;
			//clone.renderer.sortingOrder = i;
			HealthScaleStack.Push(clone);
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DropScale(){
		HealthScale scale = HealthScaleStack.Pop();
		scale.rigidbody2D.gravityScale = 1.0f;
		scale.rigidbody2D.AddForce(new Vector2(100.0f,100.0f));
	}
}
