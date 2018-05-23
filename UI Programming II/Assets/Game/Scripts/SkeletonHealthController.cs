using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeletonHealthController : MonoBehaviour {

	public float SkeletonHP;

	public Slider enemyhealthbar1;
	public AudioClip enemyDeathSound;
	AudioSource enemyAS;

	Animator enemyAnim;

	float currentHealth;
	public bool alive = true;
	Rigidbody2D enemyRB;
	public BoxCollider2D SkeletonCollider1;
	public BoxCollider2D SkeletonCollider2;

	// Boolean to check wether the target is in the process of dying, so shooting it wont add more score
	bool dying = false;

	// Use this for initialization
	void Start () {
		currentHealth = SkeletonHP;	
		enemyhealthbar1.maxValue = currentHealth;
		enemyhealthbar1.value = currentHealth;
		enemyAnim = GetComponentInChildren<Animator> ();
		enemyRB = GetComponentInParent<Rigidbody2D> ();
		enemyAS = GetComponent<AudioSource> ();
		SkeletonCollider1 = GetComponent<BoxCollider2D> ();
		SkeletonCollider2 = GetComponent<BoxCollider2D> ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void addDamage(float damage){
		enemyhealthbar1.gameObject.SetActive (true);
		currentHealth = currentHealth - damage;
		enemyhealthbar1.value = currentHealth;

		if (currentHealth <= 0 && dying == false) {
			// Disable the colliders during the deathanimaton so the player can walk through the corpse and doesnt
			// take damage from touching the corpse, we also set the parents Rigidbody to kinematic to avoid the corpse falling through the map
			foreach(Collider2D c in GetComponents<BoxCollider2D> ()) {
				c.enabled = false;
			}
			enemyRB.isKinematic = true;
			alive = false;
			dying = true;
			enemyAS.clip = enemyDeathSound;
			enemyAS.PlayOneShot (enemyDeathSound);
			ScoreScript.scoreValue += 500;
			enemyAnim.SetBool ("EnemyDeath", true);
			Destroy(gameObject, 1.1f);
		}
	}

	void killEnemy(){
		Destroy (gameObject);
	}

}