using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPickup : MonoBehaviour {

	public float healthAmount;


	// Adds health on picking up a heart and destroys the gameobject.
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			Playerhealth theHealth = other.gameObject.GetComponent<Playerhealth> ();
			theHealth.addHealth (healthAmount);
			Destroy (gameObject);
		}
	}
}
