using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			Playerhealth playerfall = other.GetComponent<Playerhealth> ();
			playerfall.killPlayer ();
		} else
			Destroy (other.gameObject);
	}
}
