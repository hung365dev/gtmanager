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
using Database;
using Utils;
using UnityEngine;


namespace Drivers
{
	public class GTDriverBase
	{
		public int id;
		public string name;
		public int stamina;
		public float aggressivenessOnBrake;
		public float speedSteeringFactor;
		public float lookAheadFactor;
		public float lookAheadConstant;
		public float corneringSpeedFactor;
		public float maxDriftAngle;
		public float driftingThrottleFactor;
		public float steeringDriftFactor;
		public float sideAvoidingFactor;
		public float collisionSideFactor;
		public float overtakeFactor;
		public float humanError;
		public float overtakeSpeedDifference;
		public float overtakeOffsetIncrementMin;
		public float overtakeOffsetIncrementMax;
		public float backToLineIncrement;
		public float shiftFactor;
		public float shiftUpFactor;
		public float tyreChangePercentage;
		public float fuelLoadPercentage;
		public float fullAccelMargin;
		public float frontCollDist;
		public float backCollDist;
		public float sideMargin;
		public float heightMargin;
		public float lengthMargin;
		public float SIDE_MARGIN;
		public float offtrackThrottleMultiplier;
		public float jumpThrottleMultiplier;
		public float jumpThrottleTime;
		public float agressiveMultiplier;
		public float sponsorFriendliness;
		public int demandingReputation;
		public int positionDemanded;
		public DriverLibraryRecord record;
		public void initFromLibrary(DriverLibraryRecord aLibraryRecord) {
			record = aLibraryRecord;
  
			GTDriver.allDrivers.Add((GTDriver) this);
			this.id = aLibraryRecord.id;
			this.aggressivenessOnBrake = aLibraryRecord.aggressivenessOnBrake;
			this.agressiveMultiplier = aLibraryRecord.agressiveMultiplier;
			this.backCollDist = aLibraryRecord.backCollDist;
			this.backToLineIncrement = aLibraryRecord.backToLineIncrement;
			this.collisionSideFactor = aLibraryRecord.collisionSideFactor;
			this.corneringSpeedFactor = aLibraryRecord.corneringSpeedFactor;
			this.driftingThrottleFactor = aLibraryRecord.driftingThrottleFactor;
			this.name = aLibraryRecord.driverName;
			this.frontCollDist = aLibraryRecord.frontCollDist;
			this.fuelLoadPercentage = aLibraryRecord.fuelLoadPercentage;
			this.fullAccelMargin = aLibraryRecord.fullAccelMargin;
			this.heightMargin = aLibraryRecord.heightMargin;
			this.humanError = aLibraryRecord.humanError;
			this.jumpThrottleMultiplier = aLibraryRecord.jumpThrottleMultiplier;
			this.jumpThrottleTime = aLibraryRecord.jumpThrottleTime;
			this.lengthMargin = aLibraryRecord.lengthMargin;
			this.lookAheadConstant = aLibraryRecord.lookAheadConstant;
			this.lookAheadFactor = aLibraryRecord.lookAheadFactor;
			this.maxDriftAngle = aLibraryRecord.maxDriftAngle;
			this.offtrackThrottleMultiplier = aLibraryRecord.offtrackThrottleMultiplier;
			this.overtakeFactor = aLibraryRecord.overtakeFactor;
			this.overtakeOffsetIncrementMax = aLibraryRecord.overtakeOffsetIncrementMax;
			this.overtakeOffsetIncrementMin = aLibraryRecord.overtakeOffsetIncrementMin;
			this.overtakeSpeedDifference = aLibraryRecord.overtakeSpeedDifference;
			this.shiftFactor = aLibraryRecord.shiftFactor;
			this.shiftUpFactor = aLibraryRecord.shiftUpFactor;
			this.SIDE_MARGIN = aLibraryRecord.SIDE_MARGIN;
			this.sideAvoidingFactor = aLibraryRecord.sideAvoidingFactor;
			this.sideMargin = aLibraryRecord.sideMargin;
			this.speedSteeringFactor = aLibraryRecord.speedSteeringFactor;
			this.steeringDriftFactor = aLibraryRecord.steeringDriftFactor;
			this.tyreChangePercentage = aLibraryRecord.tyreChangePercentage;

			this.sponsorFriendliness = aLibraryRecord.sponsorAppeal;

			this.demandingReputation = aLibraryRecord.demandsReputation;
		}
		

		public virtual string SaveString() {
			return Base64.Base64Encode(id+"|"+name+"|"+stamina+"|"+this.aggressivenessOnBrake+"|"+this.speedSteeringFactor+"|"+lookAheadFactor+"|"+lookAheadConstant+"|"+this.corneringSpeedFactor+
			"|"+this.maxDriftAngle+"|"+driftingThrottleFactor+"|"+steeringDriftFactor+"|"+sideAvoidingFactor+"|"+collisionSideFactor+"|"+overtakeFactor+"|"+this.humanError+"|"+
			this.overtakeSpeedDifference+"|"+this.overtakeOffsetIncrementMin+"|"+this.overtakeOffsetIncrementMax+"|"+this.backToLineIncrement+"|"+
			this.shiftFactor+"|"+this.shiftUpFactor+"|"+this.tyreChangePercentage+"|"+this.fuelLoadPercentage+"|"+fullAccelMargin+"|"+frontCollDist+"|"+backCollDist+"|"+
			this.sideMargin+"|"+this.heightMargin+"|"+lengthMargin+"|"+SIDE_MARGIN+"|"+offtrackThrottleMultiplier+"|"+jumpThrottleMultiplier+"|"+jumpThrottleTime+"|"+
			this.agressiveMultiplier+"|"+sponsorFriendliness+"|"+demandingReputation+"|"+this.positionDemanded);
			
		}
		public virtual void FromString(string aString) {
			string[] all = Base64.Base64Decode(aString).Split(new char[] {'|'});
			id = Convert.ToInt32(all[0]);
			name = all[1];
			stamina = Convert.ToInt32(all[2]);
			this.aggressivenessOnBrake = (float) Convert.ToDouble(all[3]);
			this.speedSteeringFactor = (float) Convert.ToDouble(all[4]);
			this.lookAheadFactor = (float) Convert.ToDouble(all[5]);

			this.lookAheadConstant = (float) Convert.ToDouble(all[6]);
			this.corneringSpeedFactor = (float) Convert.ToDouble(all[7]);
			this.maxDriftAngle = (float) Convert.ToDouble(all[8]);
			driftingThrottleFactor = (float) Convert.ToDouble(all[9]);
			steeringDriftFactor = (float) Convert.ToDouble(all[10]);
			this.sideAvoidingFactor = (float) Convert.ToDouble(all[11]);
			this.collisionSideFactor = (float) Convert.ToDouble(all[12]);
			this.overtakeFactor = (float) Convert.ToDouble(all[13]);
			this.humanError = (float) Convert.ToDouble (all[14]);
			this.overtakeSpeedDifference = (float) Convert.ToDouble(all[15]);
			this.overtakeOffsetIncrementMin = (float) Convert.ToDouble(all[16]);
			this.overtakeOffsetIncrementMax = (float) Convert.ToDouble(all[17]);
			this.backToLineIncrement = (float) Convert.ToDouble(all[18]);
			this.shiftFactor = (float) Convert.ToDouble(all[19]);
			this.shiftUpFactor = (float) Convert.ToDouble(all[20]);
			this.tyreChangePercentage = (float) Convert.ToDouble(all[21]);
			this.fuelLoadPercentage = (float) Convert.ToDouble (all[22]);
			this.fullAccelMargin = (float) Convert.ToDouble(all[23]);
			this.frontCollDist = (float) Convert.ToDouble(all[24]);
			this.backCollDist = (float) Convert.ToDouble(all[25]);
			this.sideMargin = (float) Convert.ToDouble(all[26]);
			this.heightMargin = (float) Convert.ToDouble(all[27]);
			this.lengthMargin = (float) Convert.ToDouble(all[28]);
			this.SIDE_MARGIN = (float) Convert.ToDouble(all[29]);
			this.offtrackThrottleMultiplier = (float) Convert.ToDouble(all[30]);
			this.jumpThrottleMultiplier = (float) Convert.ToDouble(all[31]);
			this.jumpThrottleTime = (float) Convert.ToDouble(all[32]);
			this.agressiveMultiplier = (float) Convert.ToDouble(all[33]);
			this.sponsorFriendliness = (float) Convert.ToDouble(all[34]);
			this.demandingReputation = Convert.ToInt32(all[35]);
			this.positionDemanded = Convert.ToInt32(all[36]);


			for(int i = 0;i<DriverLibrary.REF.drivers.Count;i++) {
				if(DriverLibrary.REF.drivers[i].id==this.id) {
					this.record = DriverLibrary.REF.drivers[i];
				}
			}
			
			GTDriver.allDrivers.Add((GTDriver) this);
			if(GTDriver.allDrivers.Count>39) {
				Debug.LogError("Too many drivers");
			}
		}
		public string sponsorAppealString { 
			get {
				if(this.sponsorFriendliness<0.25f) {
					return "Toxic";
				}
				if(this.sponsorFriendliness<0.5f) {
					return "Awful";
				}
				if(this.sponsorFriendliness<0.75f) {
					return "Very Poor";
				}
				if(this.sponsorFriendliness<1f) {
					return "Poor";
				}
				if(this.sponsorFriendliness<1.25f) {
					return "Average";
				}
				if(this.sponsorFriendliness<1.5f) {
					return "Good";
				}
				return "Excellent";
			}
		}
		public string brakingAggressionString {
			get {
				if(this.aggressivenessOnBrake>1.5f) {
					return "Very Late Braker";
				} else 
					if(this.aggressivenessOnBrake>1.4f) {
					return "Late Braker";
				} else 
					if(this.aggressivenessOnBrake>1.2f) {
					return "Average";
				} else 
					if(this.aggressivenessOnBrake>1.1f) {
					return "Early Braker";
				} else 
					if(this.aggressivenessOnBrake>1f) {
					return "Very Early Braker";
				} else {
					return "Over Cautious";
				}
			}
		}

		public string corneringSkillString {
			get {
				if(this.corneringSpeedFactor<1.8f) {
					return "Terribly Slow";
				}
				if(this.corneringSpeedFactor<1.9f) {
					return "Very Slow";
				}
				if(this.corneringSpeedFactor<2f) {
					return "Average";
				}
				if(this.corneringSpeedFactor<2.1f) {
					return "Fast";
				}
				if(this.corneringSpeedFactor<2.4f) {
					return "Very Fast";
				}
				return "Wreckless!";
			}
		}

		public string errorProneString {
			get {
				if(this.humanError<0.002) {
					return "Faultless";
				}
				if(this.humanError<0.03) {
					return "Reliable";
				}
				if(this.humanError<0.06) {
					return "Average";
				}
				if(this.humanError<0.1) {
					return "Unreliable";
				}
				return "Dangerous";
			}
		}
		public string staminaString {
			get {
				return "Stamina";
			}
		}
		public string overtakingString {
			get {
				if(this.overtakeSpeedDifference<-10) {
					return "Aggressive Overtaker";
				}
				
				if(this.overtakeSpeedDifference<-8) {
					return "Fast Overtaker";
				}
				if(this.overtakeSpeedDifference<-8) {
					return "Average Overtaker";
				}
				if(this.overtakeSpeedDifference<-4) {
					return "Cautious Overtaker";
				}
				return "Poor Overtaker";
				
			}
		}


	}
}

