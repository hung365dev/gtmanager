﻿using UnityEngine;
using System.Collections;
using Utils;

public class SettingsScreen : MonoBehaviour {

	// Use this for initialization

	public UILabel currentResolutionText;
	public UIProgressBar resolutionProgressBar;
	public UIPopupList popupList;
	public UIPopupList shadowList;

	public UILabel shadowsLabel;
	public UILabel antiAliasingLabel;

	public static Resolution[] resolutions;
	public static int shadowLevel = 0; 
	public bool madeUpRess = false;
	public const int MAX_RESOLUTION_CHOICES = 4;

	void Start () {
		
		int maxResolutionWidth = Screen.width;
		Debug.Log ("Settings Screen: "+maxResolutionWidth);
		if(resolutions==null) {
			resolutions = Screen.resolutions;
		}
		if(resolutions.Length==0) {
			madeUpRess = true;
			Debug.Log ("No supported resolutions!");
			float aspectRatio = Screen.height/Screen.width;
			resolutions = new Resolution[MAX_RESOLUTION_CHOICES];
			float startingWidth = Screen.width/MAX_RESOLUTION_CHOICES;
			float currentWidth = startingWidth;
			float startingHeight = Screen.height/MAX_RESOLUTION_CHOICES;
			float currentHeight = startingHeight;
			for(int i = 0;i<MAX_RESOLUTION_CHOICES;i++) {
				resolutions[i] = new Resolution();
				resolutions[i].width = (int) currentWidth;
				resolutions[i].height = (int) currentHeight;
				currentWidth += startingWidth;
				currentHeight += startingHeight;

			}
		}
//		resolutionProgressBar.numberOfSteps = resolutions.Length-1;
//		resolutionProgressBar.onChange.Add(new EventDelegate(this,"onResolutionChange"));

		
		showShadowsLabel();
		this.showAntiAliasingLabel();
		this.currentResolutionText.text = Screen.width+" x "+Screen.height;

	}
	public void doSaveSettings() {
	//	int resIndex = Mathf.RoundToInt(resolutionProgressBar.value*resolutionProgressBar.numberOfSteps);
	//	Debug.Log ("Setting resolution to: "+resIndex);
	//	Screen.SetResolution(resolutions[resIndex].width,resolutions[resIndex].height,true);

		/*
		 * 
x 2 Antialiasing
x 4 Antialiasing
*/
		SaveGameUtils.saveSettings();
		Destroy(this.gameObject);
		if(InterfaceMainButtons.REF!=null)
			InterfaceMainButtons.REF.onCloseOtherScreen(); else
				MainMenuScene.REF.onCloseSettings();
	}

	
 

	public int currentResolutionIndex {
		get {
			int width = Screen.width;
			for(int i = 0;i<resolutions.Length;i++) {
				if(resolutions[i].width==width) {
					return i;
				}
			}
			return resolutions.Length-1;
		}
		set {
			Screen.SetResolution(resolutions[value].width,resolutions[value].height,true);
		}
	}
	public void onDecreaseResolution() {
		if(currentResolutionIndex>0) {
			currentResolutionIndex--;
		}
		this.currentResolutionText.text = Screen.width+" x "+Screen.height;
	}

	public void onIncreaseResolution() {
		if(currentResolutionIndex<resolutions.Length-1) {
			currentResolutionIndex++;
		}
		
		this.currentResolutionText.text = Screen.width+" x "+Screen.height;
	}

	public void onDecreaseShadows() {
		if(shadowLevel>0) {
			shadowLevel--;
		}
		showShadowsLabel();
	}
	
	public void onIncreaseShadows() {
		if(shadowLevel<2) {
			shadowLevel++;
		}
		this.showShadowsLabel();
	}

	private void showShadowsLabel() {
		switch(shadowLevel ) {
		case(0):this.shadowsLabel.text = "No Shadows (Fast)";break;
		case(1):this.shadowsLabel.text = "Basic Shadows";break;
		case(2):this.shadowsLabel.text = "Good Shadows (Slow)";break;
		}
	}
	public void onDecreaseAntiAliasing() {
		if(QualitySettings.antiAliasing>0) {
			switch(QualitySettings.antiAliasing) {
			case(2):QualitySettings.antiAliasing = 0;break;
			case(4):QualitySettings.antiAliasing = 2;break;
			case(8):QualitySettings.antiAliasing = 4;break;
			}
		}
		this.showAntiAliasingLabel();
	}
	
	public void onIncreaseAntiAliasing() {
		if(QualitySettings.antiAliasing<8) {
			switch(QualitySettings.antiAliasing) {
				case(0):QualitySettings.antiAliasing = 2;break;
				case(2):QualitySettings.antiAliasing = 4;break;
				case(4):QualitySettings.antiAliasing = 8;break;
			}
		}
		this.showAntiAliasingLabel();
	}
	
	private void showAntiAliasingLabel() {
		switch(QualitySettings.antiAliasing ) {
		case(0):this.antiAliasingLabel.text = "No Anti Aliasing (Fast)";break;
		case(2):this.antiAliasingLabel.text = "x2 Anti Aliasing";break;
		case(4):this.antiAliasingLabel.text = "x4 Anti Aliasing";break;
		case(8):this.antiAliasingLabel.text = "x8 Anti Aliasing (Slow)";break;
		}
	}


	private void onResolutionChange() {
		int maxValue = Mathf.RoundToInt(resolutionProgressBar.value*resolutionProgressBar.numberOfSteps);
		Debug.Log ("Resolution changed: "+resolutions[maxValue].width+"x"+resolutions[maxValue].height);
		string newRes = resolutions[maxValue].width+"x"+resolutions[maxValue].height;
		if(madeUpRess)
			this.currentResolutionText.text = "Made up Resolution: "+newRes; else {
			this.currentResolutionText.text = "Native Res: "+newRes;
		}
	}
	// Update is called once per frame
	void Update () {
	}
}
