using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTutorial : MonoBehaviour {

	public GameObject Menubutton;
	public GameObject Quitbutton;

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter2D(){
		Time.timeScale = 0.05f;
		Time.fixedDeltaTime = 0.02F * Time.timeScale;
		Menubutton.SetActive (true);
		Quitbutton.SetActive (true);
	}
}
