using UnityEngine;
using System.Collections;
using Teams;
using championship;

public class GarageManager : MonoBehaviour {


	public UILabel teamName;
	public UILabel leagueName;
	public UILabel teamCash;
	public UILabel leaguePosition;
	public UILabel currentDate;
	public UILabel nextRaceDate;
	public static GarageManager REF;

	public GameObject interfacePanel;
	public GameObject mainButtons;
	public CalendarManager calendarManager;
	// Use this for initialization
	void Start () {
		UpdateDisplay();
		REF = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	public void handleStartOfCalendarView() {
		ChampionshipSeason.ACTIVE_SEASON.allowTimeToPass = true;
		calendarManager.gameObject.SetActive(true);
		mainButtons.gameObject.SetActive(false);
	}
	public void handleEndOfCalendarView() {
		calendarManager.gameObject.SetActive(false);
		mainButtons.gameObject.SetActive(true);
	}
	public void UpdateDisplay() {
		if(ChampionshipSeason.ACTIVE_SEASON==null) {
			Application.LoadLevel("InitGame");
			return;
		}
		if(GameObject.Find("TopInfoPanel")!=null)	
			interfacePanel = GameObject.Find ("TopInfoPanel");
		GTTeam team = ChampionshipSeason.ACTIVE_SEASON.getUsersTeam();
		ChampionshipSeasonLeague league = ChampionshipSeason.ACTIVE_SEASON.seasonForTeam(team);
		this.teamName.text = team.teamName;
		this.teamCash.text = "$"+team.cash;
		this.leagueName.text = league.leagueName;
		int currentPosition = league.positionForTeamInChampionship(team);
		switch(currentPosition) {
			default:this.leaguePosition.text = currentPosition+"th";break;
			case(0):this.leaguePosition.text = "1st";break;
			case(1):this.leaguePosition.text = "2nd";break;
			case(2):this.leaguePosition.text = "3rd";break;

		}
		;
		this.currentDate.text = "Current Date: "+ChampionshipSeason.ACTIVE_SEASON.dateString(ChampionshipSeason.ACTIVE_SEASON.secondsPast);
		this.nextRaceDate.text = "Next Race: "+ChampionshipSeason.ACTIVE_SEASON.dateString(ChampionshipSeason.ACTIVE_SEASON.nextRace.startDate);
		MeshRenderer[] ms = this.GetComponentsInChildren<MeshRenderer>();
		for(int i =0;i<ms.Length;i++) {
			for(int j = 0;j<ms[i].materials.Length;j++) {
				if(ms[i].materials[j].shader.name=="RedDotGames/Mobile/Scrolled Environment/Car Paint Medium Detail")
					ms[i].materials[j].SetColor("_Color",team.teamColor);
			}

		}
	}
}
