using UnityEngine;
using System.Collections;

public class ArcLightningScript : MonoBehaviour {

	private Transform targetTransform;
	private Transform sourceTransform;

	// Use this for initialization
	void Start () {
		targetTransform = GameObject.Find ("Dragon Placeholder").transform;
		sourceTransform = GameObject.Find ("Odin").transform;
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 vectorToTarget = targetTransform.position - transform.position;
		float angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg) - 90;
		Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
		transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 1.0f);	
		transform.localPosition = sourceTransform.localPosition; //+ new Vector3(Mathf.Cos(angle),Mathf.Sin(angle),0);
	}
}
