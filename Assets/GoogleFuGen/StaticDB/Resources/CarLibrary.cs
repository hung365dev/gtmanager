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
		public CarLibraryRow(string __id, string __carname, string __carprefabname, string __carcost, string __carstyle, string __carhp, string __carhprpm, string __cartorquenm, string __cartorquerpm, string __carshiftspeed, string __caraero, string __carfrontwing, string __carrearwing, string __cartireweareffect, string __cardrivabilityeffect, string __gear1, string __gear2, string __gear3, string __gear4, string __gear5, string __gear6, string __gear7, string __finaldrive, string __reversegear, string __tiregrip) 
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
		}

		public int Length { get { return 25; } }

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
					ret = _carcost.ToString();
					break;
				case 4:
					ret = _carstyle.ToString();
					break;
				case 5:
					ret = _carhp.ToString();
					break;
				case 6:
					ret = _carhprpm.ToString();
					break;
				case 7:
					ret = _cartorquenm.ToString();
					break;
				case 8:
					ret = _cartorquerpm.ToString();
					break;
				case 9:
					ret = _carshiftspeed.ToString();
					break;
				case 10:
					ret = _caraero.ToString();
					break;
				case 11:
					ret = _carfrontwing.ToString();
					break;
				case 12:
					ret = _carrearwing.ToString();
					break;
				case 13:
					ret = _cartireweareffect.ToString();
					break;
				case 14:
					ret = _cardrivabilityeffect.ToString();
					break;
				case 15:
					ret = _gear1.ToString();
					break;
				case 16:
					ret = _gear2.ToString();
					break;
				case 17:
					ret = _gear3.ToString();
					break;
				case 18:
					ret = _gear4.ToString();
					break;
				case 19:
					ret = _gear5.ToString();
					break;
				case 20:
					ret = _gear6.ToString();
					break;
				case 21:
					ret = _gear7.ToString();
					break;
				case 22:
					ret = _finaldrive.ToString();
					break;
				case 23:
					ret = _reversegear.ToString();
					break;
				case 24:
					ret = _tiregrip.ToString();
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
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "id" + " : " + _id.ToString() + "} ";
			ret += "{" + "carname" + " : " + _carname.ToString() + "} ";
			ret += "{" + "carprefabname" + " : " + _carprefabname.ToString() + "} ";
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
			return ret;
		}
	}
	public sealed class CarLibrary : IGoogleFuDB
	{
		public enum rowIds {
			CarLib_1, CarLib_2, CarLib_3, CarLib_4, CarLib_5, CarLib_6, CarLib_7, CarLib_8, CarLib_9, CarLib_10, CarLib_11, CarLib_12, CarLib_13, CarLib_14, CarLib_15, CarLib_16, CarLib_17, CarLib_18, CarLib_19, CarLib_20, 
			CarLib_21, CarLib_22, CarLib_23, CarLib_24, CarLib_25
		};
		public string [] rowNames = {
			"CarLib_1", "CarLib_2", "CarLib_3", "CarLib_4", "CarLib_5", "CarLib_6", "CarLib_7", "CarLib_8", "CarLib_9", "CarLib_10", "CarLib_11", "CarLib_12", "CarLib_13", "CarLib_14", "CarLib_15", "CarLib_16", "CarLib_17", "CarLib_18", "CarLib_19", "CarLib_20", 
			"CarLib_21", "CarLib_22", "CarLib_23", "CarLib_24", "CarLib_25"
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
														"1.2"));
			Rows.Add( new CarLibraryRow("2",
														"Volkswagen Golf",
														"GolfWhite",
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
														"1.2"));
			Rows.Add( new CarLibraryRow("3",
														"Mini Cooper",
														"NewMini1",
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
														"1.2"));
			Rows.Add( new CarLibraryRow("4",
														"Ford Focus",
														"BlueFordFocus",
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
														"1.2"));
			Rows.Add( new CarLibraryRow("5",
														"Lamborghini Spider",
														"Avantador1",
														"80000",
														"99",
														"100",
														"5500",
														"200",
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
														"1.2"));
			Rows.Add( new CarLibraryRow("6",
														"Ferrari Enzo",
														"FerrariEnzo",
														"120000",
														"90",
														"100",
														"5500",
														"200",
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
														"1.2"));
			Rows.Add( new CarLibraryRow("7",
														"Nissan GTR",
														"NissanGTR1",
														"90000",
														"80",
														"100",
														"5500",
														"200",
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
														"1.2"));
			Rows.Add( new CarLibraryRow("8",
														"Bugatti Veyron",
														"BugattiVeyron",
														"150000",
														"92",
														"100",
														"5500",
														"200",
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
														"1.2"));
			Rows.Add( new CarLibraryRow("9",
														"Audi A3",
														"AudiA3",
														"14000",
														"9",
														"210",
														"5800",
														"235",
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
														"1.2"));
			Rows.Add( new CarLibraryRow("10",
														"Seat Leon",
														"SeatLeon1",
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
														"1.2"));
			Rows.Add( new CarLibraryRow("11",
														"Porsche 911",
														"Porsche911",
														"1250000",
														"85",
														"100",
														"5500",
														"200",
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
														"1.2"));
			Rows.Add( new CarLibraryRow("12",
														"Aston Martin DB10",
														"AstonMartinDB10",
														"1500000",
														"100",
														"100",
														"5500",
														"200",
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
														"1.2"));
			Rows.Add( new CarLibraryRow("13",
														"Ford Mustang",
														"Mustang1",
														"65000",
														"20",
														"100",
														"5500",
														"200",
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
														"1.2"));
			Rows.Add( new CarLibraryRow("14",
														"Audi TT",
														"AudiTT",
														"70000",
														"25",
														"100",
														"5500",
														"200",
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
														"1.2"));
			Rows.Add( new CarLibraryRow("15",
														"BMW 5 Series",
														"BMW5Series",
														"75000",
														"30",
														"100",
														"5500",
														"200",
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
														"1.2"));
			Rows.Add( new CarLibraryRow("16",
														"Corvette",
														"Corvette",
														"80000",
														"35",
														"100",
														"5500",
														"200",
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
														"1.2"));
			Rows.Add( new CarLibraryRow("17",
														"Ferrari Scagialetti",
														"FerrariScagialetti",
														"85000",
														"40",
														"100",
														"5500",
														"200",
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
														"1.2"));
			Rows.Add( new CarLibraryRow("18",
														"Ford GT40",
														"FordGT40",
														"90000",
														"45",
														"100",
														"5500",
														"200",
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
														"1.2"));
			Rows.Add( new CarLibraryRow("19",
														"Ford Mondeo",
														"FordMondeo",
														"95000",
														"50",
														"100",
														"5500",
														"200",
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
														"1.2"));
			Rows.Add( new CarLibraryRow("20",
														"Koenigsegg",
														"Koenigsegg",
														"100000",
														"55",
														"100",
														"5500",
														"200",
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
														"1.2"));
			Rows.Add( new CarLibraryRow("21",
														"Lexus",
														"Lexus",
														"105000",
														"60",
														"100",
														"5500",
														"200",
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
														"1.2"));
			Rows.Add( new CarLibraryRow("22",
														"McClaren P1",
														"McClarenP1",
														"110000",
														"65",
														"100",
														"5500",
														"200",
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
														"1.2"));
			Rows.Add( new CarLibraryRow("23",
														"Mitsubishi",
														"Mitsubishi",
														"115000",
														"70",
														"100",
														"5500",
														"200",
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
														"1.2"));
			Rows.Add( new CarLibraryRow("24",
														"Zonda",
														"Zonda",
														"120000",
														"75",
														"100",
														"5500",
														"200",
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
														"1.2"));
			Rows.Add( new CarLibraryRow("25",
														"TVR",
														"CarTVR1",
														"125000",
														"80",
														"100",
														"5500",
														"200",
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
														"1.2"));
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
