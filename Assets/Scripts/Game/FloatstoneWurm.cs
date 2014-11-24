using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FloatstoneWurm : MonoBehaviour {
	public FloatstoneWurmSegment head;
	public FloatstoneWurmSegment body;
	public FloatstoneWurmSegment tail;
	public int bodySegmentCount = 6;
	public float health = 10f;
	public bool dying;
	List<SpriteRenderer> boss_sprites;
	FloatstoneWurmSegment headSegment;

	// Use this for initialization
	void Start () {

		dying = false;

		//get all the sprites that form the boss
		boss_sprites = new List<SpriteRenderer>();

		Vector3 offset = new Vector3 (2.5f, 0f, 0f);

		FloatstoneWurmSegment bodySegment;
		FloatstoneWurmSegment tailSegment;

		headSegment = Instantiate (head, this.transform.position, Quaternion.identity) as FloatstoneWurmSegment;
		headSegment.mainBody = this;

		foreach(SpriteRenderer spriteRenderer in headSegment.GetComponentsInChildren<SpriteRenderer>()){
			boss_sprites.Add(spriteRenderer);
		}


		for (int x = 1; x<=bodySegmentCount; x++) {
			bodySegment = Instantiate (body, this.transform.position + offset*(x*1.0f), Quaternion.identity) as FloatstoneWurmSegment;
			bodySegment.bodyRotation = x*60f;
			bodySegment.mainBody = this;
			boss_sprites.Add (bodySegment.GetComponentInChildren<SpriteRenderer>());
		}

		tailSegment = Instantiate (tail, this.transform.position + offset*(bodySegmentCount*1.0f), Quaternion.identity) as FloatstoneWurmSegment;
		tailSegment.mainBody = this;
		boss_sprites.Add(tailSegment.GetComponentInChildren<SpriteRenderer>());
	}

	public void takeDamage(float damage){
		health -= damage;
		//boss_sprites = this.transform.parent.parent.GetComponentsInChildren<SpriteRenderer>();
		StartCoroutine(FlashSprites(boss_sprites,1,0.1f,false));
		if (health < 0 && !dying)
		{
			dying = true;
			StartCoroutine("playDeathAnimation");
		}
	}

	IEnumerator playDeathAnimation(){

		StartCoroutine(FlashSprites (boss_sprites, 7, 0.2f, true));

		foreach(SpriteRenderer spriteRender in boss_sprites){
			Rigidbody2D spriteBody = spriteRender.gameObject.GetComponent<Rigidbody2D>();
			if(spriteBody != null){
				spriteBody.velocity = new Vector2(0f,0f);
			}
			Collider2D spriteCollider = spriteRender.gameObject.GetComponent<Collider2D>();
			if(spriteCollider != null){
				spriteCollider.enabled = false;
			}
		}
		headSegment.rigidbody2D.velocity = new Vector2(0f,0f);

		yield return new WaitForSeconds(1f);

		//headSegment.rigidbody2D.velocity = new Vector2(0f,-1f);
		headSegment.rigidbody2D.gravityScale = 1.0f;

		foreach(SpriteRenderer spriteRender in boss_sprites){
			Rigidbody2D spriteBody = spriteRender.gameObject.GetComponent<Rigidbody2D>();
			if(spriteBody != null){
				yield return new WaitForSeconds(1f);
				//spriteBody.velocity = new Vector2(0f,-1f);
				spriteBody.rigidbody2D.gravityScale = 1.0f;
			}
		}




		yield return new WaitForSeconds(3.0f);
		GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>().endLevel(new Vector2(900.0f, 300.0f));	
		//GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().stopMusic();
		//GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().playMusic2();
		yield return new WaitForSeconds(1f);
		//this.transform.parent.rigidbody2D.AddForce(new Vector2(0f,-100f));
		yield return new WaitForSeconds(10.0f);
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
					sprites[i].color = new Color(1.0f,0.3f,0.3f,1f);
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
				}
			}
			
			// delay specified amount
			yield return new WaitForSeconds(delay);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
