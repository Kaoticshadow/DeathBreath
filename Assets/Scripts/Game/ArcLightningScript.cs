using UnityEngine;
using System.Collections;

public class ArcLightningScript : MonoBehaviour {

	public float duration = 6.0f;
	public float max_range = 8.0f;
	private Transform targetTransform;
	private Transform sourceTransform;
	private bool visible;
	private float timer;

	// Use this for initialization
	void Start () {
		targetTransform = GameObject.FindGameObjectWithTag ("Player").transform;
		sourceTransform = GameObject.Find ("Odin").transform;
		visible = false;
		timer = 0;
		this.gameObject.GetComponent<Renderer>().enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		//rotate
		Vector3 vectorToTarget = targetTransform.position - transform.position;
		float angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg) - 90;
		Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
		transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 1.0f);	
		transform.localPosition = sourceTransform.localPosition; //+ new Vector3(Mathf.Cos(angle),Mathf.Sin(angle),0);

		//scale
		timer += Time.deltaTime;
		float distance = Vector2.Distance (targetTransform.localPosition, sourceTransform.localPosition);
		transform.localScale = new Vector2 (transform.localScale.x, Mathf.Clamp(timer*7,1.0f, max_range));
		if (timer >= duration) {

			transform.localScale = new Vector2 (transform.localScale.x, 0);
			this.gameObject.GetComponent<Renderer>().enabled = !this.gameObject.GetComponent<Renderer>().enabled;
			timer = 0;
		}
	}
}
