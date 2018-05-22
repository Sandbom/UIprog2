using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playerhealth : MonoBehaviour {

	public float fullHealth;
	public GameObject Deatheffect;
	public AudioClip PlayerhurtSound;

	AudioSource playerAS;

	float currentHealth;

	PlayerController controlMovement;


	// HUD variables
	public Slider healthSlider;
	public Image damageScreen;
	public GameObject gameOverText;
	public GameObject RetryButton;

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

		playerAS = GetComponent<AudioSource> ();
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

		playerAS.clip = PlayerhurtSound; // Set clip to play on damage taken
		playerAS.PlayOneShot(PlayerhurtSound);
		healthSlider.value = currentHealth;
		damaged = true;

		if (currentHealth <= 0) {
			killPlayer ();
		}
			
	}

	public void addHealth(float healthAmount){
		currentHealth += healthAmount;
		if (currentHealth > fullHealth) {
			currentHealth = fullHealth;
		}
		healthSlider.value = currentHealth;
	}

	public void killPlayer(){
		Instantiate (Deatheffect, transform.position, transform.rotation);
		Destroy (gameObject);

		damageScreen.color = damagedColor;
		Animator gameOverAnimator = gameOverText.GetComponent<Animator> ();
		gameOverAnimator.SetTrigger ("gameOver");
		RetryButton.SetActive (true);
	}
}
