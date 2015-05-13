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
	public class RnDRow : IGoogleFuRow
	{
		public int _id;
		public string _partname;
		public string _partcategory;
		public string _partdescription;
		public int _maxlevelstounlock;
		public string _upgradestacktype;
		public string _partprerequisites;
		public int _partprerequisitestaff;
		public int _partprerequisitedivision;
		public int _daystoresearch;
		public int _costtoresearch;
		public float _effectonhp;
		public float _effectontorque;
		public float _effectonturbopsi;
		public int _effectonnitrocapacity;
		public float _effectonnitrodurability;
		public float _effectonnitrofuel;
		public float _effectonshiftspeed;
		public float _tirecoefficientofgripchange;
		public float _tirehardnesseffect;
		public float _coolingmaxtempeffect;
		public float _coolingbaseeffect;
		public float _humanerrorreductor;
		public float _frontwingeffectdownforceeffect;
		public float _rearwingdownforceeffect;
		public float _frontwingangleeffect;
		public float _rearwingangleeffect;
		public float _bodyaerodragreduce;
		public float _percentofdrswingtoremove;
		public RnDRow(string __id, string __partname, string __partcategory, string __partdescription, string __maxlevelstounlock, string __upgradestacktype, string __partprerequisites, string __partprerequisitestaff, string __partprerequisitedivision, string __daystoresearch, string __costtoresearch, string __effectonhp, string __effectontorque, string __effectonturbopsi, string __effectonnitrocapacity, string __effectonnitrodurability, string __effectonnitrofuel, string __effectonshiftspeed, string __tirecoefficientofgripchange, string __tirehardnesseffect, string __coolingmaxtempeffect, string __coolingbaseeffect, string __humanerrorreductor, string __frontwingeffectdownforceeffect, string __rearwingdownforceeffect, string __frontwingangleeffect, string __rearwingangleeffect, string __bodyaerodragreduce, string __percentofdrswingtoremove) 
		{
			{
			int res;
				if(int.TryParse(__id, out res))
					_id = res;
				else
					Debug.LogError("Failed To Convert id string: "+ __id +" to int");
			}
			_partname = __partname;
			_partcategory = __partcategory;
			_partdescription = __partdescription;
			{
			int res;
				if(int.TryParse(__maxlevelstounlock, out res))
					_maxlevelstounlock = res;
				else
					Debug.LogError("Failed To Convert maxlevelstounlock string: "+ __maxlevelstounlock +" to int");
			}
			_upgradestacktype = __upgradestacktype;
			_partprerequisites = __partprerequisites;
			{
			int res;
				if(int.TryParse(__partprerequisitestaff, out res))
					_partprerequisitestaff = res;
				else
					Debug.LogError("Failed To Convert partprerequisitestaff string: "+ __partprerequisitestaff +" to int");
			}
			{
			int res;
				if(int.TryParse(__partprerequisitedivision, out res))
					_partprerequisitedivision = res;
				else
					Debug.LogError("Failed To Convert partprerequisitedivision string: "+ __partprerequisitedivision +" to int");
			}
			{
			int res;
				if(int.TryParse(__daystoresearch, out res))
					_daystoresearch = res;
				else
					Debug.LogError("Failed To Convert daystoresearch string: "+ __daystoresearch +" to int");
			}
			{
			int res;
				if(int.TryParse(__costtoresearch, out res))
					_costtoresearch = res;
				else
					Debug.LogError("Failed To Convert costtoresearch string: "+ __costtoresearch +" to int");
			}
			{
			float res;
				if(float.TryParse(__effectonhp, out res))
					_effectonhp = res;
				else
					Debug.LogError("Failed To Convert effectonhp string: "+ __effectonhp +" to float");
			}
			{
			float res;
				if(float.TryParse(__effectontorque, out res))
					_effectontorque = res;
				else
					Debug.LogError("Failed To Convert effectontorque string: "+ __effectontorque +" to float");
			}
			{
			float res;
				if(float.TryParse(__effectonturbopsi, out res))
					_effectonturbopsi = res;
				else
					Debug.LogError("Failed To Convert effectonturbopsi string: "+ __effectonturbopsi +" to float");
			}
			{
			int res;
				if(int.TryParse(__effectonnitrocapacity, out res))
					_effectonnitrocapacity = res;
				else
					Debug.LogError("Failed To Convert effectonnitrocapacity string: "+ __effectonnitrocapacity +" to int");
			}
			{
			float res;
				if(float.TryParse(__effectonnitrodurability, out res))
					_effectonnitrodurability = res;
				else
					Debug.LogError("Failed To Convert effectonnitrodurability string: "+ __effectonnitrodurability +" to float");
			}
			{
			float res;
				if(float.TryParse(__effectonnitrofuel, out res))
					_effectonnitrofuel = res;
				else
					Debug.LogError("Failed To Convert effectonnitrofuel string: "+ __effectonnitrofuel +" to float");
			}
			{
			float res;
				if(float.TryParse(__effectonshiftspeed, out res))
					_effectonshiftspeed = res;
				else
					Debug.LogError("Failed To Convert effectonshiftspeed string: "+ __effectonshiftspeed +" to float");
			}
			{
			float res;
				if(float.TryParse(__tirecoefficientofgripchange, out res))
					_tirecoefficientofgripchange = res;
				else
					Debug.LogError("Failed To Convert tirecoefficientofgripchange string: "+ __tirecoefficientofgripchange +" to float");
			}
			{
			float res;
				if(float.TryParse(__tirehardnesseffect, out res))
					_tirehardnesseffect = res;
				else
					Debug.LogError("Failed To Convert tirehardnesseffect string: "+ __tirehardnesseffect +" to float");
			}
			{
			float res;
				if(float.TryParse(__coolingmaxtempeffect, out res))
					_coolingmaxtempeffect = res;
				else
					Debug.LogError("Failed To Convert coolingmaxtempeffect string: "+ __coolingmaxtempeffect +" to float");
			}
			{
			float res;
				if(float.TryParse(__coolingbaseeffect, out res))
					_coolingbaseeffect = res;
				else
					Debug.LogError("Failed To Convert coolingbaseeffect string: "+ __coolingbaseeffect +" to float");
			}
			{
			float res;
				if(float.TryParse(__humanerrorreductor, out res))
					_humanerrorreductor = res;
				else
					Debug.LogError("Failed To Convert humanerrorreductor string: "+ __humanerrorreductor +" to float");
			}
			{
			float res;
				if(float.TryParse(__frontwingeffectdownforceeffect, out res))
					_frontwingeffectdownforceeffect = res;
				else
					Debug.LogError("Failed To Convert frontwingeffectdownforceeffect string: "+ __frontwingeffectdownforceeffect +" to float");
			}
			{
			float res;
				if(float.TryParse(__rearwingdownforceeffect, out res))
					_rearwingdownforceeffect = res;
				else
					Debug.LogError("Failed To Convert rearwingdownforceeffect string: "+ __rearwingdownforceeffect +" to float");
			}
			{
			float res;
				if(float.TryParse(__frontwingangleeffect, out res))
					_frontwingangleeffect = res;
				else
					Debug.LogError("Failed To Convert frontwingangleeffect string: "+ __frontwingangleeffect +" to float");
			}
			{
			float res;
				if(float.TryParse(__rearwingangleeffect, out res))
					_rearwingangleeffect = res;
				else
					Debug.LogError("Failed To Convert rearwingangleeffect string: "+ __rearwingangleeffect +" to float");
			}
			{
			float res;
				if(float.TryParse(__bodyaerodragreduce, out res))
					_bodyaerodragreduce = res;
				else
					Debug.LogError("Failed To Convert bodyaerodragreduce string: "+ __bodyaerodragreduce +" to float");
			}
			{
			float res;
				if(float.TryParse(__percentofdrswingtoremove, out res))
					_percentofdrswingtoremove = res;
				else
					Debug.LogError("Failed To Convert percentofdrswingtoremove string: "+ __percentofdrswingtoremove +" to float");
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
					ret = _partname.ToString();
					break;
				case 2:
					ret = _partcategory.ToString();
					break;
				case 3:
					ret = _partdescription.ToString();
					break;
				case 4:
					ret = _maxlevelstounlock.ToString();
					break;
				case 5:
					ret = _upgradestacktype.ToString();
					break;
				case 6:
					ret = _partprerequisites.ToString();
					break;
				case 7:
					ret = _partprerequisitestaff.ToString();
					break;
				case 8:
					ret = _partprerequisitedivision.ToString();
					break;
				case 9:
					ret = _daystoresearch.ToString();
					break;
				case 10:
					ret = _costtoresearch.ToString();
					break;
				case 11:
					ret = _effectonhp.ToString();
					break;
				case 12:
					ret = _effectontorque.ToString();
					break;
				case 13:
					ret = _effectonturbopsi.ToString();
					break;
				case 14:
					ret = _effectonnitrocapacity.ToString();
					break;
				case 15:
					ret = _effectonnitrodurability.ToString();
					break;
				case 16:
					ret = _effectonnitrofuel.ToString();
					break;
				case 17:
					ret = _effectonshiftspeed.ToString();
					break;
				case 18:
					ret = _tirecoefficientofgripchange.ToString();
					break;
				case 19:
					ret = _tirehardnesseffect.ToString();
					break;
				case 20:
					ret = _coolingmaxtempeffect.ToString();
					break;
				case 21:
					ret = _coolingbaseeffect.ToString();
					break;
				case 22:
					ret = _humanerrorreductor.ToString();
					break;
				case 23:
					ret = _frontwingeffectdownforceeffect.ToString();
					break;
				case 24:
					ret = _rearwingdownforceeffect.ToString();
					break;
				case 25:
					ret = _frontwingangleeffect.ToString();
					break;
				case 26:
					ret = _rearwingangleeffect.ToString();
					break;
				case 27:
					ret = _bodyaerodragreduce.ToString();
					break;
				case 28:
					ret = _percentofdrswingtoremove.ToString();
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
				case "partname":
					ret = _partname.ToString();
					break;
				case "partcategory":
					ret = _partcategory.ToString();
					break;
				case "partdescription":
					ret = _partdescription.ToString();
					break;
				case "maxlevelstounlock":
					ret = _maxlevelstounlock.ToString();
					break;
				case "upgradestacktype":
					ret = _upgradestacktype.ToString();
					break;
				case "partprerequisites":
					ret = _partprerequisites.ToString();
					break;
				case "partprerequisitestaff":
					ret = _partprerequisitestaff.ToString();
					break;
				case "partprerequisitedivision":
					ret = _partprerequisitedivision.ToString();
					break;
				case "daystoresearch":
					ret = _daystoresearch.ToString();
					break;
				case "costtoresearch":
					ret = _costtoresearch.ToString();
					break;
				case "effectonhp":
					ret = _effectonhp.ToString();
					break;
				case "effectontorque":
					ret = _effectontorque.ToString();
					break;
				case "effectonturbopsi":
					ret = _effectonturbopsi.ToString();
					break;
				case "effectonnitrocapacity":
					ret = _effectonnitrocapacity.ToString();
					break;
				case "effectonnitrodurability":
					ret = _effectonnitrodurability.ToString();
					break;
				case "effectonnitrofuel":
					ret = _effectonnitrofuel.ToString();
					break;
				case "effectonshiftspeed":
					ret = _effectonshiftspeed.ToString();
					break;
				case "tirecoefficientofgripchange":
					ret = _tirecoefficientofgripchange.ToString();
					break;
				case "tirehardnesseffect":
					ret = _tirehardnesseffect.ToString();
					break;
				case "coolingmaxtempeffect":
					ret = _coolingmaxtempeffect.ToString();
					break;
				case "coolingbaseeffect":
					ret = _coolingbaseeffect.ToString();
					break;
				case "humanerrorreductor":
					ret = _humanerrorreductor.ToString();
					break;
				case "frontwingeffectdownforceeffect":
					ret = _frontwingeffectdownforceeffect.ToString();
					break;
				case "rearwingdownforceeffect":
					ret = _rearwingdownforceeffect.ToString();
					break;
				case "frontwingangleeffect":
					ret = _frontwingangleeffect.ToString();
					break;
				case "rearwingangleeffect":
					ret = _rearwingangleeffect.ToString();
					break;
				case "bodyaerodragreduce":
					ret = _bodyaerodragreduce.ToString();
					break;
				case "percentofdrswingtoremove":
					ret = _percentofdrswingtoremove.ToString();
					break;
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "id" + " : " + _id.ToString() + "} ";
			ret += "{" + "partname" + " : " + _partname.ToString() + "} ";
			ret += "{" + "partcategory" + " : " + _partcategory.ToString() + "} ";
			ret += "{" + "partdescription" + " : " + _partdescription.ToString() + "} ";
			ret += "{" + "maxlevelstounlock" + " : " + _maxlevelstounlock.ToString() + "} ";
			ret += "{" + "upgradestacktype" + " : " + _upgradestacktype.ToString() + "} ";
			ret += "{" + "partprerequisites" + " : " + _partprerequisites.ToString() + "} ";
			ret += "{" + "partprerequisitestaff" + " : " + _partprerequisitestaff.ToString() + "} ";
			ret += "{" + "partprerequisitedivision" + " : " + _partprerequisitedivision.ToString() + "} ";
			ret += "{" + "daystoresearch" + " : " + _daystoresearch.ToString() + "} ";
			ret += "{" + "costtoresearch" + " : " + _costtoresearch.ToString() + "} ";
			ret += "{" + "effectonhp" + " : " + _effectonhp.ToString() + "} ";
			ret += "{" + "effectontorque" + " : " + _effectontorque.ToString() + "} ";
			ret += "{" + "effectonturbopsi" + " : " + _effectonturbopsi.ToString() + "} ";
			ret += "{" + "effectonnitrocapacity" + " : " + _effectonnitrocapacity.ToString() + "} ";
			ret += "{" + "effectonnitrodurability" + " : " + _effectonnitrodurability.ToString() + "} ";
			ret += "{" + "effectonnitrofuel" + " : " + _effectonnitrofuel.ToString() + "} ";
			ret += "{" + "effectonshiftspeed" + " : " + _effectonshiftspeed.ToString() + "} ";
			ret += "{" + "tirecoefficientofgripchange" + " : " + _tirecoefficientofgripchange.ToString() + "} ";
			ret += "{" + "tirehardnesseffect" + " : " + _tirehardnesseffect.ToString() + "} ";
			ret += "{" + "coolingmaxtempeffect" + " : " + _coolingmaxtempeffect.ToString() + "} ";
			ret += "{" + "coolingbaseeffect" + " : " + _coolingbaseeffect.ToString() + "} ";
			ret += "{" + "humanerrorreductor" + " : " + _humanerrorreductor.ToString() + "} ";
			ret += "{" + "frontwingeffectdownforceeffect" + " : " + _frontwingeffectdownforceeffect.ToString() + "} ";
			ret += "{" + "rearwingdownforceeffect" + " : " + _rearwingdownforceeffect.ToString() + "} ";
			ret += "{" + "frontwingangleeffect" + " : " + _frontwingangleeffect.ToString() + "} ";
			ret += "{" + "rearwingangleeffect" + " : " + _rearwingangleeffect.ToString() + "} ";
			ret += "{" + "bodyaerodragreduce" + " : " + _bodyaerodragreduce.ToString() + "} ";
			ret += "{" + "percentofdrswingtoremove" + " : " + _percentofdrswingtoremove.ToString() + "} ";
			return ret;
		}
	}
	public sealed class RnD : IGoogleFuDB
	{
		public enum rowIds {
			PART_1, PART_2, PART_3, PART_4, PART_5, PART_6, PART_7, PART_8, PART_9, PART_10, PART_11, PART_12, PART_13, PART_14, PART_15, PART_16, PART_17
		};
		public string [] rowNames = {
			"PART_1", "PART_2", "PART_3", "PART_4", "PART_5", "PART_6", "PART_7", "PART_8", "PART_9", "PART_10", "PART_11", "PART_12", "PART_13", "PART_14", "PART_15", "PART_16", "PART_17"
		};
		public System.Collections.Generic.List<RnDRow> Rows = new System.Collections.Generic.List<RnDRow>();

		public static RnD Instance
		{
			get { return NestedRnD.instance; }
		}

		private class NestedRnD
		{
			static NestedRnD() { }
			internal static readonly RnD instance = new RnD();
		}

		private RnD()
		{
			Rows.Add( new RnDRow("1",
														"Micro Turbo",
														"Turbo",
														"Provides a 0.25 PSI Boost to this cars Turbo",
														"4",
														"Linear",
														"",
														"1",
														"4",
														"12",
														"60000",
														"0",
														"0",
														"0.25",
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
														"0",
														"0",
														"0",
														"0"));
			Rows.Add( new RnDRow("2",
														"Medium Turbo",
														"Turbo",
														"Provides a 0.5 PSI Boost to this cars Turbo",
														"3",
														"Linear",
														"Micro Turbo",
														"3",
														"3",
														"30",
														"90000",
														"0",
														"0",
														"0.5",
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
														"0",
														"0",
														"0",
														"0"));
			Rows.Add( new RnDRow("3",
														"Super Turbo",
														"Turbo",
														"Provies a 1 PSI Boost to this cars Turbo",
														"2",
														"Linear",
														"Medium Turbo",
														"6",
														"1",
														"60",
														"120000",
														"0",
														"0",
														"1",
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
														"0",
														"0",
														"0",
														"0"));
			Rows.Add( new RnDRow("4",
														"Advanced Ignition",
														"Engine",
														"No Description",
														"3",
														"Linear",
														"",
														"1",
														"4",
														"15",
														"50000",
														"20",
														"20",
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
														"0",
														"0",
														"0",
														"0",
														"0"));
			Rows.Add( new RnDRow("5",
														"Variable Valve Timing",
														"Engine",
														"No Description",
														"2",
														"Linear",
														"Advanced Ignition",
														"2",
														"3",
														"35",
														"75000",
														"40",
														"50",
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
														"0",
														"0",
														"0",
														"0",
														"0"));
			Rows.Add( new RnDRow("6",
														"Hybrid Boost",
														"Engine",
														"No Description",
														"2",
														"Linear",
														"Variable Valve Timing",
														"8",
														"2",
														"70",
														"150000",
														"50",
														"40",
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
														"0",
														"0",
														"0",
														"0",
														"0"));
			Rows.Add( new RnDRow("7",
														"Lite Nitro Storage",
														"Engine",
														"No Description",
														"3",
														"Linear",
														"",
														"2",
														"4",
														"18",
														"75000",
														"0",
														"0",
														"0",
														"1",
														"0.2",
														"5",
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
														"0"));
			Rows.Add( new RnDRow("8",
														"Advanced Nitro Durability",
														"Engine",
														"No Description",
														"3",
														"Linear",
														"Lite Nitro Storage",
														"2",
														"4",
														"18",
														"75000",
														"0",
														"0",
														"0",
														"0",
														"0",
														"10",
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
														"0"));
			Rows.Add( new RnDRow("9",
														"Nitro Ferocity ",
														"Engine",
														"No Description",
														"3",
														"Linear",
														"Lite Nitro Storage",
														"2",
														"4",
														"18",
														"75000",
														"0",
														"0",
														"0",
														"0",
														"0.3",
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
														"0",
														"0"));
			Rows.Add( new RnDRow("10",
														"Syncro Upgrade",
														"Gearbox",
														"No Description",
														"2",
														"Linear",
														"Advanced Ignition",
														"2",
														"4",
														"23",
														"75000",
														"0",
														"0",
														"0",
														"0",
														"0.2",
														"10",
														"-0.05",
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
														"0"));
			Rows.Add( new RnDRow("11",
														"Aero Kit",
														"Engine",
														"No Description",
														"2",
														"Linear",
														"",
														"5",
														"2",
														"20",
														"75000",
														"50",
														"20",
														"0",
														"0",
														"0.1",
														"20",
														"-0.1",
														"0",
														"0",
														"0",
														"0",
														"-0.01",
														"0",
														"0",
														"0",
														"0",
														"-0.1",
														"0"));
			Rows.Add( new RnDRow("12",
														"Cooling Kit",
														"Reliability",
														"No Description",
														"2",
														"Linear",
														"",
														"1",
														"4",
														"20",
														"75000",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"10",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0"));
			Rows.Add( new RnDRow("13",
														"Retreadded Rubber",
														"Reliability",
														"No Description",
														"3",
														"Linear",
														"Medium Turbo",
														"4",
														"4",
														"20",
														"75000",
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
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0"));
			Rows.Add( new RnDRow("14",
														"DRS System",
														"Aerodynamics",
														"No Description",
														"3",
														"Linear",
														"Retreadded Rubber,Advanced Nitro Durability",
														"7",
														"4",
														"20",
														"75000",
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
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0.33"));
			Rows.Add( new RnDRow("15",
														"Holographic Driver HUD",
														"Reliability",
														"No Description",
														"4",
														"Linear",
														"Nitro Ferocity ",
														"5",
														"4",
														"21",
														"75001",
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
														"0.1",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0"));
			Rows.Add( new RnDRow("16",
														"Composite Cooling Liquids",
														"Reliability",
														"No Description",
														"3",
														"Linear",
														"Syncro Upgrade",
														"6",
														"2",
														"25",
														"100000",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"20",
														"0.1",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0"));
			Rows.Add( new RnDRow("17",
														"Airless Tires",
														"Reliability",
														"No Description",
														"3",
														"Linear",
														"Cooling Kit",
														"6",
														"2",
														"25",
														"100000",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"20",
														"0.1",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0",
														"0"));
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
		public RnDRow GetRow(rowIds in_RowID)
		{
			RnDRow ret = null;
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
		public RnDRow GetRow(string in_RowString)
		{
			RnDRow ret = null;
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
