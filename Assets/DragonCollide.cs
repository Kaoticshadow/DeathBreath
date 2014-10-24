using UnityEngine;
using System.Collections;

public class DragonCollide : MonoBehaviour {

	public int currentHealth = 100;
	public int maxHealth = 100;
	public int invulnerableCountdown;
	public int blinkduration = 10;
	int blinkCount= 0;
	bool invulnerable;
	SpriteRenderer m_sprite;
	// Use this for initialization
	void Start () {
		invulnerable = false;
		invulnerableCountdown = 0;
		m_sprite = this.gameObject.GetComponent <SpriteRenderer>();
	
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
				if (m_sprite.color.a == 0f)
					m_sprite.color = new Color (1f, 1f, 1f, 1f);
				else
					m_sprite.color = new Color (1f, 1f, 1f, 0f);
			}
		} else {
			m_sprite.color = new Color (1f, 1f, 1f, 1f);
		}
	
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (!invulnerable) 
		{
			Debug.Log (coll.gameObject.name);
			if (coll.gameObject.tag == "Enemy)") {
				//AdjustCurrentHealth (-20);
				GameObject.Find("Health Bar").GetComponent<HealthScript>().SendMessage("DropScale");
				invulnerable = true;
				invulnerableCountdown = 90;
			}
		}
	}
}
