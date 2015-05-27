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

	public string name;
	public Color colourWhenOwned;
	public Color colourWhenBetTarget;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void init() {
		if(racingAI.humanControl) {
			myLabel.color = colourWhenOwned;
			
		}
		RandomEvent r = ChampionshipSeason.ACTIVE_SEASON.seasonForTeam(ChampionshipSeason.ACTIVE_SEASON.getTeamFromDriver(racingAI.driverRecord)).getRandomEventCompletingOnDay(ChampionshipSeason.ACTIVE_SEASON.secondsPast);
		name = racingAI.driverName;
		if(r!=null) {
			if(r.targetTeam == ChampionshipSeason.ACTIVE_SEASON.getTeamFromDriver(racingAI.driverRecord)) {
				name += "   [ffff00]$[-]";
				myLabel.color = colourWhenBetTarget;
			}
		}
		mySprite.color = ChampionshipSeason.ACTIVE_SEASON.getTeamFromDriver(racingAI.driverRecord).teamColor;
		
	}

	public void doUpdate() {
		if(ai!=null) {
			int aiPos = Convert.ToInt16(ai.racePosition);
			this.gameObject.name = aiPos+" pos";
			
			if(racingAI.humanControl) {
				myLabel.color = colourWhenOwned;
			}
			this.myLabel.text = aiPos+". "+name;
		}
	}
}
