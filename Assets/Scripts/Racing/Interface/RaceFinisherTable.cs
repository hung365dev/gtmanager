using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using championship;
using Drivers;
using Teams;
using PixelCrushers.DialogueSystem;

public class RaceFinisherTable : MonoBehaviour {

	// Use this for initialization
	public List<RaceCompleteMember> completeMembers;
	public UILabel titleText;
	public int stage = 0;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void activate(BetterList<RacingAI> aFinishers) {
		this.gameObject.SetActive(true);
		aFinishers.Sort(finishPositionSort);
		int i = 0;
		for(i = 0;i<aFinishers.size;i++) {
			completeMembers[i].init(aFinishers[i],i);
			completeMembers[i].gameObject.SetActive(true);
		}

		for(int c = i;c<completeMembers.Count;c++) {
			completeMembers[i].gameObject.SetActive(false);
		}
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
	public void doContinue() {
		stage++;
		switch(stage) {
			case(1):titleText.text = "Prize Money";break;
			case(2):titleText.text = "Points for Race";break;
			case(3):titleText.text = "Drivers Championship";break;
			case(4):titleText.text = "Constructors Championship";break;
		} 
		if(stage==5) {
			ChampionshipSeason.ACTIVE_SEASON.secondsPast++;
			Lua.Result r = DialogueLua.GetVariable("TotalRacesComplete");
			DialogueLua.SetVariable("TotalRacesComplete",r.AsInt + 1);
			StartCoroutine(ChampionshipSeason.ACTIVE_SEASON.LoadLevel("Garage"));

		} else if(stage==4) {
			List<GTTeam> sortedTeams = ChampionshipSeason.ACTIVE_SEASON.seasonForTeam(ChampionshipSeason.ACTIVE_SEASON.getUsersTeam()).sortedTeams;
			int i = 0;
			for(i = 0;i<sortedTeams.Count;i++) {
				completeMembers[i].initTeam(sortedTeams[i]);
				completeMembers[i].gameObject.SetActive(true);
			}
			
			for(int c = i;c<completeMembers.Count;c++) {
				completeMembers[c].gameObject.SetActive(false);
			}
			
		} else
		if(stage==3) {
			List<GTDriver> drivers = ChampionshipSeason.ACTIVE_SEASON.nextRace.driversForRace();
			drivers.Sort(ChampionshipSeasonBase.SortByChampionshipPoints);
			for(int i = 0;i<completeMembers.Count;i++) {
				completeMembers[i].showChampionshipPoints(drivers[i]);
			}
		} else {
			for(int i = 0;i<completeMembers.Count;i++) {
				completeMembers[i].doContinue();
			}
		}
	}
}
