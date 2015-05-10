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


namespace Drivers
{
	public class GTDriverBase
	{
		public string driverName;
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

		public void initFromLibrary(DriverLibraryRecord aLibraryRecord) {

			this.aggressivenessOnBrake = aLibraryRecord.aggressivenessOnBrake;
			this.agressiveMultiplier = aLibraryRecord.agressiveMultiplier;
			this.backCollDist = aLibraryRecord.backCollDist;
			this.backToLineIncrement = aLibraryRecord.backToLineIncrement;
			this.collisionSideFactor = aLibraryRecord.collisionSideFactor;
			this.corneringSpeedFactor = aLibraryRecord.corneringSpeedFactor;
			this.driftingThrottleFactor = aLibraryRecord.driftingThrottleFactor;
			this.driverName = aLibraryRecord.driverName;
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
				if(this.corneringSpeedFactor<1f) {
					return "Terribly Slow";
				}
				if(this.corneringSpeedFactor<1.25f) {
					return "Very Slow";
				}
				if(this.corneringSpeedFactor<1.5f) {
					return "Average";
				}
				if(this.corneringSpeedFactor<1.75f) {
					return "Fast";
				}
				if(this.corneringSpeedFactor<2f) {
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
				return "Unknown";
			}
		}


	}
}

