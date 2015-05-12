//----------------------------------------------
//    GoogleFu: Google Doc Unity integration
//         Copyright © 2013 Litteratus
//
//        This file has been auto-generated
//              Do not manually edit
//----------------------------------------------

using UnityEngine;

namespace GoogleFu
{
	[System.Serializable]
	public class TeamNamesRow : IGoogleFuRow
	{
		public int _id;
		public string _teamname;
		public int _startleague;
		public float _teamcolorr;
		public float _teamcolorg;
		public float _teamcolorb;
		public string _teamdescription;
		public string _startingcar1;
		public string _startingcar2;
		public int _reputation;
		public TeamNamesRow(string __id, string __teamname, string __startleague, string __teamcolorr, string __teamcolorg, string __teamcolorb, string __teamdescription, string __startingcar1, string __startingcar2, string __reputation) 
		{
			{
			int res;
				if(int.TryParse(__id, out res))
					_id = res;
				else
					Debug.LogError("Failed To Convert id string: "+ __id +" to int");
			}
			_teamname = __teamname;
			{
			int res;
				if(int.TryParse(__startleague, out res))
					_startleague = res;
				else
					Debug.LogError("Failed To Convert startleague string: "+ __startleague +" to int");
			}
			{
			float res;
				if(float.TryParse(__teamcolorr, out res))
					_teamcolorr = res;
				else
					Debug.LogError("Failed To Convert teamcolorr string: "+ __teamcolorr +" to float");
			}
			{
			float res;
				if(float.TryParse(__teamcolorg, out res))
					_teamcolorg = res;
				else
					Debug.LogError("Failed To Convert teamcolorg string: "+ __teamcolorg +" to float");
			}
			{
			float res;
				if(float.TryParse(__teamcolorb, out res))
					_teamcolorb = res;
				else
					Debug.LogError("Failed To Convert teamcolorb string: "+ __teamcolorb +" to float");
			}
			_teamdescription = __teamdescription;
			_startingcar1 = __startingcar1;
			_startingcar2 = __startingcar2;
			{
			int res;
				if(int.TryParse(__reputation, out res))
					_reputation = res;
				else
					Debug.LogError("Failed To Convert reputation string: "+ __reputation +" to int");
			}
		}

		public int Length { get { return 10; } }

		public string this[int i]
		{
		    get
		    {
		        return GetStringDataByIndex(i);
		    }
		}

		public string GetStringDataByIndex( int index )
		{
			string ret = System.String.Empty;
			switch( index )
			{
				case 0:
					ret = _id.ToString();
					break;
				case 1:
					ret = _teamname.ToString();
					break;
				case 2:
					ret = _startleague.ToString();
					break;
				case 3:
					ret = _teamcolorr.ToString();
					break;
				case 4:
					ret = _teamcolorg.ToString();
					break;
				case 5:
					ret = _teamcolorb.ToString();
					break;
				case 6:
					ret = _teamdescription.ToString();
					break;
				case 7:
					ret = _startingcar1.ToString();
					break;
				case 8:
					ret = _startingcar2.ToString();
					break;
				case 9:
					ret = _reputation.ToString();
					break;
			}

			return ret;
		}

		public string GetStringData( string colID )
		{
			var ret = System.String.Empty;
			switch( colID.ToLower() )
			{
				case "id":
					ret = _id.ToString();
					break;
				case "teamname":
					ret = _teamname.ToString();
					break;
				case "startleague":
					ret = _startleague.ToString();
					break;
				case "teamcolorr":
					ret = _teamcolorr.ToString();
					break;
				case "teamcolorg":
					ret = _teamcolorg.ToString();
					break;
				case "teamcolorb":
					ret = _teamcolorb.ToString();
					break;
				case "teamdescription":
					ret = _teamdescription.ToString();
					break;
				case "startingcar1":
					ret = _startingcar1.ToString();
					break;
				case "startingcar2":
					ret = _startingcar2.ToString();
					break;
				case "reputation":
					ret = _reputation.ToString();
					break;
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "id" + " : " + _id.ToString() + "} ";
			ret += "{" + "teamname" + " : " + _teamname.ToString() + "} ";
			ret += "{" + "startleague" + " : " + _startleague.ToString() + "} ";
			ret += "{" + "teamcolorr" + " : " + _teamcolorr.ToString() + "} ";
			ret += "{" + "teamcolorg" + " : " + _teamcolorg.ToString() + "} ";
			ret += "{" + "teamcolorb" + " : " + _teamcolorb.ToString() + "} ";
			ret += "{" + "teamdescription" + " : " + _teamdescription.ToString() + "} ";
			ret += "{" + "startingcar1" + " : " + _startingcar1.ToString() + "} ";
			ret += "{" + "startingcar2" + " : " + _startingcar2.ToString() + "} ";
			ret += "{" + "reputation" + " : " + _reputation.ToString() + "} ";
			return ret;
		}
	}
	public sealed class TeamNames : IGoogleFuDB
	{
		public enum rowIds {
			TEAM_1, TEAM_2, TEAM_3, TEAM_4, TEAM_5, TEAM_6, TEAM_7, TEAM_8, TEAM_9, TEAM_10, TEAM_11, TEAM_12, TEAM_13, TEAM_14, TEAM_15, TEAM_16
		};
		public string [] rowNames = {
			"TEAM_1", "TEAM_2", "TEAM_3", "TEAM_4", "TEAM_5", "TEAM_6", "TEAM_7", "TEAM_8", "TEAM_9", "TEAM_10", "TEAM_11", "TEAM_12", "TEAM_13", "TEAM_14", "TEAM_15", "TEAM_16"
		};
		public System.Collections.Generic.List<TeamNamesRow> Rows = new System.Collections.Generic.List<TeamNamesRow>();

		public static TeamNames Instance
		{
			get { return NestedTeamNames.instance; }
		}

		private class NestedTeamNames
		{
			static NestedTeamNames() { }
			internal static readonly TeamNames instance = new TeamNames();
		}

		private TeamNames()
		{
			Rows.Add( new TeamNamesRow("1",
														"Silver Sparrows",
														"1",
														"192",
														"192",
														"192",
														"Not yet",
														"Koenigsegg",
														"Bugatti Veyron",
														"1000"));
			Rows.Add( new TeamNamesRow("2",
														"Ferraro",
														"1",
														"255",
														"40",
														"0",
														"Not yet",
														"Ferrari Enzo",
														"Zonda",
														"900"));
			Rows.Add( new TeamNamesRow("3",
														"Walliams",
														"1",
														"5",
														"11",
														"118",
														"Not yet",
														"Porsche 911",
														"Aston Martin DB10",
														"850"));
			Rows.Add( new TeamNamesRow("4",
														"Tsunami Racing",
														"1",
														"70",
														"253",
														"52",
														"Not yet",
														"Lamborghini Spider",
														"Lamborghini Spider",
														"825"));
			Rows.Add( new TeamNamesRow("5",
														"Force China",
														"2",
														"240",
														"236",
														"48",
														"Not yet",
														"Nissan GTR",
														"Ford GT40",
														"900"));
			Rows.Add( new TeamNamesRow("6",
														"USGT",
														"2",
														"12",
														"60",
														"160",
														"Not yet",
														"Audi TT",
														"Aston Martin DB10",
														"800"));
			Rows.Add( new TeamNamesRow("7",
														"Russia Racing",
														"2",
														"136",
														"17",
														"36",
														"Not yet",
														"Ferrari Scagialetti",
														"Porsche 911",
														"750"));
			Rows.Add( new TeamNamesRow("8",
														"Blue Omega",
														"2",
														"55",
														"84",
														"85",
														"Not yet",
														"Mitsubishi",
														"Mitsubishi",
														"700"));
			Rows.Add( new TeamNamesRow("9",
														"Skidmark Racing",
														"3",
														"140",
														"58",
														"24",
														"Not yet",
														"Lexus",
														"Ford Mustang",
														"670"));
			Rows.Add( new TeamNamesRow("10",
														"Piston GT",
														"3",
														"138",
														"147",
														"155",
														"Not yet",
														"BMW 5 Series",
														"Corvette",
														"620"));
			Rows.Add( new TeamNamesRow("11",
														"Panther",
														"3",
														"3",
														"3",
														"3",
														"Not yet",
														"Ford Mondeo",
														"TVR",
														"500"));
			Rows.Add( new TeamNamesRow("12",
														"Super Hans Racing",
														"3",
														"232",
														"167",
														"25",
														"Not yet",
														"Corvette",
														"Lexus",
														"480"));
			Rows.Add( new TeamNamesRow("13",
														"Joe GT",
														"4",
														"24",
														"0",
														"255",
														"Not yet",
														"Ford Focus",
														"Ford Focus",
														"700"));
			Rows.Add( new TeamNamesRow("14",
														"Team Pink",
														"4",
														"223",
														"0",
														"255",
														"Not yet",
														"Mini Cooper",
														"Volkswagen Golf",
														"500"));
			Rows.Add( new TeamNamesRow("15",
														"Test Pilots",
														"4",
														"254",
														"255",
														"0",
														"Not yet",
														"Honda Civic",
														"Volkswagen Golf",
														"400"));
			Rows.Add( new TeamNamesRow("16",
														"Backstreet Racing",
														"4",
														"122",
														"186",
														"191",
														"Not yet",
														"Audi A3",
														"Mini Cooper",
														"300"));
		}
		public IGoogleFuRow GetGenRow(string in_RowString)
		{
			IGoogleFuRow ret = null;
			try
			{
				ret = Rows[(int)System.Enum.Parse(typeof(rowIds), in_RowString)];
			}
			catch(System.ArgumentException) {
				Debug.LogError( in_RowString + " is not a member of the rowIds enumeration.");
			}
			return ret;
		}
		public IGoogleFuRow GetGenRow(rowIds in_RowID)
		{
			IGoogleFuRow ret = null;
			try
			{
				ret = Rows[(int)in_RowID];
			}
			catch( System.Collections.Generic.KeyNotFoundException ex )
			{
				Debug.LogError( in_RowID + " not found: " + ex.Message );
			}
			return ret;
		}
		public TeamNamesRow GetRow(rowIds in_RowID)
		{
			TeamNamesRow ret = null;
			try
			{
				ret = Rows[(int)in_RowID];
			}
			catch( System.Collections.Generic.KeyNotFoundException ex )
			{
				Debug.LogError( in_RowID + " not found: " + ex.Message );
			}
			return ret;
		}
		public TeamNamesRow GetRow(string in_RowString)
		{
			TeamNamesRow ret = null;
			try
			{
				ret = Rows[(int)System.Enum.Parse(typeof(rowIds), in_RowString)];
			}
			catch(System.ArgumentException) {
				Debug.LogError( in_RowString + " is not a member of the rowIds enumeration.");
			}
			return ret;
		}

	}

}
