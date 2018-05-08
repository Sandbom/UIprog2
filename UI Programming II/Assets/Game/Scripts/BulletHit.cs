using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour {

	public float weaponDamage;

	projectileController myPC;

	public GameObject explosionEffect;

	// Use this for initialization
	void Awake () {
		myPC = GetComponentInParent<projectileController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Enemy") {
			Instantiate (explosionEffect, transform.position, transform.rotation);
			Destroy (gameObject);
		}
	}
}
