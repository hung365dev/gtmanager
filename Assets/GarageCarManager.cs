using UnityEngine;
using System.Collections;
using Cars;
using championship;
using Teams;
using System;
using Database;

public class GarageCarManager : MonoBehaviour {


	public int indexInTeam = 0;
	public CarLibraryRecord record = null;
	public GTCar car = null;
	public GameObject thisCarsGameObject;
	// Use this for initialization
	void Start () {
		initCar();
	}

	public void initCar() {
		if(ChampionshipSeason.ACTIVE_SEASON!=null) {
			GTTeam team = ChampionshipSeason.ACTIVE_SEASON.getUsersTeam();
			IRDSCarControllerAI carController = team.cars[indexInTeam].carReference;
			record = team.cars[indexInTeam].carLibRecord;
			GameObject thisCar = GameObject.Instantiate(carController.gameObject);
			car = team.cars[indexInTeam];
			thisCar.transform.position = this.gameObject.transform.position;
			Quaternion q = this.gameObject.transform.rotation;
			thisCar.transform.rotation = q;
			RacingAI thisAI = thisCar.GetComponent<RacingAI>();
			try {
				thisAI.initSmokes();  
				thisAI.hidePilot();
			} catch(Exception e) { 
				
			}
			thisCarsGameObject = thisCar;
			team.applySponsorsToCar(thisCarsGameObject);
			thisAI.engineFailure = Racing.EEngineFailureStage.Normal;
			thisAI.setEngineFailureStage();
			thisAI.recolourCarForTeam(team);
			Destroy(thisAI.engineBlackSmoke);
			Destroy(thisAI.engineFire);
			Destroy(thisAI.engineWhiteSmoke);
			Destroy(thisAI);
			IRDSDrivetrain dt = thisCar.GetComponent<IRDSDrivetrain>();
			Destroy(dt);
			
			IRDSCarControllerAI ai = thisCar.GetComponent<IRDSCarControllerAI>();
			Destroy(ai);
			IRDSCarVisuals cv = thisCar.GetComponent<IRDSCarVisuals>();
			Destroy(cv);
			
			IRDSCarSetup cs = thisCar.GetComponent<IRDSCarSetup>();
			Destroy(cs);
			
			this.deleteIRDSClasses(thisCar);
		}
	}
	public void deleteIRDSClasses(GameObject aObject) {
		if(aObject.GetComponent<IRDSSoundController>()!=null) {
			Destroy(aObject.GetComponent<IRDSSoundController>());
		}
		if(aObject.GetComponent<IRDSAerodynamicResistance>()!=null) {
			Destroy(aObject.GetComponent<IRDSAerodynamicResistance>());
		}
		if(aObject.GetComponent<IRDSCarDamage>()!=null) {
			Destroy(aObject.GetComponent<IRDSCarDamage>());
		}
		if(aObject.GetComponent<IRDSNavigateTWaypoints>()!=null) {
			Destroy(aObject.GetComponent<IRDSNavigateTWaypoints>());
		}
		if(aObject.GetComponent<IRDSPlayerControls>()!=null) {
			Destroy(aObject.GetComponent<IRDSPlayerControls>());
		}
		if(aObject.GetComponent<IRDSPerCarGUI>()!=null) {
			Destroy(aObject.GetComponent<IRDSPerCarGUI>());
		}
		if(aObject.GetComponent<IRDSCarControllerAI>()!=null) {
			Destroy(aObject.GetComponent<IRDSCarControllerAI>());
		}
		if(aObject.GetComponent<IRDSDrivetrain>()!=null) {
			Destroy(aObject.GetComponent<IRDSDrivetrain>());
		}
	}

	// Update is called once per frame
	void Update () {
		if(car.carLibRecord!=this.record) {
			Destroy(this.thisCarsGameObject);
			this.initCar();
		}
	}
}
