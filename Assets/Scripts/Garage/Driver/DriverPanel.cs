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

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
	}
	public void onGotoMainMenu() {
		InterfaceMainButtons.REF.onCloseOtherScreen();
		/*if(otherDrivers!=null) {
			Destroy(otherDrivers.gameObject);
			Destroy(otherDrivers);
			otherDrivers = null;
			
		}*/
		Destroy(this.gameObject);
	}
	public void initDriver(GTDriver aDriver) {
		if(driverTitle==null)
			initLabels();
		if(driverTitle!=null) {
			driverTitle.text = aDriver.driverName;
			brakingAggressionLabel.text = aDriver.brakingAggressionString;
			corneringLabel.text = aDriver.corneringSkillString;
			errorProneLabel.text = aDriver.errorProneString;
			overtakingLabel.text = aDriver.overtakingString;
			staminaLabel.text = aDriver.staminaString;
			GTTeam team = ChampionshipSeason.ACTIVE_SEASON.getTeamFromDriver(aDriver);
			this.currentTeamLabel.text = team.teamName;
			 

		}
	}


}
