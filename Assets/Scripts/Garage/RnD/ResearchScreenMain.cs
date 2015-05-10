using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Cars;
using championship;
using Teams;

public class ResearchScreenMain : MonoBehaviour {

	public Color defaultColour;
	public Color hoverColour;
	public Color downColour;
	public Color unavailableColour;
	public Color unlockedColour;
	public Color selectedColour;
	public GarageCameraController camController;
	public IndividualPieceOfResearch individualResearch;
	public UILabel researchBoxTitle;
	public GameObject blackFadeForIndividualResearch;
	public List<ResearchItem> researchItems = new List<ResearchItem>();

	public GTCar carRef;
	// Use this for initialization
	void Start () {
		if(researchBoxTitle==null) {
			researchBoxTitle = GameObject.Find("ResearchBoxTitle").GetComponent<UILabel>();
		}
		ResearchItem[] kids = this.GetComponentsInChildren<ResearchItem>();
		for(int i = 0;i<kids.Length;i++) {
			researchItems.Add(kids[i]);
		}
		camController = GameObject.Find("Main Camera").GetComponent<GarageCameraController>();

		StartCoroutine(delayToInit());

	}
	public void switchCar() {
		carRef = ChampionshipSeason.ACTIVE_SEASON.getUsersTeam().otherCar(carRef);
		initFromCar(carRef);
	}
	public void initFromCar(GTCar aCar) {
		camController = GameObject.Find("Main Camera").GetComponent<GarageCameraController>();
		carRef = aCar;
		GTTeam team = ChampionshipSeason.ACTIVE_SEASON.getUsersTeam();
		this.researchBoxTitle.text = aCar.carLibRecord.name+" - "+team.getDriverFromCar(carRef).driverName;

		if(team.cars[0]==aCar) {
			camController.lookAtThis = GameObject.Find ("GarageLeftSide");
		} else {
			camController.lookAtThis = GameObject.Find ("GarageRightSide");
		}
		StartCoroutine(delayToInit());
	}
	private IEnumerator delayToInit() {
		yield return new WaitForEndOfFrame();
		
		selectKid(null);
	}

	public void closeInidividualResearchScreen() {
		individualResearch.gameObject.SetActive(false);
		blackFadeForIndividualResearch.gameObject.SetActive(false);
		InterfaceMainButtons.REF.destroyCarDetailsScreen();
	}
	public void notifyOfIndividualResearchScreen(IndividualPieceOfResearch aResearch) {
		aResearch.gameObject.SetActive(false);
		individualResearch = aResearch;
		blackFadeForIndividualResearch.gameObject.SetActive(false);
	}
	public void deselectAllKids() {
		for(int i = 0;i<researchItems.Count;i++) {
			researchItems[i].deselect();
		}
	}

	public void selectKid(ResearchItem aItem) {
		deselectAllKids();
		if(aItem!=null) {
			aItem.select();
			blackFadeForIndividualResearch.gameObject.SetActive(true);
			individualResearch.initResearch(aItem.researchRow,this.carRef);
			
			InterfaceMainButtons.REF.createCarDetailsScreen(this.gameObject,this.carRef,false);
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
