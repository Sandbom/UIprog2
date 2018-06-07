using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onPowerPickup : MonoBehaviour {

	public static bool Powerupped = false;
	public static bool removeTimers = false;


	float timer = 1f;

	// Sets lightning effect weapon to true for 10 seconds after reset is called
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			gameObject.SetActive (false);
			Destroy (gameObject, 15f);
			Powerupped = true;
			Invoke ("resetPowerup", 10);
		}
	}

	// Resets lightning effect
	void resetPowerup(){
		Powerupped = false;
		removeTimers = true;
	}
}
