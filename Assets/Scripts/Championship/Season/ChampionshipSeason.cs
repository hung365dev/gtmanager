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
using PixelCrushers.DialogueSystem;
using Utils;


namespace championship
{
	public class ChampionshipSeason : ChampionshipSeasonWithRaces
	{

		public static ChampionshipSeason ACTIVE_SEASON;


		public void initNextRace() {

		}

		public void initFromDatabase(string aUsersTeamName) {
			ACTIVE_SEASON = this;
			List<TeamDataRecord> allTeams = Database.TeamDatabase.REF.teams;
			for(int i = 0;i<allTeams.Count;i++) {
				this.seasonForLeague(allTeams[i].startLeague).addTeam(new GTTeam(allTeams[i]));
			}
			this.season = 1;
			this.getUsersTeam().teamName = aUsersTeamName;
			DialogueLua.SetVariable("PlayersTeamName",aUsersTeamName);
			ChampionshipSeason.ACTIVE_SEASON = this;
			if(Application.loadedLevelName=="MainMenu") {
				StartCoroutine(this.LoadLevel("Garage"));
			}
		}

		public int racesRemainingInSeason {
			get {
				GTTeam humansTeam = this.getUsersTeam();
				ChampionshipSeasonLeague league = this.leagueForTeam(humansTeam);
				return league.racesRemainingInSeason;
			}
		}

		public void SaveGame() {
			string headline = this.getUsersTeam().teamName+" - Season: "+this.season;
			List<string> list = new List<string>();
			list.Add("");
			list.Add("");
			list.Add("");
			list.Add("");
			list.Add("");
			list.Add("");
			list[(int) ESavedGameSetup.Day] = ""+this.secondsPast;
			list[(int) ESavedGameSetup.GameData] = this.SaveString();
			list[(int) ESavedGameSetup.SavedGameHeadline] = headline;
			list[(int) ESavedGameSetup.SeasonsPast] = ""+this.season;
			list[(int) ESavedGameSetup.Lua] = PersistentDataManager.GetSaveData();
			SaveGameUtils.save(list);	
		}
  

	}
}

