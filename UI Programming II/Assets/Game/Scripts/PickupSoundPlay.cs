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
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			pickupAS.clip = PickupSound;
			pickupAS.PlayOneShot (PickupSound);	
			soundCol.enabled = false;

		}
	}
}
