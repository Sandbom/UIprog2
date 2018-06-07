using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour {

	public float damage;
	public float damagerate;
	public float pushBackForce;
	public GameObject Deatheffect;

	float nextDamage;

	// Use this for initialization
	void Start () {
		nextDamage = 0f;
		
	}

	// Push back player and add damage to player
	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "Player" && nextDamage < Time.time) {
			Playerhealth HP = other.gameObject.GetComponent<Playerhealth> ();
			HP.addDamage (damage);
			nextDamage = Time.time + damagerate;

			pushBack (other.transform);
		}
	}

	// If player comes in contact with an enemy make the player get pushed away
	void pushBack(Transform pushedObject){
		Vector2 pushDirection = new Vector2 (pushedObject.position.x - transform.position.x, pushedObject.position.y - transform.position.y).normalized;
		pushDirection *= pushBackForce;
		Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D> ();
		pushRB.velocity = Vector2.zero;
		pushRB.AddForce (pushDirection, ForceMode2D.Impulse);
		Instantiate (Deatheffect, transform.position, transform.rotation);

	}

}
