using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour {

	Button btn;

	// Use this for initialization
	void Start () {
		btn = GetComponent<Button> ();
	}

	public void resetGame() {
		SceneManager.LoadScene (1);
		ScoreScript.scoreValue = 0;
	}
}
