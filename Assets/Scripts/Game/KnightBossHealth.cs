using UnityEngine;
using System.Collections;

public class KnightBossHealth : MonoBehaviour {

	public float health = 100.0f;
	bool dying;
	SpriteRenderer[] boss_sprites;

	// Use this for initialization
	void Start () {
		//get all the sprites that form the boss
		//boss_sprites = this.transform.parent.parent.GetComponentsInChildren<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void takeDamage(float damage){
		health -= damage;
		boss_sprites = this.transform.parent.parent.GetComponentsInChildren<SpriteRenderer>();
		StartCoroutine(FlashSprites(boss_sprites,1,0.1f,false));
		if (health < 0 && !dying)
		{
			//Instantiate(spicy_chicken,this.transform.localPosition,Quaternion.identity);
			//	GameObject.FindGameObjectWithTag("PopupScore").GetComponent<PopupScore>().popScore(this.transform.position);

			//Destroy (this.transform.parent.parent.gameObject);
			dying = true;
			StartCoroutine("playDeathAnimation");
			GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>().endLevel(new Vector2(900.0f, 300.0f));

			//	GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript>().increaseScore(100);
			
		}
		//score++;
	}
	IEnumerator playDeathAnimation(){
		this.transform.parent.GetComponent<Animator>().enabled = false;
		StartCoroutine(FlashSprites (boss_sprites, 15, 0.4f, true));
		yield return new WaitForSeconds(3.0f);
		GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().stopMusic();
		GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().playMusic2();
		yield return new WaitForSeconds(1f);
		this.transform.parent.rigidbody2D.AddForce(new Vector2(0f,-100f));
		yield return new WaitForSeconds(10.0f);
		Destroy (this.transform.parent.parent.gameObject);
	}

	IEnumerator FlashSprites(SpriteRenderer[] sprites, int numTimes, float delay, bool disable = false) {
		// number of times to loop
		for (int loop = 0; loop < numTimes; loop++) {            
			// cycle through all sprites
			for (int i = 0; i < sprites.Length; i++) {                
				if (disable) {
					// for disabling
					sprites[i].enabled = false;
				} else {
					// for changing the alpha
					//sprites[i].color = new Color(sprites[i].color.r, sprites[i].color.g, sprites[i].color.b, 0.1f);
					sprites[i].color = new Color(0.5f,0.5f,0.5f,1f);
				}
			}
			
			// delay specified amount
			yield return new WaitForSeconds(delay);
			
			// cycle through all sprites
			for (int i = 0; i < sprites.Length; i++) {
				if (disable) {
					// for disabling
					sprites[i].enabled = true;
				} else {
					// for changing the alpha
					//sprites[i].color = new Color(sprites[i].color.r, sprites[i].color.g, sprites[i].color.b, 1);
					sprites[i].color = new Color(1f,1f,1f,1f);
				}
			}
			
			// delay specified amount
			yield return new WaitForSeconds(delay);
		}
	}

}
