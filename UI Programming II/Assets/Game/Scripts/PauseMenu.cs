	using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	public static bool GameIsPaused = false;

	public GameObject pauseMenuUI;

	public Animator animation;

	// Texts to translate
	public Text resumetext;
	public Text menutext;
	public Text quittext;

		// Check wether desired language is english or swedish
	void Start () {
		if (SettingsMenu.EnglishText) {
			resumetext.text = "Resume";
			menutext.text = "Menu";
			quittext.text = "Quit";
		} else if (!SettingsMenu.EnglishText) {
			resumetext.text = "Fortsätt";
			menutext.text = "Meny";
			quittext.text = "Avsluta";
		}
	}
	
	// If game is not paused brings up pause menu on hitting escape, otherwise resumes game
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (GameIsPaused) {
				Resume ();
			} else {
				Pause ();
			}
		}
	}

	// Sets pause canvas to false to hide buttons and resumes time at normal pace
	public void Resume(){
		pauseMenuUI.SetActive (false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}

	// Sets pause canvas to true to show buttons and sets time to 0 to pause it.
	void Pause(){
		pauseMenuUI.SetActive (true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}

	// Loads menu scene and resets score value.
	public void loadMenu(){
		Time.timeScale = 1f;
		Time.fixedDeltaTime = 0.02F;
		GameIsPaused = false;
		animation.SetTrigger ("FadeOut");
		ScoreScript.scoreValue = 0;
	}

	// Exits game
	public void quitGame(){
		Debug.Log ("Quitting Game");
		Application.Quit ();
	}

	public void delayloadMenu(){
		SceneManager.LoadScene (0);
	}

	public void CompleteFademenu(){
		SceneManager.LoadScene (0);
	}
}
