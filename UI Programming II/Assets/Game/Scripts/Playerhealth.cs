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
	public Image damageScreen;

	bool damaged = false;
	Color damagedColor = new Color(255f,255f,255f,0.5f);
	float smoothColor = 2f;

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
		if (damaged) {
			damageScreen.color = damagedColor;
		} else {
			damageScreen.color = Color.Lerp (damageScreen.color, Color.clear, smoothColor*Time.deltaTime);
		}
		damaged = false;
		
	}

	public void addDamage(float Damage){
		if (Damage <= 0) {
			return;
		}
		currentHealth = currentHealth - Damage;
		healthSlider.value = currentHealth;
		damaged = true;

		if (currentHealth <= 0) {
			killPlayer ();
		}
			
	}

	public void killPlayer(){
		Instantiate (Deatheffect, transform.position, transform.rotation);
		Destroy (gameObject);
	}
}
