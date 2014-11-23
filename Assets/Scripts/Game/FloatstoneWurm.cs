using UnityEngine;
using System.Collections;

public class FloatstoneWurm : MonoBehaviour {
	public FloatstoneWurmSegment head;
	public FloatstoneWurmSegment body;
	public FloatstoneWurmSegment tail;
	public int bodySegmentCount = 6;

	// Use this for initialization
	void Start () {

		Vector3 offset = new Vector3 (2.5f, 0f, 0f);
		FloatstoneWurmSegment headSegment;
		FloatstoneWurmSegment bodySegment;
		FloatstoneWurmSegment tailSegment;

		headSegment = Instantiate (head, this.transform.position, Quaternion.identity) as FloatstoneWurmSegment;

		for (int x = 1; x<=bodySegmentCount; x++) {
			bodySegment = Instantiate (body, this.transform.position + offset*(x*1.0f), Quaternion.identity) as FloatstoneWurmSegment;
			bodySegment.bodyRotation = x*60f;
		}

		tailSegment = Instantiate (tail, this.transform.position + offset*(bodySegmentCount*1.0f), Quaternion.identity) as FloatstoneWurmSegment;

		/*
		 FloatstoneBody bodySegment1, bodySegment2, tailSegment;


		headSegment = Instantiate (head, this.transform.position, Quaternion.identity) as FloatstoneHead;

		bodySegment1 = Instantiate (body, this.transform.position + offset, Quaternion.identity) as FloatstoneBody;
		bodySegment1.target = headSegment.gameObject;

		for (int x = 0; x<3; x++) {
						bodySegment2 = Instantiate (body, this.transform.position + (offset * 2.0f+(2.0f*x)), Quaternion.identity) as FloatstoneBody;
						bodySegment2.target = bodySegment1.gameObject;
						bodySegment1 = Instantiate (body, this.transform.position + (offset * 3.0f+(2.0f*x)), Quaternion.identity) as FloatstoneBody;
						bodySegment1.target = bodySegment2.gameObject;
				}

		tailSegment = Instantiate (tail, this.transform.position, Quaternion.identity) as FloatstoneBody;
		tailSegment.target = bodySegment1.gameObject;
		*/


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
