using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ResetGame : MonoBehaviour {

	public Text lightningtext;
	public TextMeshProUGUI youdiedtext;
	public Text retrytext;

	public TextMeshProUGUI winnertext;
	public Text menubutton;
	public Text quitbutton;

	Button btn;

	// Use this for initialization
	void Start () {
		if (SettingsMenu.EnglishText) {
			lightningtext.text = "Lightning";
			retrytext.text = "Retry";
			youdiedtext.text = "You Died";
			winnertext.text = "You Won";
			menubutton.text = "Menu";
			quitbutton.text = "Quit";

		} else if (!SettingsMenu.EnglishText) {
			lightningtext.text = "Blixtar";
			retrytext.text = "Försök igen";
			youdiedtext.text = "Du dog";
			winnertext.text = "Du vann!";
			menubutton.text = "Meny";
			quitbutton.text = "Avsluta";

		}
		btn = GetComponent<Button> ();
	}

	public void resetGame() {
		SceneManager.LoadScene (1);
		ScoreScript.scoreValue = 0;
	}
}
