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
	public class SponsorLibraryRow : IGoogleFuRow
	{
		public int _id;
		public string _sponsorname;
		public int _positiondemanded;
		public float _startpayperrace;
		public string _sponsorlogo;
		public float _becomeinterestedatreputation;
		public float _becomedisinterestedatreputation;
		public SponsorLibraryRow(string __id, string __sponsorname, string __positiondemanded, string __startpayperrace, string __sponsorlogo, string __becomeinterestedatreputation, string __becomedisinterestedatreputation) 
		{
			{
			int res;
				if(int.TryParse(__id, out res))
					_id = res;
				else
					Debug.LogError("Failed To Convert id string: "+ __id +" to int");
			}
			_sponsorname = __sponsorname;
			{
			int res;
				if(int.TryParse(__positiondemanded, out res))
					_positiondemanded = res;
				else
					Debug.LogError("Failed To Convert positiondemanded string: "+ __positiondemanded +" to int");
			}
			{
			float res;
				if(float.TryParse(__startpayperrace, out res))
					_startpayperrace = res;
				else
					Debug.LogError("Failed To Convert startpayperrace string: "+ __startpayperrace +" to float");
			}
			_sponsorlogo = __sponsorlogo;
			{
			float res;
				if(float.TryParse(__becomeinterestedatreputation, out res))
					_becomeinterestedatreputation = res;
				else
					Debug.LogError("Failed To Convert becomeinterestedatreputation string: "+ __becomeinterestedatreputation +" to float");
			}
			{
			float res;
				if(float.TryParse(__becomedisinterestedatreputation, out res))
					_becomedisinterestedatreputation = res;
				else
					Debug.LogError("Failed To Convert becomedisinterestedatreputation string: "+ __becomedisinterestedatreputation +" to float");
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
					ret = _sponsorname.ToString();
					break;
				case 2:
					ret = _positiondemanded.ToString();
					break;
				case 3:
					ret = _startpayperrace.ToString();
					break;
				case 4:
					ret = _sponsorlogo.ToString();
					break;
				case 5:
					ret = _becomeinterestedatreputation.ToString();
					break;
				case 6:
					ret = _becomedisinterestedatreputation.ToString();
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
				case "sponsorname":
					ret = _sponsorname.ToString();
					break;
				case "positiondemanded":
					ret = _positiondemanded.ToString();
					break;
				case "startpayperrace":
					ret = _startpayperrace.ToString();
					break;
				case "sponsorlogo":
					ret = _sponsorlogo.ToString();
					break;
				case "becomeinterestedatreputation":
					ret = _becomeinterestedatreputation.ToString();
					break;
				case "becomedisinterestedatreputation":
					ret = _becomedisinterestedatreputation.ToString();
					break;
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "id" + " : " + _id.ToString() + "} ";
			ret += "{" + "sponsorname" + " : " + _sponsorname.ToString() + "} ";
			ret += "{" + "positiondemanded" + " : " + _positiondemanded.ToString() + "} ";
			ret += "{" + "startpayperrace" + " : " + _startpayperrace.ToString() + "} ";
			ret += "{" + "sponsorlogo" + " : " + _sponsorlogo.ToString() + "} ";
			ret += "{" + "becomeinterestedatreputation" + " : " + _becomeinterestedatreputation.ToString() + "} ";
			ret += "{" + "becomedisinterestedatreputation" + " : " + _becomedisinterestedatreputation.ToString() + "} ";
			return ret;
		}
	}
	public sealed class SponsorLibrary : IGoogleFuDB
	{
		public enum rowIds {
			Sponsor_1, Sponsor_2, Sponsor_3, Sponsor_4, Sponsor_5, Sponsor_6, Sponsor_7, Sponsor_8, Sponsor_9, Sponsor_10, Sponsor_11, Sponsor_12, Sponsor_13, Sponsor_14, Sponsor_15, Sponsor_16, Sponsor_17, Sponsor_18, Sponsor_19, Sponsor_20, 
			Sponsor_21, Sponsor_22, Sponsor_23, Sponsor_24, Sponsor_25, Sponsor_26, Sponsor_27, Sponsor_28, Sponsor_29, Sponsor_30, Sponsor_31, Sponsor_32
		};
		public string [] rowNames = {
			"Sponsor_1", "Sponsor_2", "Sponsor_3", "Sponsor_4", "Sponsor_5", "Sponsor_6", "Sponsor_7", "Sponsor_8", "Sponsor_9", "Sponsor_10", "Sponsor_11", "Sponsor_12", "Sponsor_13", "Sponsor_14", "Sponsor_15", "Sponsor_16", "Sponsor_17", "Sponsor_18", "Sponsor_19", "Sponsor_20", 
			"Sponsor_21", "Sponsor_22", "Sponsor_23", "Sponsor_24", "Sponsor_25", "Sponsor_26", "Sponsor_27", "Sponsor_28", "Sponsor_29", "Sponsor_30", "Sponsor_31", "Sponsor_32"
		};
		public System.Collections.Generic.List<SponsorLibraryRow> Rows = new System.Collections.Generic.List<SponsorLibraryRow>();

		public static SponsorLibrary Instance
		{
			get { return NestedSponsorLibrary.instance; }
		}

		private class NestedSponsorLibrary
		{
			static NestedSponsorLibrary() { }
			internal static readonly SponsorLibrary instance = new SponsorLibrary();
		}

		private SponsorLibrary()
		{
			Rows.Add( new SponsorLibraryRow("1",
														"John Wolf",
														"3",
														"5000",
														"logo_howlwolf",
														"50",
														"800"));
			Rows.Add( new SponsorLibraryRow("2",
														"Wild West Autos",
														"28",
														"2000",
														"logo_wildwestauto",
														"100",
														"50"));
			Rows.Add( new SponsorLibraryRow("3",
														"Yikipedia",
														"20",
														"5000",
														"logo_yikipedia",
														"200",
														"150"));
			Rows.Add( new SponsorLibraryRow("4",
														"Vodagnome",
														"3",
														"5000",
														"logo_quotemark",
														"300",
														"800"));
			Rows.Add( new SponsorLibraryRow("5",
														"Two Diamonds",
														"3",
														"5000",
														"logo_twinarrow",
														"400",
														"800"));
			Rows.Add( new SponsorLibraryRow("6",
														"Tokia",
														"3",
														"5000",
														"logo_tokia",
														"500",
														"800"));
			Rows.Add( new SponsorLibraryRow("7",
														"Terra Monsters",
														"3",
														"5000",
														"logo_terramonsters",
														"600",
														"800"));
			Rows.Add( new SponsorLibraryRow("8",
														"HMAF",
														"3",
														"5000",
														"logo_raf",
														"700",
														"800"));
			Rows.Add( new SponsorLibraryRow("9",
														"Dino",
														"3",
														"5000",
														"logo_dino",
														"800",
														"800"));
			Rows.Add( new SponsorLibraryRow("10",
														"Social Titans",
														"3",
														"5000",
														"logo_socialtitans",
														"900",
														"800"));
			Rows.Add( new SponsorLibraryRow("11",
														"Skull",
														"3",
														"5000",
														"logo_skull",
														"1000",
														"800"));
			Rows.Add( new SponsorLibraryRow("12",
														"Red Pillars",
														"3",
														"5000",
														"logo_redpillars",
														"1100",
														"800"));
			Rows.Add( new SponsorLibraryRow("13",
														"Masters Voice",
														"3",
														"5000",
														"logo_mastersvoice",
														"1200",
														"800"));
			Rows.Add( new SponsorLibraryRow("14",
														"Pineapple",
														"3",
														"5000",
														"logo_pineapple",
														"1300",
														"800"));
			Rows.Add( new SponsorLibraryRow("15",
														"Many Soft",
														"3",
														"5000",
														"logo_manysoft",
														"1400",
														"800"));
			Rows.Add( new SponsorLibraryRow("16",
														"Master Crook",
														"3",
														"5000",
														"logo_mastercrook",
														"1500",
														"800"));
			Rows.Add( new SponsorLibraryRow("17",
														"JS Engineering",
														"3",
														"5000",
														"logo_js",
														"1600",
														"800"));
			Rows.Add( new SponsorLibraryRow("18",
														"Hypnotoad",
														"3",
														"5000",
														"logo_hypnotoad",
														"1700",
														"800"));
			Rows.Add( new SponsorLibraryRow("19",
														"Hedgefunds R Us",
														"3",
														"5000",
														"logo_hedgefund",
														"1800",
														"800"));
			Rows.Add( new SponsorLibraryRow("20",
														"Goggles",
														"3",
														"5000",
														"logo_goggles",
														"1900",
														"800"));
			Rows.Add( new SponsorLibraryRow("21",
														"Fed Up",
														"3",
														"5000",
														"logo_fedup",
														"2000",
														"800"));
			Rows.Add( new SponsorLibraryRow("22",
														"EMP",
														"3",
														"5000",
														"logo_emp",
														"2100",
														"800"));
			Rows.Add( new SponsorLibraryRow("23",
														"Diceformoes",
														"3",
														"5000",
														"logo_diceformoes",
														"2200",
														"800"));
			Rows.Add( new SponsorLibraryRow("24",
														"DeeDees",
														"3",
														"5000",
														"logo_dds",
														"2300",
														"800"));
			Rows.Add( new SponsorLibraryRow("25",
														"Mining Corp",
														"3",
														"5000",
														"logo_spokes",
														"2400",
														"800"));
			Rows.Add( new SponsorLibraryRow("26",
														"Three Stripe",
														"3",
														"5000",
														"logo_threestripe",
														"2500",
														"800"));
			Rows.Add( new SponsorLibraryRow("27",
														"Cola",
														"3",
														"5000",
														"logo_cola",
														"2600",
														"800"));
			Rows.Add( new SponsorLibraryRow("28",
														"Chicago",
														"3",
														"5000",
														"logo_chicago",
														"2700",
														"800"));
			Rows.Add( new SponsorLibraryRow("29",
														"Wondys",
														"3",
														"5000",
														"logo_wondys",
														"2800",
														"800"));
			Rows.Add( new SponsorLibraryRow("30",
														"EMP",
														"3",
														"5000",
														"logo_emp",
														"2900",
														"800"));
			Rows.Add( new SponsorLibraryRow("31",
														"Awkward Penguin",
														"3",
														"5000",
														"logo_awkwardpenguin",
														"3000",
														"800"));
			Rows.Add( new SponsorLibraryRow("32",
														"A Cars",
														"3",
														"5000",
														"logo_acars",
														"3100",
														"800"));
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
		public SponsorLibraryRow GetRow(rowIds in_RowID)
		{
			SponsorLibraryRow ret = null;
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
		public SponsorLibraryRow GetRow(string in_RowString)
		{
			SponsorLibraryRow ret = null;
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
