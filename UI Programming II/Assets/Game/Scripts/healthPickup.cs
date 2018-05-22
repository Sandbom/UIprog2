using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPickup : MonoBehaviour {

	public float healthAmount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			Playerhealth theHealth = other.gameObject.GetComponent<Playerhealth> ();
			theHealth.addHealth (healthAmount);
			Destroy (gameObject);
		}
	}
}
