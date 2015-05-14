using UnityEngine;
using System.Collections;
using Database;
using Drivers;
using championship;
using Teams;


public class RaceCompleteMember : MonoBehaviour {

	// Use this for initialization
	public UILabel positionLabel;
	public UILabel nameLabel;
	public UISprite sprite;
	public UILabel prizeInfo;
	public RacingAI driver;
	public int stage = 0;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void init(RacingAI aDriver,int aPosition) {
		driver = aDriver;
		if(positionLabel==null) {
			UILabel[] childLabels = this.GetComponentsInChildren<UILabel>();
			for(int i = 0;i<childLabels.Length;i++) {
				if(childLabels[i].gameObject.name=="FinisherPosition") {
					positionLabel = childLabels[i];
				}
				if(childLabels[i].gameObject.name=="FinisherName") {
					nameLabel = childLabels[i];
				}
				if(childLabels[i].gameObject.name=="FinisherDetail") {
					prizeInfo = childLabels[i];
				}
			}
		}
		string pos = (aPosition+1)+". ";
		this.positionLabel.text = pos;
		this.nameLabel.text = aDriver.driverName+" "+ChampionshipSeason.ACTIVE_SEASON.getTeamFromDriver(aDriver.driverRecord).teamName;
		this.prizeInfo.text = aDriver.finishTimeString;

	}

	public void initTeam(GTTeam aTeam) {
		this.nameLabel.text = aTeam.teamName;
		this.prizeInfo.text = ""+aTeam.seasonPoints;
	}

	public void showChampionshipPoints(GTDriver aDriver) {
		this.nameLabel.text = aDriver.name+" "+ChampionshipSeason.ACTIVE_SEASON.getTeamFromDriver(aDriver).teamName;
		this.prizeInfo.text = aDriver.championshipPoints+"";
	}
	public void doContinue() {
		stage++;
		switch(stage) {
			case(1):
				this.prizeInfo.text = "$"+driver.prizeString;
			break;
			case(2):
				this.prizeInfo.text = ""+driver.finishPoints;
			break;
		}
	}
}
