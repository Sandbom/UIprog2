using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour {

	public float aliveTime;

	// Function to destroy a projectile seconds after its instantiated, time is based on aliveTime
	void Awake () {
		Destroy (gameObject, aliveTime);
	}

}
