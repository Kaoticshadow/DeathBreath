﻿using UnityEngine;
using System.Collections;

public class DragonHP : MonoBehaviour {


	public int currentHealth = 100;
	public int maxHealth = 100;
	
	Stack healthScales = new Stack();



	// Use this for initialization
	void Start () 
	{


		healthScales.Push(GameObject.Find ("DragonScaleHealthBar-1"));
		healthScales.Push(GameObject.Find ("DragonScaleHealthBar-2"));
		healthScales.Push(GameObject.Find ("DragonScaleHealthBar-3"));
		healthScales.Push(GameObject.Find ("DragonScaleHealthBar-4"));
		healthScales.Push(GameObject.Find ("DragonScaleHealthBar-5"));


	
	}



	// Update is called once per frame
	void Update () 
	{

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

			Gravitron.rigidbody2D.velocity = new Vector3(1, -4, 0);
	



			healthScales.Pop();
		}

		if (currentHealth <= 0)
		{
			GameObject LosingText = GameObject.Find ("LosingText");

			GameObject.Find ("LosingText").guiText.text  = "YOU LOSE SUCKAAAAA";
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
