﻿using UnityEngine;
using System.Collections;
using Database;
using Racing;
using Drivers;
using cars;
using System;
using Teams;
using Cars;

public class RacingAI : MonoBehaviour {
	public IRDSCarControllerAI aiCar;
	public IRDSDrivetrain aiDriveTrain;
	public IRDSCarControllInput aiInput;
	public IRDSAerodynamicResistance aero;
	public float frontWingDownforce;
	public float rearWingDownforce;
	public GTCar carRef;
	public float originalPower;
	public float originalTorque; 
	public float originalBrakingAggressiveness;
	public float originalCorneringSpeed;
	public float originalOvertakeSpeedDiff;
	public float originalOvertakeFactor;
	public float originalMaxRPM;
	public IRDSWing[] wings;
	public IRDSWheel[] wheels;
	public WheelInfo[] wheelInfo;
	public float nitroBoostDurability = 200f;
	public bool inited = false;
	public string driverName;
	public float originalSpeedCorner = 0f;
	public float engineWearPerFrame = 0f;
	public bool humanControl = false;
	public bool inNitroZone = false;
	public static bool allowNitros = true;
	public int lastSector;
	public float carInfrontTime;
	public float carBehindTime;
	public byte nitrosRemaining = 3;
	public float maxSpeed;
	public float originalShiftUp;
	public IRDSCarControllerAI carInfront;
	public IRDSCarControllerAI carBehind;

	public EngineTemperatureMonitor engineTempMonitor;

	public string finishTimeString = "DNF";
	private bool usingNitro = false;
	public bool raceComplete = false;
	public EDriverOrders currentOrders = EDriverOrders.DriveNormal;

	public float damage;
	public int finishPosition = int.MaxValue;
	public int finishPoints = 0;
	public string prizeString;

	public GTDriver driverRecord;

	public GameObject engineWhiteSmoke;
	public GameObject engineBlackSmoke;
	public GameObject engineFire;

	public EEngineFailureStage engineFailure;
	// Use this for initialization
	void Start () {
		this.tag = "Player";
	}
	
	// Update is called once per frame


	public RacingAI initDriver(GTDriver aRecord) {
		GameObject g = this.gameObject;
		aiCar = g.GetComponent<IRDSCarControllerAI>();
		if (aiCar != null) {
			driverRecord = aRecord;
			aiCar.SetAggressivenessOnBrake(aRecord.aggressivenessOnBrake);
			this.originalBrakingAggressiveness = aRecord.aggressivenessOnBrake;
			aiCar.SetBackCollDist(aRecord.backCollDist);
			aiCar.backToLineIncrement = aRecord.backToLineIncrement;
			aiCar.SetCollisionSideFactor(aRecord.collisionSideFactor);
			aiCar.SetCorneringSpeedFactor(aRecord.corneringSpeedFactor);
			//aRecord.driftingThrottleFactor
			aiCar.SetFrontCollDist(aRecord.frontCollDist);
			aiCar.SetFuelloadPorcentage(aRecord.fuelLoadPercentage);
			aiCar.SetFullAccelMaring(aRecord.fullAccelMargin);
			aiCar.SetHeightMargin(aRecord.heightMargin);
			aiCar.SetHumanError(aRecord.humanError);
			aiCar.jumpThrottleMulpilier = aRecord.jumpThrottleMultiplier;
			aiCar.jumpThrottleTime = aRecord.jumpThrottleTime;
			aiCar.SetLength_Margin(aRecord.lengthMargin);
			aiCar.LookAheadConst = aRecord.lookAheadConstant;
			aiCar.SetLookahead_factor(aRecord.lookAheadFactor);
			aiCar.SetMaxDriftAngle(aRecord.maxDriftAngle);
			aiCar.offTrackThrottleMulpilier = aRecord.offtrackThrottleMultiplier;
			aiCar.SetOvertakeFactor(aRecord.overtakeFactor);
			aiCar.SetOvertakeOffsetIncrementMax(aRecord.overtakeOffsetIncrementMax);
			aiCar.SetOvertakeOffsetIncrementMin(aRecord.overtakeOffsetIncrementMin);
			aiCar.SetOvertakeSpeedDiference(aRecord.overtakeSpeedDifference);
			aiCar.SetShifFactor(aRecord.shiftFactor);
			aiCar.shiftUpFactor = aRecord.shiftUpFactor;
			//aRecord.sideAvoidingFactor
			aiCar.SetSideMargin(aRecord.sideMargin);
			aiCar.SetSide_Margin(	aRecord.SIDE_MARGIN);
			aiCar.SetSpeedSteeringFactor(aRecord.speedSteeringFactor);
			aiCar.SetSteeringDriftFactor(aRecord.steeringDriftFactor);
			aiCar.SetTyrechangePorcentage(aRecord.tyreChangePercentage);
			
			this.originalCorneringSpeed = aRecord.corneringSpeedFactor;
			this.originalOvertakeSpeedDiff = aRecord.overtakeSpeedDifference;
			this.originalOvertakeFactor = aRecord.overtakeFactor;
			this.originalShiftUp = aRecord.shiftUpFactor;
			initSmokes();

			aiCar.SetMaxDriftAngle(45f);


			this.aiCar = this.GetComponent<IRDSCarControllerAI>();
			this.aiDriveTrain = this.GetComponent<IRDSDrivetrain>();
			wheels = this.gameObject.GetComponentsInChildren<IRDSWheel>();

			IRDSCameraPosition[] cp = this.GetComponentsInChildren<IRDSCameraPosition>();
			for(int i = 0;i<cp.Length;i++) {
				if(cp[i].gameObject.name=="Roof") {
					Vector3 v = new Vector3(5f,27f,-7.3f);
					cp[i].distanceSides= v;
					cp[i].minFieldOfView = 55;
					cp[i].maxFieldOfView = 72;
					cp[i].fieldOfViewChangeSpeedMultiplier = 2f;
					cp[i].set_rotationDamping_(1000f);
					cp[i].set_heightDamping_(20f);
					cp[i].set_height_(40f);
					cp[i].set_distance_(5f);
					cp[i].sidesDamping = 9f; 

				}
			}
		}
		return this;
	}

	public void initSmokes() {
		try {
			if(engineWhiteSmoke==null&&this.gameObject.transform.FindChild("EngineWhiteSmoke")!=null) {
				engineWhiteSmoke = this.gameObject.transform.FindChild("EngineWhiteSmoke").gameObject;
			}
			if(engineBlackSmoke==null&&this.gameObject.transform.FindChild("EngineBlackSmoke")!=null) {
				engineBlackSmoke = this.gameObject.transform.FindChild("EngineBlackSmoke").gameObject;
			}
			if(engineFire==null&&this.gameObject.transform.FindChild("EngineFire")!=null) {
				engineFire = this.gameObject.transform.FindChild("EngineFire").gameObject;
			}
		} catch(Exception e) {
			
		}
		engineFailure = EEngineFailureStage.Normal;
		setEngineFailureStage();
	}
	public void setEngineFailureStage() {
		switch(engineFailure) {
			case(EEngineFailureStage.Normal):
				if(engineFire!=null)
					engineFire.gameObject.SetActive(false);	
				if(engineWhiteSmoke!=null)
					engineWhiteSmoke.gameObject.SetActive(false);	
				if(engineBlackSmoke!=null)
					engineBlackSmoke.gameObject.SetActive(false);	
				if(aiDriveTrain!=null) {
					if(!float.IsNaN(this.originalMaxRPM)&&(this.originalMaxRPM>0)) {
						this.aiDriveTrain.SetMaxPower(this.originalPower);
						this.aiDriveTrain.SetMaxTorque(this.originalTorque);
						this.aiDriveTrain.SetMaxRPM(this.originalMaxRPM);
					}
				}
		

			break;
		case(EEngineFailureStage.Hot):
			if(engineFire!=null)
				engineFire.gameObject.SetActive(false);	
			if(engineWhiteSmoke!=null)
				engineWhiteSmoke.gameObject.SetActive(true);	
			if(engineBlackSmoke!=null)
				engineBlackSmoke.gameObject.SetActive(false);	

			if(aiDriveTrain!=null) {
			//	this.aiDriveTrain.SetMaxPower(this.originalPower*0.95f);
			//	this.aiDriveTrain.SetMaxTorque(this.originalTorque*0.95f);
			//	this.aiDriveTrain.SetMaxRPM(this.originalMaxRPM);
			}

			break;
		case(EEngineFailureStage.VeryHot):
			if(engineFire!=null)
				engineFire.gameObject.SetActive(false);	
			if(engineWhiteSmoke!=null)
				engineWhiteSmoke.gameObject.SetActive(true);	
			if(engineBlackSmoke!=null)
				engineBlackSmoke.gameObject.SetActive(true);
			if(aiDriveTrain!=null) {
			//	this.aiDriveTrain.SetMaxPower(this.originalPower*0.90f);
			//	this.aiDriveTrain.SetMaxTorque(this.originalTorque*0.90f);
			//	this.aiDriveTrain.SetMaxRPM(this.originalMaxRPM*0.95f);
			}
			break;
		case(EEngineFailureStage.Failed):
			if(engineFire!=null)
				engineFire.gameObject.SetActive(true);	
			if(engineWhiteSmoke!=null)
				engineWhiteSmoke.gameObject.SetActive(true);	
			if(engineBlackSmoke!=null)
				engineBlackSmoke.gameObject.SetActive(true);	

			if(aiDriveTrain!=null) {
				this.aiCar.EnableSpeedRestriction(0,int.MaxValue,true,5f);
			}

			break;
		}
	}

	public void changeOrders(EDriverOrders aOrder) {
		if(aOrder!=this.currentOrders) {
			if(originalPower==0f||float.IsNaN(originalMaxRPM)) {
				originalPower = this.aiDriveTrain.GetMaxPower();
				originalTorque = this.aiDriveTrain.GetMaxTorque();
				this.originalMaxRPM = this.aiDriveTrain.revLimiterRPM;
			}

			DriverOrderSetup newOrder = DriverOrderLibrary.REF.getOrderFromEnum(aOrder);
			newOrder.addEffectToCar(this,this.wings);
			this.currentOrders = aOrder;
		}
	}
	public void useNitro() {
		if(aiCar.GetCarSpeed()>2f) {
			aiDriveTrain.nitroFuel = 1f;
			aiDriveTrain.nitroBoostDurability = 1f;
			aiInput.activateNitro = true;
			nitrosRemaining--;
		}
	}

	public void hidePilot() {
		MeshRenderer[] findPilot = this.gameObject.GetComponentsInChildren<MeshRenderer>();
		for(int i = 0;i<findPilot.Length;i++) {
			if(findPilot[i].name.ToLower().Contains("pilot")) {
				findPilot[i].gameObject.SetActive(false);
			}
		}
	}

	public void OnTriggerEnter(Collider aOtherCollider) {
		if (aOtherCollider.gameObject.tag == "NitroZone") {
			inNitroZone = true;
		}
	}
	
	public void OnTriggerExit(Collider aOtherCollider) {
		if (aOtherCollider.gameObject.tag == "NitroZone") {
			inNitroZone = false;
		}
	}

	public void forceRaceComplete() {
		if(!this.raceComplete) {
			finishPosition = int.MaxValue;
			raceComplete = true;
			this.changeOrders(EDriverOrders.RaceComplete);
			RaceManager.REF.HandleNewFinisher(this);

		}
	}
	public void recolourCarForTeam(GTTeam aTeam) {
		MeshRenderer[] ms = this.GetComponentsInChildren<MeshRenderer>();
	//	Debug.Log (ms[0].material.shader.name+" on "+this.gameObject.name);
		for(int i = 0;i<ms.Length;i++) 
			if(ms[i].material.shader.name.Contains("Car Paint"))
				ms[i].material.SetColor("_Color",aTeam.teamColor); else {
//			Debug.Log (ms[i].material.shader.name);
		} 
	}
	public void FixedUpdate() {
		
		engineTempMonitor.Update(this.aiDriveTrain,this.aiCar,this.aiInput,this);
	}
	void Update () {

		if (!inited) {
			inited = true;

			GameObject g = this.gameObject;
			aiCar = g.GetComponent<IRDSCarControllerAI>();
			aiDriveTrain = g.GetComponent<IRDSDrivetrain>();
			if(g==null||aiDriveTrain==null) {
				return;
			}

			aiDriveTrain.useNitro = true;
			aiDriveTrain.nitroBoostDurability = 5;
			aiDriveTrain.nitroFuel = 0;
			aiInput = g.GetComponent<IRDSCarControllInput>();
			
			if(aiInput!=null&&aiInput.GetCarDamage()!=null) {
				aero = g.GetComponent<IRDSAerodynamicResistance>();
				wings = g.GetComponentsInChildren<IRDSWing>();
				
				frontWingDownforce = wings[0].GetLiftCoefficient();
				rearWingDownforce = wings[1].GetLiftCoefficient();

				this.wheelInfo = new WheelInfo[wheels.Length];
				for(int i = 0;i<wheelInfo.Length;i++) {
					wheelInfo[i] = new WheelInfo(wheels[i]);
				}
				driverName = this.aiCar.GetDriverName();
				//wings[0].SetLiftCoefficient(-0.3f);
				//wings[1].SetLiftCoefficient(-0.8f);
				originalSpeedCorner = aiCar.GetCorneringSpeedFactor();
				inNitroZone = false;
				this.aiInput.GetCarDamage().SetRepairDelta(0f);

				this.originalPower = this.aiDriveTrain.GetMaxPower();
				this.originalTorque = this.aiDriveTrain.GetMaxTorque();

				
				engineTempMonitor = new EngineTemperatureMonitor();
				engineTempMonitor.initDriveTrainVals(this.aiDriveTrain,this.aiInput);

			}
			return;
		}
		if(this.aiCar==null) {
			return;
		}
		if(this.aiCar.GetCarSpeed()*3.6f>maxSpeed) {
			maxSpeed = aiCar.GetCarSpeed()*3.6f;
		}

		damage = this.aiInput.GetCarDamage().totalDamage;
		if(!raceComplete) {
			for(int i = 0;i<wheelInfo.Length;i++) {
				wheelInfo[i].Update();
			}
			if(this.aiCar.GetEndRace()) {
				raceComplete = true;
				finishTimeString = this.aiCar.GetCurrentTotalRaceTimeString();
				this.changeOrders(EDriverOrders.RaceComplete);
				finishPosition = this.aiCar.racePosition;
				aiCar.LookAheadConst = 6f;
				RaceManager.REF.HandleNewFinisher(this);
			} else {

			}
		}
		if (humanControl) {
		} else {
			if(this.engineTempMonitor.percentTempRange<0.5f) {
				if(this.currentOrders!=EDriverOrders.DoOrDie)
					this.changeOrders(EDriverOrders.DoOrDie);
			} else if(this.engineTempMonitor.percentTempRange<0.75f) {
				if(this.currentOrders!=EDriverOrders.DriveNormal)
					this.changeOrders(EDriverOrders.DriveNormal); 
			} else {
				if(this.currentOrders!=EDriverOrders.TakeItEasy)
					this.changeOrders(EDriverOrders.TakeItEasy);
			}
			if(inNitroZone&&allowNitros) {
				if(!usingNitro&&nitrosRemaining>0) {
					if(aiCar.GetIsOvertaking()) {
						useNitro();
					}
					if(UnityEngine.Random.Range(0,100000)==1) {
						useNitro();
					}
				}
			}
		}
		if (aiDriveTrain.nitroFuel > 0f&&!usingNitro) {
			aiInput.activateNitro = true;
			usingNitro = true;

		} else {
			aiInput.activateNitro = false;
			usingNitro = false;
		}

	}
}
