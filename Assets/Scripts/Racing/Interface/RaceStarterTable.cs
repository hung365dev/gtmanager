using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using championship;
using Drivers;
using Teams;

public class RaceStarterTable : MonoBehaviour {
	
	// Use this for initialization
	public List<RaceStarterMember> starterMembers;
	public UILabel titleText;
	public int stage = 0;
	public List<GTDriver> starters;
	public List<GTTeam> teamPositions;
	public List<GTDriver> champStandings;

	public Color colorIfHumanDriver;
	public int startSetting = 0;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void onStartRace() {
		GameObject g = GameObject.Find ("RaceManager");
		if(g!=null) {
			RaceManager r = g.GetComponent<RaceManager>();
			r.doStartRace();

		}
	}
	public void activate(List<GTDriver> aStarters) {
		this.gameObject.SetActive(true);
		teamPositions = ChampionshipSeason.ACTIVE_SEASON.seasonForTeam(ChampionshipSeason.ACTIVE_SEASON.getUsersTeam()).sortedTeams;
		champStandings = ChampionshipSeason.ACTIVE_SEASON.seasonForTeam(ChampionshipSeason.ACTIVE_SEASON.getUsersTeam()).driversChampionshipPositions();
		
		starters = aStarters;
		int i = 0;
		for(i = 0;i<this.starters.Count;i++) {
			starterMembers[i].init(starters[i],i,false);
			starterMembers[i].gameObject.SetActive(true);
		}
		
		for(int j = i;j<starterMembers.Count;j++) {
			starterMembers[j].gameObject.SetActive(false);
		}
		for(i = starterMembers.Count-1;i>=0;i--) {
			TweenAlpha alph = TweenAlpha.Begin(starterMembers[i].gameObject,0.5f,1f);
			//starterMembers[i].doContinue(startSetting);
			alph.delay = i*0.1f;
		}
		StartCoroutine(rotateStartAlphas());
	}

	private IEnumerator rotateStartAlphas() {

		while(true) {
			yield return new WaitForSeconds(4f);
			int c = 0;
			for(int i = starterMembers.Count-1;i>=0;i--) {
				TweenAlpha alph = TweenAlpha.Begin(starterMembers[i].gameObject,0.5f,0f);
				alph.delay = c*0.1f;
				c++;
			}
			yield return new WaitForSeconds(2f);
			startSetting++;
			switch(startSetting) {
				case(0):this.titleText.text = "Grid Positions";
					int i = 0;
					for(i = 0;i<this.starters.Count;i++) {
						starterMembers[i].init(starters[i],i,false);
						starterMembers[i].gameObject.SetActive(true);
					}
					
					for(int j = i;j<starterMembers.Count;j++) {
						starterMembers[j].gameObject.SetActive(false);
					}

				break;
				case(1):
					this.titleText.text = "Constructors Championship";
					int k = 0;
					for(k = 0;k<this.teamPositions.Count;k++) {
						starterMembers[k].init(teamPositions[k],k,true);
						starterMembers[k].gameObject.SetActive(true);
					}
					
					for(int j = k;k<starterMembers.Count;k++) {
						starterMembers[k].gameObject.SetActive(false);
					}


				break;
			case(2):
					this.titleText.text = "Drivers Championship";
					int l = 0;
					for(l = 0;l<this.champStandings.Count;l++) {
						starterMembers[l].init(champStandings[l],l,true);
						starterMembers[l].gameObject.SetActive(true);
					}
					
					for(int j = l;l<starterMembers.Count;l++) {
						starterMembers[l].gameObject.SetActive(false);
					}


				break;
			}
			for(int i = starterMembers.Count-1;i>=0;i--) {
				TweenAlpha alph = TweenAlpha.Begin(starterMembers[i].gameObject,0.5f,1f);
				//starterMembers[i].doContinue(startSetting);
				alph.delay = i*0.1f;
			}

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
		case(0):titleText.text = "Grid Layout";break;
		case(1):titleText.text = "Drivers Championship";break;
		case(2):titleText.text = "Constructors Championship";break;
		} 
		if(stage==5) {
			ChampionshipSeason.ACTIVE_SEASON.secondsPast++;
			StartCoroutine(ChampionshipSeason.ACTIVE_SEASON.LoadLevel("Garage"));
			
		} else if(stage==4) {
			List<GTTeam> sortedTeams = ChampionshipSeason.ACTIVE_SEASON.seasonForTeam(ChampionshipSeason.ACTIVE_SEASON.getUsersTeam()).sortedTeams;
			int i = 0;
			for(i = 0;i<sortedTeams.Count;i++) {
				starterMembers[i].initTeam(sortedTeams[i]);
				starterMembers[i].gameObject.SetActive(true);
			}
			
			for(int c = i;c<starterMembers.Count;c++) {
				starterMembers[c].gameObject.SetActive(false);
			}
			
		} else
		if(stage==3) {
			List<GTDriver> drivers = ChampionshipSeason.ACTIVE_SEASON.nextRace.driversForRace();
			drivers.Sort(ChampionshipSeasonBase.SortByChampionshipPoints);
			for(int i = 0;i<starterMembers.Count;i++) {
				starterMembers[i].showChampionshipPoints(drivers[i]);
			}
		} else {
			for(int i = 0;i<starterMembers.Count;i++) {
				starterMembers[i].doContinue();
			}
		}
	}
}
