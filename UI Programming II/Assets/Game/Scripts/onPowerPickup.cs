using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onPowerPickup : MonoBehaviour {

	public static bool Powerupped = false;
	public static bool removeTimers = false;


	float timer = 1f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}


	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			gameObject.SetActive (false);
			Destroy (gameObject, 15f);
			Powerupped = true;
			Invoke ("resetPowerup", 10);
		}
	}

	void resetPowerup(){
		Powerupped = false;
		removeTimers = true;
	}
}
