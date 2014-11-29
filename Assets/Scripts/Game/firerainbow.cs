using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class firerainbow : MonoBehaviour {
	
	public float beamDamagePerSecond = 1f;
	public float beamRange = 10f;
	public int collisionLevel = 10;
	GameObject HitObj;
	float Distance = 0f;
	GameObject rainbowLine;
	int lengthOfLineRenderer = 20;
	//LineRenderer rainbowRenderer;
	SpriteRenderer sprite;
	Color c1;
	Color c2;
	Color c1target;
	Color c2target;
	float counter;
	List<Color> colors;
	int colorIndex1;
	int colorIndex2;
	GameObject particles;
	GameObject coverParticles;
	float originalScale;
	//Vector3 beamStartTarget;
	//Vector3 beamEndTarget;
	FlameBreath f;
	
	
	// Use this for initialization
	void Start () {
		originalScale = this.transform.localScale.x;
		//beamStartTarget = new Vector3 ();
		//beamEndTarget = new Vector3 ();
		colors = new List<Color> ();
		f = GameObject.FindGameObjectWithTag ("Player").GetComponentInChildren<FlameBreath> ();
		Debug.Log (f);
		//colors.Add (Color.cyan);
		//colors.Add (Color.gray);
		//colors.Add (Color.magenta);
		
		colors.Add (Color.red);
		colors.Add (new Color (0.5f, 0.3f, 0.4f)); //orange?
		colors.Add (Color.yellow);
		//colors.Add (Color.green);
		//colors.Add (Color.blue);
		//colors.Add (new Color(75f/255f,0,130f/255f)); //indigo?
		//colors.Add (new Color (138f / 255f, 43f / 255f, 226f / 255f)); //violet?
		
	//	particles = GameObject.Find ("Rainbow Particles");
	//	coverParticles = GameObject.Find ("Rainbow Cover Particles");
		
		//rainbowLine = new GameObject();
	//	this.gameObject.AddComponent<LineRenderer>();
		//rainbowRenderer = this.gameObject.GetComponent<LineRenderer>();
		//rainbowRenderer.sortingLayerName = "UI";
		//rainbowRenderer.sortingOrder = 12;

		sprite = this.gameObject.GetComponent<SpriteRenderer>();

		c1 = Color.blue;
		c2 = Color.red;
		c1target = Color.red;
		c2target = Color.blue;
		colorIndex1 = 0;
		colorIndex2 = 1;
		counter = 0;
	//	particles.GetComponent<ParticleSystem> ().emissionRate = 0;
	//	coverParticles.GetComponent<ParticleSystem> ().emissionRate = 0;
	}
	
	// Update is called once per frame
	void Update () {
		counter += Time.deltaTime * 15f;
		
		
		
		if (counter >= 1) {
			counter = 0;
			//colorIndex1 = Random.Range(0,colors.Count-1);
			//colorIndex2 = Random.Range(0,colors.Count-1);
			colorIndex1 = (colorIndex1 + 1) % (colors.Count);
			colorIndex2 = (colorIndex2 + 1) % (colors.Count);
			c1target = colors[colorIndex1];
			c2target = colors[colorIndex2];


		}

		//int i = 0;
		
		c1 = Color.Lerp (c1, c1target, counter);
		c2 = Color.Lerp (c2, c2target, counter);
		c1 = new Color (c1.r, c1.g, c1.b, 1);
		c2 = new Color (c2.r, c2.g, c2.b, 1);
		//while (i < lengthOfLineRenderer) {
		//	Vector3 pos = new Vector3(i * 0.5F, Mathf.Sin(i + Time.time), 0);
		//	rainbowRenderer.SetPosition(i, pos);
		//	i++;
		//}
		
		//if(Input.GetKey(KeyCode.R)){
			
			//rainbowRenderer.enabled = true;
		//	RaycastHit2D hit = Physics2D.Raycast(GameObject.Find("FlameBreathOrigin").transform.position, Vector2.right,beamRange,collisionLevel);
			// Making a new ray that will go straight down from the gameobject the code is attached to
			
			//Debugging is optional but I like to see the red raycast line and it makes it easy to see what it's hitting
		//	if(hit.transform.gameObject != null){
		//		HitObj = hit.transform.gameObject;
		///		HitObj.SendMessage("takeDamage",beamDamagePerSecond * Time.deltaTime);
		//	}
			// Again optional unless you want to access the hit with more detail
		//	Distance = Mathf.Abs(hit.point.y - transform.position.y);
			// grabbing the distance in a 2d plane AS A FLOAT
			
			//rainbowRenderer.material = new Material(Shader.Find("Particles/Alpha Blended"));
			//rainbowRenderer.SetColors(c2,c1);
			//rainbowRenderer.SetPosition(0, this.transform.position);
			//rainbowRenderer.SetPosition(1, hit.point + new Vector2(0f,Mathf.Sin(Time.time)));
			//rainbowRenderer.SetPosition(1, this.transform.position+new Vector3(f.ammo-0.2f,0,0));
			//rainbowRenderer.SetWidth(0.5f,0.5f);

			sprite.color = c1;
			this.transform.localScale = new Vector3(originalScale * f.ammo - 0.2f, this.transform.localScale.y, this.transform.localScale.z);
	}
}
