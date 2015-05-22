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


	public UIButton hireNewDriversBtn;
	public GTDriver driverRef;
	public NewDriverPanel otherDrivers;
	public NewDriverPanel prefabDriverPanel;
	public GarageCameraController camController;
	public UI2DSprite faceSprite;
	// Use this for initialization
	void Start () {
		
		GarageManager.REF.doConversation("OpenDriversScreen");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void showButtons() {
		hireNewDriversBtn.gameObject.SetActive(true);
	}	
	public void onSelectOtherDriver() {
		if(otherDrivers!=null) {
			Destroy(otherDrivers.gameObject);
		}
		
		GTTeam team = ChampionshipSeason.ACTIVE_SEASON.getUsersTeam();
		camController = GameObject.Find("Main Camera").GetComponent<GarageCameraController>();
		
		if(team.drivers[0]==this.driverRef) {
			this.initDriver(team.drivers[1]);
			camController.lookAtThis = GameObject.Find ("GarageRightSide");
			
			
		} else if(team.drivers[1]==this.driverRef) {
			this.initDriver(team.drivers[0]);
			camController.lookAtThis = GameObject.Find ("GarageLeftSide");
		}

		
	}
	public void onLookAtOtherDrivers() {
		if(otherDrivers!=null) {
			Destroy(otherDrivers.gameObject);
		}
		GameObject go = NGUITools.AddChild(this.gameObject.transform.parent.gameObject,prefabDriverPanel.gameObject);
		
		hireNewDriversBtn.gameObject.SetActive(false);
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
	//	this.staminaLabel = this.transform.FindChild("StaminaValue").GetComponent<UILabel>();
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
		camController = GameObject.Find("Main Camera").GetComponent<GarageCameraController>();
		
		if(driverTitle!=null) {
			driverTitle.text = aDriver.name;
			brakingAggressionLabel.text = aDriver.brakingAggressionString;
			corneringLabel.text = aDriver.corneringSkillString;
			errorProneLabel.text = aDriver.errorProneString;
			overtakingLabel.text = aDriver.overtakingString;
		//	staminaLabel.text = aDriver.staminaString;
			GTTeam team = aDriver.contract.team;
			if(team==null) {
				this.currentTeamLabel.text = "No Team";
				
			} else
				this.currentTeamLabel.text = team.teamName;
			
			faceSprite.sprite2D = aDriver.record.sprite;;
			this.sponsorAppealLabel.text = aDriver.sponsorAppealString;
			
			this.payPerRaceLabel.text = ""+string.Format("{0:C}", aDriver.contract.payPerRace);

			
		}
		this.driverRef = aDriver;
	}


}
