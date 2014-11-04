using UnityEngine;
using System.Collections;

public class FloatstoneWurm : MonoBehaviour {
	public FloatstoneHead head;
	public FloatstoneBody body;
	public FloatstoneBody tail;

	// Use this for initialization
	void Start () {

		FloatstoneHead headSegment;
		FloatstoneBody bodySegment1, bodySegment2, tailSegment;


		headSegment = Instantiate (head, this.transform.position, Quaternion.identity) as FloatstoneHead;

		bodySegment1 = Instantiate (body, this.transform.position, Quaternion.identity) as FloatstoneBody;
		bodySegment1.target = headSegment.gameObject;

		for (int x = 0; x<2; x++) {
						bodySegment2 = Instantiate (body, this.transform.position, Quaternion.identity) as FloatstoneBody;
						bodySegment2.target = bodySegment1.gameObject;
						bodySegment1 = Instantiate (body, this.transform.position, Quaternion.identity) as FloatstoneBody;
						bodySegment1.target = bodySegment2.gameObject;
				}

		tailSegment = Instantiate (tail, this.transform.position, Quaternion.identity) as FloatstoneBody;
		tailSegment.target = bodySegment1.gameObject;


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
