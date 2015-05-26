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
using Database;
using System.Collections.Generic;
using Drivers;
using UnityEngine;


namespace championship
{
	[System.Serializable]
	public class ChampionshipRaceSettings
	{
		public int prizeFund = 0;
		public EPrizeDistrbution prizeDistrbutionSetting;
		public EPointsDistribution driversPointsDistribution;
		public EPointsDistribution constructorsPointsDistribution;
		public EGridSetup gridSetup = EGridSetup.ReverseGrid;
		public List<GTTeam> teamsInRace = new List<GTTeam>();
		public static ChampionshipRaceSettings ACTIVE_RACE;
		public bool isCompleted = false;
		
		public TrackDatabaseRecord track;
		public int startDate;
		public ChampionshipRaceSettings ()
		{
		}

	
		public void setupDefaultsForLeague(int aLeague,int aRaceInCalendar) {
			prizeDistrbutionSetting = EPrizeDistrbution.Standard;
			track = TrackDatabase.REF.recordFromName("OvalTrack");
			switch(aRaceInCalendar) {
			case(2):track = TrackDatabase.REF.recordFromName("ShortSnowTrack");break;
			case(6):track = TrackDatabase.REF.recordFromName("LongStraights");break;
			case(4):track = TrackDatabase.REF.recordFromName("RaceCircuit1");break;
			case(3):track = TrackDatabase.REF.recordFromName("OvalTrack");break;
			case(7):track = TrackDatabase.REF.recordFromName("LowerLevel1");break;
			case(0):track = TrackDatabase.REF.recordFromName("MiniOval");break;
			case(5):track = TrackDatabase.REF.recordFromName("HillTrack1");break;
			case(1):track = TrackDatabase.REF.recordFromName("DirtGrassTrack");break;
			} 
			prizeFund = 50000*(5-aLeague);
			driversPointsDistribution = EPointsDistribution.F12010Style;
			constructorsPointsDistribution = EPointsDistribution.F12010Style;
			startDate = (aRaceInCalendar+1)*(7+ChampionshipSeason.ACTIVE_SEASON.secondsPast)-1;
		} 

		public List<GTDriver> driversForRace() {  
			//TODO So far no grid setup is acknowledged.
			List<GTDriver> ret = new List<GTDriver>();
			for(int i = 0;i<teamsInRace.Count;i++) {
				ret.Add(teamsInRace[i].drivers[0]); 
				ret.Add(teamsInRace[i].drivers[1]); 
			}
			switch(this.gridSetup) {
				case(EGridSetup.ReverseGrid):default:
					ret.Sort(SortListByReverse);
				break;
			}
			return ret;
		}


		private static int SortListByReverse(GTDriver a1, GTDriver a2)
		{
			if(a1==a2) {
				return 0;
			}
			if(a1.championshipPoints>a2.championshipPoints) {
				return 1;
			} else if(a1.championshipPoints<a2.championshipPoints) {
				return -1;
			} else {
				if(UnityEngine.Random.Range(0,100)<50) {
					return -1;
				} else {
					return 1;
				}
			}
		}

		public int pointsForDriverPosition(int aPosition) {
			switch(driversPointsDistribution) {
				default:case(EPointsDistribution.F12010Style):
					int[] allPrizes = new int[8];
					allPrizes[0] = 10;
					allPrizes[1] = 8;
					allPrizes[2] = 6;
					allPrizes[3] = 5;
					allPrizes[4] = 4;
					allPrizes[5] = 3;
					allPrizes[6] = 2;
					allPrizes[7] = 1;
					if(aPosition>allPrizes.Length) {
						return 0;
					} else {
						return allPrizes[aPosition-1];
					}
			}
		}
		public int prizeForPosition(int aPosition,int aTotalPrizes) {
			float[] allPrizes = new float[aTotalPrizes+1]; 
			int lastPrize = prizeFund/100;
			int firstPrize = 2 * prizeFund/aTotalPrizes+lastPrize;
			float ratio = (firstPrize-lastPrize)/(aTotalPrizes-1);
			allPrizes[aTotalPrizes] = lastPrize;
			for(int i = aTotalPrizes-1;i>=1;i--) {
				allPrizes[i] = allPrizes[i+1]+ratio;
			}
			if(aPosition>=allPrizes.Length) {
				Debug.LogError("Trying to get a prize for position: "+aPosition);
				return 0;
			}
			return Convert.ToInt32(allPrizes[aPosition]);
		}


	}
}

 