using UnityEngine;
using System.Collections;

public class DragonCollide : MonoBehaviour {

	public int currentHealth = 100;
	public int maxHealth = 100;
	public int invulnerableCountdown;
	public int blinkduration = 10;
	int blinkCount= 0;
	bool invulnerable;
	Renderer m_sprite;
	// Use this for initialization
	void Start () {
		invulnerable = false;
		invulnerableCountdown = 0;
		m_sprite = this.gameObject.renderer;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (invulnerable) {
			invulnerableCountdown--;
			if (invulnerableCountdown <= 0) {
					invulnerable = false;
			}
			blinkCount++;
			if (blinkCount % blinkduration == 0) {
					m_sprite.enabled = !m_sprite.enabled;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (!invulnerable) 
		{
			Debug.Log (coll.gameObject.name);
			if (coll.gameObject.tag == "Enemy") {
				//AdjustCurrentHealth (-20);
				GameObject.Find("Health Bar").GetComponent<HealthScript>().DropScale();
				invulnerable = true;
				invulnerableCountdown = 90;
			}
		}
	}
}
