using UnityEngine;
using System.Collections;

public class DragonCollide : MonoBehaviour {

	public int currentHealth = 100;
	public int maxHealth = 100;
	public int blinkduration = 10;
	public int invincibilityFrames = 80;
	public float invincibilityDuration = 1.5f;
	public float invulnerableCountdown = 0f;

	//int invulnerableCountdown;
	//int blinkCount= 0;
	bool invulnerable;
	Renderer[] m_sprites;
	// Use this for initialization
	void Start () {
		invulnerable = false;
		invincibilityFrames = 0;
		invulnerableCountdown = 0;
		m_sprites = this.GetComponentsInChildren<Renderer>();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (invulnerable) {

			if(invincibilityFrames % blinkduration == 0){
				foreach(Renderer r in m_sprites) {
						r.enabled = !r.enabled;
				}
			}
			invincibilityFrames ++;
		}

		invulnerableCountdown -= Time.deltaTime;

		if (invulnerable && invulnerableCountdown <= 0) {
			invulnerable = false;
			foreach(Renderer r in m_sprites) {
				r.enabled = true;
			}
		}
	}

	void takeDamage(){
		if (!invulnerable) 
		{
			GameObject.Find("Health Bar").SendMessage("DropScale");
			invulnerable = true;
			invulnerableCountdown = invincibilityDuration;
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (!invulnerable) 
		{
			Debug.Log (coll.gameObject.name);
			if (coll.gameObject.tag == "Enemy"||coll.gameObject.tag == "EnemyProjectile"||coll.gameObject.tag == "EnemyTerrain") {
				//AdjustCurrentHealth (-20);
				takeDamage();
				if(coll.gameObject.tag == "EnemyProjectile"){
					Destroy (coll.gameObject);
				}
			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (!invulnerable) 
		{
			Debug.Log (coll.gameObject.name);
			if (coll.gameObject.tag == "Enemy"||coll.gameObject.tag == "EnemyProjectile"||coll.gameObject.tag == "EnemyTerrain") {
				//AdjustCurrentHealth (-20);
				takeDamage();
				if(coll.gameObject.tag == "EnemyProjectile"){
					Destroy (coll.gameObject);
				}
			}
		}
	}
}
