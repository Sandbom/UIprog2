using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour {

	public AudioMixer audioMixer;

	Resolution[] resolutions;

	public static bool EnglishText = true;

	public Dropdown resolutionDropDown;


	//Variables for changing lang
	public TextMeshProUGUI title;
	public TextMeshProUGUI playbutton;
	public TextMeshProUGUI optionsbutton;
	public TextMeshProUGUI quitbutton;
	public TextMeshProUGUI optionstext;
	public TextMeshProUGUI resolutiontext;
	public TextMeshProUGUI graphicstext;
	public TextMeshProUGUI Fullscreentext;
	public TextMeshProUGUI Volumetext;
	public TextMeshProUGUI backtext;
	public TextMeshProUGUI Tutorialtext;




	void Start(){
		// First see what language we want the menu to be in based on players choices, default is english
		if (EnglishText == true) {
			title.text = "Save the world";
			playbutton.text = "Play";
			optionsbutton.text = "Options";
			quitbutton.text = "Quit";
			optionstext.text = "Options";
			resolutiontext.text = "Resolution";
			graphicstext.text = "Graphics";
			Fullscreentext.text = "Full Screen";
			Volumetext.text = "Volume";
			backtext.text = "Back";
			Tutorialtext.text = "Tutorial";
		}

		else if (EnglishText == false) {
			title.text = "Rädda Världen";
			playbutton.text = "Spela";
			optionsbutton.text = "Inställningar";
			quitbutton.text = "Avsluta";
			optionstext.text = "Inställningar";
			resolutiontext.text = "Upplösning";
			graphicstext.text = "Kvalitet";
			Fullscreentext.text = "Fullskärm";
			Volumetext.text = "Volym";
			backtext.text = "Tillbaka";
			Tutorialtext.text = "Instruktioner";
		}

		resolutions = Screen.resolutions;

		List<string> options = new List<string>();

		// add lists of resolutions available for the computer playing the game
		int currentResolutionIndex = 0;
		for (int i = 0; i < resolutions.Length; i++) {
			string option = resolutions [i].width + "x" + resolutions [i].height;
			options.Add (option);

			if (resolutions [i].width == Screen.currentResolution.width
			   && resolutions [i].height == Screen.currentResolution.height) {
				currentResolutionIndex = i;
			} 
		}
		// add resolutions to drop down list
		resolutionDropDown.AddOptions (options);
		resolutionDropDown.value = currentResolutionIndex;
		resolutionDropDown.RefreshShownValue ();
	}

	// Use this for initialization
	public void SetVolume(float volume){
		audioMixer.SetFloat ("Volume", volume);
	}

	// Set quality based on Unity's graphic quality levels
	public void SetQuality(int qualityLevel){
		QualitySettings.SetQualityLevel (qualityLevel);
	}

	// Toggle full screen
	public void SetFullScreen(bool isFullScreen){
		Screen.fullScreen = isFullScreen;
	}

	// Applies chosen resolution
	public void SetResolution(int ResolutionIndex){

		Resolution resolution = resolutions [ResolutionIndex];
		Screen.SetResolution (resolution.width, resolution.height, Screen.fullScreen);
	}

	// Change language to swedish
	public void SetSwedishLanguage(){
		if (EnglishText == true) {
			EnglishText = false;
			title.text = "Rädda Världen";
			playbutton.text = "Spela";
			optionsbutton.text = "Inställningar";
			quitbutton.text = "Avsluta";
			optionstext.text = "Inställningar";
			resolutiontext.text = "Upplösning";
			graphicstext.text = "Kvalitet";
			Fullscreentext.text = "Fullskärm";
			Volumetext.text = "Volym";
			backtext.text = "Tillbaka";
			Tutorialtext.text = "Instruktioner";
		}
	}
	// Change language to english
	public void SetEnglishLanguage(){
		if (EnglishText == false) {
			EnglishText = true;
			title.text = "Save the world";
			playbutton.text = "Play";
			optionsbutton.text = "Options";
			quitbutton.text = "Quit";
			optionstext.text = "Options";
			resolutiontext.text = "Resolution";
			graphicstext.text = "Graphics";
			Fullscreentext.text = "Full Screen";
			Volumetext.text = "Volume";
			backtext.text = "Back";
			Tutorialtext.text = "Tutorial";
		}
	}

}