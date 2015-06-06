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
using Drivers;
using Cars;
using Database;
using UnityEngine;
using championship;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;


namespace Teams
{
	[System.Serializable]
	public class GTTeam : GTTeamWithSponsors
	{
		public GTTeam() {

		}
		public GTTeam (TeamDataRecord aTeamDataRecord) {
			cars.Add(aTeamDataRecord.carA);
			cars.Add(aTeamDataRecord.carB);


			initDriver(aTeamDataRecord.driverA);
			initDriver(aTeamDataRecord.driverB);
			reputation = aTeamDataRecord.reputation;
			teamColor = aTeamDataRecord.teamColor;
			wheelColor = aTeamDataRecord.wheelColor;
			teamName = aTeamDataRecord.name;

			if(teamName==HUMANS_DEBUG_TEAM) {
				humanControlled = true;
				DialogueLua.SetVariable("PlayersDriver1",drivers[0].name);
			} else {
			
			}
			initDriverRelationships();
			initSponsorRelationships();
			ignoreFromRelegationAndPromotion = false;
		}

		public void buyCarForDivision(int aDivision) {
			List<CarLibraryRecord> recs = new List<CarLibraryRecord>();
			for(int i = 0;i<CarDatabase.REF.cars.Count;i++) {
				if(CarDatabase.REF.cars[i].leagueRequired==aDivision) {
					recs.Add(CarDatabase.REF.cars[i]);
				}
			}
			if(recs.Count>0) {
				if(UnityEngine.Random.Range(0,1)==0)
					cars[0].replaceCarAI(recs[UnityEngine.Random.Range(0,recs.Count)]);
			
				if(UnityEngine.Random.Range(0,1)==0)
					cars[1].replaceCarAI(recs[UnityEngine.Random.Range(0,recs.Count)]);
			}
		}
		public void addPoints(int aPoints,int aPosition) {
			
			seasonPoints += aPoints;
			ChampionshipSeasonLeague league = ChampionshipSeason.ACTIVE_SEASON.leagueForTeam(this);
			
			addSponsorPoints((league.divisionNumber-1)*8+aPosition);
		}
		

		public GTCar otherCar(GTCar aThisCar) {
			if(cars[0]==aThisCar) {
				return cars[1];
			} else {
				return cars[0];
			}
		}

		public bool hasResearchCompletingOnDay(int aDay) {
			if(cars[0].hasResearchCompletingOnDay(aDay)!=null||cars[1].hasResearchCompletingOnDay(aDay)!=null) {
				return true;
			}
			return false;
		}
		public void doTick(int aTick) {
			for(int i = 0;i<this.cars.Count;i++) {
				if(cars[i].partBeingResearched!=null) {
					GTEquippedResearch partBeingResearched = cars[i].partBeingResearched;
					cars[i].partBeingResearched.daysOfResearchRemaining--;
					if(cars[i].partBeingResearched!=null&&ChampionshipSeason.ACTIVE_SEASON.nextRace!=null)
					if(cars[i].partBeingResearched.dayOfCompletion==ChampionshipSeason.ACTIVE_SEASON.nextRace.startDate) {
						cars[i].partBeingResearched.dayOfCompletion++;
						cars[i].partBeingResearched.daysOfResearchRemaining++;
					}
					if(partBeingResearched.daysOfResearchRemaining == 0) {

				//		partBeingResearched.level++;
						if(this.humanControlled) {
							DialogueLua.SetVariable("CompletedResearchName",""+partBeingResearched.researchRow._partname);
			
							GarageManager.REF.doConversation("ResearchComplete");
						}
					}
				}
			}
			if(!humanControlled) {
				findSponsorsForMe();
			} 
		}

		public IRDSCarControllerAI getCarFromDriver(GTDriver aDriver) {
			int index = indexForDriver(aDriver);
			GTCar car = cars[index];

			IRDSCarControllerAI ret = car.carReference;
			ret.SetDriverName(aDriver.name);
			return ret;
		}

		public GTDriver getDriverFromCar(GTCar aCar) {
			int index = indexForCar(aCar);
			if(index>=0) {

				GTDriver driver = drivers[index];
				return driver;
			}
			return null;
		}
		public GTCar getGTCarFromDriver(GTDriver aDriver) {
			int index = indexForDriver(aDriver);
			GTCar car = cars[index];
			return car;
		}
		public GTCar hasCar(GTCar aCar) {
			for(int i = 0;i<this.cars.Count;i++) {
				if(cars[i]==aCar) {
					return cars[i];
				}
			}
			return null;
		}
		public GTDriver hasDriver(GTDriver aDriver) {
			for(int i = 0;i<drivers.Count;i++) {
				if(drivers[i]==aDriver) {
					return drivers[i];
				}
			}
			return null;
		}
		public int indexForCar(GTCar aCar) {
			for(int i = 0;i<cars.Count;i++) {
				if(cars[i]==aCar) {
					return i;
				}
			}
			return -1;
		}
		public int indexForDriver(GTDriver aDriver) {
			for(int i = 0;i<drivers.Count;i++) {
				if(drivers[i]==aDriver) {
					return i;
				}
			}
			return -1;
		}

	}
}

