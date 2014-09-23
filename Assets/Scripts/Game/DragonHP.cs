using UnityEngine;
using System.Collections;

public class DragonHP : MonoBehaviour {


	public int currentHealth = 100;
	public int maxHealth = 100;
	public int invulnerableCountdown;
	public int blinkduration = 10;
	int blinkCount= 0;
	bool invulnerable;

	SpriteRenderer m_sprite;
	Stack healthScales = new Stack();



	// Use this for initialization
	void Start () 
	{
		healthScales.Push(GameObject.Find ("DragonScaleHealthBar-1"));
		healthScales.Push(GameObject.Find ("DragonScaleHealthBar-2"));
		healthScales.Push(GameObject.Find ("DragonScaleHealthBar-3"));
		healthScales.Push(GameObject.Find ("DragonScaleHealthBar-4"));
		healthScales.Push(GameObject.Find ("DragonScaleHealthBar-5"));

		invulnerableCountdown = 0;
		m_sprite = this.gameObject.GetComponent <SpriteRenderer>();
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (!invulnerable) 
		{
			Debug.Log (coll.gameObject.name);
			if (coll.gameObject.name == "Arrow(Clone)") {
				AdjustCurrentHealth (-20);
				invulnerable = true;
				invulnerableCountdown = 90;
			}
		}
	}

	// Update is called once per frame
	void Update () 
	{
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


		AdjustCurrentHealth (0);
		/*healthText.text = currentHealth + " / " + maxHealth;



		if (currentHealth < 0) 
		{
			currentHealth = 0;
		}

		if (maxHealth > 100)
		{
			maxHealth = 100;
		}

		if (Input.GetKeyDown (KeyCode.P))
		{
			currentHealth -= 10;
		}

		*/
	
		if(Input.GetKeyDown (KeyCode.K))
		{
			AdjustCurrentHealth (-20);
		}
	}

	public void AdjustCurrentHealth(int adjustment)
	{
		currentHealth += adjustment;
		if(adjustment < 0 )
		{
			GameObject Gravitron = healthScales.Peek () as GameObject;

			Gravitron.rigidbody2D.velocity = new Vector3(2, 2, 0);
			Gravitron.rigidbody2D.gravityScale = 2;
	



			healthScales.Pop();
		}

		if (currentHealth <= 0)
		{
			GameObject LosingText = GameObject.Find ("LosingText");

			GameObject.Find ("LosingText").guiText.text  = "GAME OVER";
		}




	}


	/*IEnumerator HealthRegen (float timeWait)
	{
		int i;
		for (i=1; i>0; i++)
		{
			if (currentHealth < maxHealth)
			{
				currentHealth++;
			}

			yield return new WaitForSeconds (timeWait);

		}

	}*/





	void OnGUI()
	{


		GUI.Label (new Rect (10, 10, 10, 30), "YOU LOSE SUCKAAAAA");
	}






}
