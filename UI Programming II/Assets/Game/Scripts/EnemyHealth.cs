using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

	public float enemyMaxHealth;

	public GameObject enemyDeathFX;
	public Slider enemyhealthbar;

	public bool drops;
	public GameObject theDrop;
	float dropChance;

	Animator enemyAnim;

	float currentHealth;
	Rigidbody2D enemyRB;

	public AudioClip PlantDeathSound;
	AudioSource plantAS;

	SpriteRenderer rend;
	PolygonCollider2D col,col2;
	Animator anim;

	enemyDamage dmg;



	// Use this for initialization
	void Start () {
		currentHealth = enemyMaxHealth;	
		enemyhealthbar.maxValue = currentHealth;
		enemyhealthbar.value = currentHealth;
		enemyAnim = GetComponentInChildren<Animator> ();
		enemyRB = GetComponentInParent<Rigidbody2D> ();
		plantAS = GetComponent<AudioSource> ();
		rend = GetComponent<SpriteRenderer> ();
		col = GetComponent<PolygonCollider2D> ();
		col2 = GetComponentInChildren<PolygonCollider2D> ();
		anim = GetComponent<Animator> ();
		dmg = GetComponent<enemyDamage> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addDamage(float damage){
		enemyhealthbar.gameObject.SetActive (true);
		currentHealth = currentHealth - damage;
		enemyhealthbar.value = currentHealth;

		if (currentHealth <= 0) {
			ScoreScript.scoreValue += 100;
			plantAS.clip = PlantDeathSound;
			plantAS.PlayOneShot (PlantDeathSound);
			Instantiate (enemyDeathFX, transform.position, transform.rotation);

			//Disable all attributes of the gameobject as if we destroy it completely it cannot play any sounds
			rend.enabled = false;
			col.enabled = false;
			anim.enabled = false;
			dmg.enabled = false;
			foreach (Transform child in transform)
				child.gameObject.SetActive(false);
			gameObject.tag = "Untagged";
			gameObject.layer = 0;
			killEnemy ();


		}
	}

	void killEnemy(){

		Destroy (gameObject, 3f);
		// On death plants have a 15% chance of dropping health
		dropChance = Random.Range (0f, 10f);
		if (drops && dropChance >= 8.5) {
			Instantiate (theDrop, transform.position, transform.rotation);
		}
	}
		
}
