using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	//Movement variables
	public float maxSpeed;

	//jumping variables
	bool grounded = false;
	float groundCheckRadius = 0.2f;
	public LayerMask groundLayer;
	public Transform groundCheck;
	public float jumpHeight;


	Rigidbody2D myRB;
	Animator myAnim;
	bool facingRight;


	//For shooting
	public Transform gunTip;
	public Transform lightninggunTip;
	public GameObject bullet;
	public GameObject lightning;
	public float fireRate = 0.15f;
	float nextFire = 0f;	


	// Use this for initialization
	void Start () {
		// Initialize the rigidbody and animator components
		myRB = GetComponent<Rigidbody2D> ();
		myAnim = GetComponent<Animator> ();

		facingRight = true;

	}
	
	// Update is called once per frame
	void Update(){
		if(grounded && Input.GetAxis("Vertical")>0){

			grounded = false;
			myAnim.SetBool("isGrounded",grounded);
			myRB.AddForce(new Vector2(0,jumpHeight));
		}

		//Player shooting, checks if player is pressing the fire button
		if(Input.GetAxisRaw("Jump")>0){
			fireGun ();
		}
	}


	// Fixedupdate is instead called once per milli second for example so its more exact
	void FixedUpdate () {

		//Draw a circle and check if we are touching the ground
		// Check if we are grounded and if no then we are falling
		grounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,groundLayer);
		myAnim.SetBool("isGrounded",grounded);

		myAnim.SetFloat ("verticalSpeed", myRB.velocity.y);

		// Initialize the var Move to get the horizontal axes provided by Unity, if the player presses a or left arrow
		// Move is a negative value between 0 and 1 and if the player presses d or right arrow it is positive instead
		float Move = Input.GetAxis ("Horizontal");

		//Set the animation variable speed to the absolute value of move to differentiate between idle and running animation
		myAnim.SetFloat ("Speed", Mathf.Abs (Move));

		// Change the velocity of our character based on the Move variable and maxSpeed, if Move is positive we move to the right 
		// if move is negative we move to the left
		myRB.velocity = new Vector2 (Move * maxSpeed, myRB.velocity.y);

		//If the player presses d or -> and the character is facing left, flip it
		if (Move > 0 && !facingRight) {
			flip ();
		} 
		//If the player presses a or <- and the character is facing right, flip it
		else if (Move < 0 && facingRight) {
			flip ();
		}
	}

	//Function for flipping the character by manipulation of the x scale variable, if its positive the graphic faces right and
	// if it is negative the character is facing left
	void flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void fireGun(){
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			if (facingRight && !onPowerPickup.Powerupped) {
				Instantiate (bullet, gunTip.position, Quaternion.Euler (new Vector3 (0, 0, 0)));
			} 
			else if (!facingRight && !onPowerPickup.Powerupped) {
				Instantiate (bullet, gunTip.position, Quaternion.Euler (new Vector3 (0, 0, 180)));
			}
			else if (facingRight && onPowerPickup.Powerupped) {
				Instantiate (lightning, lightninggunTip.position, Quaternion.Euler (new Vector3 (0, 0, 0)));
			}
			else if (!facingRight && onPowerPickup.Powerupped) {
				Instantiate (lightning, lightninggunTip.position, Quaternion.Euler (new Vector3 (0, 0, 180)));
			}
		}
	}
}
