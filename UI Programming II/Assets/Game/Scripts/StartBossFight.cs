using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartBossFight : MonoBehaviour {

	public Slider BossHealthSlider;
	public Text BossNameText;
	public float BossHealth;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			BossHealthSlider.gameObject.SetActive (true);
			BossNameText.gameObject.SetActive (true);
			BossHealthSlider.value = BossHealth;
		}

	}
}
