using UnityEngine;
using System.Collections;
using Drivers;
using Teams;
using championship;
using System;
using Cars;
using PixelCrushers.DialogueSystem;

public class ContractOfferScreen : MonoBehaviour {


	public UILabel titleForScreen;
	public UILabel driverDemands;
	public UILabel contractLength;
	
	public UILabel payOffer;
	public UILabel winBonusOffer;

	public UILabel currentContractInfo;

	public UI2DSprite faceSprite;

	private GTDriver _thisDriver;
	private GTDriver _driverToReplace;
	public DriverContract offerContract = new DriverContract();
	public delegate void OnCloseContract ();
	public OnCloseContract onCloseContractScreenF;
	
	public delegate void OnContractAccepted (GTDriver aDriver);
	public OnContractAccepted onContractAccepted;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Lua.Result r = DialogueLua.GetVariable("HintArrowOfferContract");
		Debug.Log (r.AsInt);
	}


	public void initDriver(GTDriver aDriver,GTDriver aDriverToReplace) {

		GarageManager.REF.doConversation("OpenHireDriverScreen");
		_thisDriver = aDriver;
		_driverToReplace = aDriverToReplace; 
		GTTeam driversTeam = ChampionshipSeason.ACTIVE_SEASON.getTeamFromDriver(aDriver);
		GTTeam myTeam = ChampionshipSeason.ACTIVE_SEASON.getUsersTeam();
		faceSprite.sprite2D = aDriver.record.sprite;
		if(driversTeam==myTeam) {
			this.titleForScreen.text = "Renew Contract with "+aDriver.name;
		} else {
			
			this.titleForScreen.text = "Offer Contract to "+aDriver.name;

		}
		if(driversTeam==null) {
			currentContractInfo.text = aDriver.name+" is a Free Agent";
		} else {
			currentContractInfo.text = aDriver.name+" is contracted to "+driversTeam.teamName+"";
		}
		offerContract.team = ChampionshipSeason.ACTIVE_SEASON.getUsersTeam();
		//float demandSalary = aDriver.contract;
		DriverRelationshipRecord relationshipForDriver = myTeam.relationshipWithDriver(aDriver);
		if(relationshipForDriver.interest.payDemand==0f) {
			this.driverDemands.text = aDriver.name+" is not interested in joining your team at any price";
		} else {
			string payDemand = aDriver.name+" is demanding "+relationshipForDriver.interest.payDemand.ToString("C0")+" Per Race for a minimum of "+relationshipForDriver.interest.contractLength+" seasons. ";
			offerContract.payPerRace = Convert.ToInt32(relationshipForDriver.interest.payDemand);
			if(relationshipForDriver.interest.bonusDemand>0f) {
				string bonusDemand = "They are also demanding a win bonus of "+relationshipForDriver.interest.bonusDemand.ToString("C0")+". ";
				payDemand += bonusDemand;
				offerContract.bonusPerRace = Convert.ToInt32(relationshipForDriver.interest.bonusDemand);
			}
			offerContract.remainingOnContract = relationshipForDriver.interest.contractLength;
			if(aDriver.contract.team!=null&&aDriver.contract.team!=myTeam) {
				string compensation = "If "+aDriver.name+" accepts our offer, we must pay "+aDriver.contract.team.teamName+" "+aDriver.contract.compensationAmount.ToString("C0")+" compensation if the contract is accepted.";
				payDemand += compensation;
			}
			this.driverDemands.text = payDemand;
		}
		showCurrentContractOffer();
	}
	private void showCurrentContractOffer() {
		this.payOffer.text = ""+this.offerContract.payPerRace.ToString("C0");
		this.contractLength.text = ""+this.offerContract.remainingOnContract;
		this.winBonusOffer.text = ""+this.offerContract.bonusPerRace.ToString("C0");
	}
	public void onShorterContract() {
		if(offerContract.remainingOnContract>1) {
			offerContract.remainingOnContract--;
		}
		showCurrentContractOffer();
	}

	public void onLongerContract() {
		
		if(offerContract.remainingOnContract<5) {
			offerContract.remainingOnContract++;
		}
		showCurrentContractOffer();
	}

	public void onLessPay() {
		
		if(offerContract.payPerRace>500) {
			offerContract.payPerRace-=250;
		}
		showCurrentContractOffer();
	}
	public void onMorePay() {
		
		if(offerContract.payPerRace<50000) {
			offerContract.payPerRace+=250;
		}
		showCurrentContractOffer();
	}
	public void onLessBonus() {
		
		if(offerContract.bonusPerRace>500) {
			offerContract.bonusPerRace-=250;
		}
		showCurrentContractOffer();
	}
	public void onMoreBonus() {
		
		if(offerContract.bonusPerRace<50000) {
			offerContract.bonusPerRace+=250;
		}
		showCurrentContractOffer();
	}

	public void onOfferContract() {

		GTTeam driversTeam = ChampionshipSeason.ACTIVE_SEASON.getTeamFromDriver(_thisDriver);
		GTTeam myTeam = ChampionshipSeason.ACTIVE_SEASON.getUsersTeam();
		
		DriverRelationshipRecord relationshipForDriver = myTeam.relationshipWithDriver(_thisDriver);
		if(offerContract.payPerRace>Convert.ToInt32(relationshipForDriver.interest.willAccept*relationshipForDriver.interest.payDemand)) {
			if(offerContract.bonusPerRace>Convert.ToInt32(relationshipForDriver.interest.willAccept*relationshipForDriver.interest.bonusDemand)) {
				if(_thisDriver.contract.compensationAmount<myTeam.cash) {
					
					
					GarageManager.REF.doConversation("OpenHireDriverScreen");
					if(_driverToReplace!=null) {
						GTCar car = myTeam.getGTCarFromDriver(this._driverToReplace);
						int indexForMyDriver = myTeam.indexForDriver(_driverToReplace);
					   
						GTDriver oldDriver = _driverToReplace;
						GTDriver newDriver = this._thisDriver;
					   
						GTTeam oldTeam = ChampionshipSeason.ACTIVE_SEASON.getTeamFromDriver(newDriver);
					   	int indexForOldDriver = oldTeam.indexForDriver(newDriver);
						// At the moment the drivers old team just get my driver
					   	oldTeam.drivers[indexForOldDriver] = this._driverToReplace;
						myTeam.drivers[indexForMyDriver] = this._thisDriver;
					}
					Destroy(this.gameObject);
					_thisDriver.contract = this.offerContract;
					this.onCloseContractScreenF();
					this.onContractAccepted(this._thisDriver);
					DialogueLua.SetVariable("SignedDriver",_thisDriver.name);
					GarageManager.REF.doConversation("ContractSignedMessage");
				
				}
			else {
					this.driverDemands.text = "You cannot afford to pay "+ChampionshipSeason.ACTIVE_SEASON.getTeamFromDriver(_thisDriver).teamName+" their compensation.";
				}
			} else {
				this.driverDemands.text = _thisDriver.name+" is close to agreeing terms but feels they deserve a bigger win bonus.";
			}
		} else {
			this.driverDemands.text = _thisDriver.name+" is demanding more pay per race.";
		}
	}
	public void onCloseContractScreen() {
		if(onCloseContractScreenF!=null) {
			onCloseContractScreenF();
			Destroy(this.gameObject);
		}
	}
}
