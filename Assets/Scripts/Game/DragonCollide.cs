using UnityEngine;
using System.Collections;

public class DragonCollide : MonoBehaviour {

	public int currentHealth = 100;
	public int maxHealth = 100;
	public int blinkduration = 10;
	public int invincibilityDuration = 80;

	int invulnerableCountdown;
	//int blinkCount= 0;
	bool invulnerable;
	Renderer[] m_sprites;
	// Use this for initialization
	void Start () {
		invulnerable = false;
		invulnerableCountdown = 0;
		m_sprites = this.GetComponentsInChildren<Renderer>();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (invulnerable) {
			if(invulnerableCountdown % blinkduration == 0){
				foreach(Renderer r in m_sprites) {
						r.enabled = !r.enabled;
				}
			}
		}
	invulnerableCountdown--;

	if (invulnerableCountdown <= 0) {
			invulnerable = false;
			if(invulnerableCountdown % blinkduration == 0){
				foreach(Renderer r in m_sprites) {
					r.enabled = true;
				}
			}
	}
}


	void OnTriggerEnter2D(Collider2D coll) {
		if (!invulnerable) 
		{
			Debug.Log (coll.gameObject.name);
			if (coll.gameObject.tag == "Enemy"||coll.gameObject.tag == "EnemyProjectile") {
				//AdjustCurrentHealth (-20);
				GameObject.Find("Health Bar").SendMessage("DropScale");
				invulnerable = true;
				invulnerableCountdown = 80;
				if(coll.gameObject.tag == "EnemyProjectile"){
					Destroy (coll.gameObject);
				}
			}

			if (coll.gameObject.tag == "HealthPickup") {
				GameObject.Find("Health Bar").SendMessage("AddScale");
				Destroy(coll.gameObject);
			}
		}
	}
}
