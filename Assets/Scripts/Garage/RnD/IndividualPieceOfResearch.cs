using UnityEngine;
using System.Collections;
using Cars;
using GoogleFu;
using championship;
using System;
using PixelCrushers.DialogueSystem;
using Teams;

public class IndividualPieceOfResearch : MonoBehaviour {
	public ResearchScreenMain parent;

	public UILabel partNameTitle;
	public UILabel partDescription;
	public UILabel staffRequired;
	public UILabel divisionRequired;
	public UILabel prerequisiteParts;
	public UISprite  partGraphic;
	public UILabel lblCost;
	public UILabel lblDaysToResearch;
	public UIButton closeBtn;
	public UIButton startResearchBtn;
	public RnDRow researchRow;
	public GTCar carRef;
	// Use this for initialization
	void Start () {
		parent = this.GetComponentInParent<ResearchScreenMain>();
		parent.notifyOfIndividualResearchScreen(this);
		closeBtn.onClick.Add(new EventDelegate(this,"onCloseWindow"));
		startResearchBtn.onClick.Add(new EventDelegate(this,"onStartDoingResearch"));
		
	}

	public void Awake() {
		
	}
	public void onCloseWindow() {
		parent.closeInidividualResearchScreen();
	}
	public void onStartDoingResearch() {
		//TODO make it so we make sure we meet requirements, etc..
		GTTeam team = ChampionshipSeason.ACTIVE_SEASON.getUsersTeam();
		if(team.cash>=researchRow._costtoresearch) {
			GTEquippedResearch er = carRef.addPartToCar(researchRow,ChampionshipSeason.ACTIVE_SEASON.getUsersTeam());
			if(er!=null) {
				er.daysOfResearchRemaining = researchRow._daystoresearch;
				team.cash -= researchRow._costtoresearch;
				Lua.Result res = DialogueLua.GetVariable("ResearchTutorialDone");
				if(res.AsBool == false ) {
					
					GarageManager.REF.doConversation("Research_Tutorial3");
					er.dayOfCompletion = 2+ChampionshipSeason.ACTIVE_SEASON.secondsPast;
					er.daysOfResearchRemaining = 2;
				} else
					er.dayOfCompletion = researchRow._daystoresearch+ChampionshipSeason.ACTIVE_SEASON.secondsPast;
				this.onCloseWindow();
			} else {
				Debug.Log ("Couldn't research");
			}
		} else {
			GarageManager.REF.doConversation("NoCashForResearch");
		}
	}
	// Update is called once per frame
	void Update () {
		if(carRef.partBeingResearched!=null) {
			startResearchBtn.SetState(UIButtonColor.State.Disabled,true);
			lblCost.text = "Researching: "+carRef.partBeingResearched.researchRow._partname;
			this.lblDaysToResearch.text = "Days to Research: "+carRef.partBeingResearched.daysOfResearchRemaining;
		} else {
			startResearchBtn.SetState(UIButtonColor.State.Normal,true);
			initResearch(this.researchRow,carRef,this.partGraphic);
		}
	}

	public void toggleConversation() {
		GarageManager.REF.doConversation("Research_Tutorial2");
	}
	public void initResearch(RnDRow aRow,GTCar aCar,UISprite aSprite) {
		this.gameObject.SetActive(true);
		researchRow = aRow;
		carRef = aCar;
		GTEquippedResearch r = carRef.hasPart(aRow);
		if(r==null) {
			partNameTitle.text = aRow._partname+" (0/"+aRow._maxlevelstounlock+")"; 
		} else {
			partNameTitle.text = aRow._partname+" ("+r.activeLevel+"/"+aRow._maxlevelstounlock+")";
		}
		
		partDescription.text = aRow._partdescription;
		staffRequired.text = "Staff Required: "+aRow._partprerequisitestaff;
		divisionRequired.text = "Division Required: "+aRow._partprerequisitedivision;
		prerequisiteParts.text = "Prerequisite Parts: "+aRow._partprerequisites;
		lblCost.text = "Cost to Research: "+String.Format("{0:C}",aRow._costtoresearch);
		this.lblDaysToResearch.text = "Days to Research: "+aRow._daystoresearch;
		partGraphic.spriteName = aSprite.spriteName;

		
	}
} 
