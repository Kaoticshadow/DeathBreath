using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	public HealthScale scalePrefab;
	Stack HealthScaleStack;
	Transform m_t;

	// Use this for initialization
	void Start () {
		HealthScaleStack = new Stack();
		m_t = this.transform;

		for(int i=0;i<5;i++)
		{
			HealthScale clone = Instantiate(scalePrefab,m_t.localPosition + new Vector3(i/3.0f,0f,0f),Quaternion.identity) as HealthScale;
			HealthScaleStack.Push(clone);
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void DropScale(){
		GameObject scale = HealthScaleStack.Pop() as GameObject;
		scale.rigidbody2D.gravityScale = 1;
		scale.rigidbody2D.velocity = new Vector3(2, 2, 0);
	}
}
