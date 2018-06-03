	using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	public static bool GameIsPaused = false;

	public GameObject pauseMenuUI;

	public Animator animation;

	public Text resumetext;
	public Text menutext;
	public Text quittext;

	// Use this for initialization
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
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (GameIsPaused) {
				Resume ();
			} else {
				Pause ();
			}
		}
	}

	public void Resume(){
		pauseMenuUI.SetActive (false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}

	void Pause(){
		pauseMenuUI.SetActive (true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}

	public void loadMenu(){
		Time.timeScale = 1f;
		Time.fixedDeltaTime = 0.02F;
		GameIsPaused = false;
		animation.SetTrigger ("FadeOut");
		ScoreScript.scoreValue = 0;
	}

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
