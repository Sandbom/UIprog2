using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndTutorial : MonoBehaviour {

	public GameObject tutorialCanvas;

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter2D(){
		Time.timeScale = 0.05f;
		Time.fixedDeltaTime = 0.02F * Time.timeScale;
		tutorialCanvas.SetActive (true);
	}
}
