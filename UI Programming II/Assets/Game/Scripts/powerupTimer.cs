using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powerupTimer : MonoBehaviour {

	float timer = 10;
	Text timerText;
	public Image lightningproj;
	public Image blueproj;
	public Image infinitySymbol;

	// Use this for initialization
	void Start () {
		timerText = GetComponent<Text> ();
		lightningproj.enabled = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (onPowerPickup.Powerupped) {
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
	
		}
	}
}
