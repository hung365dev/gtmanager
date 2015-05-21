﻿using UnityEngine;
using System.Collections;
using Racing;

[System.Serializable]
public class DriverOrderSetup {

	public EDriverOrders orderType;


	public float frontWingAddition = 0f;
	public float rearWingAddition = 0f;

	public float horsePowerMultiplier = 0f;
	public float torqueMultiplier = 0f;
	public float engineWearAdd = 0f;

	public float aggressionOnBrakingPercent = 1f;
	public float overtakeFactorPercent = 1f;
	public float corneringSpeedFactorPercent = 1f;
	public float lengthMarginMultiplier = 1f;

	public float overtakeSpeedDiffModifier = 0f;

	public float humanErrorModifier = 0f;
	public float humanErrorPercent = 1f;

	public float changeUpMultiplier = 1f;

	public float staminaDecrementer = 0.1f;

	// Use this for initialization


	public void addEffectToCar(RacingAI aAI,IRDSWing[] aWings) {
		IRDSCarControllerAI ai = aAI.GetComponent<IRDSCarControllerAI>();
		IRDSDrivetrain driveTrain = aAI.GetComponent<IRDSDrivetrain>();
		//IRDSCarControllInput controlInput = aAI.GetComponent<IRDSCarControllInput>();
		if(humanErrorPercent!=0f)
			ai.SetHumanError(ai.GetHumanError()*humanErrorPercent);
		ai.SetHumanError(ai.GetHumanError()+humanErrorModifier);

		
		aAI.engineWearPerFrame += engineWearAdd;
		if(corneringSpeedFactorPercent!=0f)
			ai.SetCorneringSpeedFactor(aAI.originalCorneringSpeed*corneringSpeedFactorPercent);
		if(aggressionOnBrakingPercent!=0f)
			ai.SetAggressivenessOnBrake(aAI.originalBrakingAggressiveness*aggressionOnBrakingPercent);
		ai.SetOvertakeSpeedDiference(aAI.originalOvertakeSpeedDiff+overtakeSpeedDiffModifier);
		
		if(overtakeFactorPercent!=0f)
			ai.SetOvertakeFactor(aAI.originalOvertakeFactor*overtakeFactorPercent);
		aAI.staminaDecrementer = staminaDecrementer;
		if(horsePowerMultiplier!=0f) {
			float newPower = aAI.originalPower*horsePowerMultiplier;
			if(float.IsNaN(newPower)) {
				Debug.LogError("New Power is NaN: "+aAI.originalPower+","+horsePowerMultiplier);
			} else
				driveTrain.SetMaxPower(newPower);
		}
		if(torqueMultiplier!=0f) {
			float newMaxTorque = aAI.originalTorque*torqueMultiplier;
			if(float.IsNaN(newMaxTorque)) {
				Debug.LogError("New Torque is NaN: "+aAI.originalTorque+","+torqueMultiplier);
			} else
				driveTrain.SetMaxTorque(newMaxTorque);
		}
		if(float.IsNaN(driveTrain.GetRPM())) {
			Debug.LogError("RPM is now NaN!");
		}
		if(changeUpMultiplier!=0f) {
			float newShiftRange = changeUpMultiplier;
	//		Debug.Log ("new shift range is: "+newShiftRange+" car is: "+aAI.gameObject.name);
			if(newShiftRange>0.97f) {
				newShiftRange = 0.97f;
			}
			ai.shiftUpFactor = newShiftRange;
		}



		
		/*
		aWings[0].SetLiftCoefficient(aWings[0].GetLiftCoefficient()+frontWingAddition);
		aWings[1].SetLiftCoefficient(aWings[1].GetLiftCoefficient()+rearWingAddition);*/
	}
}
