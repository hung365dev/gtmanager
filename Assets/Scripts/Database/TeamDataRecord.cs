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
using Cars;
using UnityEngine;
using Drivers;


namespace Database
{
	[System.Serializable]
	public class TeamDataRecord
	{
		public int id;
		public string name;
		public string description;
		public GTCar carA;
		public GTCar carB;
		public GTDriver driverA;
		public GTDriver driverB;

		public Color teamColor;
		public int startLeague;
		
		public int reputation;
		public TeamDataRecord (TeamNamesRow aTeamNameRow)
		{
			id = aTeamNameRow._id;
			name = aTeamNameRow._teamname;
			description = aTeamNameRow._teamdescription;
			teamColor = new Color(aTeamNameRow._teamcolorr/255f,aTeamNameRow._teamcolorg/255f,aTeamNameRow._teamcolorb/255f);
			startLeague = aTeamNameRow._startleague;
			carA = new GTCar (aTeamNameRow._startingcar1);
			reputation = aTeamNameRow._reputation;
			

			driverA = new GTDriver (); 
			DriverLibraryRecord driverRecord = DriverLibrary.REF.getAvailableDriver();
			driverRecord.assignedTeam = id;
			driverA.initFromLibrary(driverRecord);
			carB = new GTCar (aTeamNameRow._startingcar2);

			driverB = new GTDriver ();
			driverRecord = DriverLibrary.REF.getAvailableDriver();
			driverB.initFromLibrary(driverRecord);
			driverRecord.assignedTeam = id;

		}


	}
}

