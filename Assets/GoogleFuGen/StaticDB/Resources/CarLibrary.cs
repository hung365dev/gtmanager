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
	public class CarLibraryRow : IGoogleFuRow
	{
		public int _id;
		public string _carname;
		public string _carprefabname;
		public int _leaguerequired;
		public int _carcost;
		public int _carstyle;
		public int _carhp;
		public float _carhprpm;
		public float _cartorquenm;
		public float _cartorquerpm;
		public float _carshiftspeed;
		public float _caraero;
		public float _carfrontwing;
		public float _carrearwing;
		public float _cartireweareffect;
		public float _cardrivabilityeffect;
		public float _gear1;
		public float _gear2;
		public float _gear3;
		public float _gear4;
		public float _gear5;
		public float _gear6;
		public float _gear7;
		public float _finaldrive;
		public float _reversegear;
		public float _tiregrip;
		public float _maxspeed;
		public float _revlimiter;
		public float _cardrag;
		public CarLibraryRow(string __id, string __carname, string __carprefabname, string __leaguerequired, string __carcost, string __carstyle, string __carhp, string __carhprpm, string __cartorquenm, string __cartorquerpm, string __carshiftspeed, string __caraero, string __carfrontwing, string __carrearwing, string __cartireweareffect, string __cardrivabilityeffect, string __gear1, string __gear2, string __gear3, string __gear4, string __gear5, string __gear6, string __gear7, string __finaldrive, string __reversegear, string __tiregrip, string __maxspeed, string __revlimiter, string __cardrag) 
		{
			{
			int res;
				if(int.TryParse(__id, out res))
					_id = res;
				else
					Debug.LogError("Failed To Convert id string: "+ __id +" to int");
			}
			_carname = __carname;
			_carprefabname = __carprefabname;
			{
			int res;
				if(int.TryParse(__leaguerequired, out res))
					_leaguerequired = res;
				else
					Debug.LogError("Failed To Convert leaguerequired string: "+ __leaguerequired +" to int");
			}
			{
			int res;
				if(int.TryParse(__carcost, out res))
					_carcost = res;
				else
					Debug.LogError("Failed To Convert carcost string: "+ __carcost +" to int");
			}
			{
			int res;
				if(int.TryParse(__carstyle, out res))
					_carstyle = res;
				else
					Debug.LogError("Failed To Convert carstyle string: "+ __carstyle +" to int");
			}
			{
			int res;
				if(int.TryParse(__carhp, out res))
					_carhp = res;
				else
					Debug.LogError("Failed To Convert carhp string: "+ __carhp +" to int");
			}
			{
			float res;
				if(float.TryParse(__carhprpm, out res))
					_carhprpm = res;
				else
					Debug.LogError("Failed To Convert carhprpm string: "+ __carhprpm +" to float");
			}
			{
			float res;
				if(float.TryParse(__cartorquenm, out res))
					_cartorquenm = res;
				else
					Debug.LogError("Failed To Convert cartorquenm string: "+ __cartorquenm +" to float");
			}
			{
			float res;
				if(float.TryParse(__cartorquerpm, out res))
					_cartorquerpm = res;
				else
					Debug.LogError("Failed To Convert cartorquerpm string: "+ __cartorquerpm +" to float");
			}
			{
			float res;
				if(float.TryParse(__carshiftspeed, out res))
					_carshiftspeed = res;
				else
					Debug.LogError("Failed To Convert carshiftspeed string: "+ __carshiftspeed +" to float");
			}
			{
			float res;
				if(float.TryParse(__caraero, out res))
					_caraero = res;
				else
					Debug.LogError("Failed To Convert caraero string: "+ __caraero +" to float");
			}
			{
			float res;
				if(float.TryParse(__carfrontwing, out res))
					_carfrontwing = res;
				else
					Debug.LogError("Failed To Convert carfrontwing string: "+ __carfrontwing +" to float");
			}
			{
			float res;
				if(float.TryParse(__carrearwing, out res))
					_carrearwing = res;
				else
					Debug.LogError("Failed To Convert carrearwing string: "+ __carrearwing +" to float");
			}
			{
			float res;
				if(float.TryParse(__cartireweareffect, out res))
					_cartireweareffect = res;
				else
					Debug.LogError("Failed To Convert cartireweareffect string: "+ __cartireweareffect +" to float");
			}
			{
			float res;
				if(float.TryParse(__cardrivabilityeffect, out res))
					_cardrivabilityeffect = res;
				else
					Debug.LogError("Failed To Convert cardrivabilityeffect string: "+ __cardrivabilityeffect +" to float");
			}
			{
			float res;
				if(float.TryParse(__gear1, out res))
					_gear1 = res;
				else
					Debug.LogError("Failed To Convert gear1 string: "+ __gear1 +" to float");
			}
			{
			float res;
				if(float.TryParse(__gear2, out res))
					_gear2 = res;
				else
					Debug.LogError("Failed To Convert gear2 string: "+ __gear2 +" to float");
			}
			{
			float res;
				if(float.TryParse(__gear3, out res))
					_gear3 = res;
				else
					Debug.LogError("Failed To Convert gear3 string: "+ __gear3 +" to float");
			}
			{
			float res;
				if(float.TryParse(__gear4, out res))
					_gear4 = res;
				else
					Debug.LogError("Failed To Convert gear4 string: "+ __gear4 +" to float");
			}
			{
			float res;
				if(float.TryParse(__gear5, out res))
					_gear5 = res;
				else
					Debug.LogError("Failed To Convert gear5 string: "+ __gear5 +" to float");
			}
			{
			float res;
				if(float.TryParse(__gear6, out res))
					_gear6 = res;
				else
					Debug.LogError("Failed To Convert gear6 string: "+ __gear6 +" to float");
			}
			{
			float res;
				if(float.TryParse(__gear7, out res))
					_gear7 = res;
				else
					Debug.LogError("Failed To Convert gear7 string: "+ __gear7 +" to float");
			}
			{
			float res;
				if(float.TryParse(__finaldrive, out res))
					_finaldrive = res;
				else
					Debug.LogError("Failed To Convert finaldrive string: "+ __finaldrive +" to float");
			}
			{
			float res;
				if(float.TryParse(__reversegear, out res))
					_reversegear = res;
				else
					Debug.LogError("Failed To Convert reversegear string: "+ __reversegear +" to float");
			}
			{
			float res;
				if(float.TryParse(__tiregrip, out res))
					_tiregrip = res;
				else
					Debug.LogError("Failed To Convert tiregrip string: "+ __tiregrip +" to float");
			}
			{
			float res;
				if(float.TryParse(__maxspeed, out res))
					_maxspeed = res;
				else
					Debug.LogError("Failed To Convert maxspeed string: "+ __maxspeed +" to float");
			}
			{
			float res;
				if(float.TryParse(__revlimiter, out res))
					_revlimiter = res;
				else
					Debug.LogError("Failed To Convert revlimiter string: "+ __revlimiter +" to float");
			}
			{
			float res;
				if(float.TryParse(__cardrag, out res))
					_cardrag = res;
				else
					Debug.LogError("Failed To Convert cardrag string: "+ __cardrag +" to float");
			}
		}

		public int Length { get { return 29; } }

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
					ret = _carname.ToString();
					break;
				case 2:
					ret = _carprefabname.ToString();
					break;
				case 3:
					ret = _leaguerequired.ToString();
					break;
				case 4:
					ret = _carcost.ToString();
					break;
				case 5:
					ret = _carstyle.ToString();
					break;
				case 6:
					ret = _carhp.ToString();
					break;
				case 7:
					ret = _carhprpm.ToString();
					break;
				case 8:
					ret = _cartorquenm.ToString();
					break;
				case 9:
					ret = _cartorquerpm.ToString();
					break;
				case 10:
					ret = _carshiftspeed.ToString();
					break;
				case 11:
					ret = _caraero.ToString();
					break;
				case 12:
					ret = _carfrontwing.ToString();
					break;
				case 13:
					ret = _carrearwing.ToString();
					break;
				case 14:
					ret = _cartireweareffect.ToString();
					break;
				case 15:
					ret = _cardrivabilityeffect.ToString();
					break;
				case 16:
					ret = _gear1.ToString();
					break;
				case 17:
					ret = _gear2.ToString();
					break;
				case 18:
					ret = _gear3.ToString();
					break;
				case 19:
					ret = _gear4.ToString();
					break;
				case 20:
					ret = _gear5.ToString();
					break;
				case 21:
					ret = _gear6.ToString();
					break;
				case 22:
					ret = _gear7.ToString();
					break;
				case 23:
					ret = _finaldrive.ToString();
					break;
				case 24:
					ret = _reversegear.ToString();
					break;
				case 25:
					ret = _tiregrip.ToString();
					break;
				case 26:
					ret = _maxspeed.ToString();
					break;
				case 27:
					ret = _revlimiter.ToString();
					break;
				case 28:
					ret = _cardrag.ToString();
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
				case "carname":
					ret = _carname.ToString();
					break;
				case "carprefabname":
					ret = _carprefabname.ToString();
					break;
				case "leaguerequired":
					ret = _leaguerequired.ToString();
					break;
				case "carcost":
					ret = _carcost.ToString();
					break;
				case "carstyle":
					ret = _carstyle.ToString();
					break;
				case "carhp":
					ret = _carhp.ToString();
					break;
				case "carhprpm":
					ret = _carhprpm.ToString();
					break;
				case "cartorquenm":
					ret = _cartorquenm.ToString();
					break;
				case "cartorquerpm":
					ret = _cartorquerpm.ToString();
					break;
				case "carshiftspeed":
					ret = _carshiftspeed.ToString();
					break;
				case "caraero":
					ret = _caraero.ToString();
					break;
				case "carfrontwing":
					ret = _carfrontwing.ToString();
					break;
				case "carrearwing":
					ret = _carrearwing.ToString();
					break;
				case "cartireweareffect":
					ret = _cartireweareffect.ToString();
					break;
				case "cardrivabilityeffect":
					ret = _cardrivabilityeffect.ToString();
					break;
				case "gear1":
					ret = _gear1.ToString();
					break;
				case "gear2":
					ret = _gear2.ToString();
					break;
				case "gear3":
					ret = _gear3.ToString();
					break;
				case "gear4":
					ret = _gear4.ToString();
					break;
				case "gear5":
					ret = _gear5.ToString();
					break;
				case "gear6":
					ret = _gear6.ToString();
					break;
				case "gear7":
					ret = _gear7.ToString();
					break;
				case "finaldrive":
					ret = _finaldrive.ToString();
					break;
				case "reversegear":
					ret = _reversegear.ToString();
					break;
				case "tiregrip":
					ret = _tiregrip.ToString();
					break;
				case "maxspeed":
					ret = _maxspeed.ToString();
					break;
				case "revlimiter":
					ret = _revlimiter.ToString();
					break;
				case "cardrag":
					ret = _cardrag.ToString();
					break;
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "id" + " : " + _id.ToString() + "} ";
			ret += "{" + "carname" + " : " + _carname.ToString() + "} ";
			ret += "{" + "carprefabname" + " : " + _carprefabname.ToString() + "} ";
			ret += "{" + "leaguerequired" + " : " + _leaguerequired.ToString() + "} ";
			ret += "{" + "carcost" + " : " + _carcost.ToString() + "} ";
			ret += "{" + "carstyle" + " : " + _carstyle.ToString() + "} ";
			ret += "{" + "carhp" + " : " + _carhp.ToString() + "} ";
			ret += "{" + "carhprpm" + " : " + _carhprpm.ToString() + "} ";
			ret += "{" + "cartorquenm" + " : " + _cartorquenm.ToString() + "} ";
			ret += "{" + "cartorquerpm" + " : " + _cartorquerpm.ToString() + "} ";
			ret += "{" + "carshiftspeed" + " : " + _carshiftspeed.ToString() + "} ";
			ret += "{" + "caraero" + " : " + _caraero.ToString() + "} ";
			ret += "{" + "carfrontwing" + " : " + _carfrontwing.ToString() + "} ";
			ret += "{" + "carrearwing" + " : " + _carrearwing.ToString() + "} ";
			ret += "{" + "cartireweareffect" + " : " + _cartireweareffect.ToString() + "} ";
			ret += "{" + "cardrivabilityeffect" + " : " + _cardrivabilityeffect.ToString() + "} ";
			ret += "{" + "gear1" + " : " + _gear1.ToString() + "} ";
			ret += "{" + "gear2" + " : " + _gear2.ToString() + "} ";
			ret += "{" + "gear3" + " : " + _gear3.ToString() + "} ";
			ret += "{" + "gear4" + " : " + _gear4.ToString() + "} ";
			ret += "{" + "gear5" + " : " + _gear5.ToString() + "} ";
			ret += "{" + "gear6" + " : " + _gear6.ToString() + "} ";
			ret += "{" + "gear7" + " : " + _gear7.ToString() + "} ";
			ret += "{" + "finaldrive" + " : " + _finaldrive.ToString() + "} ";
			ret += "{" + "reversegear" + " : " + _reversegear.ToString() + "} ";
			ret += "{" + "tiregrip" + " : " + _tiregrip.ToString() + "} ";
			ret += "{" + "maxspeed" + " : " + _maxspeed.ToString() + "} ";
			ret += "{" + "revlimiter" + " : " + _revlimiter.ToString() + "} ";
			ret += "{" + "cardrag" + " : " + _cardrag.ToString() + "} ";
			return ret;
		}
	}
	public sealed class CarLibrary : IGoogleFuDB
	{
		public enum rowIds {
			CarLib_1, CarLib_2, CarLib_3, CarLib_4, CarLib_10, CarLib_9, CarLib_19, CarLib_21, CarLib_23, CarLib_14, CarLib_25, CarLib_15, CarLib_13, CarLib_16, CarLib_17, CarLib_7, CarLib_18, CarLib_5, CarLib_11, CarLib_12, 
			CarLib_22, CarLib_6, CarLib_24, CarLib_20, CarLib_8
		};
		public string [] rowNames = {
			"CarLib_1", "CarLib_2", "CarLib_3", "CarLib_4", "CarLib_10", "CarLib_9", "CarLib_19", "CarLib_21", "CarLib_23", "CarLib_14", "CarLib_25", "CarLib_15", "CarLib_13", "CarLib_16", "CarLib_17", "CarLib_7", "CarLib_18", "CarLib_5", "CarLib_11", "CarLib_12", 
			"CarLib_22", "CarLib_6", "CarLib_24", "CarLib_20", "CarLib_8"
		};
		public System.Collections.Generic.List<CarLibraryRow> Rows = new System.Collections.Generic.List<CarLibraryRow>();

		public static CarLibrary Instance
		{
			get { return NestedCarLibrary.instance; }
		}

		private class NestedCarLibrary
		{
			static NestedCarLibrary() { }
			internal static readonly CarLibrary instance = new CarLibrary();
		}

		private CarLibrary()
		{
			Rows.Add( new CarLibraryRow("1",
														"Honda Civic",
														"ShitRed2",
														"4",
														"0",
														"1",
														"143",
														"6500",
														"174",
														"4300",
														"0.25",
														"0.3",
														"-1",
														"-2",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"1.2",
														"132",
														"8000",
														"0.5"));
			Rows.Add( new CarLibraryRow("2",
														"Volkswagen Golf",
														"GolfWhite",
														"4",
														"1000",
														"5",
														"170",
														"4500",
														"269",
														"1600",
														"0.25",
														"0.3",
														"-1",
														"-2",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"1.2",
														"144",
														"8000",
														"0.6"));
			Rows.Add( new CarLibraryRow("3",
														"Mini Cooper",
														"NewMini1",
														"4",
														"5000",
														"8",
														"192",
														"5000",
														"280",
														"1250",
														"0.25",
														"0.3",
														"-1",
														"-2",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"1.2",
														"138",
														"8000",
														"0.7"));
			Rows.Add( new CarLibraryRow("4",
														"Ford Focus",
														"BlueFordFocus",
														"4",
														"7000",
														"5",
														"180",
														"6500",
														"230",
														"3000",
														"0.25",
														"0.3",
														"-1",
														"-2",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"1.2",
														"141",
														"8000",
														"0.5"));
			Rows.Add( new CarLibraryRow("10",
														"Seat Leon",
														"SeatLeon1",
														"4",
														"12000",
														"7",
														"201",
														"6200",
														"265",
														"3400",
														"0.25",
														"0.3",
														"-1",
														"-2",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"1.2",
														"140",
														"8000",
														"0.6"));
			Rows.Add( new CarLibraryRow("9",
														"Audi A3",
														"AudiA3",
														"4",
														"14000",
														"9",
														"210",
														"5800",
														"275",
														"2250",
														"0.25",
														"0.3",
														"-1",
														"-2",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"1.2",
														"145",
														"8000",
														"0.6"));
			Rows.Add( new CarLibraryRow("19",
														"Ford Mondeo",
														"FordMondeo",
														"3",
														"60000",
														"50",
														"230",
														"6000",
														"385",
														"4250",
														"0.25",
														"0.3",
														"-1",
														"-2",
														"0",
														"0",
														"3.42",
														"2.14",
														"1.45",
														"1.03",
														"0.77",
														"0",
														"0",
														"0",
														"0",
														"1.2",
														"141",
														"8000",
														"0.5"));
			Rows.Add( new CarLibraryRow("21",
														"Lexus",
														"Lexus",
														"3",
														"65000",
														"60",
														"242",
														"7100",
														"420",
														"5000",
														"0.25",
														"0.3",
														"-1",
														"-2",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"1.2",
														"168",
														"8000",
														"0.8"));
			Rows.Add( new CarLibraryRow("23",
														"Mitsubishi",
														"Mitsubishi",
														"3",
														"67500",
														"70",
														"300",
														"6500",
														"422",
														"1250",
														"0.25",
														"0.3",
														"-1",
														"-2",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"1.2",
														"155",
														"8000",
														"0.7"));
			Rows.Add( new CarLibraryRow("14",
														"Audi TT",
														"AudiTT",
														"3",
														"70000",
														"25",
														"312",
														"6300",
														"440",
														"3500",
														"0.25",
														"0.3",
														"-1",
														"-2",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"1.2",
														"198",
														"8000",
														"0.5"));
			Rows.Add( new CarLibraryRow("25",
														"TVR",
														"CarTVR1",
														"3",
														"72000",
														"80",
														"322",
														"7200",
														"390",
														"5500",
														"0.25",
														"0.3",
														"-1",
														"-2",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"1.2",
														"190",
														"8000",
														"0.6"));
			Rows.Add( new CarLibraryRow("15",
														"BMW 5 Series",
														"BMW5Series",
														"3",
														"75000",
														"30",
														"343",
														"6700",
														"378",
														"2750",
														"0.25",
														"0.3",
														"-1",
														"-2",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"1.2",
														"195",
														"8000",
														"0.5"));
			Rows.Add( new CarLibraryRow("13",
														"Ford Mustang",
														"Mustang1",
														"3",
														"77000",
														"20",
														"419",
														"6000",
														"529",
														"4250",
														"0.25",
														"0.3",
														"-1",
														"-2",
														"0",
														"0",
														"3.65",
														"2.43",
														"1.68",
														"1.31",
														"1",
														"0.65",
														"0",
														"3.55",
														"0",
														"1.2",
														"155",
														"8000",
														"0.8"));
			Rows.Add( new CarLibraryRow("16",
														"Corvette",
														"Corvette",
														"2",
														"80000",
														"35",
														"426",
														"5900",
														"569",
														"4600",
														"0.25",
														"0.3",
														"-1",
														"-2",
														"0",
														"0",
														"3.01",
														"2.07",
														"1.43",
														"1",
														"0.84",
														"0.57",
														"0",
														"3.45",
														"0",
														"1.2",
														"155",
														"8000",
														"0.7"));
			Rows.Add( new CarLibraryRow("17",
														"Ferrari Scagialetti",
														"FerrariScagialetti",
														"2",
														"85000",
														"40",
														"532",
														"7250",
														"588",
														"5250",
														"0.25",
														"0.3",
														"-1",
														"-2",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"1.2",
														"195",
														"8000",
														"0.6"));
			Rows.Add( new CarLibraryRow("7",
														"Nissan GTR",
														"NissanGTR1",
														"2",
														"90000",
														"80",
														"545",
														"6400",
														"578",
														"4000",
														"0.25",
														"0.3",
														"-1",
														"-2",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"1.2",
														"194",
														"8000",
														"0.6"));
			Rows.Add( new CarLibraryRow("18",
														"Ford GT40",
														"FordGT40",
														"2",
														"90000",
														"45",
														"560",
														"6200",
														"644",
														"5000",
														"0.25",
														"0.3",
														"-1",
														"-2",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"1.2",
														"300",
														"8000",
														"0.7"));
			Rows.Add( new CarLibraryRow("5",
														"Lamborghini Spider",
														"Avantador1",
														"2",
														"92000",
														"99",
														"575",
														"8000",
														"540",
														"6500",
														"0.2",
														"0.3",
														"-1",
														"-2",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"1.2",
														"228",
														"8000",
														"0.7"));
			Rows.Add( new CarLibraryRow("11",
														"Porsche 911",
														"Porsche911",
														"1",
														"96000",
														"85",
														"600",
														"7500",
														"590",
														"5750",
														"0.25",
														"0.3",
														"-1",
														"-2",
														"0",
														"0",
														"3.91",
														"2.29",
														"1.55",
														"1.3",
														"1.08",
														"0.88",
														"0.71",
														"3.44",
														"0",
														"1.2",
														"187",
														"7800",
														"1"));
			Rows.Add( new CarLibraryRow("12",
														"Aston Martin DB10",
														"AstonMartinDB10",
														"1",
														"98000",
														"100",
														"620",
														"6500",
														"570",
														"5750",
														"0.25",
														"0.3",
														"-1",
														"-2",
														"0",
														"0",
														"3.15",
														"1.95",
														"1.44",
														"1.15",
														"0.94",
														"0.76",
														"0",
														"3.71",
														"0",
														"1.2",
														"194",
														"7800",
														"0.7"));
			Rows.Add( new CarLibraryRow("22",
														"McClaren P1",
														"McClarenP1",
														"1",
														"110000",
														"65",
														"647",
														"7400",
														"649",
														"5600",
														"0.25",
														"0.3",
														"-1",
														"-2",
														"0",
														"0",
														"3.23",
														"2.19",
														"1.71",
														"1.39",
														"1.16",
														"0.93",
														"0",
														"2.37",
														"0",
														"1.2",
														"240",
														"8000",
														"0.7"));
			Rows.Add( new CarLibraryRow("6",
														"Ferrari Enzo",
														"FerrariEnzo",
														"1",
														"120000",
														"90",
														"680",
														"7800",
														"789",
														"5500",
														"0.25",
														"0.2",
														"-1",
														"-2",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"1.2",
														"218",
														"9000",
														"0.6"));
			Rows.Add( new CarLibraryRow("24",
														"Zonda",
														"Zonda",
														"1",
														"120000",
														"75",
														"697",
														"5500",
														"800",
														"1250",
														"0.25",
														"0.3",
														"-1",
														"-2",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"1.2",
														"300",
														"8000",
														"0.7"));
			Rows.Add( new CarLibraryRow("20",
														"Koenigsegg",
														"Koenigsegg",
														"1",
														"125000",
														"55",
														"848",
														"7500",
														"1370",
														"4500",
														"0.25",
														"0.3",
														"-1",
														"-2",
														"0",
														"0",
														"3.36",
														"2.875",
														"1.77",
														"1.26",
														"1",
														"0.83",
														"0.71",
														"0",
														"0",
														"1.2",
														"273",
														"8000",
														"0.7"));
			Rows.Add( new CarLibraryRow("8",
														"Bugatti Veyron",
														"BugattiVeyron",
														"1",
														"200000",
														"92",
														"1000",
														"6400",
														"1500",
														"4000",
														"0.25",
														"0.3",
														"-1",
														"-2",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"1.2",
														"233",
														"9000",
														"1"));
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
		public CarLibraryRow GetRow(rowIds in_RowID)
		{
			CarLibraryRow ret = null;
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
		public CarLibraryRow GetRow(string in_RowString)
		{
			CarLibraryRow ret = null;
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
