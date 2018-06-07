using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public Animator animator;

	public GameObject cans;

	// run this function when pressing Play button in menu, we activate the canvas holding the fade out animation
	public void PlayGame()
	{	
		cans.SetActive (true);
		animator.SetTrigger ("FadeOut");
	}


	// Loading scene number 2 which is the tutorial
	public void PlayTutorial(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 2);
	}

	// QUitting game
	public void Quitgame()
	{
		Debug.Log ("Quitting game");
		Application.Quit ();
	}

	// Run this function after fade out animation to get fade out effect and not immediately swap scene
	public void CompleteFade(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}
}
