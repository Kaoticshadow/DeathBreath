using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RainbowBeam : MonoBehaviour {

	public float beamDamagePerSecond = 1f;
	public float beamRange = 10f;
	public int collisionLevel = 10;
	GameObject HitObj;
	float Distance = 0f;
	GameObject rainbowLine;
	int lengthOfLineRenderer = 20;
	LineRenderer rainbowRenderer;
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
	Vector3 beamStartTarget;
	Vector3 beamEndTarget;
	float maxbreath = 0.5f;
	float currentbreath = 0.5f;
	bool canshoot = true;
	// Use this for initialization
	void Start () {
		beamStartTarget = new Vector3 ();
		beamEndTarget = new Vector3 ();
		colors = new List<Color> ();

		//colors.Add (Color.cyan);
		//colors.Add (Color.gray);
		//colors.Add (Color.magenta);

		colors.Add (Color.red);
		colors.Add (new Color (0.2f, 0.3f, 0.4f)); //orange?
		colors.Add (Color.yellow);
		colors.Add (Color.green);
		colors.Add (Color.blue);
		colors.Add (new Color(75f/255f,0,130f/255f)); //indigo?
		colors.Add (new Color (138f / 255f, 43f / 255f, 226f / 255f)); //violet?

		particles = GameObject.Find ("Rainbow Particles");
		coverParticles = GameObject.Find ("Rainbow Cover Particles");

		rainbowLine = new GameObject();
		rainbowLine.AddComponent<LineRenderer>();
		rainbowRenderer = rainbowLine.GetComponent<LineRenderer> ();
		c1 = Color.blue;
		c2 = Color.red;
		c1target = Color.red;
		c2target = Color.blue;
		colorIndex1 = 0;
		colorIndex2 = 1;
		counter = 0;
		particles.GetComponent<ParticleSystem> ().emissionRate = 0;
		coverParticles.GetComponent<ParticleSystem> ().emissionRate = 0;
	}
	
	// Update is called once per frame
	void Update () {
		counter += Time.deltaTime * 20;



		if (counter >= 1) {
			counter = 0;
			//colorIndex1 = Random.Range(0,colors.Count-1);
			//colorIndex2 = Random.Range(0,colors.Count-1);
			colorIndex1 = (colorIndex1 + 1) % (colors.Count-1);
			colorIndex2 = (colorIndex2 + 1) % (colors.Count-1);
			c1target = colors[colorIndex1];
			c2target = colors[colorIndex2];
		}

		//int i = 0;

		c1 = Color.Lerp (c1, c1target, counter);
		c2 = Color.Lerp (c2, c2target, counter);

		//while (i < lengthOfLineRenderer) {
		//	Vector3 pos = new Vector3(i * 0.5F, Mathf.Sin(i + Time.time), 0);
		//	rainbowRenderer.SetPosition(i, pos);
		//	i++;
		//}

		if (Input.GetKey (KeyCode.R)&&canshoot) {

						currentbreath -= Time.deltaTime;
						if(currentbreath<0)
							canshoot = false;
						rainbowRenderer.enabled = true;
						RaycastHit2D hit = Physics2D.Raycast (GameObject.Find ("FlameBreathOrigin").transform.position, Vector2.right, beamRange, collisionLevel);

						if (hit.transform != null) {
								HitObj = hit.transform.gameObject;
								//HitObj.SendMessage("takeDamage",beamDamagePerSecond * Time.deltaTime);
								HitObj.SendMessage ("HitByARainbow", Time.deltaTime);
						} else {
								hit.point = GameObject.Find ("FlameBreathOrigin").transform.position + new Vector3 (beamRange, 0f, 0f);
						}

						Distance = Mathf.Abs (hit.point.y - transform.position.y);


						rainbowRenderer.material = new Material (Shader.Find ("Particles/Additive"));
						rainbowRenderer.sortingLayerName = "Middle_player";
						rainbowRenderer.SetColors (c2, c1);
						rainbowRenderer.SetPosition (0, GameObject.Find ("FlameBreathOrigin").transform.position);
						//rainbowRenderer.SetPosition(1, hit.point + new Vector2(0f,Mathf.Sin(Time.time)));
						rainbowRenderer.SetPosition (1, hit.point);
						rainbowRenderer.SetWidth (0.03f, 0.5f);

						particles.transform.position = hit.point;
						coverParticles.transform.position = hit.point;
						particles.GetComponent<ParticleSystem> ().emissionRate = 200;
						coverParticles.GetComponent<ParticleSystem> ().emissionRate = 200;
		
				} else {
					currentbreath += Time.deltaTime;
					if(currentbreath>maxbreath){
						canshoot=true;
				currentbreath = maxbreath;
			}
						

			rainbowRenderer.SetWidth(0,0);
			particles.GetComponent<ParticleSystem> ().emissionRate = 0;
			coverParticles.GetComponent<ParticleSystem> ().emissionRate = 0;
				

				}

		if(Input.GetKeyUp(KeyCode.R)){
			particles.GetComponent<ParticleSystem> ().emissionRate = 0;
			coverParticles.GetComponent<ParticleSystem> ().emissionRate = 0;
			rainbowRenderer.enabled = false;
		}
	
	}
}
