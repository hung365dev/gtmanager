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

	public class SponsorPlacedRelationshipRecord : SponsorRelationshipRecord
	{
		public ESponsorPosition position;
		public int remaining = 0;
		public float valuePerRace;
		public SponsorPlacedRelationshipRecord (ESponsorPosition aSponsor,SponsorRecord aRecord,float aValuePerRace,int aRacesRemaining) : base(aRecord,0)
		{
		
			position = aSponsor;
			remaining = aRacesRemaining;
			valuePerRace = aValuePerRace;
			
		}
	}

