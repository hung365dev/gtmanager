using UnityEngine;
using System.Collections;
using championship;
using System;
using Teams;

public class CalendarManager : MonoBehaviour {

	public CalendarItem[] calendarItems;
	// Use this for initialization
	void Start () {
	
	}


	void OnEnable() {
		updateDay();
		GTTeam team = ChampionshipSeason.ACTIVE_SEASON.getUsersTeam();
		team.initEmptySponsorVars();
		if(ChampionshipSeason.ACTIVE_SEASON.nextRace==null)
			GarageManager.REF.doConversation("CalendarConversation"); else
		if(ChampionshipSeason.ACTIVE_SEASON.nextRace!=null&&ChampionshipSeason.ACTIVE_SEASON.nextRace.startDate==ChampionshipSeason.ACTIVE_SEASON.secondsPast&&ChampionshipSeason.ACTIVE_SEASON.nextRace.startDate>0) {
} else
		GarageManager.REF.doConversation("CalendarConversation");
	}


	public void onReturnToMainMenu() {
		ChampionshipSeason.ACTIVE_SEASON.allowTimeToPass = false;
		GameObject g = GameObject.Find("GarageManager");
		if(g!=null) {
			GarageManager gm = g.GetComponent<GarageManager>();
			gm.handleEndOfCalendarView();
		}
	}
	public void updateDay() {
		GameObject g = GameObject.Find("ContinueButton");
		if(g!=null) {
			g.gameObject.SetActive(false);
		}
		if(ChampionshipSeason.ACTIVE_SEASON!=null) {
			double secondsPast = Convert.ToDouble(ChampionshipSeason.ACTIVE_SEASON.secondsPast);
			
			int w = Convert.ToInt32(Math.Floor(secondsPast/7.0));
			int d = ChampionshipSeason.ACTIVE_SEASON.secondsPast%7;
			for(int i = 0;i<calendarItems.Length;i++) {
				calendarItems[i].setToDayOfYear(w*7+(i));
			}
		}
	}
	void Update () {
	
	}
}
