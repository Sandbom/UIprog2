using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onPickup : MonoBehaviour {

	public float Score;


	// Removes coin on pickup and adds score
	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "Player") {
			Destroy (gameObject);
			ScoreScript.scoreValue += 100;
		}
	}
}
