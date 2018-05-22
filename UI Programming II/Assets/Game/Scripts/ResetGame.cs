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
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			SceneManager.LoadScene (1);
			ScoreScript.scoreValue = 0;
		}
	}
}
