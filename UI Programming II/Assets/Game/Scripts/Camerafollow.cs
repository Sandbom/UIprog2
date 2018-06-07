	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour {

	public Transform target; //What the camera is following
	public float smoothing; //Dampening on follow movement

	Vector3 offset;

	float lowY; // Lowest point the camera can reach

	// Use this for initialization
	void Start () {
		offset = transform.position - target.position;

		lowY = transform.position.y ;
	}
	
	// Makes camera follow player
	void FixedUpdate () {
		Vector3 targetCanPos = target.position + offset;

		transform.position = Vector3.Lerp (transform.position, targetCanPos, smoothing*Time.deltaTime);

		if (transform.position.y < lowY) {
			transform.position = new Vector3 (transform.position.x, lowY, transform.position.z);
		}
	}


}
