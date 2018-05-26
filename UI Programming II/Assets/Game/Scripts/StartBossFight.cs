using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class StartBossFight : MonoBehaviour {

	public Slider BossHealthSlider;
	public Text BossNameText;
	public float BossHealth;

	public AudioMixer audioMixer;
	public AudioClip BossMusic;
	AudioSource bossAS;

	public static bool bossEngaged = false;

	// Use this for initialization
	void Start () {
		bossAS = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!BossMovement.BossAlive) {
			BossHealthSlider.gameObject.SetActive (false);
			BossNameText.gameObject.SetActive (false);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			audioMixer.SetFloat ("Volume", -80f);
			bossEngaged = true;
			BossHealthSlider.gameObject.SetActive (true);
			BossNameText.gameObject.SetActive (true);
			BossHealthSlider.value = BossHealth;
			bossAS.clip = BossMusic;
			bossAS.PlayOneShot (BossMusic);
		}

	}
}
