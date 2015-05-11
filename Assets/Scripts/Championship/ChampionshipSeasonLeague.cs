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
using Teams;
using UnityEngine;
using System.Collections.Generic;
using Drivers;
using Cars;
using Database;


namespace championship
{
	[System.Serializable]
	public class ChampionshipSeasonLeague
	{
		public string leagueName;
		public int divisionNumber;
		public List<ChampionshipRaceSettings> races = new List<ChampionshipRaceSettings>();
		public List<GTTeam> teams = new List<GTTeam>();
		public ChampionshipSeasonLeague ()
		{

		}
		public GTTeam getTeamFromDriver(GTDriver aDriver) {
			for(int i = 0;i<teams.Count;i++) {
				if(teams[i].hasDriver(aDriver)!=null) {
					return teams[i];
				}
			}
			return null;
		}
		public GTTeam getTeamFromCar(GTCar aCar) {
			for(int i = 0;i<teams.Count;i++) {
				GTCar car = teams[i].hasCar(aCar);
				if(car!=null) {
					return teams[i];
				}
			}
			return null;
		}
		public GTTeam hasTeam(GTTeam aTeam) {
			for(int i = 0;i<teams.Count;i++) {
				if(teams[i]==aTeam) {
					return teams[i];
				}
			}
			return null;
		}
		public GTTeam getUsersTeam() {
			for(int i = 0;i<teams.Count;i++) {
				if(teams[i].humanControlled) {
					return teams[i];
				}
			}
			return null;
		}
		public void addTeam(GTTeam aTeamToAdd) {
			teams.Add(aTeamToAdd);
		}

		public void initRaces() {
			ChampionshipRaceSettings race1 = new ChampionshipRaceSettings();
			race1.setupDefaultsForLeague(divisionNumber,0);
			races.Add(race1);
			ChampionshipRaceSettings race2 = new ChampionshipRaceSettings();
			race2.setupDefaultsForLeague(divisionNumber,1);
			races.Add(race2);
			ChampionshipRaceSettings race3 = new ChampionshipRaceSettings();
			race3.setupDefaultsForLeague(divisionNumber,2);
			races.Add(race3);

			ChampionshipRaceSettings race4 = new ChampionshipRaceSettings();
			race4.setupDefaultsForLeague(divisionNumber,3);
			races.Add(race4);
		}
		public bool humanLeague {
			get {
				for(int i = 0;i<teams.Count;i++) {
					if(teams[i].humanControlled) {
						return true;
					}
				}
				return false;
			}
		}

		public int positionForTeamInChampionship(GTTeam aTeam) {
			int lastPosition = -1;
			int lastPoints = -1;
			int lastWins = -1;

			teams.Sort(sortOnChampsPoints);
			for(int i = 0;i<teams.Count;i++) {
				if(lastPosition==-1) {
					lastPosition = 0;
					lastPoints = teams[i].seasonPoints;
					lastWins = teams[i].seasonWins;
				} else {
					if(teams[i].seasonPoints==lastPoints&&teams[i].seasonWins==lastWins) {

					} else {
						lastPosition++;
					}
				}
				if(teams[i]==aTeam) {
					return lastPosition;
				}
			}
			return 0;
		}

		public List<GTTeam> sortedTeams {
			get {
				teams.Sort(sortOnChampsPoints);
				return teams;
			}
		}

		public List<GTDriver> driversChampionshipPositions() {
			//TODO So far no grid setup is acknowledged.
			List<GTDriver> ret = new List<GTDriver>();
			for(int i = 0;i<this.teams.Count;i++) {
				ret.Add(teams[i].drivers[0]);
				ret.Add(teams[i].drivers[1]); 
			}
			ret.Sort(ChampionshipSeasonBase.SortByChampionshipPoints);
			return ret;
		}


		public int sortOnChampsPoints(GTTeam aTeam1,GTTeam aTeam2) {
			if(aTeam1.seasonPoints>aTeam2.seasonPoints) {
				return -1;
			} else if(aTeam2.seasonPoints>aTeam1.seasonPoints) {
				return 1;
			} else if(aTeam1.seasonWins>aTeam2.seasonWins) {
				return -1;
			} else if(aTeam2.seasonWins>aTeam1.seasonWins) {
				return 1;
			} else {
				return 0;
			}
		}

		public TrackDatabaseRecord eventOnDay(int aDay) {
			for(int i=0;i<this.races.Count;i++) {
				if(this.races[i].startDate==aDay) {
					return this.races[i].track;
				}
			}
			return null;
		}
		public void doTick(int aCurrentTick) {
			bool foundNextRace = false;
			
			ChampionshipRaceSettings nextRace = null;
			for(int i = 0;i<this.teams.Count;i++) {
				teams[i].doTick(aCurrentTick);
			}
			for(int i = 0;i<races.Count;i++) {
				
				int ticksTillThisRace = races[i].startDate-aCurrentTick;
				if(ticksTillThisRace>=0&&!foundNextRace) {
					if(races[i].teamsInRace==null||races[i].teamsInRace.Count==0) {
						races[i].teamsInRace = teams;
					}
					nextRace = races[i];
					foundNextRace = true;
				}
				if(races[i].startDate==aCurrentTick) {

				}

			}
			if(humanLeague) {
				
				ChampionshipSeason.ACTIVE_SEASON.nextRace = nextRace;
				int ticksTillNextRace = nextRace.startDate-aCurrentTick;
				Debug.Log("Ticks till next race: "+ticksTillNextRace);
			}
		}
	}	
}

