using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour {

	public float projectileSpeed;
	public float weaponDamage;

	Rigidbody2D myRB;

	// Awake is called once the object is instantiated, in this case the boss projectile.
	// this function makes sure the projectile is fired in the right direction & proper speed
	void Awake () {
		myRB = GetComponent<Rigidbody2D> ();
		if (transform.localRotation.z <= 0) {
			myRB.AddForce (new Vector2 (-1, 0) * projectileSpeed, ForceMode2D.Impulse);
		}
		else myRB.AddForce (new Vector2 (1, 0) * projectileSpeed, ForceMode2D.Impulse);
	}

	// if bullet hits player, add damage to player health.
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.layer == LayerMask.NameToLayer ("Ground")) {
			Destroy (gameObject);
		}
		if (other.tag == "Player") {

			Playerhealth hurtPlayer = other.gameObject.GetComponent<Playerhealth> ();
			hurtPlayer.addDamage (weaponDamage);
		}
	}

}
