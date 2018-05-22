﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {

	public AudioMixer audioMixer;

	Resolution[] resolutions;

	public Dropdown resolutionDropDown;

	void Start(){
		resolutions = Screen.resolutions;

		List<string> options = new List<string>();

		int currentResolutionIndex = 0;
		for (int i = 0; i < resolutions.Length; i++) {
			string option = resolutions [i].width + "x" + resolutions [i].height;
			options.Add (option);

			if (resolutions [i].width == Screen.currentResolution.width
			   && resolutions [i].height == Screen.currentResolution.height) {
				currentResolutionIndex = i;
			} 
		}

		resolutionDropDown.AddOptions (options);
		resolutionDropDown.value = currentResolutionIndex;
		resolutionDropDown.RefreshShownValue ();
	}

	// Use this for initialization
	public void SetVolume(float volume){
		audioMixer.SetFloat ("Volume", volume);
	}

	public void SetQuality(int qualityLevel){
		QualitySettings.SetQualityLevel (qualityLevel);
	}

	public void SetFullScreen(bool isFullScreen){
		Screen.fullScreen = isFullScreen;
	}

	public void SetResolution(int ResolutionIndex){

		Resolution resolution = resolutions [ResolutionIndex];
		Screen.SetResolution (resolution.width, resolution.height, Screen.fullScreen);
	}
}