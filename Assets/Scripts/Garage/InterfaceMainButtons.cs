﻿using UnityEngine;
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

	public CarDetails prefabCarDetails;
	public DriverPanel prefabDriverDetails;
	public SettingsScreen prefabSettingsScreen;

	public static InterfaceMainButtons REF;
	// Use this for initialization
	void Start () {
		REF = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onLaunchResearch() {
		researchScreen.gameObject.SetActive(true);
		this.gameObject.SetActive(false);
		researchScreen.initFromCar(ChampionshipSeason.ACTIVE_SEASON.getUsersTeam().cars[0]);
	}

	public void onLaunchSettingsScreen() {
		GameObject g = NGUITools.AddChild(GameObject.Find ("UI Root"),prefabSettingsScreen.gameObject);
	}
	public void onLaunchCarDetails() {
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

	public void createCarDetailsScreen(GameObject aLastScreen,GTCar aCar,bool aShowButtons) {
		destroyCarDetailsScreen();
		GameObject g = NGUITools.AddChild(GameObject.Find ("UI Root"),prefabCarDetails.gameObject);
		carDetailsScreen = g.GetComponent<CarDetails>();
		carDetailsScreen.initCar(aCar);
		if(!aShowButtons) {
			carDetailsScreen.disableButtons();
		}
	}

	public void onCloseOtherScreen() {
		destroyCarDetailsScreen();
		researchScreen.gameObject.SetActive(false);
		this.gameObject.SetActive(true);
	}
}
