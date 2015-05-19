using UnityEngine;
using System.Collections;
using Database;
using System;
using championship;

public class RacePositionHolder : MonoBehaviour {

	// Use this for initialization

	public UILabel myLabel;
	public UISprite mySprite;

	public UISprite tireSprite;
	public UISprite engineSprite;

	public IRDSCarControllerAI ai;
	public RacingAI racingAI;
	public Color colourWhenOwned;

	public Color engineTempTooHot;
	public Color engineTempVeryHot;
	public Color engineTempWarm;
	public Color engineTempPerfect;

	public Color tireWearCold;
	public Color tireWearWarmedUp;
	public Color tireWearPerfect;
	public Color tireWearWorn;
	public Color tireWearDangerous;


	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void init() {
		if(racingAI.humanControl) {
			myLabel.color = colourWhenOwned;
			
		} else {
			Destroy(tireSprite.gameObject);
			Destroy(this.engineSprite.gameObject);
		}
		mySprite.color = ChampionshipSeason.ACTIVE_SEASON.getTeamFromDriver(racingAI.driverRecord).teamColor;
		
	}

	public void doUpdate() {
		if(ai!=null) {
			int aiPos = Convert.ToInt16(ai.racePosition);
			this.gameObject.name = aiPos+" pos";
			
			if(racingAI.humanControl) {
				myLabel.color = colourWhenOwned;
				if(racingAI.engineTempMonitor.isGettingHot) {
					this.engineSprite.color = engineTempWarm;
				} else if(racingAI.engineTempMonitor.isOverheating) {
					this.engineSprite.color = this.engineTempVeryHot;
				} else if(racingAI.engineTempMonitor.isTooHot) {
					this.engineSprite.color = this.engineTempTooHot;
				} else this.engineSprite.color = this.engineTempPerfect;

				if(racingAI.tireWearLevel==ETireWear.Cold) {
					this.tireSprite.color = this.tireWearCold;
				} else if(racingAI.tireWearLevel==ETireWear.Warm) {
					this.tireSprite.color = this.tireWearWarmedUp;
				} else if(racingAI.tireWearLevel==ETireWear.Perfect) {
					this.tireSprite.color = this.tireWearPerfect;
				} else if(racingAI.tireWearLevel==ETireWear.LightWear) {
					this.tireSprite.color = this.tireWearWorn;
				} else if(racingAI.tireWearLevel==ETireWear.Worn) {
					this.tireSprite.color = this.tireWearWorn;
				}	else if(racingAI.tireWearLevel==ETireWear.Dangerous) {
					this.tireSprite.color = this.tireWearDangerous;
				}
			}
			this.myLabel.text = aiPos+". "+ai.GetDriverName();
		}
	}
}
