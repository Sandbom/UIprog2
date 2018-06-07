using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSoundPlay : MonoBehaviour {


	public AudioClip PickupSound;
	AudioSource pickupAS;

	BoxCollider2D soundCol;

	// Use this for initialization
	void Start () {
		pickupAS = GetComponent<AudioSource> ();
		soundCol = GetComponent<BoxCollider2D> ();
	}

	// Play pickup sound when collecting coins and disable the collider once picked up once to prevent hearing sound multiple times
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			pickupAS.clip = PickupSound;
			pickupAS.PlayOneShot (PickupSound);	
			soundCol.enabled = false;

		}
	}
}
