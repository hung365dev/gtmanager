using UnityEngine;
using System.Collections;
using Database;
using Racing;
using championship;
using System.Collections.Generic;
using Teams;
using Drivers;
using Cars;

public class RaceManager : MonoBehaviour {
	public IRDSCarCamera carCamera;
	public IRDSLevelLoadVariables levLoad;
	public bool inited = false;
	public IRDSManager manager;
	public IRDSPlaceCars placeCars;
	public static RaceManager REF;
	public int maxLaps = 3;
	public int activeCarsCount = 0;
	public int maxCars = 0;
	public int timeUntilForcedFinish = int.MinValue;
	public BetterList<RacingAI> finishers = new BetterList<RacingAI>();
	public float lastUpdate;
	public RaceFinisherTable raceFinisherTable;
	public GameObject minimapObject;
	public IndividualCarInterfaceManager individualCarInterface;
	public TeamControl teamController; 
	public RacePositionsTable racePositions;
	public bool hasStarted = false;
	public ChampionshipRaceSettings raceSettings;
//	public CarLibrary carLib;
	// Use this for initialization
	void Start () {
		lastUpdate = Time.time;
		REF = this;
		carCamera = GameObject.Find("Main_Camera").GetComponent<IRDSCarCamera>();
		//Screen.SetResolution(640, 480, true);
		carCamera.ActivateRoadCamera ();
		if (TeamDatabase.REF == null) {
			return;
		}
		GameObject light = GameObject.Find("Directional Light");
		Light dl = light.GetComponent<Light>();
		switch(SettingsScreen.shadowLevel) {
			case(0):dl.shadows = LightShadows.None;break;
			case(1):dl.shadows = LightShadows.Hard;break;
			case(2):dl.shadows = LightShadows.Soft;break;
		}
	//	Time.timeScale = 4;
		manager = GameObject.Find ("IRDSManager").GetComponent<IRDSManager> ();
		raceFinisherTable = GameObject.Find("RaceCompletePanel").GetComponent<RaceFinisherTable>();
		raceFinisherTable.gameObject.SetActive(false);
		carCamera = manager.GetComponentInChildren<IRDSCarCamera>();
		placeCars = manager.gameObject.GetComponentInChildren<IRDSPlaceCars> (); 
	//	BetterList<IRDSCarControllerAI> allCars = new BetterList<IRDSCarControllerAI> ();

		List<GTDriver> driversInRace = ChampionshipRaceSettings.ACTIVE_RACE.driversForRace();

		for(int i = 0;i<driversInRace.Count;i++) {
			GTTeam team = ChampionshipSeason.ACTIVE_SEASON.getTeamFromDriver(driversInRace[i]);
			GTCar gtCar = team.getGTCarFromDriver(driversInRace[i]);
			IRDSCarControllerAI car = team.getCarFromDriver(driversInRace[i]);
			IRDSCarControllerAI placedCar = placeCars.AddNewAICar(car.gameObject,team.teamColor,driversInRace[i].driverName);
			if(placedCar!=null) {

				RacingAI thisCar = placedCar.GetComponent<RacingAI>().initDriver(driversInRace[i]);
				if(team.humanControlled) {
					thisCar.humanControl = true;
		
				}
				thisCar.recolourCarForTeam(team);
				thisCar.carRef = gtCar;
				gtCar.applyResearchToCar(thisCar.aiDriveTrain,thisCar.aiCar,thisCar.GetComponent<RacingAI>());
				activeCarsCount++;
				this.maxCars++;
			}
			if(team.humanControlled) {
				teamController.initHumanCar(placedCar);

			}
		}

	}

	public void HandleNewFinisher(RacingAI aRacingAI) {
		finishers.Add(aRacingAI);
		GTTeam team = ChampionshipSeason.ACTIVE_SEASON.getTeamFromDriver(aRacingAI.driverRecord);
		team.cash += ChampionshipRaceSettings.ACTIVE_RACE.prizeForPosition(finishers.size,this.maxCars);;
		aRacingAI.prizeString = ""+ChampionshipRaceSettings.ACTIVE_RACE.prizeForPosition(finishers.size,this.maxCars);
		aRacingAI.finishPoints = ChampionshipRaceSettings.ACTIVE_RACE.pointsForDriverPosition(finishers.size);
		aRacingAI.driverRecord.lastRacePoints = aRacingAI.finishPoints;
		aRacingAI.driverRecord.championshipPoints += aRacingAI.finishPoints;
		
		GTTeam owningTeam = ChampionshipSeason.ACTIVE_SEASON.getTeamFromDriver(aRacingAI.driverRecord);
		if(finishers.size==1) {
			timeUntilForcedFinish = 45;
			owningTeam.seasonWins++;
		}
		owningTeam.seasonPoints += aRacingAI.finishPoints;
		activeCarsCount--;
		if(activeCarsCount==0) {
			Debug.Log ("Race Finished!");
			this.teamController.finish();
			Destroy(this.minimapObject);
			Destroy(this.racePositions.gameObject);
			raceFinisherTable.activate(finishers);
		}
	}
	// Update is called once per frame

	private void forceFinish() {
		GameObject[] gs = GameObject.FindGameObjectsWithTag("Player");
		for(int i = 0;i<gs.Length;i++) {
			RacingAI ai = gs[i].GetComponent<RacingAI>();
			if(ai!=null) {
				if(!ai.raceComplete) {
					ai.forceRaceComplete();
				}
			}
		}
	}
	void Update () {
		if (!inited) {
			carCamera.ActivateRoadCamera ();
			racePositions = GameObject.Find ("RacePositionsTable").GetComponent<RacePositionsTable>();
			inited = true;
		} else {
			if(Time.time-lastUpdate>1f) {
				// Second has ticked by
				if(timeUntilForcedFinish>0) {
					timeUntilForcedFinish--;
					if(timeUntilForcedFinish==0) {
						forceFinish();
					}
				}
				lastUpdate = Time.time;
			}
		}


	}
}
