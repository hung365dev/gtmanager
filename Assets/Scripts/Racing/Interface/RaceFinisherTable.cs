using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using championship;
using Drivers;
using Teams;
using PixelCrushers.DialogueSystem;
using Championship;
using System;
using UnionAssets.FLE;
using Utils;

public class RaceFinisherTable : MonoBehaviour {

	// Use this for initialization
	public List<RaceCompleteMember> completeMembers;
	public UILabel titleText;
	public int stage = 0;
	public static int betWon = 0;
	public RaceEndFinances finances = new RaceEndFinances();
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void activate(BetterList<RacingAI> aFinishers) {


		this.gameObject.SetActive(true);
		aFinishers.Sort(finishPositionSort);
		int i = 0;
		for(i = 0;i<aFinishers.size;i++) {
			completeMembers[i].init(aFinishers[i],i);
			
			completeMembers[i].gameObject.SetActive(true);
		}
		if(ChampionshipSeason.ACTIVE_SEASON.getTeamFromDriver(completeMembers[0].driver.driverRecord)==ChampionshipSeason.ACTIVE_SEASON.getUsersTeam()) {
			MobileNativeRateUs ratePopUp =  new MobileNativeRateUs("Enjoying Racing Manager?", "Rate us 5 Stars to help with future updates!","5 Stars","Not Right Now","Never!");
			#if UNITY_IOS
				ratePopUp.SetAppleId("975017895");
			#endif
			#if UNITY_ANDROID
				ratePopUp.SetAndroidAppUrl("market://details?id=com.blueomega.gpmanager");
			#endif
			ratePopUp.addEventListener(BaseEvent.COMPLETE,OnRatePopUpClose);
			ratePopUp.Start();
		} 
		for(int c = i;c<completeMembers.Count;c++) {
			completeMembers[i].gameObject.SetActive(false);
		}
	}
			private void OnRatePopUpClose(CEvent e) {
				//removing listner
				e.dispatcher.removeEventListener(BaseEvent.COMPLETE, OnRatePopUpClose);
				//parsing result
				switch((MNDialogResult)e.data) {
				case MNDialogResult.RATED:
					// No action needed
					SaveGameUtils.allowRating = false;
					break;
				case MNDialogResult.REMIND:
					Debug.Log ("Remind Option picked");
					SaveGameUtils.allowRating = true;
					break;
				case MNDialogResult.DECLINED:
					Debug.Log ("Declined Option picked");
			
					SaveGameUtils.allowRating = false;
					SaveGameUtils.saveSettings();
					break;
				}
			}
			
	private int finishPositionSort(RacingAI a1,RacingAI a2) {
		if(a1.finishPoints>a2.finishPoints) {
			return -1;
		} else if(a1.finishPoints<a2.finishPoints) {
			return 1;
		}
		return 0;
	}
	public void doContinue() {
		stage++;
		switch(stage) {
			case(1):titleText.text = "Prize Money";break;
			case(2):titleText.text = "Points for Race";break;
			case(3):titleText.text = "Drivers Championship";break;
			case(4):titleText.text = "Constructors Championship";break;
		} 
		if(stage==5) {
			ChampionshipSeason.ACTIVE_SEASON.secondsPast++;
			Lua.Result r = DialogueLua.GetVariable("TotalRacesComplete");
			DialogueLua.SetVariable("TotalRacesComplete",r.AsInt + 1);
			GTTeam playersTeam = ChampionshipSeason.ACTIVE_SEASON.getUsersTeam();
			for(int i = 0;i<this.completeMembers.Count;i++) {
				GTTeam teamForDriver = ChampionshipSeason.ACTIVE_SEASON.getTeamFromDriver(completeMembers[i].driver.driverRecord);
				
				GTDriver thisDriver = completeMembers[i].driver.driverRecord;
				if(teamForDriver==playersTeam) {
					int indexForDriver = playersTeam.indexForDriver(thisDriver);
					switch(indexForDriver) {
					case(0):finances.driverACost += thisDriver.contract.payPerRace;
						if(completeMembers[i].driver.won)
							finances.driverABonus+= thisDriver.contract.bonusPerRace;
						finances.prizeA = completeMembers[i].driver.prize;
						finances.damagesA += Convert.ToInt32((completeMembers[i].driver.damage/100)*completeMembers[i].driver.carRef.carLibRecord.carCost/10);
						break;
					case(1):finances.driverBCost += thisDriver.contract.payPerRace; 
						if(completeMembers[i].driver.won)
							finances.driverBBonus+= thisDriver.contract.bonusPerRace;
						finances.damagesB += Convert.ToInt32((completeMembers[i].driver.damage/100)*completeMembers[i].driver.carRef.carLibRecord.carCost/10);
						
						finances.prizeB = completeMembers[i].driver.prize;
						break;
					}
				}

			}

			finances.sponsorIncome =playersTeam.sponsorIncomePerRace;
			finances.date = ChampionshipSeason.ACTIVE_SEASON.secondsPast;
			playersTeam.decreaseSponsorContractLengths();
			RaceEndFinances.showFinance = true;
			RaceEndFinances.mostRecent = finances;
			RaceEndFinances.mostRecent.bets = betWon;
			StartCoroutine(ChampionshipSeason.ACTIVE_SEASON.LoadLevel("Garage","Loading Garage"));

 
		} else if(stage==4) {
			List<GTTeam> sortedTeams = ChampionshipSeason.ACTIVE_SEASON.seasonForTeam(ChampionshipSeason.ACTIVE_SEASON.getUsersTeam()).sortedTeams;
			int i = 0;
			for(i = 0;i<sortedTeams.Count;i++) {
				completeMembers[i].initTeam(sortedTeams[i]);
				completeMembers[i].gameObject.SetActive(true);
			}
			
			for(int c = i;c<completeMembers.Count;c++) {
				completeMembers[c].gameObject.SetActive(false);
			}
			
		} else
		if(stage==3) {
			List<GTDriver> drivers = ChampionshipSeason.ACTIVE_SEASON.nextRace.driversForRace();
			drivers.Sort(ChampionshipSeasonBase.SortByChampionshipPoints);
			for(int i = 0;i<completeMembers.Count;i++) {
				completeMembers[i].showChampionshipPoints(drivers[i]);
			}
		} else {
			for(int i = 0;i<completeMembers.Count;i++) {
				completeMembers[i].doContinue();
			}
		}
	}
}
