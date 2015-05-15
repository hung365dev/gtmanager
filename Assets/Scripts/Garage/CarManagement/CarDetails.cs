using UnityEngine;
using System.Collections;
using Cars;
using Teams;
using championship;
using Garage;
using Database;

public class CarDetails : MonoBehaviour {

	public UILabel carTitle;
	public UILabel horsepowerValue;
	public UILabel horsepowerBoost;

	public UILabel torqueValue;
	public UILabel torqueBoost;


	public UILabel turboValue;
	public UILabel turboBoost;

	public UILabel nitroValue;
	public UILabel nitroBoost;

	public UILabel shiftspeedValue;
	public UILabel shiftspeedBoost;

	public UILabel downforceValue;
	public UILabel downforceBoost;

	public UILabel hasDRSValue;
	public UILabel carValue;

	
	public UILabel drivabilityValue;
	public UILabel drivabilityBoost;

	public UILabel gripValue;
	public UILabel gripBoost;
	public GTCar carRef;
	
	public GarageCameraController camController;
	public BuyCarsScreen otherCars;

	public BuyCarsScreen prefabBuyCars;

	public GameObject buttonsHolder;
	// Use this for initialization
	void Start () {
		if(carTitle==null)
			initLabels();
	}

	public void returnToMainMenu() {
		InterfaceMainButtons.REF.onCloseOtherScreen();
		if(otherCars!=null) {
			Destroy(otherCars.gameObject);
			Destroy(otherCars);
			otherCars = null;

		}
		Destroy(this.gameObject);
	}
	private void initLabels() {
		carTitle = this.transform.FindChild("CarTitle").GetComponent<UILabel>();
		horsepowerValue = this.transform.FindChild("HorsepowerValue").GetComponent<UILabel>();
		horsepowerBoost = this.transform.FindChild("HorsepowerBoost").GetComponent<UILabel>();
		torqueValue = this.transform.FindChild("TorqueValue").GetComponent<UILabel>();
		torqueBoost = this.transform.FindChild("TorqueBoost").GetComponent<UILabel>();
		nitroValue = this.transform.FindChild("NitroCapacityValue").GetComponent<UILabel>();
		nitroBoost = this.transform.FindChild("NitroCapacityBoost").GetComponent<UILabel>();
		shiftspeedValue = this.transform.FindChild("ShiftSpeedValue").GetComponent<UILabel>();
		shiftspeedBoost = this.transform.FindChild("ShiftSpeedBoost").GetComponent<UILabel>();
		downforceValue = this.transform.FindChild("DownforceValue").GetComponent<UILabel>();
		downforceBoost = this.transform.FindChild("DownforceBoost").GetComponent<UILabel>();
		hasDRSValue = this.transform.FindChild("HasDRSValue").GetComponent<UILabel>();
		carValue = this.transform.FindChild("CarValueValue").GetComponent<UILabel>();

		
		turboValue = this.transform.FindChild("TurboValue").GetComponent<UILabel>();
		turboBoost = this.transform.FindChild("TurboBoost").GetComponent<UILabel>();

		gripValue = this.transform.FindChild("GripValue").GetComponent<UILabel>();
		drivabilityValue = this.transform.FindChild("DrivabilityValue").GetComponent<UILabel>();
	}

	public void reInit(GTCar aLastCar) {
		buttonsHolder.gameObject.SetActive(true);
		this.initCar(aLastCar);
	}
	public void disableButtons() {

		GameObject g = this.gameObject.transform.FindChild("MoreButtons").gameObject;
		if(g!=null) {
			Destroy(g);
		}
	
	}
	
	public void alignToLeft() {


		GameObject go = this.transform.FindChild("FadedCarBG").gameObject;
		UISprite spr = go.GetComponent<UISprite>();
		if(spr!=null) {
		 
			go = this.transform.parent.gameObject;
			 
			if(go!=null) {
				Debug.Log ("Game Object is: "+go);
				Transform t = go.transform;
			//	pan.leftAnchor.target = t;
				spr.leftAnchor.relative = 0;
				//pan.rightAnchor.target = t;
				spr.rightAnchor.relative = 0.35f;
					//pan.topAnchor.target = t;
				spr.topAnchor.relative = 0.84f;
				spr.topAnchor.absolute = 0;

					
				spr.bottomAnchor.target = t;
				spr.bottomAnchor.relative = 0;
				spr.bottomAnchor.absolute = 0;
				spr.ResetAndUpdateAnchors();
			}
		}
	}
	public void hideButtons() {
		buttonsHolder = this.gameObject.transform.FindChild("MoreButtons").gameObject;
		buttonsHolder.gameObject.SetActive(false);
	}
	public void gotoOtherCar() {
		GTTeam team = ChampionshipSeason.ACTIVE_SEASON.getUsersTeam();
		camController = GameObject.Find("Main Camera").GetComponent<GarageCameraController>();
		
		if(team.cars[0]==carRef) {
			this.initCar(team.cars[1]);
			
		} else {
			this.initCar(team.cars[0]);
		}

	}

	public void showOtherCars() {
		if(otherCars!=null) {
			Destroy(otherCars.gameObject);
		}






		GameObject go = NGUITools.AddChild(this.gameObject.transform.parent.gameObject,prefabBuyCars.gameObject);







		Debug.Log (go.name);

		otherCars = go.GetComponent<BuyCarsScreen>();
		if(otherCars!=null)
			otherCars.init(this,this.carRef);
		hideButtons();
	}


	public void showCar(CarLibraryRecord aRecord) {		
		if(carTitle==null) {
			initLabels();
		}

		this.carTitle.text = ""+aRecord.name;
		horsepowerValue.text = ""+aRecord.carHP;
		torqueValue.text = ""+aRecord.carTorque;
		this.turboValue.text = "0";
		nitroValue.text = ""+aRecord.maxNitro;
		shiftspeedValue.text = ""+aRecord.carShiftSpeed;
		downforceValue.text = ""+aRecord.carAero;
		drivabilityValue.text = ""+aRecord.carDrivabilityEffect;
		gripValue.text = ""+aRecord.carTireWearEffect;
		 
	}
	public void initCar(GTCar aCar) {
		if(carTitle==null) {
			initLabels();
		} 
		
		GTTeam team = ChampionshipSeason.ACTIVE_SEASON.getUsersTeam();
		camController = GameObject.Find("Main Camera").GetComponent<GarageCameraController>();
		carRef = aCar;
		this.showCar(aCar.carLibRecord);
		
		if(aCar.hasDRS) {
			hasDRSValue.text = "YES";
		} else {
			hasDRSValue.text = "NO";
		}

		if(team.cars[0]==carRef) {
			camController.lookAtThis = GameObject.Find ("GarageLeftSide");
			
		} else {
			camController.lookAtThis = GameObject.Find ("GarageRightSide");
		}


	}
	// Update is called once per frame
	void Update () {
	
	}
}
