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
using Database;
using System.Collections.Generic;
using Teams;
using UnityEngine;


namespace championship
{
	public class ChampionshipSeason : ChampionshipSeasonWithRaces
	{

		public static ChampionshipSeason ACTIVE_SEASON;


		public void initFromDatabase() {
			ACTIVE_SEASON = this;
			List<TeamDataRecord> allTeams = Database.TeamDatabase.REF.teams;
			for(int i = 0;i<allTeams.Count;i++) {
				this.seasonForLeague(allTeams[i].startLeague).addTeam(new GTTeam(allTeams[i]));
			}
			if(Application.loadedLevelName=="InitGame") {
				StartCoroutine(this.LoadLevel("Garage"));
			}
		}


	}
}

