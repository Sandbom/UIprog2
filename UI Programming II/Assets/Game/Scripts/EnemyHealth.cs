using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

	public float enemyMaxHealth;

	public GameObject enemyDeathFX;
	public Slider enemyhealthbar;

	Animator enemyAnim;

	float currentHealth;
	public bool alive = true;
	Rigidbody2D enemyRB;

	// Use this for initialization
	void Start () {
		currentHealth = enemyMaxHealth;	
		enemyhealthbar.maxValue = currentHealth;
		enemyhealthbar.value = currentHealth;
		enemyAnim = GetComponentInChildren<Animator> ();
		enemyRB = GetComponentInParent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addDamage(float damage){
		enemyhealthbar.gameObject.SetActive (true);
		currentHealth = currentHealth - damage;
		enemyhealthbar.value = currentHealth;

		if (currentHealth <= 0) {
			enemyAnim.SetBool ("EnemyDeath", true);
			alive = false;
			//enemyRB.velocity = new Vector2 (0f, 0f);
			Invoke("killEnemy", 1);
		}
	}

	void killEnemy(){
		//Instantiate (enemyDeathFX, transform.position, transform.rotation);
		Destroy (gameObject);
	}
		
}
