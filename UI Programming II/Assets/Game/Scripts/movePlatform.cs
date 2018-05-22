using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class movePlatform: MonoBehaviour
{
	[SerializeField]
	private Vector3 velocity;
	private bool moving;


	private void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag=="Player") {
			moving = true;
			other.collider.transform.SetParent (transform);
		}
	}

	private void OnCollisionExit2D(Collision2D other){
		if (other.gameObject.tag == "Player") {
			other.collider.transform.SetParent (null);
			moving = false;
		}
	}

	void FixedUpdate()
	{
		if (moving) {
			transform.position = (velocity * Time.deltaTime) + transform.position;
		}
	}
}