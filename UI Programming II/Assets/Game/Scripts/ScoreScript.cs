using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

	public static int scoreValue = 0;
	Text Score;

	// Use this for initialization
	void Start () {
		Score = GetComponent<Text> ();
	}
	
	// Changes lang based on choice
	void Update () {
		if (SettingsMenu.EnglishText) {
			Score.text = ("Score: " + scoreValue);
		}
		else if (!SettingsMenu.EnglishText) {
			Score.text = ("Poäng: " + scoreValue);
		}
	}
}
