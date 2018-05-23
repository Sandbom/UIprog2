using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackClosePlayer : MonoBehaviour {

	Animator enemyanim;
	Rigidbody2D parentRB;
	public GameObject skeleton;

	public static bool attacking = false;

	// Use this for initialization
	void Start () {
		//enemyanim = GameObject.Find("Skeleton_PowerfulAIenemy").GetComponent<Animator> ();
		enemyanim = skeleton.GetComponent<Animator>();
		parentRB = GetComponentInParent<Rigidbody2D> ();
	}


	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "Player") {
			attacking = true;
			//enemyanim.SetBool ("SeesPlayer", false);
			enemyanim.SetBool ("AttackPlayer", true);
			parentRB.isKinematic = true;
		}
	}


	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player") {
			attacking = false;
			enemyanim.SetBool ("SeesPlayer", true);
			enemyanim.SetBool ("AttackPlayer", false);
			parentRB.isKinematic = false;
		}
	}
}
