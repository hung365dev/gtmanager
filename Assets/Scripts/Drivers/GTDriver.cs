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
using Cars;
using Database;
using UnityEngine;
using System.Collections.Generic;
using Utils;


namespace Drivers
{
	[System.Serializable]
	public class GTDriver : GTDriverWithContract
	{
		public GTCar assignedCar;
		public int championshipPoints;
		public int lastRacePoints;

		public static List<GTDriver> allDrivers = new List<GTDriver>();
		public GTDriver ()
		{
		}
		public override string ToString() {
			return Base64.Base64Encode(base.ToString ()+"|"+championshipPoints+"|"+lastRacePoints+"|"+contract.bonusPerRace+"|"+contract.payPerRace+"|"+contract.remainingOnContract+"|");
		}

		public override void FromString(string aString) {
			string s = Base64.Base64Decode(aString);
			string[] split = s.Split (new char[] {'|'});
			base.FromString(split[0]);
			championshipPoints = Convert.ToInt32(split[1]);
			this.lastRacePoints = Convert.ToInt32(split[2]);
			this.contract.bonusPerRace = Convert.ToInt32(split[3]);
			this.contract.payPerRace = Convert.ToInt32(split[4]);
			this.contract.remainingOnContract = Convert.ToInt32(split[5]);
		}
		public static float percentOfGoodnessBrakingValue(float aValue) {
			float worstBraking = brakingAggressionLimit(false);;
			float bestBraking = brakingAggressionLimit(true);
			return (aValue-worstBraking)/(bestBraking-worstBraking);
		}
		public static float percentOfGoodnessCorneringValue(float aValue) {
			float worst = corneringSpeedLimit(false);
			float best = corneringSpeedLimit(true);
			return (aValue-worst)/(best-worst);
		}
		public static float percentOfGoodnessErrorValue(float aValue) {
			float worst = errorLimit(true);
			float best = errorLimit(false);
			float divided = ((aValue-worst)/(best-worst));
			float toReturn = 1-divided;
			return toReturn;
		}
		public static float percentOfGoodnessOvertakingValue(float aValue) {
			float worst = overtakingLimit(true);
			float best = overtakingLimit(false);
			return (aValue-worst)/(best-worst);
		}
		public static float percentOfGoodnessSponsorValue(float aValue) {
			float worst = sponsorLimit(false);
			float best = sponsorLimit(true);
			return (aValue-worst)/(best-worst);
		}

		public static float brakingAggressionLimit(bool aMax) {
			float limit = float.MaxValue;
			if(aMax) {
				limit = float.MinValue;
			}
			for(int i =0;i<allDrivers.Count;i++) {
				if(aMax) {
					if(allDrivers[i].aggressivenessOnBrake>limit) {
						limit = allDrivers[i].aggressivenessOnBrake;
					}
				} else if(allDrivers[i].aggressivenessOnBrake<limit) {
					limit = allDrivers[i].aggressivenessOnBrake;
				}
		    }
			return limit;
		}
		public static float corneringSpeedLimit(bool aMax) {
			float limit = float.MaxValue;
			if(aMax) {
				limit = float.MinValue;
			}
			for(int i =0;i<allDrivers.Count;i++) {
				if(aMax) {
					if(allDrivers[i].corneringSpeedFactor>limit) {
						limit = allDrivers[i].corneringSpeedFactor;
					}
				} else if(allDrivers[i].corneringSpeedFactor<limit) {
					limit = allDrivers[i].corneringSpeedFactor;
				}
			}
			return limit;
		}
		public static float errorLimit(bool aMax) {
			float limit = float.MaxValue;
			if(aMax) {
				limit = float.MinValue;
			}
			for(int i =0;i<allDrivers.Count;i++) {
				if(aMax) {
					if(allDrivers[i].humanError>limit) {
						limit = allDrivers[i].humanError;
					}
				} else if(allDrivers[i].humanError<limit) {
					limit = allDrivers[i].humanError;
				}
			}
			return limit;
		}
		public static float overtakingLimit(bool aMax) {
			float limit = float.MaxValue;
			if(aMax) {
				limit = float.MinValue;
			}
			for(int i =0;i<allDrivers.Count;i++) {
				if(aMax) {
					if(allDrivers[i].overtakeSpeedDifference>limit) {
						limit = allDrivers[i].overtakeSpeedDifference;
					}
				} else if(allDrivers[i].overtakeSpeedDifference<limit) {
					limit = allDrivers[i].overtakeSpeedDifference;
				}
			}
			return limit;
		}
		public static float sponsorLimit(bool aMax) {
			float limit = float.MaxValue;
			if(aMax) {
				limit = float.MinValue;
			}
			for(int i =0;i<allDrivers.Count;i++) {
				if(aMax) {
					if(allDrivers[i].sponsorFriendliness>limit) {
						limit = allDrivers[i].sponsorFriendliness;
					}
				} else if(allDrivers[i].sponsorFriendliness<limit) {
					limit = allDrivers[i].sponsorFriendliness;
				}
			}
			return limit;
		}
	}

}

