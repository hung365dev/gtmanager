using UnityEngine;
using System.Collections;

public class ScreenDarknessController : MonoBehaviour {

	public bool isFadingIn = false;
	public bool isFadingOut = false;
	public CC_BrightnessContrastGamma brightnessController;
	// Use this for initialization
	void Start () {
		brightnessController = this.GetComponent<CC_BrightnessContrastGamma>();
	}
	
	// Update is called once per frame
	void Update () {
		if(isFadingIn) {
			if(brightnessController!=null) {
				brightnessController.brightness+=1;
				if(brightnessController.brightness>=0) {
					brightnessController.brightness = 0;
					isFadingIn = false;
				}
			}
		}
		if(isFadingOut) {
			if(brightnessController!=null) {
				brightnessController.brightness-=1;
				if(brightnessController.brightness<=-100) {
					brightnessController.brightness = -100;
					isFadingOut = false;
				}
			}
		}
	}
	public void DoFadeOut() {
		isFadingOut = true;
		isFadingIn = false;
		brightnessController.brightness = 0;
		Debug.Log("Doing Fade Out: ");
	}
	public void DoFadeIn(string aName) {
		isFadingIn = true;
		isFadingOut = false;
		brightnessController.brightness = -100;
		Debug.Log("Doing Fade In: "+aName);
		if(aName=="Start") {
			GameObject g = GameObject.Find("RaceManager");
			RaceManager m = g.GetComponent<RaceManager>();
			m.doStartRace();
			GameObject raceStartGUI = GameObject.Find ("RaceStartGUI");
			if(raceStartGUI!=null) {
				Destroy(raceStartGUI);
			}
		} 
		else {
			GameObject title = GameObject.Find ("RaceStartTitleLabel");
			if(title!=null) {
				UILabel titleLabel = title.GetComponent<UILabel>();
				titleLabel.text = "Race Start";
			}
			GameObject snl = GameObject.Find("SectorNameLabel");
			if(snl!=null) {
				UILabel t = snl.GetComponent<UILabel>();
					t.text = aName;
				} 
		}

	}
}
