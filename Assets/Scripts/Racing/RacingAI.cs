using UnityEngine;
using System.Collections;
using Database;
using Racing;
using Drivers;
using cars;
using System;
using Teams;
using Cars;
using PixelCrushers.DialogueSystem;

public class RacingAI : RacingAIWithHeating {
	public float nitroBoostDurability = 200f;
	public float speedCornerBeforeError = 0f;
	public float backToLineBeforeError = 0f;
	public float breakAggressionBeforeError = 0f;
	public float engineWearPerFrame = 0f;
	public static bool allowNitros = true;
	public int lastSector;
	public float carInfrontTime;
	public float carBehindTime;
	public byte nitrosRemaining = 3;
	public float maxSpeed;
	public float originalShiftUp;
	public IRDSCarControllerAI carInfront;
	public IRDSCarControllerAI carBehind;
	public int fatigueCount = 0;
		
	public ETireWear currentTireWear;
	public float tireTemp;
	public float tireWear;

	public string finishTimeString = "DNF";
	private bool usingNitro = false;
	public bool raceComplete = false;
	public EDriverOrders currentOrders = EDriverOrders.DriveNormal;
	public EDriverOrders currentTyreOrders = EDriverOrders.DriveNormal;
	
	public float damage;
	public int finishPosition = int.MaxValue;
	public int finishPoints = 0;
	public string prizeString;

	public GTDriver driverRecord;


	public bool drsActivated = false;
	public bool canDRS = false;

	public float fatigue = 8000f;
	public float staminaDecrementer = 0f;

	public EDriverMessage lastMessage;
	public bool dmgTriggered = false;

	public ETireWear tireWearLevel = ETireWear.Cold;
	public static bool considerNitroTutorials = true;
	public float lastMessageTime;

	public DriverFaceManager messageHolder;

	public ErrorState currentErrorState;
	// Use this for initialization
	void Start () {
		this.tag = "Player";
		Lua.Result r = DialogueLua.GetVariable ("HintArrowNitroBoost");
		if(r.AsInt==3) {
			considerNitroTutorials = false;
		}
	}
	
	// Update is called once per frame


	public RacingAI initDriver(GTDriver aRecord) {
		GameObject g = this.gameObject;
		aiCar = g.GetComponent<IRDSCarControllerAI>();
		if (aiCar != null) {
			driverRecord = aRecord;
			lastMessageTime = Time.time;
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
					cp[i].set_height_(80f);
					cp[i].set_distance_(5f);
					cp[i].sidesDamping = 9f; 
				}
				if(cp[i].gameObject.name=="FrontBumper") {
					Vector3 v = new Vector3(5f,1.21f,9.4f);
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



	public void changeTyreOrders(EDriverOrders aOrder) {
		if(aOrder!=this.currentTyreOrders) {
			if(originalPower==0f||float.IsNaN(originalMaxRPM)) {
				originalPower = this.aiDriveTrain.GetMaxPower();
				originalTorque = this.aiDriveTrain.GetMaxTorque();
				this.originalMaxRPM = this.aiDriveTrain.revLimiterRPM;
			}
			DriverOrderSetup newOrder = DriverOrderLibrary.REF.getTyreOrderFromEnum(aOrder);
			newOrder.addEffectToCar(this,this.wings);
			
			this.currentTyreOrders = aOrder;
		}
	}

	public void changeEngineOrders(EDriverOrders aOrder) {
		if(aOrder!=this.currentOrders) {
			if(originalPower==0f||float.IsNaN(originalMaxRPM)) {
				originalPower = this.aiDriveTrain.GetMaxPower();
				originalTorque = this.aiDriveTrain.GetMaxTorque();
				this.originalMaxRPM = this.aiDriveTrain.revLimiterRPM;
			}
			if(this.humanControl&&aOrder==EDriverOrders.TakeItEasy&&DialogueLua.GetVariable("HintArrowOverheating").AsInt==1) {
				RaceManager.REF.doConversation("TutorialOverheating");
			}
			DriverOrderSetup newOrder = DriverOrderLibrary.REF.getEngineOrderFromEnum(aOrder);
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
			this.changeEngineOrders(EDriverOrders.RaceComplete);
			this.changeTyreOrders(EDriverOrders.RaceComplete);
			RaceManager.REF.HandleNewFinisher(this);

		}
	}

	public void FixedUpdate() {
		
		if(this.currentErrorState==null) {
			if(this.aiCar!=null&&UnityEngine.Random.Range(0f,50f)<this.aiCar.GetHumanError()) {
				currentErrorState = new ErrorState(this.aiCar.GetHumanError(),this);
				speedCornerBeforeError = this.aiCar.GetCorneringSpeedFactor();
				this.breakAggressionBeforeError = this.aiCar.GetAggressivenessOnBrake();
				this.backToLineBeforeError = this.aiCar.backToLineIncrement; 
				
			}
		} else {
			currentErrorState.framesOfError--;
			this.aiCar.SetCorneringSpeedFactor(speedCornerBeforeError*currentErrorState.corneringSpeedEffector);
			this.aiCar.backToLineIncrement = currentErrorState.backToLineError;
			this.aiCar.SetAggressivenessOnBrake(this.currentErrorState.brakeAggressionEffector);
			if(currentErrorState.framesOfError==0) {
				currentErrorState = null;
				this.aiCar.SetCorneringSpeedFactor(speedCornerBeforeError);
				this.aiCar.backToLineIncrement = backToLineBeforeError;
				this.aiCar.SetAggressivenessOnBrake(this.breakAggressionBeforeError);
			} else
				this.aiCar.SetCorneringSpeedFactor(speedCornerBeforeError*currentErrorState.corneringSpeedEffector);
		}
		engineTempMonitor.Update(this.aiDriveTrain,this.aiCar,this.aiInput,this);
		this.fatigue -= this.staminaDecrementer;
		fatigueCount++;
		if(fatigueCount%40==0&&aiCar!=null) {
			//if(fatigue>0)
				//this.aiCar.SetHumanError(500000f+(this.driverRecord.humanError*(this.fatigue/this.driverRecord.stamina)));
				//this.aiCar.SetHumanError(this.driverRecord.humanError+(this.driverRecord.humanError*(this.fatigue/this.driverRecord.stamina)));
		}
	}


	void Update () {

		if (!inited) {
			initCar();
			initEngineTempMonitor();
			inited = true;

		}
		if(this.aiCar==null) {
			return;
		}
		float time = Time.time;
		if(this.aiCar.GetCarSpeed()*3.6f>maxSpeed) {
			maxSpeed = aiCar.GetCarSpeed()*3.6f;
		}

		damage = this.aiInput.GetCarDamage().totalDamage;
		if(!raceComplete) {
			for(int i = 0;i<wheelInfo.Length;i++) {
				wheelInfo[i].Update();
				if(wheelInfo[i].tireTemp>this.tireTemp) {
					tireTemp = wheelInfo[i].tireTemp;
				}
				if(wheelInfo[i].dividedTireWear<this.tireWear||this.tireWear==0) {
					tireWear = wheelInfo[i].dividedTireWear;
				}
				if(tireTemp<0.8f) {
					this.currentTireWear = ETireWear.Cold;
				} else if(tireTemp<1f) {
					this.currentTireWear = ETireWear.Warm;
				} else if(tireTemp>0.8f) { 
					this.currentTireWear = ETireWear.Perfect;
				} else if(tireTemp>0.6f) {
					this.currentTireWear = ETireWear.LightWear;
				} else if(tireTemp>0.4f) {
					this.currentTireWear = ETireWear.Worn;
				} else this.currentTireWear = ETireWear.Dangerous;
			} 
			if(this.aiCar.GetEndRace()) {
				raceComplete = true;
				finishTimeString = this.aiCar.GetCurrentTotalRaceTimeString();
				this.changeEngineOrders(EDriverOrders.RaceComplete);
				this.changeTyreOrders(EDriverOrders.RaceComplete);
				finishPosition = this.aiCar.racePosition;
				RaceManager.REF.HandleNewFinisher(this);
			} else {

			}
		}
		if((inNitroZone&&canDRS)&&!drsActivated) {
			removeWings();
			drsActivated = true;
		} else if(drsActivated&&!inNitroZone) {
			addWings();
			drsActivated = false;
		}
		if (humanControl) {
			if(time-this.lastMessageTime>10f&&RaceManager.REF.raceStartersTable==null) {
				lastMessageTime = time;
				if(lastMessage!=EDriverMessage.BrakingOnOpponent&&this.aiCar.GetIsBrakingOnOpponent()&&carInfrontTime<2f) {
					this.messageHolder.doMessage(EDriverMessage.BrakingOnOpponent);
					
				} else if(lastMessage!=EDriverMessage.Avoiding&&this.aiCar.GetIsAvoidingOpponentSideways()&&(carInfrontTime<1f||carBehindTime>-1f)) {
					this.messageHolder.doMessage(EDriverMessage.Avoiding);
				} else if(lastMessage!=EDriverMessage.Damage&&dmgTriggered) {
					this.messageHolder.doMessage(EDriverMessage.Damage);
				} else if(lastMessage!=EDriverMessage.GettingHot&&this.engineTempMonitor.isGettingHot) {
					this.messageHolder.doMessage(EDriverMessage.GettingHot);
				} else if(lastMessage!=EDriverMessage.GettingHot&&this.engineTempMonitor.isOverheating) {
					this.messageHolder.doMessage(EDriverMessage.Overheating);
				} else if(lastMessage!=EDriverMessage.Overtaking&&this.aiCar.GetIsOvertaking()) {
					this.messageHolder.doMessage(EDriverMessage.Overtaking);
				} else if(lastMessage!=EDriverMessage.TiresWorn&&this.tireWearLevel==ETireWear.Dangerous) {
					this.messageHolder.doMessage(EDriverMessage.TiresWorn);
				} else if(lastMessage!=EDriverMessage.TooHot&&this.engineTempMonitor.isTooHot) {
					this.messageHolder.doMessage(EDriverMessage.TooHot);
				}
			}
			if(this.inNitroZone&&TeamControl.REF.selectedCar==this) {
				if(considerNitroTutorials)
					RaceManager.REF.doConversation("NitroBoost");
			}
		} else {
			if(this.engineTempMonitor.percentTempRange<0.65f) {
				if(this.currentOrders!=EDriverOrders.DoOrDie)
					this.changeEngineOrders(EDriverOrders.DoOrDie);
			} else if(this.engineTempMonitor.percentTempRange<0.80f) {
				if(this.currentOrders!=EDriverOrders.DriveNormal)
					this.changeEngineOrders(EDriverOrders.DriveNormal); 
			} else {
				if(this.currentOrders!=EDriverOrders.TakeItEasy)
					this.changeEngineOrders(EDriverOrders.TakeItEasy);
			}
			if(this.tireWearLevel==ETireWear.Cold||this.tireWearLevel==ETireWear.Worn) {
				if(this.currentTyreOrders!=EDriverOrders.DriveNormal) {
					this.changeTyreOrders(EDriverOrders.DriveNormal);
				}
			}
			if(this.tireWearLevel==ETireWear.Warm||this.tireWearLevel==ETireWear.Perfect||this.tireWearLevel==ETireWear.LightWear) {
				if(this.currentTyreOrders!=EDriverOrders.DoOrDie) {
					this.changeTyreOrders(EDriverOrders.DoOrDie);
				}
			}
			if(this.tireWearLevel==ETireWear.Dangerous) {
				if(this.currentTyreOrders!=EDriverOrders.TakeItEasy) {
					this.changeTyreOrders(EDriverOrders.TakeItEasy);
				}
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
