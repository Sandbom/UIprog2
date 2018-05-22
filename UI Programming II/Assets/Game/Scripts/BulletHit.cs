using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour {

	public float weaponDamage;

	//projectileController myPC;

	public GameObject explosionEffect;

	// Use this for initialization
	//void Awake () {
	//	myPC = GetComponentInParent<projectileController> ();
	//}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.layer == LayerMask.NameToLayer ("Shootable")) {
			Instantiate (explosionEffect, transform.position, transform.rotation);
			Destroy (gameObject);
		} else if (other.gameObject.layer == LayerMask.NameToLayer ("Ground")) {
			Instantiate (explosionEffect, transform.position, transform.rotation);
			Destroy (gameObject);
		}

		if (other.tag == "Enemy") {

			EnemyHealth hurtEnemy = other.gameObject.GetComponent<EnemyHealth> ();
			hurtEnemy.addDamage (weaponDamage);
		}

		if (other.tag == "Enemy1") {
			SkeletonHealthController hurtEnemy = other.gameObject.GetComponent<SkeletonHealthController> ();
			hurtEnemy.addDamage (weaponDamage);
		}
	}
}
