using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public float enemyMaxHealth;

	float currentHealth;

	// Use this for initialization
	void Start () {
		currentHealth = enemyMaxHealth;	
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addDamage(float damage){
		currentHealth = currentHealth - damage;
		if (currentHealth <= 0) {
			killEnemy ();
		}
	}

	void killEnemy(){
		Destroy (gameObject);
	}
}
