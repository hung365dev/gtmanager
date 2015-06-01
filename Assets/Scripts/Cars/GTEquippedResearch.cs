// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using GoogleFu;
using UnityEngine;
using championship;


namespace Cars
{
	[System.Serializable]
	public class GTEquippedResearch
	{

		public RnDRow researchRow;
		public int level;
		public int daysOfResearchRemaining = 0;
		public int dayOfCompletion = 0;
		public GTEquippedResearch (RnDRow aPart)
		{
			researchRow = aPart;
			level = 1;
		}
		public GTEquippedResearch(int aActiveLevel,int aDayOfCompletion,int aDaysOfResearchRemaining,int aRnDLevel,int aResearchID) {
			this.dayOfCompletion = aDayOfCompletion;
			this.daysOfResearchRemaining = aDaysOfResearchRemaining;
			this.level = aRnDLevel;
			for(int i = 0;i<RnD.Instance.Rows.Count;i++) {
				if(RnD.Instance.Rows[i]._id==aResearchID) {
					this.researchRow = RnD.Instance.Rows[i];
				}
			}
		}
		                          
		public int activeLevel {
			get {
				if(daysOfResearchRemaining>0) {
					return level-1;
				}
				return level;
			}
		}
		public void applyPartToCar(IRDSDrivetrain aDriveTrain,IRDSCarControllerAI aAI,RacingAI aRacingAI) {

			for(int i = 0;i<activeLevel;i++) {
				aDriveTrain.SetTurboPSI(aDriveTrain.GetTurboAirPresure()+researchRow._effectonturbopsi);
				float hpToKW = 745.699872f;
				aDriveTrain.SetMaxPower(aDriveTrain.GetOriginalPower()+researchRow._effectonhp*hpToKW);
				aDriveTrain.SetMaxTorque(aDriveTrain.GetMaxTorque()+researchRow._effectontorque);
				aRacingAI.nitrosRemaining += (byte) researchRow._effectonnitrocapacity;
				aDriveTrain.ShiftSpeed += researchRow._effectonshiftspeed;

				if(aDriveTrain.ShiftSpeed<0) {
					aDriveTrain.ShiftSpeed = 0.01f;
				}

				IRDSAerodynamicResistance ar = aDriveTrain.gameObject.GetComponent<IRDSAerodynamicResistance>();
				Vector3 coefficients = ar.GetCoefficients();
				coefficients.z -= researchRow._bodyaerodragreduce;
				if(coefficients.z<0.01f) {
					coefficients.z = 0.01f;
				}
				ar.SetCoefficients(coefficients);

				aAI.SetHumanError(aAI.GetHumanError()-researchRow._humanerrorreductor);
				aRacingAI.engineTempMonitor.engineBlowupTemp += researchRow._coolingmaxtempeffect;
				aRacingAI.engineTempMonitor.baseCooling += researchRow._coolingbaseeffect;
				if(float.IsNaN(aRacingAI.engineTempMonitor.baseCooling)||float.IsNaN(aRacingAI.engineTempMonitor.engineBlowupTemp)) {
					Debug.Log ("STOP!");
				}
				IRDSWheel[] wheels = aRacingAI.wheels;
				for(int c = 0;c<wheels.Length;c++) {
					wheels[c].SetGrip(wheels[c].GetGrip()+researchRow._tirecoefficientofgripchange);
					
				}
 

			 

			}

		}
	}
}

