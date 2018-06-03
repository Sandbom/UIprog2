using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public Animator animator;

	public GameObject cans;

	public void PlayGame()
	{	
		cans.SetActive (true);
		animator.SetTrigger ("FadeOut");
	}

	public void PlayTutorial(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 2);
	}

	public void Quitgame()
	{
		Debug.Log ("Quitting game");
		Application.Quit ();
	}

	public void CompleteFade(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}
}
