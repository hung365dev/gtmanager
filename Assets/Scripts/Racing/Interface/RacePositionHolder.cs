using UnityEngine;
using System.Collections;
using Database;
using System;
using championship;

public class RacePositionHolder : MonoBehaviour {

	// Use this for initialization

	public UILabel myLabel;
	public UISprite mySprite;
	public IRDSCarControllerAI ai;
	public RacingAI racingAI;
	public Color colourWhenOwned;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void init() {
		if(racingAI.humanControl) {
			myLabel.color = colourWhenOwned;
		}
		mySprite.color = ChampionshipSeason.ACTIVE_SEASON.getTeamFromDriver(racingAI.driverRecord).teamColor;
//.teamFromDriverID(racingAI.driverRecord.id).teamColor;
	}

	public void doUpdate() {
		if(ai!=null) {
			int aiPos = Convert.ToInt16(ai.racePosition);
			this.gameObject.name = aiPos+" pos";
			
			if(racingAI.humanControl) {
				myLabel.color = colourWhenOwned;
			}
			this.myLabel.text = aiPos+".    "+ai.GetDriverName();
		}
	}
}
