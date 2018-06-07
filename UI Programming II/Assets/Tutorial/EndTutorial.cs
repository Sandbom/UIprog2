using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndTutorial : MonoBehaviour {

	public GameObject tutorialCanvas;


	// When entering this collider 
	// we show the canvas letting player exit to main menu and we slow down time giving a slow motion effect
	void OnTriggerEnter2D(){
		Time.timeScale = 0.05f;
		Time.fixedDeltaTime = 0.02F * Time.timeScale;
		tutorialCanvas.SetActive (true);
	}
}
