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
	public class RaceTracksRow : IGoogleFuRow
	{
		public int _id;
		public string _trackname;
		public string _scenename;
		public string _texturename;
		public string _description;
		public int _divisionsavailablelow;
		public int _divisionsavailablehigh;
		public RaceTracksRow(string __id, string __trackname, string __scenename, string __texturename, string __description, string __divisionsavailablelow, string __divisionsavailablehigh) 
		{
			{
			int res;
				if(int.TryParse(__id, out res))
					_id = res;
				else
					Debug.LogError("Failed To Convert id string: "+ __id +" to int");
			}
			_trackname = __trackname;
			_scenename = __scenename;
			_texturename = __texturename;
			_description = __description;
			{
			int res;
				if(int.TryParse(__divisionsavailablelow, out res))
					_divisionsavailablelow = res;
				else
					Debug.LogError("Failed To Convert divisionsavailablelow string: "+ __divisionsavailablelow +" to int");
			}
			{
			int res;
				if(int.TryParse(__divisionsavailablehigh, out res))
					_divisionsavailablehigh = res;
				else
					Debug.LogError("Failed To Convert divisionsavailablehigh string: "+ __divisionsavailablehigh +" to int");
			}
		}

		public int Length { get { return 7; } }

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
					ret = _trackname.ToString();
					break;
				case 2:
					ret = _scenename.ToString();
					break;
				case 3:
					ret = _texturename.ToString();
					break;
				case 4:
					ret = _description.ToString();
					break;
				case 5:
					ret = _divisionsavailablelow.ToString();
					break;
				case 6:
					ret = _divisionsavailablehigh.ToString();
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
				case "trackname":
					ret = _trackname.ToString();
					break;
				case "scenename":
					ret = _scenename.ToString();
					break;
				case "texturename":
					ret = _texturename.ToString();
					break;
				case "description":
					ret = _description.ToString();
					break;
				case "divisionsavailablelow":
					ret = _divisionsavailablelow.ToString();
					break;
				case "divisionsavailablehigh":
					ret = _divisionsavailablehigh.ToString();
					break;
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "id" + " : " + _id.ToString() + "} ";
			ret += "{" + "trackname" + " : " + _trackname.ToString() + "} ";
			ret += "{" + "scenename" + " : " + _scenename.ToString() + "} ";
			ret += "{" + "texturename" + " : " + _texturename.ToString() + "} ";
			ret += "{" + "description" + " : " + _description.ToString() + "} ";
			ret += "{" + "divisionsavailablelow" + " : " + _divisionsavailablelow.ToString() + "} ";
			ret += "{" + "divisionsavailablehigh" + " : " + _divisionsavailablehigh.ToString() + "} ";
			return ret;
		}
	}
	public sealed class RaceTracks : IGoogleFuDB
	{
		public enum rowIds {
			RACETRACK_1, RACETRACK_2, RACETRACK_3, RACETRACK_4, RACETRACK_5, RACETRACK_6, RACETRACK_7, RACETRACK_8
		};
		public string [] rowNames = {
			"RACETRACK_1", "RACETRACK_2", "RACETRACK_3", "RACETRACK_4", "RACETRACK_5", "RACETRACK_6", "RACETRACK_7", "RACETRACK_8"
		};
		public System.Collections.Generic.List<RaceTracksRow> Rows = new System.Collections.Generic.List<RaceTracksRow>();

		public static RaceTracks Instance
		{
			get { return NestedRaceTracks.instance; }
		}

		private class NestedRaceTracks
		{
			static NestedRaceTracks() { }
			internal static readonly RaceTracks instance = new RaceTracks();
		}

		private RaceTracks()
		{
			Rows.Add( new RaceTracksRow("1",
														"Lower Level1",
														"LowerLevel1",
														"LowerLevel1",
														"ShortDescription",
														"4",
														"4"));
			Rows.Add( new RaceTracksRow("2",
														"Oval Track",
														"OvalTrack",
														"OvalTrack",
														"ShortDescription",
														"3",
														"1"));
			Rows.Add( new RaceTracksRow("3",
														"Race Circuit",
														"RaceCircuit1",
														"RaceCircuit1",
														"ShortDescription",
														"3",
														"1"));
			Rows.Add( new RaceTracksRow("4",
														" Short Snow Track",
														"ShortSnowTrack",
														"ShortSnowTrack",
														"ShortDescription",
														"4",
														"3"));
			Rows.Add( new RaceTracksRow("5",
														"Long Straights",
														"LongStraights",
														"LongStraights",
														"ShortDescription",
														"3",
														"1"));
			Rows.Add( new RaceTracksRow("6",
														"Mini Oval",
														"MiniOval",
														"MiniOval",
														"ShortDescription",
														"4",
														"4"));
			Rows.Add( new RaceTracksRow("7",
														"Hill Track",
														"HillTrack1",
														"HillTrack1",
														"ShortDescription",
														"4",
														"3"));
			Rows.Add( new RaceTracksRow("8",
														"DirtGrassTrack",
														"DirtGrassTrack",
														"DirtGrassTrack",
														"ShortDescription",
														"4",
														"2"));
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
		public RaceTracksRow GetRow(rowIds in_RowID)
		{
			RaceTracksRow ret = null;
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
		public RaceTracksRow GetRow(string in_RowString)
		{
			RaceTracksRow ret = null;
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
