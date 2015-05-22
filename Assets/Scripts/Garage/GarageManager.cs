using UnityEngine;
using System.Collections;
using Teams;
using championship;
using PixelCrushers.DialogueSystem;

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
	public ConversationTrigger trigger;

	// Use this for initialization
	void Start () {
		REF = this;
		trigger = this.GetComponent<ConversationTrigger>();
		UpdateDisplay();
//		trigger.TryStartConversation(this.gameObject.transform);
		
		trigger = this.GetComponent<ConversationTrigger>();
		trigger.conversation = "Welcome Conversation";
		trigger.TryStartConversation(this.transform);
	}
	
	// Update is called once per frame
	void Update () {
		if(teamCash!=null) {
			if(ChampionshipSeason.ACTIVE_SEASON==null) {
				Application.LoadLevel("InitGame");
				return;
			}
			GTTeam team = ChampionshipSeason.ACTIVE_SEASON.getUsersTeam();
			this.teamCash.text = "$"+team.cash;
		}
	}
	public void Awake() {
		
		trigger = this.GetComponent<ConversationTrigger>();
		trigger.conversation = "Welcome Conversation";
		if(ChampionshipSeason.ACTIVE_SEASON!=null)
			trigger.OnUse();
		
	}
	public void onConversationEnded() {
		Lua.Result r = DialogueLua.GetVariable("OnCloseAction");
		
		DialogueLua.SetVariable("OnCloseAction","");
		if(r.AsString=="Garage") {
		//	handleEndOfCalendarView();
		//	InterfaceMainButtons.REF.onCloseOtherScreen();

		} else if(r.AsString=="Calendar")  {
			handleStartOfCalendarView();
		}
	}
	public void doConversation(string aConversationName) {
		
		trigger = this.GetComponent<ConversationTrigger>();
		trigger.conversation = aConversationName;
		trigger.OnUse();
	}
	public void OnDestroy() { 
		REF = null;
	}
	public void hideTopButtons() {
		if(interfacePanel!=null)
		interfacePanel.gameObject.SetActive(false);
	}
	public void showTopButtons() {
		if(interfacePanel!=null)
		interfacePanel.gameObject.SetActive(true);
		
		trigger = this.GetComponent<ConversationTrigger>();
		trigger.conversation = "Welcome Conversation";
		trigger.OnUse();

	}

	public void handleStartOfCalendarView() {
		ChampionshipSeason.ACTIVE_SEASON.allowTimeToPass = true;
		calendarManager.gameObject.SetActive(true);
		mainButtons.gameObject.SetActive(false);
	}
	public void handleEndOfCalendarView() {
		ChampionshipSeason.ACTIVE_SEASON.allowTimeToPass = false;
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
		if(ChampionshipSeason.ACTIVE_SEASON.nextRace!=null)
			this.nextRaceDate.text = "Next Race: "+ChampionshipSeason.ACTIVE_SEASON.dateString(ChampionshipSeason.ACTIVE_SEASON.nextRace.startDate);
		MeshRenderer[] ms = this.GetComponentsInChildren<MeshRenderer>();
		for(int i =0;i<ms.Length;i++) {
			for(int j = 0;j<ms[i].materials.Length;j++) {
				if(ms[i].materials[j].shader.name=="RedDotGames/Mobile/Scrolled Environment/Car Paint Medium Detail")
					ms[i].materials[j].SetColor("_Color",team.teamColor);
			}

		}
		if(ChampionshipSeason.ACTIVE_SEASON.seasonComplete) {
			
			Debug.Log ("The season is now complete! Show the championship end screen and promote / relegate!");
			GameObject mbp = GameObject.Find("MainButtonsPanel");
			if(mbp!=null) {
				InterfaceMainButtons imb = mbp.GetComponent<InterfaceMainButtons>();
				imb.onLaunchChampionshipCompleteScreens();
			} else {
				InterfaceMainButtons.REF.onLaunchChampionshipScreens();
			}
			this.handleEndOfCalendarView();
			ChampionshipSeason.ACTIVE_SEASON.allowTimeToPass = false;
		}	

	}
}
