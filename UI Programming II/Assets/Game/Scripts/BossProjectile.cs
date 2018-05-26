using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour {

	public float projectileSpeed;
	public float weaponDamage;

	Rigidbody2D myRB;

	// Use this for initialization
	void Awake () {
		myRB = GetComponent<Rigidbody2D> ();
		if (transform.localRotation.z <= 0) {
			myRB.AddForce (new Vector2 (-1, 0) * projectileSpeed, ForceMode2D.Impulse);
		}
		else myRB.AddForce (new Vector2 (1, 0) * projectileSpeed, ForceMode2D.Impulse);
	}


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
