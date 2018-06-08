using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powerupTimer : MonoBehaviour {

	// Variables to hide / show depending on weapon active
	float timer = 10;
	Text timerText;
	public Image lightningproj;
	public Image blueproj;
	public Image infinitySymbol;
	public GameObject LightningText;


	Animator anim;

	// Use this for initialization
	void Start () {
		timerText = GetComponent<Text> ();
		lightningproj.enabled = false;
		anim = gameObject.GetComponentInChildren<Animator> ();
	}
	
	// Checks if power up is picked up and then we change which text is active and shown and we start timer.
	void FixedUpdate () {
		if (onPowerPickup.Powerupped) {
			LightningText.SetActive (true);
			Invoke ("removeText", 2);
			blueproj.enabled = false;
			infinitySymbol.enabled = false;
			lightningproj.enabled = true;
			timerText.enabled = true;
			timer = timer - Time.deltaTime;
			timerText.text = (timer + "s");
		}
		if (onPowerPickup.removeTimers) {
			lightningproj.enabled = false;
			timerText.enabled = false;
			blueproj.enabled = true;
			infinitySymbol.enabled = true;
			timerText.text = "";
			timer = 10;
			onPowerPickup.removeTimers = false;
	
		}
	}
	// Removes lightning text
	void removeText(){
		LightningText.SetActive (false);
	}
}
