using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour {


	// If player or enemy falls of screen it is killed 
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			Playerhealth playerfall = other.GetComponent<Playerhealth> ();
			playerfall.killPlayer ();
		} else
			Destroy (other.gameObject);
	}
}
