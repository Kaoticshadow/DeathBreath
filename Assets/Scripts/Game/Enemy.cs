using UnityEngine;
using System.Collections;

using System.Collections.Generic;

public class Enemy : MonoBehaviour {

	public float health = 1;
	
	List<SpriteRenderer> boss_sprites;
	public GameObject drop;
	// Use this for initialization
	void Start () {
		boss_sprites = new List<SpriteRenderer>();
		
		foreach(SpriteRenderer spriteRenderer in GetComponentsInChildren<SpriteRenderer>()){
			boss_sprites.Add(spriteRenderer);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void takeDamage(float damage){
		health -= damage;
		
		StartCoroutine("playDeathAnimation");
		if (health < 0)
		{
			if(drop != null){
				Instantiate (drop, this.transform.localPosition, Quaternion.identity);
			}
			Destroy (this.gameObject);
		}
	}


	
	IEnumerator playDeathAnimation(){
		//this.GetComponent<Animator>().enabled = false;
		StartCoroutine(FlashSprites (boss_sprites, 2, 0.05f, true));
		foreach(SpriteRenderer spriteRender in boss_sprites){
			Rigidbody2D spriteBody = spriteRender.gameObject.GetComponent<Rigidbody2D>();
			Collider2D spriteCollider = spriteRender.gameObject.GetComponent<Collider2D>();
			if(spriteCollider != null){
				spriteCollider.enabled = false;
			}
		}
		yield return new WaitForSeconds(3.0f);
		//GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().stopMusic();
		//GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().playMusic2();
		yield return new WaitForSeconds(1f);
		//this.transform.parent.rigidbody2D.AddForce(new Vector2(0f,-100f));
		yield return new WaitForSeconds(10.0f);
		GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>().endLevel(new Vector2(900.0f, 300.0f));
		Destroy (this.transform.parent.parent.gameObject);
	}
	
	IEnumerator FlashSprites(List<SpriteRenderer> sprites, int numTimes, float delay, bool disable = false) {
		// number of times to loop
		for (int loop = 0; loop < numTimes; loop++) {            
			// cycle through all sprites
			for (int i = 0; i < sprites.Count; i++) {                
				if (disable) {
					// for disabling
					sprites[i].enabled = false;
				} else {
					// for changing the alpha
					//sprites[i].color = new Color(sprites[i].color.r, sprites[i].color.g, sprites[i].color.b, 0.1f);
					//Debug.Log(sprites[i]);
					//Debug.Log(i);
					sprites[i].color = new Color(1.0f,0.3f,0.3f,1f);
					
					if(i==11)//magic number!
						sprites[i].color = new Color(1.0f,0.3f,0.3f,0);
				}
			}
			
			// delay specified amount
			yield return new WaitForSeconds(delay);
			
			// cycle through all sprites
			for (int i = 0; i < sprites.Count; i++) {
				if (disable) {
					// for disabling
					sprites[i].enabled = true;
				} else {
					// for changing the alpha
					//sprites[i].color = new Color(sprites[i].color.r, sprites[i].color.g, sprites[i].color.b, 1);
					sprites[i].color = new Color(1f,1f,1f,1f);
					
					if(i==11)//magic number!
						sprites[i].color = new Color(1.0f,0.3f,0.3f,0);
				}
			}
			
			// delay specified amount
			yield return new WaitForSeconds(delay);
		}
	}
}
