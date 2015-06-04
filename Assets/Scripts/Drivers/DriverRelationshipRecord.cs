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
namespace Drivers
{
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
	
	public class DriverRelationshipRecord
	{
		public GTDriver record;
		public int currentRelationshipValue;
		public int load_id;
		public int load_relationship_value;
		public DriverRelationshipRecord (GTDriver aRecord,int aRelationshipValue)
		{
			init(aRecord,aRelationshipValue);
		}
		public DriverRelationshipRecord (string aDriverID,int aRelationshipValue)
		{
			load_id = Convert.ToInt32(aDriverID);
			load_relationship_value = aRelationshipValue;

		}
		public void fullInit() {
			for(int i = 0;i<GTDriver.allDrivers.Count;i++) {
				if(GTDriver.allDrivers[i].id==load_id) {
					init(GTDriver.allDrivers[i],load_relationship_value);
				}
			}
		}
		public void init(GTDriver aRecord,int aRelationshipValue)
		{
			record = aRecord;
			currentRelationshipValue = aRelationshipValue - record.demandingReputation;
		}


		public DriverInterestInfo interest {
			get {
				if(currentRelationshipValue<-200) {
					return new DriverInterestInfo("Not Interested",0f,0f,0,0f);
				}
				if(currentRelationshipValue<-100) {
					return new DriverInterestInfo("Relecutant",record.contract.payPerRace*2f,1f,1,record.contract.payPerRace*2f);
				}
				if(currentRelationshipValue<-50) {
					if(currentRelationshipValue<-75)
						return new DriverInterestInfo("Tempted",record.contract.payPerRace*1.5f,0.90f,1,record.contract.payPerRace*1.5f); else {
						return new DriverInterestInfo("Tempted",record.contract.payPerRace*1.5f,0.95f,2,record.contract.payPerRace*1.5f);
					} 
				}	
				if(currentRelationshipValue<-25) {
					if(currentRelationshipValue<-50)
						return new DriverInterestInfo("Tempted",record.contract.payPerRace*1.25f,0.9f,1,record.contract.payPerRace*1.25f); else {
						return new DriverInterestInfo("Tempted",record.contract.payPerRace*1.25f,0.95f,2,record.contract.payPerRace*1.25f);
					}
				}

				return new DriverInterestInfo("Interested",record.contract.payPerRace,0.9f,3,record.contract.payPerRace*0.75f);
				
				
			}
		}
	}
	
	
}

