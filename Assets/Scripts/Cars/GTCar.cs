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
using Drivers;
using UnityEngine;
using Database;
using GoogleFu;
using System.Collections.Generic;
using Teams;
using championship;
using Utils;


namespace Cars
{
	[System.Serializable]
	public class GTCar
	{
		public int libraryIndex = 0;
		public CarLibraryRecord carLibRecord;

		public List<GTEquippedResearch> rndParts = new List<GTEquippedResearch>();
		public GTCar ()
		{

		}
		public GTCar(string aCarName)
		{
			carLibRecord = CarDatabase.REF.carByName (aCarName);
		}
		public string ToString() {
			string RnD = "";
			for(int i = 0;i<rndParts.Count;i++) {
				RnD += rndParts[i].activeLevel+"|"+rndParts[i].dayOfCompletion+"|"+rndParts[i].daysOfResearchRemaining+"|"+rndParts[i].level+"|"+rndParts[i].researchRow._id+"%";
			}
			RnD = Base64.Base64Encode(RnD);
			return Base64.Base64Encode(carLibRecord.id+"|"+RnD);
		}

		public void FromString(string aString) {
			string decode = Base64.Base64Decode(aString);
			string[] split = decode.Split(new char[] {'|'});
			if(split.Length==2) {
				carLibRecord = CarDatabase.REF.carRecordByID(Convert.ToInt32(split[0]));
				string rnd = Base64.Base64Decode(split[1]);
				string[] rndSplit = rnd.Split(new char[] {'%'});
				for(int i = 0;i<rndSplit.Length;i++) {
					string[] part = rndSplit[i].Split(new char[] {'|'});
					if(part.Length==4) {
						GTEquippedResearch research = new GTEquippedResearch(Convert.ToInt32(part[0]),Convert.ToInt32(part[1]),Convert.ToInt32(part[2]),Convert.ToInt32(part[3]),Convert.ToInt32(part[4]));
						this.rndParts.Add(research);
					}
				}
			}
			
		}
		public int carValue {
			get {
				float start = carLibRecord.carCost/2;
				for(int i = 0;i<rndParts.Count;i++) {
					start += rndParts[i].researchRow._costtoresearch/2*rndParts[i].activeLevel;
				}
				return Convert.ToInt32(start);
			}
		}
		public GTEquippedResearch hasResearchCompletingOnDay(int aDay) {
			for(int i = 0;i<rndParts.Count;i++) {
				if(rndParts[i].dayOfCompletion==aDay) {
					return rndParts[i];
				}
			}
			return null;

		}
		public void replaceCar(CarLibraryRecord aCar) {
			carLibRecord = aCar;
			rndParts = new List<GTEquippedResearch>();
		}
		public GTEquippedResearch partBeingResearched {
			get {
				for(int i = 0;i<rndParts.Count;i++) {
					if(rndParts[i].daysOfResearchRemaining>0) {
						return rndParts[i];
					}
				}
				return null;
			}
		}
		public int nitroCapacity {
			get {
				int c = 1;
				for(int i = 0;i<rndParts.Count;i++) {
					c += rndParts[i].researchRow._effectonnitrocapacity*rndParts[i].level;
				}
				return c;
			}
		}
		public int hasDRS {
			get {
				float drsLevel = 0f;
				for(int i = 0;i<rndParts.Count;i++) {
					drsLevel += rndParts[i].researchRow._percentofdrswingtoremove*rndParts[i].level;
				}
				if(drsLevel==0.33f) {
					return 1;
				}
				if(drsLevel==0.66f) {
					return 2;
				}
				if(drsLevel==0.99f) {
					return 3;
				}
				return 0;
			}
		}
		public int carMaxSpeed {
			get {
				float maxSpeed = this.carLibRecord.carMaxSpeed;
				return Convert.ToInt32(maxSpeed+this.getResearchEffectOnMaxSpeed());
			} 
		}
		public float carDrag {
			get {
				float drag = this.carLibRecord.carDrag;
				for(int i = 0;i<rndParts.Count;i++) {
					drag += rndParts[i].researchRow._bodyaerodragreduce*rndParts[i].level;
				}
				return drag;
			}
		}
		public string carDragString {
			get {
				if(carDrag>0.8f) {
					return "Very Poor";
				}
				if(carDrag>0.7f) {
					return "Poor";
				}
				if(carDrag>0.4f) {
					return "Average";
				}
				if(carDrag>0.3f) {
					return "Good";
				}
				if(carDrag>0.2f) {
					return "Excellent";
				}
				return "Amazing";
			}	
		}
		

		public float nitroStrength {
			get {
				float c = 0f;
				for(int i = 0;i<rndParts.Count;i++) {
					c += rndParts[i].researchRow._effectonnitrodurability*rndParts[i].level;
				}
				return c;
			}
		}
		public float nitroFuel {
			get {
				float c = 0f;
				for(int i = 0;i<rndParts.Count;i++) {
					c += rndParts[i].researchRow._effectonnitrofuel*rndParts[i].level;
				}
				return c;
			}
		}
			
		public void initRandomResearch(int aCount) {
			int i = 0;
			while(i<aCount) {
			//	RnDRow part = RnD.Instance.Rows[UnityEngine.Random.Range(0,RnD.Instance.Rows.Count)];
			//	addPartToCar(part,ChampionshipSeason.ACTIVE_SEASON.getTeamFromCar(this));
				RnDRow part = RnD.Instance.Rows[10];
				addPartToCar(part,ChampionshipSeason.ACTIVE_SEASON.getTeamFromCar(this));


				i++;
			} 
		}
		public void initLibraryValues(IRDSDrivetrain aDriveTrain,IRDSCarControllerAI aAI,RacingAI aRacingAI) {
			float hpToKW = 745.699872f;
			aDriveTrain.SetMaxPower(carHP*hpToKW);
			aDriveTrain.SetPowerRPM(this.carLibRecord.carHPRPM);
	
			aDriveTrain.SetMaxTorque(this.carTorque);
			aDriveTrain.SetTorqueRPM(this.carLibRecord.carTorqueRPM);
			aDriveTrain.ShiftSpeed = this.shiftSpeed;
			aAI.spdLimit = (float) this.carMaxSpeed; 
			aRacingAI.nitrosRemaining = (byte) this.nitroCapacity;
		//	aDriveTrain.SetEngineOrientation(Vector3.up);
 
		}
		public void applyResearchToCar(IRDSDrivetrain aDriveTrain,IRDSCarControllerAI aAI,RacingAI aRacingAI) {
			for(int i = 0;i<this.rndParts.Count;i++) {
				rndParts[i].applyPartToCar(aDriveTrain,aAI,aRacingAI);
			}
		}
		public GTEquippedResearch hasPart(RnDRow aRow)   {

			for(int j=0;j<rndParts.Count;j++) {
				if(rndParts[j].researchRow==aRow&&rndParts[j].level>0) {
					return rndParts[j];
				}
			}

			return null;
		}
		public bool hasPreRequisiteParts(string aPrerequisites) {
			if(aPrerequisites==null||aPrerequisites.Length==0) {
				return true;
			}
			string[] split = aPrerequisites.Split(new char[] {','});
			for(int i = 0;i<split.Length;i++) {
				for(int j=0;j<rndParts.Count;j++) {
					if(rndParts[j].researchRow._partname==split[i]&&rndParts[j].researchRow._maxlevelstounlock==rndParts[j].activeLevel) {
						return true;
					}
				}
			} 
			return false;
		}


		public bool forceAddPartToCar(GTEquippedResearch aResearch) {
			for(int i = 0;i<rndParts.Count;i++) {
				if(rndParts[i].researchRow==aResearch.researchRow) {
					return false;
				}
			}
			GTEquippedResearch r = new GTEquippedResearch(aResearch.researchRow);
			r.dayOfCompletion = -1;
			rndParts.Add(r);
			
			return true;
		}
		public GTEquippedResearch addPartToCar(RnDRow aRow,GTTeam aTeam) {
		//	if(aRow._par
			for(int i = 0;i<rndParts.Count;i++) {
				if(this.hasPreRequisiteParts(aRow._partprerequisites)) {
					if(rndParts[i].researchRow==aRow) {
						if(rndParts[i].level<aRow._maxlevelstounlock) {
							rndParts[i].level++;
							return rndParts[i];
						} else {
							return null;
						}
					}
				}
			}
			if(this.hasPreRequisiteParts(aRow._partprerequisites)) {
				rndParts.Add(new GTEquippedResearch(aRow));
				return rndParts[rndParts.Count-1];
			} else {
				return null;
			}
		}
		public IRDSCarControllerAI carReference {
			get {
				return carLibRecord.carPrefab.GetComponent<IRDSCarControllerAI>();
			}
		}
		public int carHP {
			get {
				return Convert.ToInt32(this.carLibRecord.carHP)+this.getResearchEffectOnHP();
			}
		}
		public int carTorque {
			get {
				return Convert.ToInt32(this.carLibRecord.carTorque)+this.getResearchEffectOnTorque();
			}
		}
		public int getResearchEffectOnHP() {
			int r = 0;
			for(int i = 0;i<this.rndParts.Count;i++) {
				if(rndParts[i].researchRow._effectonhp>0) {
					r+=Convert.ToInt32(rndParts[i].researchRow._effectonhp*rndParts[i].activeLevel);
				}
			}
			return r;
		}
		public float shiftSpeed {
			get {
				return this.carLibRecord.carShiftSpeed+getResearchEffectOnShiftSpeed();
			}
		}
		public float getResearchEffectOnShiftSpeed() {
			float shiftSpeed = 0f;
			for(int i = 0;i<this.rndParts.Count;i++) {
				if(rndParts[i].researchRow._effectonshiftspeed!=0f) {
					shiftSpeed+=Convert.ToInt32(rndParts[i].researchRow._effectonshiftspeed*rndParts[i].activeLevel);
				}
			}
			return shiftSpeed;
		}
		public int getResearchEffectOnTorque() {
			int r = 0;
			for(int i = 0;i<this.rndParts.Count;i++) {
				if(rndParts[i].researchRow._effectontorque>0) {
					r+=Convert.ToInt32(rndParts[i].researchRow._effectontorque*rndParts[i].activeLevel);
				}
			}
			return r; 
		}

		public int getResearchEffectOnNitros() {
			int r = 0;
			for(int i = 0;i<this.rndParts.Count;i++) {
				if(rndParts[i].researchRow._effectonnitrocapacity>0) {
					r+=Convert.ToInt32(rndParts[i].researchRow._effectonnitrocapacity*rndParts[i].activeLevel);
				}
			}
			return r; 
		}
		
		public float getResearchEffectOnDrag() {
			float turboPSI = 0f;
			for(int i = 0;i<rndParts.Count;i++) {
				turboPSI += rndParts[i].researchRow._bodyaerodragreduce*rndParts[i].activeLevel;
			}
			return turboPSI;
		}
		public float getResearchEffectOnTurboPSI() {
			float turboPSI = 0f;
			for(int i = 0;i<rndParts.Count;i++) {
				turboPSI += rndParts[i].researchRow._effectonturbopsi*rndParts[i].activeLevel;
			}
			return turboPSI;
		}
		public float getResearchEffectOnMaxSpeed() {
			float maxSpeed = 0f;
			for(int i = 0;i<rndParts.Count;i++) {
				maxSpeed += rndParts[i].researchRow._maxspeedadd*rndParts[i].activeLevel;
			}
			return Convert.ToInt32(maxSpeed);
		}


	}
}

