using UnityEngine;
using System.Collections;
using Drivers;
using championship;
using Teams;

public class DriverPanel : MonoBehaviour {


	public UILabel driverTitle;
	public UILabel brakingAggressionLabel;
	public UILabel corneringLabel;
	public UILabel errorProneLabel;
	public UILabel overtakingLabel;
	public UILabel staminaLabel;
	public UILabel currentTeamLabel;
	public UILabel payPerRaceLabel;
	public UILabel sponsorAppealLabel;

	public GTDriver driverRef;
	public NewDriverPanel otherDrivers;
	public NewDriverPanel prefabDriverPanel;

	public UI2DSprite faceSprite;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onLookAtOtherDrivers() {
		if(otherDrivers!=null) {
			Destroy(otherDrivers.gameObject);
		}
		GameObject go = NGUITools.AddChild(this.gameObject.transform.parent.gameObject,prefabDriverPanel.gameObject);
		Debug.Log (go.name);
		
		otherDrivers = go.GetComponent<NewDriverPanel>();
		otherDrivers.alignToLeft();
		otherDrivers.myDriverPanel = this;
	//	if(otherDrivers!=null)
	//		otherDrivers.initDriver(this.driverRef);
		//hideButtons();
	}
	private void initLabels() {
		driverTitle = this.transform.FindChild("DriverTitle").GetComponent<UILabel>();
		this.brakingAggressionLabel = this.transform.FindChild("BrakingAggressionValue").GetComponent<UILabel>();
		this.corneringLabel = this.transform.FindChild("CorneringValue").GetComponent<UILabel>();
		this.errorProneLabel = this.transform.FindChild("ErrorProneValue").GetComponent<UILabel>();
		this.overtakingLabel = this.transform.FindChild("OvertakingValue").GetComponent<UILabel>();
		this.staminaLabel = this.transform.FindChild("StaminaValue").GetComponent<UILabel>();
		this.currentTeamLabel = this.transform.FindChild("CurrentTeamValue").GetComponent<UILabel>();
		this.payPerRaceLabel = this.transform.FindChild("PayPerRaceValue").GetComponent<UILabel>();
		this.sponsorAppealLabel = this.transform.FindChild("SponsorAppealValue").GetComponent<UILabel>();

		this.faceSprite = this.gameObject.GetComponentInChildren<UI2DSprite>();
		
	}
	public void onGotoMainMenu() {
		InterfaceMainButtons.REF.onCloseOtherScreen();
		/*if(otherDrivers!=null) {
			Destroy(otherDrivers.gameObject);
			Destroy(otherDrivers);
			otherDrivers = null;
			
		}*/
		if(this.otherDrivers!=null) {
			Destroy(otherDrivers.gameObject);
		}
		Destroy(this.gameObject);
	}
	public void initDriver(GTDriver aDriver) {
		//if(driverTitle==null)
			initLabels();
		if(driverTitle!=null) {
			driverTitle.text = aDriver.name;
			brakingAggressionLabel.text = aDriver.brakingAggressionString;
			corneringLabel.text = aDriver.corneringSkillString;
			errorProneLabel.text = aDriver.errorProneString;
			overtakingLabel.text = aDriver.overtakingString;
			staminaLabel.text = aDriver.staminaString;
			GTTeam team = ChampionshipSeason.ACTIVE_SEASON.getTeamFromDriver(aDriver);
			if(team==null) {
				this.currentTeamLabel.text = "No Team";
				
			} else
			this.currentTeamLabel.text = team.teamName;
			
			faceSprite.sprite2D = aDriver.record.sprite;;
			
		}
		this.driverRef = aDriver;
	}


}
