using UnityEngine;
using System.Collections;
using Cars;
using Teams;
using championship;
using Garage;
using Database;
using Drivers;

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

	public UILabel dragValue;
	public UILabel dragBoost;

	public UILabel hasDRSValue;
	public UILabel carValue;

	
	public UILabel maxSpeedValue;
	public UILabel maxSpeedBoost;

	public UILabel gripValue;
	public UILabel gripBoost;
	public GTCar carRef;
	
	public GarageCameraController camController;
	public BuyCarsScreen otherCars;

	public BuyCarsScreen prefabBuyCars;

	public GameObject buttonsHolder;

	// Use this for initialization
	void Start () {
		GarageManager.REF.doConversation("TutorialCarDetails");
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
		this.dragValue = this.transform.FindChild("DragValue").GetComponent<UILabel>();
		this.dragBoost = this.transform.FindChild("DragBoost").GetComponent<UILabel>();
		hasDRSValue = this.transform.FindChild("HasDRSValue").GetComponent<UILabel>();
		
		turboValue = this.transform.FindChild("TurboValue").GetComponent<UILabel>();
		turboBoost = this.transform.FindChild("TurboBoost").GetComponent<UILabel>();

		gripValue = this.transform.FindChild("GripValue").GetComponent<UILabel>();
		maxSpeedValue = this.transform.FindChild("MaxSpeedValue").GetComponent<UILabel>();
		maxSpeedBoost = this.transform.FindChild("MaxSpeedBoost").GetComponent<UILabel>();
		this.gripBoost = this.transform.FindChild("GripBoost").GetComponent<UILabel>();
		carValue = this.transform.FindChild("CarValueValue").GetComponent<UILabel>();
	}

	public void reInit(GTCar aLastCar) {
		buttonsHolder.gameObject.SetActive(true);
		this.initCar(aLastCar);
	}

	public void showEffectOfResearch(ResearchItem aResearch) {
		if(aResearch.researchRow._effectonhp>0f) {
			this.horsepowerBoost.color = Color.green;
			this.horsepowerBoost.text = "+"+aResearch.researchRow._effectonhp;
			this.horsepowerBoost.gameObject.SetActive(true);
		}
		if(aResearch.researchRow._effectontorque>0f) {
			this.torqueBoost.color = Color.green;
			this.torqueBoost.text = "+"+aResearch.researchRow._effectontorque;
			this.torqueBoost.gameObject.SetActive(true);
		}
		if(aResearch.researchRow._effectonturbopsi>0f) {
			this.turboBoost.color = Color.green;
			this.turboBoost.text = "+"+aResearch.researchRow._effectonturbopsi;
			this.turboBoost.gameObject.SetActive(true);
		}
		if(aResearch.researchRow._effectonnitrocapacity>0f) {
			this.nitroBoost.color = Color.green;
			this.nitroBoost.text = "+"+aResearch.researchRow._effectonnitrocapacity;
			this.nitroBoost.gameObject.SetActive(true);
		}
		
		if(aResearch.researchRow._effectonshiftspeed<0f) {
			this.shiftspeedBoost.color = Color.green;
			this.shiftspeedBoost.text = "+"+aResearch.researchRow._effectonshiftspeed;
			this.shiftspeedBoost.gameObject.SetActive(true);
		}
		if(aResearch.researchRow._bodyaerodragreduce<0f) {
			this.dragBoost.color = Color.green;
			this.dragBoost.text = "+"+aResearch.researchRow._bodyaerodragreduce;
			this.dragBoost.gameObject.SetActive(true);
		}
		if(aResearch.researchRow._percentofdrswingtoremove>0f) {
			this.hasDRSValue.color = Color.green;
			this.hasDRSValue.text = "+ 1 Level";
			this.hasDRSValue.gameObject.SetActive(true);
		}
		if(aResearch.researchRow._maxspeedadd>0f) {
			this.maxSpeedBoost.color = Color.green;
			this.maxSpeedBoost.text = "+"+aResearch.researchRow._maxspeedadd;
			this.maxSpeedBoost.gameObject.SetActive(true);
		}
		
	}
	public void disableButtons() {

		GameObject g = this.gameObject.transform.FindChild("MoreButtons").gameObject;
		if(g!=null) {
			Destroy(g);
		}
	
	}
	public void colorLabel(UILabel aLabel,string aValue,Color aColor) {
		aLabel.text = aValue;
		aLabel.color = aColor;
	}
	public void compareCarTo(CarLibraryRecord aNewCar,GTCar aCurrentCar,Color aColorIfBetter,Color aColorIfWorse) {
		Color colorToUse = Color.black;
		
		float diff = aNewCar.carHP - aCurrentCar.carHP;
		if(aNewCar.carHP>aCurrentCar.carHP) {
			colorLabel(this.horsepowerBoost,"+"+diff,aColorIfBetter);
		} else {
			colorLabel(this.horsepowerBoost,""+diff,aColorIfWorse);
		}

		diff = aNewCar.carTorque - aCurrentCar.carTorque;
		if(aNewCar.carTorque>aCurrentCar.carTorque) {
			colorLabel(this.torqueBoost,"+"+diff,aColorIfBetter);
		} else {
			colorLabel(this.torqueBoost,""+diff,aColorIfWorse);
		}
		if(aNewCar.turboPSI>aCurrentCar.getResearchEffectOnTurboPSI()+aNewCar.turboPSI) {
			colorLabel(this.turboBoost,"",aColorIfBetter);
		} else {
			colorLabel(this.turboBoost,"",aColorIfWorse);
		}
		
		diff = aNewCar.maxNitro - aCurrentCar.nitroCapacity;
		if(aNewCar.maxNitro>aCurrentCar.carLibRecord.maxNitro) {
			colorLabel(this.nitroBoost,"+"+diff,aColorIfBetter);
		} else {
			colorLabel(this.nitroBoost,""+diff,aColorIfWorse);
		}
		
		diff = aCurrentCar.shiftSpeed-aNewCar.carShiftSpeed;
		if(aNewCar.carShiftSpeed<aCurrentCar.carLibRecord.carShiftSpeed) {
			colorLabel(this.shiftspeedBoost,""+diff,aColorIfBetter);
		} else {
			colorLabel(this.shiftspeedBoost,"+"+diff,aColorIfWorse);
		}

		
		diff = aCurrentCar.carDrag-aNewCar.carDrag;
		if(aNewCar.carDrag<aCurrentCar.carLibRecord.carDrag) {
			colorLabel(this.dragBoost,"+",aColorIfBetter);
		} else {
			colorLabel(this.dragBoost,"-",aColorIfWorse);
		}

		
		diff = aNewCar.carMaxSpeed-aCurrentCar.carMaxSpeed;

		if(aNewCar.carMaxSpeed>aCurrentCar.carLibRecord.carMaxSpeed) {
			colorLabel(this.maxSpeedBoost,"+"+diff,aColorIfBetter);
		} else {
			colorLabel(this.maxSpeedBoost,""+diff,aColorIfWorse);
		} 
		int cost = aNewCar.carCost-aCurrentCar.carValue;
		this.carValue.text = cost.ToString("C0");
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

	public void showCar(GTCar aRecord) {		
		if(carTitle==null) {
			initLabels();
		}
		
		horsepowerValue.text = ""+aRecord.carHP;
		torqueValue.text = ""+aRecord.carTorque;
		this.turboValue.text = "0";
		nitroValue.text = ""+aRecord.nitroCapacity;
		shiftspeedValue.text = ""+aRecord.shiftSpeed+"s";
		this.dragValue.text = ""+aRecord.carDragString+" ("+aRecord.carDrag+")";
		this.maxSpeedValue.text = ""+aRecord.carMaxSpeed+"MPH";
		this.hasDRSValue.text = "Level "+aRecord.hasDRS;
		gripValue.text = ""+aRecord.grip();
		
		this.carValue.text = ""+aRecord.carValue.ToString("C0");
		GTTeam team = ChampionshipSeason.ACTIVE_SEASON.getUsersTeam();
		GTDriver driver = team.getDriverFromCar(this.carRef);
		if(driver!=null) {
			this.carTitle.text = driver.name+"'s "+aRecord.carLibRecord.name;
		}
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
		this.dragValue.text = ""+aRecord.carDragString+" ("+aRecord.carDrag+")";
		this.maxSpeedValue.text = ""+aRecord.carMaxSpeed+"MPH";
		gripValue.text = ""+aRecord.carTireWearEffect;
		this.hasDRSValue.text = "Level 0";
		
		this.carValue.text = ""+aRecord.carCost.ToString("C0");
		GTTeam team = ChampionshipSeason.ACTIVE_SEASON.getUsersTeam();
		GTDriver driver = team.getDriverFromCar(this.carRef);
		if(driver!=null) {
			this.carTitle.text = driver.name+"'s "+aRecord.name;
		}
	}
	public void initCar(GTCar aCar) {
		if(carTitle==null) {  
			initLabels();
		} 
		
		GTTeam team = ChampionshipSeason.ACTIVE_SEASON.getUsersTeam();
		camController = GameObject.Find("Main Camera").GetComponent<GarageCameraController>();
		carRef = aCar;
		this.showCar(aCar);
		
		this.showCarImprovements();

		if(team.cars[0]==carRef) {
			camController.lookAtThis = GameObject.Find ("GarageLeftSide");
			
		} else {
			camController.lookAtThis = GameObject.Find ("GarageRightSide");
		}


	}

	private void showCarImprovements() {
		int hp = this.carRef.getResearchEffectOnHP();
		if(hp==0) {
			this.horsepowerBoost.gameObject.SetActive(false);
		} else if(hp>0) {
			this.horsepowerBoost.gameObject.SetActive(true);
			this.horsepowerBoost.text = "+"+hp;
		}

		int torque = this.carRef.getResearchEffectOnTorque();
		if(torque==0) {
			this.torqueBoost.gameObject.SetActive(false);
		} else if(torque>0) {
			this.torqueBoost.gameObject.SetActive(true);
			this.torqueBoost.text = "+"+torque;

		}

		float turboPSI = this.carRef.getResearchEffectOnTurboPSI();
		if(turboPSI==0f) {
			this.turboBoost.gameObject.SetActive(false);
		} else if(turboPSI>0) {
			this.turboBoost.gameObject.SetActive(true);
			this.turboBoost.text = "+"+turboPSI+"PSI";
		}

		int nitroCapacity = this.carRef.getResearchEffectOnNitros();
		if(nitroCapacity==0) {
			this.nitroBoost.gameObject.SetActive(false);
		} else if(nitroCapacity>0) {
			this.nitroBoost.gameObject.SetActive(true);
			this.nitroBoost.text = "+"+turboPSI+"";
		}
		float shiftSpeed = this.carRef.getResearchEffectOnShiftSpeed();
		if(shiftSpeed==0f) {
			this.shiftspeedBoost.gameObject.SetActive(false);
		} else if(shiftSpeed<0) {
			this.shiftspeedBoost.gameObject.SetActive(true);
			this.shiftspeedBoost.text = "-"+shiftSpeed+"s";
		}

		float maxSpeed = this.carRef.getResearchEffectOnMaxSpeed();
		if(maxSpeed==0f) {
			this.maxSpeedBoost.gameObject.SetActive(false);
		} else if(maxSpeed>0f) {
			this.maxSpeedBoost.gameObject.SetActive(true);
			this.maxSpeedBoost.text = "+"+maxSpeed+"MPH";		
		}

		float dragReduce = this.carRef.getResearchEffectOnDrag();
		if(dragReduce==0f) {
			this.dragBoost.gameObject.SetActive(false);
		} else if(dragReduce<0f) {
			this.dragBoost.gameObject.SetActive(true);
			this.dragBoost.text = "-"+dragReduce+"";		
		}

		float gripAdd = this.carRef.getResearchEffectOnTireGrip();
		if(gripAdd==0f) {
			this.gripBoost.gameObject.SetActive(false);
		} else if(gripAdd>0f) {
			this.gripBoost.gameObject.SetActive(true);
			this.gripBoost.text = "+"+gripAdd;
		}

	}
	// Update is called once per frame
	void Update () {
	
	}
}
