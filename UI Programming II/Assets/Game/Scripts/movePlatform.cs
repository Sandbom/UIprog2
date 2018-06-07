using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class movePlatform: MonoBehaviour
{
	[SerializeField]
	private Vector3 velocity;
	private bool moving;

	// If player is standing on platform start moving it and make player object a child of platform
	// this to prevent the player from "gliding" off as it moves
	private void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag=="Player") {
			moving = true;
			other.collider.transform.SetParent (transform);
		}
	}

	// If player is not standing on platform set it to not move and remove player as a child object
	private void OnCollisionExit2D(Collision2D other){
		if (other.gameObject.tag == "Player") {
			other.collider.transform.SetParent (null);
			moving = false;
		}
	}

	// Moves player if he/she stands on platform
	void FixedUpdate()
	{
		if (moving) {
			transform.position = (velocity * Time.deltaTime) + transform.position;
		}
	}
}