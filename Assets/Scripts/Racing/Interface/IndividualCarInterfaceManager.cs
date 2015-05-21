using UnityEngine;
using System.Collections;
using System;
using Racing;

public class IndividualCarInterfaceManager : MonoBehaviour {


	public UILabel lapNumberLabel;
	public UILabel carPosition;
	public UILabel driverNameLabel;


	public UILabel drsLabel;
	public UILabel nitrosLabel;


	public RacingAI targetAI;
	public IRDSStatistics statistics;
	public IRDSLevelLoadVariables levLoad;
	public int maxLaps = 3;

	public UIProgressBar revCounter;

	public UILabel speedLabel;
	public UILabel gearLabel;
	public UILabel rpmLabel;

	public UILabel engineTemperature;
	public UIGrid debugGrid;

	public UILabel carBehindLabel;
	public UILabel carInfrontLabel;

	public float lastUpdate;
	public const float TIME_BETWEEN_UPDATES = 0.05f;
	public EDriverOrders lastOrders;
	// Use this for initialization
	void Start () {
		lastUpdate = Time.time;
		GameObject stats = GameObject.Find ("IRDSManager");

		statistics = stats.GetComponentInChildren<IRDSStatistics> ();
		if (statistics == null) {
			statistics = stats.GetComponent<IRDSStatistics>();
		}
	}
	public void finish() {
		if(this.lapNumberLabel!=null) {
			Destroy(this.lapNumberLabel.gameObject);
			Destroy(this.carPosition.gameObject);
			Destroy(this.speedLabel.gameObject);
			Destroy(this.carBehindLabel.gameObject);
			Destroy(this.carInfrontLabel.gameObject);

		}

	}
	// Update is called once per frame

	private void initLabelsEtc() {

		/*
		 * PositionValue = Current Position
NumberOfRacers = /6 (number of racers)
LapValue = 3 Current lap
LAP = / 4 (max laps)


DriverName Label
SpeedValue
GearValue
RPM Value
*/	
		if(GameObject.Find ("DriverName Label")!=null) {
			driverNameLabel = GameObject.Find("DriverName Label").GetComponent<UILabel>();
			lapNumberLabel = GameObject.Find ("LapValue").GetComponent<UILabel>();
			carPosition = GameObject.Find ("PositionValue").GetComponent<UILabel>();
			carBehindLabel = GameObject.Find ("CarBehindLabel").GetComponent<UILabel>();
			carInfrontLabel = GameObject.Find("CarInfrontLabel").GetComponent<UILabel>();
			speedLabel = GameObject.Find ("SpeedValue").GetComponent<UILabel>();
			//revCounter = GameObject.Find ("RPM Value").GetComponent<UIProgressBar>();
			rpmLabel = GameObject.Find ("RPM Value").GetComponent<UILabel>();
			this.gearLabel = GameObject.Find ("GearValue").GetComponent<UILabel>();
			
		//	this.nitrosLabel = GameObject.Find ("NitrosLabel").GetComponent<UILabel>();
		//	this.drsLabel = GameObject.Find ("DRSLabel").GetComponent<UILabel>();
		//	this.engineTemperature = GameObject.Find ("lblEngineTemp").GetComponent<UILabel>();
		}


	}
	void Update () {
		float thisUpdate = Time.time;
		if(thisUpdate-lastUpdate>TIME_BETWEEN_UPDATES) {
			lastUpdate = thisUpdate;
		} else {
			return;
		}
			
		lastUpdate = Time.time;
		if (targetAI != null) {
			if(driverNameLabel==null) {
				initLabelsEtc();
			}
			if(lapNumberLabel!=null)
				lapNumberLabel.text = ""+targetAI.aiCar.GetLap(); else return;
		
			if(carPosition!=null)
				carPosition.text = ""+statistics.GetCarPosition(targetAI.aiCar);


			//this.nitrosLabel.text = Convert.ToString(targetAI.nitrosRemaining);
			//this.drsLabel.gameObject.SetActive(targetAI.drsActivated);
	//		engineTemperature.text = ""+Convert.ToInt32(targetAI.engineTempMonitor.currentTemperature)+"c";

			if(driverNameLabel!=null)
			driverNameLabel.text = targetAI.driverName;
			if(targetAI.carBehind!=null&&this.carBehindLabel!=null) {
				this.carBehindLabel.text = "Car Behind: "+Math.Round(targetAI.carBehindTime, 2)+"\n"+ targetAI.carBehind.GetDriverName();
				
				this.carBehindLabel.gameObject.SetActive(true);

				TweenAlpha[] alphas = this.carBehindLabel.GetComponents<TweenAlpha>();

				alphas[0].enabled = true;
				alphas[0].ResetToBeginning();
				alphas[1].enabled = true;
				
				alphas[1].ResetToBeginning();
				targetAI.carBehind = null;
			} else {
				
			//	this.carBehindLabel.gameObject.SetActive(false);
			}
			if(targetAI.carInfront!=null&&this.carInfrontLabel!=null) {
				this.carInfrontLabel.text = "Car Infront: "+Math.Round(targetAI.carInfrontTime, 2)+"\n"+ targetAI.carInfront.GetDriverName();
				
				targetAI.carInfront = null;
				this.carInfrontLabel.gameObject.SetActive(true);
				TweenAlpha[] alphas = this.carInfrontLabel.GetComponents<TweenAlpha>();
				
				alphas[0].ResetToBeginning();
				alphas[0].enabled = true;
				
				alphas[1].ResetToBeginning();
				alphas[1].enabled = true;
			} else {
			//	this.carInfrontLabel.gameObject.SetActive(false);
			}
			if(!this.targetAI.raceComplete) {

				if(targetAI.aiDriveTrain!=null) {	
					speedLabel.text = ""+Convert.ToInt16(targetAI.aiCar.GetCarSpeed()*3.6f);
					switch(targetAI.aiDriveTrain.GetGear()) {
					default:this.gearLabel.text = (targetAI.aiDriveTrain.GetGear()-1)+"th";break;
					case(2):this.gearLabel.text = "1st";break;
					case(3):this.gearLabel.text = "2nd";break;
					case(4):this.gearLabel.text = "3rd";break;
					case(0):this.gearLabel.text = "R";break;
					case(1):this.gearLabel.text = "N";break;
					}
					this.rpmLabel.text = Convert.ToInt32(Convert.ToInt16(targetAI.aiDriveTrain.GetRPM()/100)*100)+""; 
					//revCounter.value = (targetAI.aiInput.GetRpms()-targetAI.aiDriveTrain.GetOriginalMinRPM())/(targetAI.aiDriveTrain.revLimiterRPM-targetAI.aiDriveTrain.GetOriginalMinRPM());
				}
			} else {
			//	speedLabel.text = "Race Complete: "+RaceManager.REF.timeUntilForcedFinish;
				this.driverNameLabel.text = "Race Complete: "+RaceManager.REF.timeUntilForcedFinish;
			}
			if (debugGrid != null) {
				debugGrid.transform.FindChild("AggressivenessOnBrake").GetComponent<UILabel>().text = "AggressivenessOnBrake: "+targetAI.aiCar.GetAggressivenessOnBrake();
				debugGrid.transform.FindChild("SpdSteeringFactor").GetComponent<UILabel>().text = "SpdSteeringFactor: "+targetAI.aiCar.GetSpeedSteeringFactor();
				debugGrid.transform.FindChild("LOOKAHEAD_FACTOR").GetComponent<UILabel>().text = "Lookahead Factor: "+targetAI.aiCar.GetLookahead_factor();
				debugGrid.transform.FindChild("CorneringSpeedFactor").GetComponent<UILabel>().text = "CorneringSpeedFactor: "+targetAI.aiCar.GetCorneringSpeedFactor();
			//	debugGrid.transform.FindChild("MaxDriftAngle").GetComponent<UILabel>().text = "MaxDriftAngle: "+targetAI.aiCar.GetMaxDriftAngle();
				debugGrid.transform.FindChild("SteeringDriftFactor").GetComponent<UILabel>().text = "SteeringDriftFactor: "+targetAI.aiCar.GetSteeringDriftFactor();
				
				debugGrid.transform.FindChild("CollisionSideFactor").GetComponent<UILabel>().text = "CollisionSideFactor: "+targetAI.aiCar.GetCollisionSideFactor();
				debugGrid.transform.FindChild("OvertakeFactor").GetComponent<UILabel>().text = "OvertakeFactor: "+targetAI.aiCar.GetOvertakeFactor();
				debugGrid.transform.FindChild("HumanError").GetComponent<UILabel>().text = "HumanError: "+targetAI.aiCar.GetHumanError();


				debugGrid.transform.FindChild("OvertakeSpeedDiff").GetComponent<UILabel>().text = "OvertakeSpeedDiff: "+targetAI.aiCar.GetOvertakeSpeedDiference();
			//	debugGrid.transform.FindChild("OvertakeOffsetIncrementMin").GetComponent<UILabel>().text = "OvertakeOffIncMin: "+targetAI.aiCar.GetOvertakeOffsetIncrementMin();
		//		debugGrid.transform.FindChild("OvertakeOffsetIncrementMax").GetComponent<UILabel>().text = "OvertakeOffIncMax: "+targetAI.aiCar.GetOvertakeOffsetIncrementMax();

				debugGrid.transform.FindChild("BackToLineIncrement").GetComponent<UILabel>().text = "BackToLineIncrement: "+targetAI.aiCar.backToLineIncrement;
				debugGrid.transform.FindChild("ShiftFactor").GetComponent<UILabel>().text = "ShiftFactor: "+targetAI.aiCar.GetShifFactor();
				debugGrid.transform.FindChild("ShiftUpFactor").GetComponent<UILabel>().text = "ShiftUpFactor: "+targetAI.aiCar.shiftUpFactor;

			//	debugGrid.transform.FindChild("FullAccellMaring").GetComponent<UILabel>().text = "FullAccellMaring: "+targetAI.aiCar.GetFullAccelMaring();

				
				debugGrid.transform.FindChild("FrontCollDist").GetComponent<UILabel>().text = "FrontCollDist: "+targetAI.aiCar.GetFrontCollDist();
				debugGrid.transform.FindChild("BackCollDist").GetComponent<UILabel>().text = "BackCollDist: "+targetAI.aiCar.GetBackCollDist();

				debugGrid.transform.FindChild("SideMargin").GetComponent<UILabel>().text = "SideMargin: "+targetAI.aiCar.GetSideMargin();
				debugGrid.transform.FindChild("MaxSpeed").GetComponent<UILabel>().text = "Max Speed: "+targetAI.maxSpeed;

				debugGrid.transform.FindChild("BestLapTime").GetComponent<UILabel>().text = "Best Lap Time: "+targetAI.aiCar.GetFastestLapTimeString();
				if(targetAI.aiDriveTrain!=null) {
					debugGrid.transform.FindChild("Horsepower").GetComponent<UILabel>().text = "HP: "+targetAI.aiDriveTrain.GetMaxPower();
					debugGrid.transform.FindChild("Torque").GetComponent<UILabel>().text = "Torque: "+targetAI.aiDriveTrain.GetMaxTorque();
				
				}
				debugGrid.transform.FindChild("CoolingData").GetComponent<UILabel>().text = "CH, LH, LC, LR%: "+targetAI.engineTempMonitor.currentTemperature+","+targetAI.engineTempMonitor.lastHeat+","+targetAI.engineTempMonitor.lastCool+","+targetAI.engineTempMonitor.lastRPMPercent;


			}
		}
	}
}
