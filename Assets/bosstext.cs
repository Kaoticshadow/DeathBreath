using UnityEngine;
using System.Collections;

public class bosstext : MonoBehaviour {
	float firstcount = 0.5f;
	float lifecount = 5f;
	float fadeout = 0.5f;
	float alpha = 0;
	GUIText x;
	// Use this for initialization
	void Start () {
		x = this.guiText;
		this.transform.position = new Vector3 (0.5f, 0.2373428f, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (firstcount > 0) {
			firstcount -= Time.deltaTime;
			x.color = new Color(1,1,1,alpha);
			alpha+= 0.1f;
		}
		if (firstcount < 0) {
			x.color = new Color(1,1,1,1);
			lifecount-= Time.deltaTime;
			if(lifecount<0){
				fadeout -= Time.deltaTime;
				alpha-=.1f;
				x.color = new Color(1,1,1,alpha);

				if(fadeout<-5){
					Destroy(this.gameObject);
				}
			}


				}
	}

	void setText(string s){
		x.text = s;

	}
}
