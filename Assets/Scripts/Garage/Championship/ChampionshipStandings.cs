using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using championship;
using Drivers;
using Teams;

public class ChampionshipStandings : MonoBehaviour {
	
	// Use this for initialization
	public List<RaceStarterMember> starterMembers;
	public UILabel titleText;
	public int stage = 0;
	public List<GTTeam> teamPositions;
	public List<GTDriver> champStandings;
	
	public Color colorIfHumanDriver;
	public Color colorForWinner;
	public Color colorForRelegated;
	public Color colorRegular;
	
	public bool isComplete = false;
	public int startSetting = 0;

	public UIButton nextSeasonButton;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void activate(bool aIsFinished) {
		isComplete = aIsFinished;
		activate();
	}

	public void activate() {
		this.gameObject.SetActive(true);
		teamPositions = ChampionshipSeason.ACTIVE_SEASON.seasonForTeam(ChampionshipSeason.ACTIVE_SEASON.getUsersTeam()).sortedTeams;
		champStandings = ChampionshipSeason.ACTIVE_SEASON.seasonForTeam(ChampionshipSeason.ACTIVE_SEASON.getUsersTeam()).driversChampionshipPositions();
		stage = -1;
		if(isComplete) {
			GameObject g = GameObject.Find ("ExitToMenuBtn");
			if(g!=null)
			g.gameObject.SetActive(false);
		}
		this.doContinue();
		
	}
	
	private int finishPositionSort(RacingAI a1,RacingAI a2) {
		if(a1.finishPosition<a2.finishPosition) {
			return -1;
		} else if(a1.finishPosition>a2.finishPosition) {
			return 1;
		} else if(a1==a2) {
			return 0;
		}
		return 0;
	}
	public void onNextSeason() {
		ChampionshipSeason.ACTIVE_SEASON.handleRelegationsAndPromotions();
		this.gameObject.SetActive(false);
		GarageManager.REF.gameObject.SetActive(true);
		InterfaceMainButtons.REF.onCloseOtherScreen();
	}
	public void doContinue() {
		stage++;
		if(stage>1) {
			stage = 0;
		}
		switch(stage) {
		case(0):titleText.text = "Drivers Championship";nextSeasonButton.gameObject.SetActive(false);break;
		case(1):titleText.text = "Constructors Championship";if(this.isComplete) nextSeasonButton.gameObject.SetActive(true);break;
		} 
		if(stage==1) {
			List<GTTeam> sortedTeams = ChampionshipSeason.ACTIVE_SEASON.seasonForTeam(ChampionshipSeason.ACTIVE_SEASON.getUsersTeam()).sortedTeams;
			int i = 0;
			for(i = 0;i<sortedTeams.Count;i++) {
				starterMembers[i].initTeam(sortedTeams[i]);
				if(this.isComplete&&i==0) {
					starterMembers[i].GetComponent<UISprite>().color = this.colorForWinner;
				} else if(this.isComplete&&i==sortedTeams.Count-1) {
					starterMembers[i].GetComponent<UISprite>().color = this.colorForRelegated;
				}
					
				starterMembers[i].gameObject.SetActive(true);
			}
			
			for(int c = i;c<starterMembers.Count;c++) {
				starterMembers[c].gameObject.SetActive(false);
			}
			
		} else
		if(stage==0) {
			List<GTDriver> drivers = ChampionshipSeason.ACTIVE_SEASON.seasonForTeam(ChampionshipSeason.ACTIVE_SEASON.getUsersTeam()).driversChampionshipPositions();
			//drivers.Sort(ChampionshipSeasonBase.SortByChampionshipPoints);
			for(int i = 0;i<starterMembers.Count;i++) {
				starterMembers[i].showChampionshipPoints(drivers[i]);
				if(this.isComplete&&i==0) {	
					starterMembers[i].GetComponent<UISprite>().color = this.colorForWinner;
				} else {
					starterMembers[i].GetComponent<UISprite>().color = this.colorRegular;
				}
				starterMembers[i].gameObject.SetActive(true);
			}
		}
	}
}
