using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour {

	public float weaponDamage;

	public GameObject explosionEffect;


	// When entering projectile collider and if object shootable or ground we detroy the bullet and instantiate explosion animation
	// If it is an enemy we call its addDamage function to add damage to its health.
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.layer == LayerMask.NameToLayer ("Shootable")) {
			Instantiate (explosionEffect, transform.position, transform.rotation);
			Destroy (gameObject);
		} else if (other.gameObject.layer == LayerMask.NameToLayer ("Ground")) {
			Instantiate (explosionEffect, transform.position, transform.rotation);
			Destroy (gameObject);
		}

		if (other.tag == "Enemy") {

			EnemyHealth hurtEnemy = other.gameObject.GetComponent<EnemyHealth> ();
			hurtEnemy.addDamage (weaponDamage);
		}

		if (other.tag == "Enemy1") {
			SkeletonHealthController hurtEnemy = other.gameObject.GetComponent<SkeletonHealthController> ();
			hurtEnemy.addDamage (weaponDamage);
		}
		if (other.tag == "Boss") {
			BossMovement hurtEnemy = other.gameObject.GetComponent<BossMovement> ();
			hurtEnemy.addDamage (weaponDamage);
		}
	}
}
