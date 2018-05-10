using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playerhealth : MonoBehaviour {

	public float fullHealth;
	public GameObject Deatheffect;

	float currentHealth;

	PlayerController controlMovement;


	// HUD variables
	public Slider healthSlider;

	// Use this for initialization
	void Start () {
		currentHealth = fullHealth;

		controlMovement = GetComponent<PlayerController> ();

		// HUD initialization
		healthSlider.maxValue=fullHealth;
		healthSlider.value = fullHealth;
	}


	
	// Update is called once per frame
	void Update () {
		
	}

	public void addDamage(float Damage){
		if (Damage <= 0) {
			return;
		}
		currentHealth = currentHealth - Damage;
		healthSlider.value = currentHealth;

		if (currentHealth <= 0) {
			killPlayer ();
		}
			
	}

	public void killPlayer(){
		Instantiate (Deatheffect, transform.position, transform.rotation);
		Destroy (gameObject);
	}
}
