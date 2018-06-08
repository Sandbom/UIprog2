using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndTutorial : MonoBehaviour {


	public GameObject menuButton;
	//public GameObject quitButton;
	//public GameObject tutendText;


	// When entering this collider 
	// we show the canvas letting player exit to main menu and we slow down time giving a slow motion effect
	void OnTriggerEnter2D(){
		Time.timeScale = 0.02f;
		Time.fixedDeltaTime = 0.02F * Time.timeScale;
		menuButton.SetActive (true);
		//quitButton.SetActive (true);
		//tutendText.SetActive (true);
	}
}
