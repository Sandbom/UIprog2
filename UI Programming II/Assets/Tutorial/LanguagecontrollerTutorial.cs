using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LanguagecontrollerTutorial : MonoBehaviour {


	public Text text1;
	public Text text2;
	public Text text3;


	// Use this for initialization
	void Start () {
		if (SettingsMenu.EnglishText) {
			text1.text = "Use arrows to move\n\n\t& to jump";
			text2.text = "Use Space key to shoot";
			text3.text = "Pick up coins or defeat\n enemies to earn score";
		} else if (!SettingsMenu.EnglishText) {
			text1.text = "Använd pilar för att röra dig\n\n\t& för att hoppa";
			text2.text = "Tryck på mellanslag för\n att skjuta";
			text3.text = "Plocka upp mynt eller\n döda fiender för poäng";
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
