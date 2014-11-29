using UnityEngine;
using System.Collections;

using System.Collections.Generic;

public class Enemy : MonoBehaviour {

	public float health = 1;
	
	List<SpriteRenderer> enemy_sprites;
	public GameObject drop;
	// Use this for initialization
	void Start () {
		enemy_sprites = new List<SpriteRenderer>();
		
		foreach(SpriteRenderer spriteRenderer in GetComponentsInChildren<SpriteRenderer>()){
			enemy_sprites.Add(spriteRenderer);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void takeDamage(float damage){
		health -= damage;
		
		StartCoroutine(FlashSprites (enemy_sprites, 1, 0.1f, false));
		if (health < 0)
		{
			if(drop != null){
				Instantiate (drop, this.transform.localPosition, Quaternion.identity);
			}
			Destroy (this.gameObject);
		}
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
