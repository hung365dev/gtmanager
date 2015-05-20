using UnityEngine;
using System.Collections;
using championship;
using Cars;
using System;
using Teams;
using Drivers;

public class InterfaceMainButtons : MonoBehaviour {

	public ResearchScreenMain researchScreen;

	public CarDetails carDetailsScreen;
	public DriverPanel driverDetailsScreen;
	public SponsorScreen sponsorScreen;
	
	public CarDetails prefabCarDetails;
	public DriverPanel prefabDriverDetails;
	public SettingsScreen prefabSettingsScreen;
	public ChampionshipStandings champSettingsScreen;
	public SponsorScreen prefabSponsorScreen;
	
	public static InterfaceMainButtons REF;
	// Use this for initialization
	void Start () {
		REF = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnDestroy() {
		REF = null;
		Debug.Log ("OnDestroy()");
	}

	public void onLaunchSponsors() {
		GarageManager.REF.doConversation("OpenSponsorsScreen");
		this.gameObject.SetActive(false);
		GameObject g = NGUITools.AddChild(GameObject.Find ("UI Root"),this.prefabSponsorScreen.gameObject);
		sponsorScreen = g.GetComponent<SponsorScreen>();
		
	}
	
	public void onLaunchResearch() {
		
		GarageManager.REF.doConversation("OpenResearchScreen");
		researchScreen.gameObject.SetActive(true);
		this.gameObject.SetActive(false);
		researchScreen.initFromCar(ChampionshipSeason.ACTIVE_SEASON.getUsersTeam().cars[0]);
	}

	public void onLaunchChampionshipScreens() {
		
		GarageManager.REF.doConversation("OpenChampionshipScreen");
		this.gameObject.SetActive(false);
		champSettingsScreen.activate();
		GarageManager.REF.hideTopButtons();
	}
	public void onLaunchChampionshipCompleteScreens() {
		REF = this;
		this.gameObject.SetActive(false);
		champSettingsScreen.activate(true);
		if(GarageManager.REF!=null)
			GarageManager.REF.hideTopButtons();
	}
	public void onCloseChampionshipScreen() {
		this.gameObject.SetActive(true);
		champSettingsScreen.gameObject.SetActive(false);
		GarageManager.REF.showTopButtons();
	}
	public void onLaunchSettingsScreen() {
		
		this.gameObject.SetActive(false);
		GameObject g = NGUITools.AddChild(GameObject.Find ("UI Root"),prefabSettingsScreen.gameObject);
	}
	public void onLaunchCarDetails() {
	//	GarageManager.REF.doConversation("OpenCarDetails");
		this.gameObject.SetActive(false);
		GTTeam team = ChampionshipSeason.ACTIVE_SEASON.getUsersTeam();
		this.createCarDetailsScreen(null,team.cars[0],true);
	}
	public void destroyCarDetailsScreen() {
		if(carDetailsScreen != null) {
			try {
				Destroy(carDetailsScreen.gameObject);
			} catch(Exception e) {
				
			}
		}
	}

	public void onLaunchDriversScreen() {
		GarageManager.REF.doConversation("OpenDriversScreen");
		this.gameObject.SetActive(false);
		createDriverDetailsScreen(null,ChampionshipSeason.ACTIVE_SEASON.getUsersTeam().drivers[0],true);
	}

	public void createDriverDetailsScreen(GameObject aLastScreen,GTDriver aDriver,bool aShowButtons) {
		destroyCarDetailsScreen();
		GameObject g = NGUITools.AddChild(GameObject.Find ("UI Root"),this.prefabDriverDetails.gameObject);
		this.driverDetailsScreen = g.GetComponent<DriverPanel>();
		driverDetailsScreen.initDriver(aDriver);
		if(!aShowButtons) {
		//	carDetailsScreen.disableButtons();
		}
	}

	public CarDetails createCarDetailsScreen(GameObject aLastScreen,GTCar aCar,bool aShowButtons) {
		destroyCarDetailsScreen();
		GameObject g = NGUITools.AddChild(GameObject.Find ("UI Root"),prefabCarDetails.gameObject);
		carDetailsScreen = g.GetComponent<CarDetails>();
		carDetailsScreen.initCar(aCar);
		if(!aShowButtons) {
			carDetailsScreen.disableButtons();
		}
		return carDetailsScreen;
	}
	
	public void onCloseOtherScreen() {
		destroyCarDetailsScreen();
		if(sponsorScreen!=null) {
			Destroy(sponsorScreen.gameObject);
		} 
		if(driverDetailsScreen!=null) {
			Destroy(driverDetailsScreen.gameObject);
		}
		GarageManager.REF.showTopButtons(); 
		if(researchScreen!=null&&researchScreen.gameObject!=null)
			researchScreen.gameObject.SetActive(false);
		if(gameObject!=null)
			this.gameObject.SetActive(true);
	}
}
