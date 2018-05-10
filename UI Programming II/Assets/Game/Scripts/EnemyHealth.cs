using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

	public float enemyMaxHealth;

	public GameObject enemyDeathFX;
	public Slider enemyhealthbar;

	float currentHealth;

	// Use this for initialization
	void Start () {
		currentHealth = enemyMaxHealth;	
		enemyhealthbar.maxValue = currentHealth;
		enemyhealthbar.value = currentHealth;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addDamage(float damage){

		enemyhealthbar.gameObject.SetActive (true);
		currentHealth = currentHealth - damage;
		enemyhealthbar.value = currentHealth;

		if (currentHealth <= 0) {
			killEnemy ();
		}
	}

	void killEnemy(){
		Instantiate (enemyDeathFX, transform.position, transform.rotation);
		Destroy (gameObject);
	}
}
