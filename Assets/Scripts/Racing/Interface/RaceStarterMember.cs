using UnityEngine;
using System.Collections;
using Database;
using Drivers;
using championship;
using Teams;


public class RaceStarterMember : MonoBehaviour {
	
	// Use this for initialization
	public UILabel positionLabel;
	public UILabel nameLabel;
	public UISprite sprite;
	public UILabel prizeInfo;
	public GTDriver driver;

	public Color colorWhenOwned;
	public Color colorWhenNotOwned;
	public int stage = 0;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void init(GTDriver aDriver,int aPosition,bool showPoints) {
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
		this.nameLabel.text = aDriver.name+" "+ChampionshipSeason.ACTIVE_SEASON.getTeamFromDriver(aDriver).teamName;
		if(!showPoints)
			this.prizeInfo.text = ""; else {
			this.prizeInfo.text = ""+aDriver.championshipPoints;
		}

		
	}
	public void init(GTTeam aTeam,int aPosition,bool showPoints) {

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
		this.nameLabel.text = aTeam.teamName;
		this.prizeInfo.text = ""+aTeam.seasonPoints;
		
	}

	public void initTeam(GTTeam aTeam) {
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

		this.nameLabel.text = aTeam.teamName;
		this.prizeInfo.text = ""+aTeam.seasonPoints;
	}
	
	public void showChampionshipPoints(GTDriver aDriver,int aPosition) {
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
		this.positionLabel.text = (aPosition+1)+". ";
		if(ChampionshipSeason.ACTIVE_SEASON.getTeamFromDriver(aDriver)==ChampionshipSeason.ACTIVE_SEASON.getUsersTeam()) {
			this.nameLabel.color = colorWhenOwned;
		} else this.nameLabel.color = colorWhenNotOwned;
		this.nameLabel.text = aDriver.name+" "+ChampionshipSeason.ACTIVE_SEASON.getTeamFromDriver(aDriver).teamName;
		this.prizeInfo.text = aDriver.championshipPoints+"";
	}
	public void doContinue() {
		stage++;
		switch(stage) {
		case(1):
			//this.prizeInfo.text = "$"+driver.prizeString;
			break;
		case(2):
		//	this.prizeInfo.text = ""+driver.finishPoints;
			break;
		}
	}
}
