using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackClosePlayer : MonoBehaviour {

	Animator enemyanim;
	Rigidbody2D parentRB;

	// Use this for initialization
	void Start () {
		enemyanim = GameObject.Find("Skeleton_PowerfulAIenemy").GetComponent<Animator> ();
		parentRB = GetComponentInParent<Rigidbody2D> ();
	}


	void OnTriggerStay2D(Collider2D other){

		if (other.tag == "Player") {
			enemyanim.SetBool ("SeesPlayer", false);
			enemyanim.SetBool ("AttackPlayer", true);
			parentRB.isKinematic = true;
		}
	}


	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player") {
			enemyanim.SetBool ("SeesPlayer", true);
			enemyanim.SetBool ("AttackPlayer", true);
			parentRB.isKinematic = false;
		}
	}
}
