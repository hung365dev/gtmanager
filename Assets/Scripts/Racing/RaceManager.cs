using UnityEngine;
using System.Collections;
using Database;
using Racing;
using championship;
using System.Collections.Generic;
using Teams;
using Drivers;
using Cars;
using PixelCrushers.DialogueSystem;

public class RaceManager : MonoBehaviour {
	public IRDSCarCamera carCamera;
	public IRDSLevelLoadVariables levLoad;
	public IRDSStatistics statistics;
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
	public RaceStarterTable raceStartersTable;
	public GameObject genericRaceGUI;
	public ConversationTrigger conversationTrigger;
	public SendMessageOnDialogueEvent sendMessage;
	public UILabel driver1Label;
	public UILabel driver2Label;

	public bool activateFinishersOnClose = false;
	public List<CC_FastVignette> fv = new List<CC_FastVignette>();
//	public CarLibrary carLib;
	// Use this for initialization
	void Start () {
		lastUpdate = Time.time;
		REF = this;
		carCamera = GameObject.Find("Main_Camera").GetComponent<IRDSCarCamera>();
		levLoad = GameObject.Find ("LevelLoad").GetComponent<IRDSLevelLoadVariables>();

		levLoad.laps = 3;

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

		NGUIDisabler.PAUSED_TIME_SCALE = 0.1f;
	//	Time.timeScale = 4;
		manager = GameObject.Find ("IRDSManager").GetComponent<IRDSManager> ();
		statistics =manager.GetComponentInChildren<IRDSStatistics>();
		statistics.startRaceManually = true;
	//	statistics.StartTheRace();

		carCamera = manager.GetComponentInChildren<IRDSCarCamera>();
		placeCars = manager.gameObject.GetComponentInChildren<IRDSPlaceCars> (); 
	//	BetterList<IRDSCarControllerAI> allCars = new BetterList<IRDSCarControllerAI> ();


		genericRaceGUI = GameObject.Find("GenericRaceGUI");
		UILabel totalRacers = GameObject.Find ("NumberOfRacers").GetComponent<UILabel>();
		UILabel totalLaps = GameObject.Find("LAP").GetComponent<UILabel>();

		driver1Label = GameObject.Find("DriverMessage1").GetComponent<UILabel>();
		driver2Label = GameObject.Find("DriverMessage2").GetComponent<UILabel>();

		if(genericRaceGUI!=null) {
			genericRaceGUI.gameObject.SetActive(false);
		}
		List<GTDriver> driversInRace = ChampionshipRaceSettings.ACTIVE_RACE.driversForRace();
		
		totalRacers.text = "/ "+driversInRace.Count;
		totalLaps.text = "/ "+this.levLoad.laps;
		
		GameObject raceStarters = GameObject.Find("RaceLineupPanel");
		if(raceStarters!=null) {
			raceStartersTable = raceStarters.GetComponent<RaceStarterTable>();
			raceStartersTable.activate(driversInRace);
		}
		
		
		for(int i = 0;i<this.fv.Count;i++) {
			fv[i].enabled = true;
		}
		if(levLoad.raceStartType!=IRDSLevelLoadVariables.RaceStartType.Rolling) {
			
			StartCoroutine(makeCars());
		} else {
			raceStartersTable.allowRaceStart();
		}

		//
	}
	
	public void doConversation(string aConversationName) {
		conversationTrigger = this.GetComponent<ConversationTrigger>();
		if(conversationTrigger==null) {
			conversationTrigger = this.gameObject.AddComponent<ConversationTrigger>();
			sendMessage = this.gameObject.GetComponent<SendMessageOnDialogueEvent>();

		}
		conversationTrigger.conversation = aConversationName;
		conversationTrigger.OnUse();
	}
	
	public void onConversationEnded() {
		if(activateFinishersOnClose) {
			raceFinisherTable.activate(finishers);
		}
	}
	public void HandleNewFinisher(RacingAI aRacingAI) {
		finishers.Add(aRacingAI);
		GTTeam team = ChampionshipSeason.ACTIVE_SEASON.getTeamFromDriver(aRacingAI.driverRecord);
		team.cash += ChampionshipRaceSettings.ACTIVE_RACE.prizeForPosition(finishers.size,this.maxCars);;
		aRacingAI.prizeString = ""+ChampionshipRaceSettings.ACTIVE_RACE.prizeForPosition(finishers.size,this.maxCars);
		aRacingAI.prize = ChampionshipRaceSettings.ACTIVE_RACE.prizeForPosition(finishers.size,this.maxCars);
		aRacingAI.won = finishers.size==1;
		aRacingAI.finishPoints = ChampionshipRaceSettings.ACTIVE_RACE.pointsForDriverPosition(finishers.size);
		aRacingAI.driverRecord.lastRacePoints = aRacingAI.finishPoints;
		aRacingAI.driverRecord.championshipPoints += aRacingAI.finishPoints;
		
		GTTeam owningTeam = ChampionshipSeason.ACTIVE_SEASON.getTeamFromDriver(aRacingAI.driverRecord);
		if(finishers.size==1) {
			timeUntilForcedFinish = 45;
			owningTeam.seasonWins++;
		}
		owningTeam.addPoints(aRacingAI.finishPoints,finishers.size);
		activeCarsCount--;
		if(activeCarsCount==0) {
			Debug.Log ("Race Finished!");
			this.teamController.finish();
			findAndDestroyGameObjectIfExists("PositionArea");
			findAndDestroyGameObjectIfExists("TopMiddleArea");
			findAndDestroyGameObjectIfExists("LapArea");
			findAndDestroyGameObjectIfExists("BottomArea");
			findAndDestroyGameObjectIfExists("CarBehindLabel");
			findAndDestroyGameObjectIfExists("CarInfrontLabel");

			Destroy(this.minimapObject);
			if(this.racePositions!=null)
				Destroy(this.racePositions.gameObject);

			RandomEvent r = ChampionshipSeason.ACTIVE_SEASON.leagueForTeam(ChampionshipSeason.ACTIVE_SEASON.getUsersTeam()).getRandomEventCompletingOnDay(ChampionshipSeason.ACTIVE_SEASON.secondsPast);
			if(r!=null) {
				if(r.eventType==ERandomEventType.FinishAheadOf) {
					if(pointsForTeamInRace(r.targetTeam)<pointsForTeamInRace(ChampionshipSeason.ACTIVE_SEASON.getUsersTeam())) {
						// User has won their bet
						RaceFinisherTable.betWon = r.rewardCash*2;

						DialogueLua.SetVariable("RandomEventStringMessage",r.wonAlert);
						//DialogueManager.ShowAlert(r.wonAlert);
						activateFinishersOnClose = true;
						this.doConversation("RandomEventComplete");
					} else {
						DialogueLua.SetVariable("RandomEventStringMessage",r.lostAlert);
						RaceFinisherTable.betWon = r.rewardCash*-1;
						activateFinishersOnClose = true;
						this.doConversation("RandomEventComplete");
					}
					StartCoroutine(delayToActivateFinishers());
					return;
				}
			} else {
				RaceFinisherTable.betWon = 0;
			}
			
			raceFinisherTable.activate(finishers);


		}
	}

	private IEnumerator delayToActivateFinishers() {
		yield return new WaitForSeconds(3f);
		raceFinisherTable.activate(finishers);
	}
	private int pointsForTeamInRace(GTTeam aTeam) {
		int r = 0;
		for(int i =0;i<this.finishers.size;i++) {
			if(ChampionshipSeason.ACTIVE_SEASON.getTeamFromDriver(finishers[i].driverRecord)==aTeam) {
				r+= finishers[i].finishPoints;
			}
		}
		return r;
	}
	private void findAndDestroyGameObjectIfExists(string aName) {
		GameObject g = GameObject.Find(aName);
		Destroy(g);
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

	public IEnumerator makeCars() {
		yield return null;
		List<GTDriver> driversInRace = ChampionshipRaceSettings.ACTIVE_RACE.driversForRace();
		
		
		for(int i = 0;i<driversInRace.Count;i++) {
			GTTeam team = ChampionshipSeason.ACTIVE_SEASON.getTeamFromDriver(driversInRace[i]);
			GTCar gtCar = team.getGTCarFromDriver(driversInRace[i]);
			IRDSCarControllerAI car = team.getCarFromDriver(driversInRace[i]);
			IRDSCarControllerAI placedCar = placeCars.AddNewAICar(car.gameObject,team.teamColor,driversInRace[i].name);
			if(placedCar!=null) {
				
				RacingAI thisCar = placedCar.GetComponent<RacingAI>().initDriver(driversInRace[i]);
				if(team.humanControlled) {
					thisCar.humanControl = true;
					
				}
				thisCar.recolourCarForTeam(team);
				thisCar.carRef = gtCar;
				gtCar.initLibraryValues(thisCar.aiDriveTrain,thisCar.aiCar,thisCar.GetComponent<RacingAI>());
				gtCar.applyResearchToCar(thisCar.aiDriveTrain,thisCar.aiCar,thisCar.GetComponent<RacingAI>());
				
				
				team.applySponsorsToCar(thisCar.gameObject);
				activeCarsCount++;
				this.maxCars++;
			}
			if(team.humanControlled) {
				teamController.initHumanCar(placedCar);
				int indexForThis = team.indexForCar(gtCar);
				string findThis = "DriverFace2";
				if(indexForThis==0) {
					findThis = "DriverFace1";
				}
				GameObject f = GameObject.Find (findThis);
				if(f!=null) {
					DriverFaceManager m = f.GetComponent<DriverFaceManager>();
					RacingAI ai = placedCar.GetComponent<RacingAI>();
					m.init(ai);
				}	
			}
			yield return new WaitForEndOfFrame();
		}
		if(this.raceStartersTable!=null) 
			this.raceStartersTable.allowRaceStart(); else 
				doStartRace();
		

	}
	public void doStartRace() {
		if(levLoad.raceStartType==IRDSLevelLoadVariables.RaceStartType.Rolling&&maxCars==0) {
			StartCoroutine(makeCars());
			Destroy(raceStartersTable.gameObject);
			raceStartersTable = null;
			return; 
		}
		RandomEvent r = ChampionshipSeason.ACTIVE_SEASON.leagueForTeam(ChampionshipSeason.ACTIVE_SEASON.getUsersTeam()).getRandomEventCompletingOnDay(ChampionshipSeason.ACTIVE_SEASON.secondsPast);
		if(r!=null) {
			DialogueManager.ShowAlert(r.alertMessage);
		}
		this.statistics.StartTheRace();
		if(genericRaceGUI!=null) {
			genericRaceGUI.gameObject.SetActive(true);
			GameObject g = GameObject.Find ("TeamController");
			TeamControl t = g.GetComponent<TeamControl>();
			t.initButtons();

			raceFinisherTable = GameObject.Find("RaceCompletePanel").GetComponent<RaceFinisherTable>();
			raceFinisherTable.gameObject.SetActive(false);

			inited = false;

		}
		GameObject rsc = GameObject.Find ("RaceStartCamera");
		if(rsc!=null) {
			Destroy(rsc);
		}
		GameObject mc = GameObject.Find ("Main_Camera");
		if(mc!=null) {
			mc.GetComponent<Camera>().enabled = true;
		}
		GameObject g1 = GameObject.Find("RaceStartGUI");
		Destroy(g1);

	
	//	
	}

	void Update () {
		if (!inited) {
			carCamera.ActivateRoadCamera ();
			if(GameObject.Find ("RacePositionsTable")!=null) {
				racePositions = GameObject.Find ("RacePositionsTable").GetComponent<RacePositionsTable>();
				inited = true;
			}
			GameObject cam = GameObject.Find("Main_Camera");
			Camera c = cam.GetComponent<Camera>();
			if(c.GetComponent<CC_FastVignette>()==null) {
				CC_FastVignette fv1 = c.gameObject.AddComponent<CC_FastVignette>();
				fv1.enabled = true;
				fv.Add(fv1);
			}
			GameObject cam2 = GameObject.Find ("RaceStartCamera");
			if(cam2!=null) {
				c = cam2.GetComponent<Camera>();
				if(c.GetComponent<CC_FastVignette>()==null) {
					CC_FastVignette fv1 = c.gameObject.AddComponent<CC_FastVignette>();
					fv1.enabled = true;
					fv.Add(fv1);
				}
			}
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
