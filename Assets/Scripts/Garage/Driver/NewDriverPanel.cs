// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using UnityEngine;
using System.Collections.Generic;
using Drivers;
using championship;
using Teams;
using Cars;


public class NewDriverPanel : DriverPanel
{
	public List<GTDriver> driverList = new List<GTDriver>();
	public int currentIndex;
	public GTDriver thisDriver;
	public DriverPanel myDriverPanel;
	public ContractOfferScreen contractScreen;
	public UILabel isInterestedInSigning;
	public NewDriverPanel ()
	{
	}

	public void Start() {
		
		Lean.LeanTouch.OnFingerSwipe += OnFingerSwipe;
		List<GTDriver> availableDrivers = new List<GTDriver>();
		List<GTDriver> allDrivers = GTDriver.allDrivers;
		GTTeam team = ChampionshipSeason.ACTIVE_SEASON.getUsersTeam();
		for(int i = 0;i<allDrivers.Count;i++) {
			if(ChampionshipSeason.ACTIVE_SEASON.getTeamFromDriver(allDrivers[i])!=team) {
				
				GTTeam myTeam = ChampionshipSeason.ACTIVE_SEASON.getUsersTeam();
				DriverRelationshipRecord relationship = myTeam.relationshipWithDriver(allDrivers[i]);
				if(relationship.interest.payDemand>0f||true)
					availableDrivers.Add(allDrivers[i]);
			}
		}
		driverList = availableDrivers;
		this.initDriver(availableDrivers[availableDrivers.Count-1]);
		
		if(isInterestedInSigning==null) {
			GameObject g = this.gameObject.transform.FindChild("InterestedInSigningValue").gameObject;
			isInterestedInSigning = g.GetComponent<UILabel>();
		} 

		if(isInterestedInSigning!=null) {
			GTTeam myTeam = ChampionshipSeason.ACTIVE_SEASON.getUsersTeam();
			DriverRelationshipRecord relationship = myTeam.relationshipWithDriver(driverList[0]);
			if(relationship.interest.payDemand>0f) {
				isInterestedInSigning.text = relationship.interest.driverInterestString;
			} else {
				isInterestedInSigning.text = "NO";
			}
		}
		GarageManager.REF.doConversation("OpenHireDriverScreen");
	}

	public void OnDestroy() { 
		
		Lean.LeanTouch.OnFingerSwipe -= OnFingerSwipe;
	}

	private void onClosedContractScreen() {
		this.gameObject.SetActive(true);
		myDriverPanel.gameObject.SetActive(true);
	//	this.initDriver(this.thisDriver);
	} 
	public void hireThisDriver() {
		

		GameObject g = NGUITools.AddChild(GameObject.Find("UI Root").gameObject,this.prefabContractScreen.gameObject);
		ContractOfferScreen contract = g.GetComponent<ContractOfferScreen>();
		contractScreen = contract;
		this.gameObject.SetActive(false);
		myDriverPanel.gameObject.SetActive(false); 
		contractScreen.initDriver(this.driverRef,this.myDriverPanel.driverRef);
		contractScreen.onCloseContractScreenF += onClosedContractScreen;
		contractScreen.onContractAccepted += onContractAccepted;
		// This is now accept contract stuff
		/*
		GarageManager.REF.doConversation("OpenHireDriversScreen");
		GTTeam team = ChampionshipSeason.ACTIVE_SEASON.getUsersTeam();
		GTCar car = team.getGTCarFromDriver(myDriverPanel.driverRef);
		int indexForMyDriver = team.indexForDriver(this.myDriverPanel.driverRef);
		
		GTDriver oldDriver = this.myDriverPanel.driverRef;
		GTDriver newDriver = driverList[currentIndex];
		GTTeam oldTeam = ChampionshipSeason.ACTIVE_SEASON.getTeamFromDriver(newDriver);
		int indexForOldDriver = oldTeam.indexForDriver(newDriver);
		oldTeam.drivers[indexForOldDriver] = myDriverPanel.driverRef;
		team.drivers[indexForMyDriver] = newDriver;
		this.myDriverPanel.initDriver(driverList[currentIndex]);
		this.myDriverPanel.showButtons();
		Destroy(this.gameObject);*/
	
	}
	private void onContractAccepted(GTDriver aHiredDriver) {
		Destroy(this.gameObject);
		myDriverPanel.initDriver(aHiredDriver);
	}
	public void OnFingerSwipe(Lean.LeanFinger finger)
	{
		
		// Store the swipe delta in a temp variable
		var swipe = finger.SwipeDelta;
		
		if (swipe.x < -Mathf.Abs(swipe.y))
		{
			Debug.Log ("You swiped left!");
		}
		
		if (swipe.x > Mathf.Abs(swipe.y))
		{
			Debug.Log ("You swiped right!");
		}
		
		if (swipe.y < -Mathf.Abs(swipe.x))
		{
			Debug.Log ("You swiped down!");
			showDriver(currentIndex+1);
		}
		
		if (swipe.y > Mathf.Abs(swipe.x))
		{
			Debug.Log ("You swiped up!");
			showDriver(currentIndex-1);
		}
		
	}
	public void showDriver(int aIndex) {
		if(aIndex>=driverList.Count) {
			aIndex = 0;
		}
		if(aIndex<0) {
			aIndex = driverList.Count-1;
		}
		this.currentIndex = aIndex;
		if(isInterestedInSigning==null) {
			GameObject g = this.gameObject.transform.FindChild("InterestedInSigningValue").gameObject;
			isInterestedInSigning = g.GetComponent<UILabel>();
		} 
		this.initDriver(driverList[aIndex]);
		if(isInterestedInSigning!=null) {
			GTTeam myTeam = ChampionshipSeason.ACTIVE_SEASON.getUsersTeam();
			DriverRelationshipRecord relationship = myTeam.relationshipWithDriver(driverList[aIndex]);
			if(relationship.interest.payDemand>0f) {
				isInterestedInSigning.text = relationship.interest.driverInterestString;
			} else {
				isInterestedInSigning.text = "NO";
			}
		}
	}
	public void alignToLeft() {
		
		
		GameObject go = this.transform.FindChild("DriverBuyFadeBG").gameObject;
		UISprite spr = go.GetComponent<UISprite>();
		if(spr!=null) {
			
			go = this.transform.parent.gameObject;
			
			if(go!=null) {
				Debug.Log ("Game Object is: "+go);
				Transform t = go.transform;
				//	pan.leftAnchor.target = t;
				spr.leftAnchor.relative = 0.02f;
				//pan.rightAnchor.target = t;
				spr.rightAnchor.relative = 0.4f;
				//pan.topAnchor.target = t;
				spr.topAnchor.relative = 0.80f;
				spr.topAnchor.absolute = 0;
				
				
				spr.bottomAnchor.target = t;
		//		spr.bottomAnchor.relative = 0;
		//		spr.bottomAnchor.absolute = 0;
				spr.ResetAndUpdateAnchors();
			}
		}
	}

}

