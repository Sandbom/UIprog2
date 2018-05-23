using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {

	public float enemySpeed;

	Animator enemyAnimator;

	//facing variable
	public GameObject enemyGraphic;
	bool canFlip = true;
	bool facingRight = true;
	float flipTime = 5f;
	float nextFlipChance = 0f;

	//attacking variables
	public float chargeTime;
	float startChargeTime;
	bool SeesPlayer;
	Rigidbody2D enemyRB;



	AudioSource enemyAS;
	public AudioClip enemyNoticeSound;
	SkeletonHealthController enemyhp;

	// Use this for initialization
	void Start () {
		enemyAnimator = GetComponentInChildren<Animator> ();
		enemyRB = GetComponent<Rigidbody2D> ();
		enemyAS = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextFlipChance) {
			if (Random.Range (0, 10) >= 5) {
				flipFacing ();
			}
			nextFlipChance = Time.time + flipTime;
		}
		//EnemyHealth enemyhp = gameObject.GetComponentInChildren<EnemyHealth> ();
		//if (!enemyhp.alive) {
		//	enemyRB.isKinematic = true;
	//	}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			if (facingRight && other.transform.position.x < transform.position.x) {
				flipFacing ();
			}
			else if(!facingRight && other.transform.position.x > transform.position.x){
				flipFacing ();							
			}
			canFlip = false;
			SeesPlayer = true;
			startChargeTime = Time.time + chargeTime;
			enemyAS.clip = enemyNoticeSound;
			enemyAS.PlayOneShot (enemyNoticeSound);

		}
	}

	void OnTriggerStay2D(Collider2D other){

		if (other.tag == "Player") {
			if (!attackClosePlayer.attacking) {
				if (startChargeTime < Time.time) {
					SkeletonHealthController enemyhp = gameObject.GetComponentInChildren<SkeletonHealthController> ();
					if (!facingRight && enemyhp.alive) {
						enemyRB.AddForce (new Vector2 (-1, 0) * enemySpeed);
					} else if (facingRight && enemyhp.alive) {
						enemyRB.AddForce (new Vector2 (1, 0) * enemySpeed);
					} else if (!enemyhp.alive) {
						enemyRB.AddForce (new Vector2 (0f, 0f));
						enemyRB.angularVelocity = 0;
						enemyRB.angularDrag = 0;
					}
					enemyAnimator.SetBool ("SeesPlayer", SeesPlayer);	
				}
			} else if (attackClosePlayer.attacking) {
				enemyAnimator.SetBool ("SeesPlayer", SeesPlayer);
			}
		}
	}	

	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player") {
			canFlip = true;
			SeesPlayer = false;
			enemyRB.velocity = new Vector2 (0f, 0f);
			enemyAnimator.SetBool ("SeesPlayer", SeesPlayer);

		}
	}


	void flipFacing(){
		if (!canFlip) {
			return;
		}
		float facingX = enemyGraphic.transform.localScale.x;
		facingX *= -1f;
		enemyGraphic.transform.localScale = new Vector3 (facingX, enemyGraphic.transform.localScale.y, enemyGraphic.transform.localScale.z);
		facingRight = !facingRight;
	}
}
