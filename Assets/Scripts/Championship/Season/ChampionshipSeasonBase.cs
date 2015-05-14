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
using System.Collections;
using System.Collections.Generic;
using Teams;
using Drivers;
using Cars;


namespace championship
{
	public class ChampionshipSeasonBase : MonoBehaviour
	{
		public List<ChampionshipSeasonLeague> leagues = new List<ChampionshipSeasonLeague>();
		public int secondsPast;
		public bool allowTimeToPass = false;
		private float _lastUpdate;
		public ChampionshipSeasonBase ()
		{
		}

		public void Start() {
			DontDestroyOnLoad(this);
			_lastUpdate = Time.time;
		}

		public void handleRelegationsAndPromotions() {
			for(int i = 0;i<leagues.Count;i++) {
				GTTeam relegatedTeam = leagues[i].relegatedTeam;
				if(relegatedTeam!=null) {
					leagues[i+1].addTeam(relegatedTeam);
					leagues[i].removeTeam(relegatedTeam);
				} 
				GTTeam promotedTeam = leagues[i].promotedTeam;
				if(promotedTeam!=null) {
					leagues[i-1].addTeam(promotedTeam);
					leagues[i].removeTeam(promotedTeam);
				}
			}
			for(int i = 0;i<leagues.Count;i++) {
				leagues[i].initRaces();
			}
		}
		public GTTeam getTeamFromCar(GTCar aCar) {
			for(int i = 0;i<leagues.Count;i++) {
				GTTeam team = leagues[i].getTeamFromCar(aCar);
				if(team!=null) {
					return team;
				}
			}
			return null;
		}
		public GTTeam getUsersTeam() {
			for(int i = 0;i<leagues.Count;i++) {
				GTTeam team = leagues[i].getUsersTeam();
				if(team!=null) {
					return team;
				}
			}
			return null;
		}
		
		public ChampionshipSeasonLeague leagueForTeam(GTTeam aTeam) {
			for(int i = 0;i<leagues.Count;i++) {
				if(leagues[i].hasTeam(aTeam)!=null) {
					return leagues[i];
				}
			}
			return leagues[0];
		}
		public GTTeam getTeamFromDriver(GTDriver aDriver) {
			for(int i = 0;i<leagues.Count;i++) {
				GTTeam team = leagues[i].getTeamFromDriver(aDriver);
				if(team!=null) {
					return team;
				}
			}
			return null;
		}
		public virtual void Update() {
			if(Time.time-_lastUpdate>1f) {
				_lastUpdate = Time.time;
				if(allowTimeToPass) {
					secondsPast++;
					for(int i = 0;i<leagues.Count;i++) {
						leagues[i].doTick(secondsPast);
					}

					GameObject go = GameObject.Find("GarageManager");
					if(go!=null) {
						go.GetComponent<GarageManager>().UpdateDisplay();
					}

					go = GameObject.Find ("CalendarContainer");
					if(go!=null) {
						CalendarManager cm = go.GetComponent<CalendarManager>();
						cm.updateDay();
					}
				}
			}
		}

		public string dateString(int aDay) {
			DateTime theDate = new DateTime( 2016, 1, 1 ).AddDays( aDay );
			return theDate.ToShortDateString();
		}

		public ChampionshipSeasonLeague seasonForTeam(GTTeam aTeam) {
			for(int i = 0;i<leagues.Count;i++) {
				if(leagues[i].hasTeam(aTeam)!=null) {
					return leagues[i];
				}
			}
			return null;
		}
		public ChampionshipSeasonLeague seasonForLeague(int aLeague) {
			for(int i = 0;i<leagues.Count;i++) {
				if(leagues[i].divisionNumber==aLeague) {
					return leagues[i];
				}
			}
			ChampionshipSeasonLeague newLeague = new ChampionshipSeasonLeague();
			newLeague.divisionNumber = aLeague;
			newLeague.initRaces();
			leagues.Add(newLeague);
			return newLeague;
		}

		public IEnumerator LoadLevel(string aLevelName) {
			AsyncOperation async = Application.LoadLevelAsync(aLevelName);
			yield return async;
			Debug.Log("Loading complete");

		}

		public static int SortByChampionshipPoints(GTDriver aDriver1,GTDriver aDriver2) {
			if(aDriver1.championshipPoints<aDriver2.championshipPoints) {
				return 1;
			} if(aDriver1.championshipPoints>aDriver2.championshipPoints) {
				return -1;
			} else if(aDriver1.lastRacePoints>aDriver2.lastRacePoints) {
				return -1;
			} else if(aDriver1.lastRacePoints<aDriver2.lastRacePoints) {
				return 1;
			} else {
				return 0;
			}
		}

	}
}

