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
	public class DriverNamesRow : IGoogleFuRow
	{
		public int _id;
		public string _drivername;
		public float _aggressivenessonbrake;
		public float _spdsteeringfactor;
		public float _lookaheadfactor;
		public float _lookaheadconstant;
		public float _corneringspeedfactor;
		public float _maxdriftangle;
		public float _driftingthrotlefactor;
		public float _steeringdriftfactor;
		public float _sideavoidingfactor;
		public float _collisionsidefactor;
		public float _overtakefactor;
		public float _humanerror;
		public float _overtakespeeddifference;
		public float _overtakeoffsetincrementmin;
		public float _overtakeoffsetincrementmax;
		public float _backtolineincrement;
		public float _shiftfactor;
		public float _shiftupfactor;
		public float _tyrechangepercentage;
		public float _fuelloadpercentage;
		public float _fullaccelmaring;
		public float _frontcolldist;
		public float _backcolldist;
		public float _sidemargin;
		public float _heightmargin;
		public float _lengthmargin;
		public float _sidemargin_2;
		public float _offtrackthrottlemultiplier;
		public float _jumpthrottlemultiplier;
		public float _jumpthrottletime;
		public float _aggressivemultiplier;
		public float _passivemultiplier;
		public DriverNamesRow(string __id, string __drivername, string __aggressivenessonbrake, string __spdsteeringfactor, string __lookaheadfactor, string __lookaheadconstant, string __corneringspeedfactor, string __maxdriftangle, string __driftingthrotlefactor, string __steeringdriftfactor, string __sideavoidingfactor, string __collisionsidefactor, string __overtakefactor, string __humanerror, string __overtakespeeddifference, string __overtakeoffsetincrementmin, string __overtakeoffsetincrementmax, string __backtolineincrement, string __shiftfactor, string __shiftupfactor, string __tyrechangepercentage, string __fuelloadpercentage, string __fullaccelmaring, string __frontcolldist, string __backcolldist, string __sidemargin, string __heightmargin, string __lengthmargin, string __sidemargin_2, string __offtrackthrottlemultiplier, string __jumpthrottlemultiplier, string __jumpthrottletime, string __aggressivemultiplier, string __passivemultiplier) 
		{
			{
			int res;
				if(int.TryParse(__id, out res))
					_id = res;
				else
					Debug.LogError("Failed To Convert id string: "+ __id +" to int");
			}
			_drivername = __drivername;
			{
			float res;
				if(float.TryParse(__aggressivenessonbrake, out res))
					_aggressivenessonbrake = res;
				else
					Debug.LogError("Failed To Convert aggressivenessonbrake string: "+ __aggressivenessonbrake +" to float");
			}
			{
			float res;
				if(float.TryParse(__spdsteeringfactor, out res))
					_spdsteeringfactor = res;
				else
					Debug.LogError("Failed To Convert spdsteeringfactor string: "+ __spdsteeringfactor +" to float");
			}
			{
			float res;
				if(float.TryParse(__lookaheadfactor, out res))
					_lookaheadfactor = res;
				else
					Debug.LogError("Failed To Convert lookaheadfactor string: "+ __lookaheadfactor +" to float");
			}
			{
			float res;
				if(float.TryParse(__lookaheadconstant, out res))
					_lookaheadconstant = res;
				else
					Debug.LogError("Failed To Convert lookaheadconstant string: "+ __lookaheadconstant +" to float");
			}
			{
			float res;
				if(float.TryParse(__corneringspeedfactor, out res))
					_corneringspeedfactor = res;
				else
					Debug.LogError("Failed To Convert corneringspeedfactor string: "+ __corneringspeedfactor +" to float");
			}
			{
			float res;
				if(float.TryParse(__maxdriftangle, out res))
					_maxdriftangle = res;
				else
					Debug.LogError("Failed To Convert maxdriftangle string: "+ __maxdriftangle +" to float");
			}
			{
			float res;
				if(float.TryParse(__driftingthrotlefactor, out res))
					_driftingthrotlefactor = res;
				else
					Debug.LogError("Failed To Convert driftingthrotlefactor string: "+ __driftingthrotlefactor +" to float");
			}
			{
			float res;
				if(float.TryParse(__steeringdriftfactor, out res))
					_steeringdriftfactor = res;
				else
					Debug.LogError("Failed To Convert steeringdriftfactor string: "+ __steeringdriftfactor +" to float");
			}
			{
			float res;
				if(float.TryParse(__sideavoidingfactor, out res))
					_sideavoidingfactor = res;
				else
					Debug.LogError("Failed To Convert sideavoidingfactor string: "+ __sideavoidingfactor +" to float");
			}
			{
			float res;
				if(float.TryParse(__collisionsidefactor, out res))
					_collisionsidefactor = res;
				else
					Debug.LogError("Failed To Convert collisionsidefactor string: "+ __collisionsidefactor +" to float");
			}
			{
			float res;
				if(float.TryParse(__overtakefactor, out res))
					_overtakefactor = res;
				else
					Debug.LogError("Failed To Convert overtakefactor string: "+ __overtakefactor +" to float");
			}
			{
			float res;
				if(float.TryParse(__humanerror, out res))
					_humanerror = res;
				else
					Debug.LogError("Failed To Convert humanerror string: "+ __humanerror +" to float");
			}
			{
			float res;
				if(float.TryParse(__overtakespeeddifference, out res))
					_overtakespeeddifference = res;
				else
					Debug.LogError("Failed To Convert overtakespeeddifference string: "+ __overtakespeeddifference +" to float");
			}
			{
			float res;
				if(float.TryParse(__overtakeoffsetincrementmin, out res))
					_overtakeoffsetincrementmin = res;
				else
					Debug.LogError("Failed To Convert overtakeoffsetincrementmin string: "+ __overtakeoffsetincrementmin +" to float");
			}
			{
			float res;
				if(float.TryParse(__overtakeoffsetincrementmax, out res))
					_overtakeoffsetincrementmax = res;
				else
					Debug.LogError("Failed To Convert overtakeoffsetincrementmax string: "+ __overtakeoffsetincrementmax +" to float");
			}
			{
			float res;
				if(float.TryParse(__backtolineincrement, out res))
					_backtolineincrement = res;
				else
					Debug.LogError("Failed To Convert backtolineincrement string: "+ __backtolineincrement +" to float");
			}
			{
			float res;
				if(float.TryParse(__shiftfactor, out res))
					_shiftfactor = res;
				else
					Debug.LogError("Failed To Convert shiftfactor string: "+ __shiftfactor +" to float");
			}
			{
			float res;
				if(float.TryParse(__shiftupfactor, out res))
					_shiftupfactor = res;
				else
					Debug.LogError("Failed To Convert shiftupfactor string: "+ __shiftupfactor +" to float");
			}
			{
			float res;
				if(float.TryParse(__tyrechangepercentage, out res))
					_tyrechangepercentage = res;
				else
					Debug.LogError("Failed To Convert tyrechangepercentage string: "+ __tyrechangepercentage +" to float");
			}
			{
			float res;
				if(float.TryParse(__fuelloadpercentage, out res))
					_fuelloadpercentage = res;
				else
					Debug.LogError("Failed To Convert fuelloadpercentage string: "+ __fuelloadpercentage +" to float");
			}
			{
			float res;
				if(float.TryParse(__fullaccelmaring, out res))
					_fullaccelmaring = res;
				else
					Debug.LogError("Failed To Convert fullaccelmaring string: "+ __fullaccelmaring +" to float");
			}
			{
			float res;
				if(float.TryParse(__frontcolldist, out res))
					_frontcolldist = res;
				else
					Debug.LogError("Failed To Convert frontcolldist string: "+ __frontcolldist +" to float");
			}
			{
			float res;
				if(float.TryParse(__backcolldist, out res))
					_backcolldist = res;
				else
					Debug.LogError("Failed To Convert backcolldist string: "+ __backcolldist +" to float");
			}
			{
			float res;
				if(float.TryParse(__sidemargin, out res))
					_sidemargin = res;
				else
					Debug.LogError("Failed To Convert sidemargin string: "+ __sidemargin +" to float");
			}
			{
			float res;
				if(float.TryParse(__heightmargin, out res))
					_heightmargin = res;
				else
					Debug.LogError("Failed To Convert heightmargin string: "+ __heightmargin +" to float");
			}
			{
			float res;
				if(float.TryParse(__lengthmargin, out res))
					_lengthmargin = res;
				else
					Debug.LogError("Failed To Convert lengthmargin string: "+ __lengthmargin +" to float");
			}
			{
			float res;
				if(float.TryParse(__sidemargin_2, out res))
					_sidemargin_2 = res;
				else
					Debug.LogError("Failed To Convert sidemargin_2 string: "+ __sidemargin_2 +" to float");
			}
			{
			float res;
				if(float.TryParse(__offtrackthrottlemultiplier, out res))
					_offtrackthrottlemultiplier = res;
				else
					Debug.LogError("Failed To Convert offtrackthrottlemultiplier string: "+ __offtrackthrottlemultiplier +" to float");
			}
			{
			float res;
				if(float.TryParse(__jumpthrottlemultiplier, out res))
					_jumpthrottlemultiplier = res;
				else
					Debug.LogError("Failed To Convert jumpthrottlemultiplier string: "+ __jumpthrottlemultiplier +" to float");
			}
			{
			float res;
				if(float.TryParse(__jumpthrottletime, out res))
					_jumpthrottletime = res;
				else
					Debug.LogError("Failed To Convert jumpthrottletime string: "+ __jumpthrottletime +" to float");
			}
			{
			float res;
				if(float.TryParse(__aggressivemultiplier, out res))
					_aggressivemultiplier = res;
				else
					Debug.LogError("Failed To Convert aggressivemultiplier string: "+ __aggressivemultiplier +" to float");
			}
			{
			float res;
				if(float.TryParse(__passivemultiplier, out res))
					_passivemultiplier = res;
				else
					Debug.LogError("Failed To Convert passivemultiplier string: "+ __passivemultiplier +" to float");
			}
		}

		public int Length { get { return 34; } }

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
					ret = _drivername.ToString();
					break;
				case 2:
					ret = _aggressivenessonbrake.ToString();
					break;
				case 3:
					ret = _spdsteeringfactor.ToString();
					break;
				case 4:
					ret = _lookaheadfactor.ToString();
					break;
				case 5:
					ret = _lookaheadconstant.ToString();
					break;
				case 6:
					ret = _corneringspeedfactor.ToString();
					break;
				case 7:
					ret = _maxdriftangle.ToString();
					break;
				case 8:
					ret = _driftingthrotlefactor.ToString();
					break;
				case 9:
					ret = _steeringdriftfactor.ToString();
					break;
				case 10:
					ret = _sideavoidingfactor.ToString();
					break;
				case 11:
					ret = _collisionsidefactor.ToString();
					break;
				case 12:
					ret = _overtakefactor.ToString();
					break;
				case 13:
					ret = _humanerror.ToString();
					break;
				case 14:
					ret = _overtakespeeddifference.ToString();
					break;
				case 15:
					ret = _overtakeoffsetincrementmin.ToString();
					break;
				case 16:
					ret = _overtakeoffsetincrementmax.ToString();
					break;
				case 17:
					ret = _backtolineincrement.ToString();
					break;
				case 18:
					ret = _shiftfactor.ToString();
					break;
				case 19:
					ret = _shiftupfactor.ToString();
					break;
				case 20:
					ret = _tyrechangepercentage.ToString();
					break;
				case 21:
					ret = _fuelloadpercentage.ToString();
					break;
				case 22:
					ret = _fullaccelmaring.ToString();
					break;
				case 23:
					ret = _frontcolldist.ToString();
					break;
				case 24:
					ret = _backcolldist.ToString();
					break;
				case 25:
					ret = _sidemargin.ToString();
					break;
				case 26:
					ret = _heightmargin.ToString();
					break;
				case 27:
					ret = _lengthmargin.ToString();
					break;
				case 28:
					ret = _sidemargin_2.ToString();
					break;
				case 29:
					ret = _offtrackthrottlemultiplier.ToString();
					break;
				case 30:
					ret = _jumpthrottlemultiplier.ToString();
					break;
				case 31:
					ret = _jumpthrottletime.ToString();
					break;
				case 32:
					ret = _aggressivemultiplier.ToString();
					break;
				case 33:
					ret = _passivemultiplier.ToString();
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
				case "drivername":
					ret = _drivername.ToString();
					break;
				case "aggressivenessonbrake":
					ret = _aggressivenessonbrake.ToString();
					break;
				case "spdsteeringfactor":
					ret = _spdsteeringfactor.ToString();
					break;
				case "lookaheadfactor":
					ret = _lookaheadfactor.ToString();
					break;
				case "lookaheadconstant":
					ret = _lookaheadconstant.ToString();
					break;
				case "corneringspeedfactor":
					ret = _corneringspeedfactor.ToString();
					break;
				case "maxdriftangle":
					ret = _maxdriftangle.ToString();
					break;
				case "driftingthrotlefactor":
					ret = _driftingthrotlefactor.ToString();
					break;
				case "steeringdriftfactor":
					ret = _steeringdriftfactor.ToString();
					break;
				case "sideavoidingfactor":
					ret = _sideavoidingfactor.ToString();
					break;
				case "collisionsidefactor":
					ret = _collisionsidefactor.ToString();
					break;
				case "overtakefactor":
					ret = _overtakefactor.ToString();
					break;
				case "humanerror":
					ret = _humanerror.ToString();
					break;
				case "overtakespeeddifference":
					ret = _overtakespeeddifference.ToString();
					break;
				case "overtakeoffsetincrementmin":
					ret = _overtakeoffsetincrementmin.ToString();
					break;
				case "overtakeoffsetincrementmax":
					ret = _overtakeoffsetincrementmax.ToString();
					break;
				case "backtolineincrement":
					ret = _backtolineincrement.ToString();
					break;
				case "shiftfactor":
					ret = _shiftfactor.ToString();
					break;
				case "shiftupfactor":
					ret = _shiftupfactor.ToString();
					break;
				case "tyrechangepercentage":
					ret = _tyrechangepercentage.ToString();
					break;
				case "fuelloadpercentage":
					ret = _fuelloadpercentage.ToString();
					break;
				case "fullaccelmaring":
					ret = _fullaccelmaring.ToString();
					break;
				case "frontcolldist":
					ret = _frontcolldist.ToString();
					break;
				case "backcolldist":
					ret = _backcolldist.ToString();
					break;
				case "sidemargin":
					ret = _sidemargin.ToString();
					break;
				case "heightmargin":
					ret = _heightmargin.ToString();
					break;
				case "lengthmargin":
					ret = _lengthmargin.ToString();
					break;
				case "sidemargin_2":
					ret = _sidemargin_2.ToString();
					break;
				case "offtrackthrottlemultiplier":
					ret = _offtrackthrottlemultiplier.ToString();
					break;
				case "jumpthrottlemultiplier":
					ret = _jumpthrottlemultiplier.ToString();
					break;
				case "jumpthrottletime":
					ret = _jumpthrottletime.ToString();
					break;
				case "aggressivemultiplier":
					ret = _aggressivemultiplier.ToString();
					break;
				case "passivemultiplier":
					ret = _passivemultiplier.ToString();
					break;
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "id" + " : " + _id.ToString() + "} ";
			ret += "{" + "drivername" + " : " + _drivername.ToString() + "} ";
			ret += "{" + "aggressivenessonbrake" + " : " + _aggressivenessonbrake.ToString() + "} ";
			ret += "{" + "spdsteeringfactor" + " : " + _spdsteeringfactor.ToString() + "} ";
			ret += "{" + "lookaheadfactor" + " : " + _lookaheadfactor.ToString() + "} ";
			ret += "{" + "lookaheadconstant" + " : " + _lookaheadconstant.ToString() + "} ";
			ret += "{" + "corneringspeedfactor" + " : " + _corneringspeedfactor.ToString() + "} ";
			ret += "{" + "maxdriftangle" + " : " + _maxdriftangle.ToString() + "} ";
			ret += "{" + "driftingthrotlefactor" + " : " + _driftingthrotlefactor.ToString() + "} ";
			ret += "{" + "steeringdriftfactor" + " : " + _steeringdriftfactor.ToString() + "} ";
			ret += "{" + "sideavoidingfactor" + " : " + _sideavoidingfactor.ToString() + "} ";
			ret += "{" + "collisionsidefactor" + " : " + _collisionsidefactor.ToString() + "} ";
			ret += "{" + "overtakefactor" + " : " + _overtakefactor.ToString() + "} ";
			ret += "{" + "humanerror" + " : " + _humanerror.ToString() + "} ";
			ret += "{" + "overtakespeeddifference" + " : " + _overtakespeeddifference.ToString() + "} ";
			ret += "{" + "overtakeoffsetincrementmin" + " : " + _overtakeoffsetincrementmin.ToString() + "} ";
			ret += "{" + "overtakeoffsetincrementmax" + " : " + _overtakeoffsetincrementmax.ToString() + "} ";
			ret += "{" + "backtolineincrement" + " : " + _backtolineincrement.ToString() + "} ";
			ret += "{" + "shiftfactor" + " : " + _shiftfactor.ToString() + "} ";
			ret += "{" + "shiftupfactor" + " : " + _shiftupfactor.ToString() + "} ";
			ret += "{" + "tyrechangepercentage" + " : " + _tyrechangepercentage.ToString() + "} ";
			ret += "{" + "fuelloadpercentage" + " : " + _fuelloadpercentage.ToString() + "} ";
			ret += "{" + "fullaccelmaring" + " : " + _fullaccelmaring.ToString() + "} ";
			ret += "{" + "frontcolldist" + " : " + _frontcolldist.ToString() + "} ";
			ret += "{" + "backcolldist" + " : " + _backcolldist.ToString() + "} ";
			ret += "{" + "sidemargin" + " : " + _sidemargin.ToString() + "} ";
			ret += "{" + "heightmargin" + " : " + _heightmargin.ToString() + "} ";
			ret += "{" + "lengthmargin" + " : " + _lengthmargin.ToString() + "} ";
			ret += "{" + "sidemargin_2" + " : " + _sidemargin_2.ToString() + "} ";
			ret += "{" + "offtrackthrottlemultiplier" + " : " + _offtrackthrottlemultiplier.ToString() + "} ";
			ret += "{" + "jumpthrottlemultiplier" + " : " + _jumpthrottlemultiplier.ToString() + "} ";
			ret += "{" + "jumpthrottletime" + " : " + _jumpthrottletime.ToString() + "} ";
			ret += "{" + "aggressivemultiplier" + " : " + _aggressivemultiplier.ToString() + "} ";
			ret += "{" + "passivemultiplier" + " : " + _passivemultiplier.ToString() + "} ";
			return ret;
		}
	}
	public sealed class DriverNames : IGoogleFuDB
	{
		public enum rowIds {
			DRIVER_1, DRIVER_2, DRIVER_3, DRIVER_4, DRIVER_5, DRIVER_6, DRIVER_7, DRIVER_8, DRIVER_9, DRIVER_10, DRIVER_11, DRIVER_12, DRIVER_13, DRIVER_14, DRIVER_15, DRIVER_16, DRIVER_17, DRIVER_18, DRIVER_19, DRIVER_20, 
			DRIVER_21, DRIVER_22, DRIVER_23, DRIVER_24, DRIVER_25, DRIVER_26, DRIVER_27, DRIVER_28, DRIVER_29, DRIVER_30, DRIVER_31, DRIVER_32, DRIVER_33, DRIVER_34
		};
		public string [] rowNames = {
			"DRIVER_1", "DRIVER_2", "DRIVER_3", "DRIVER_4", "DRIVER_5", "DRIVER_6", "DRIVER_7", "DRIVER_8", "DRIVER_9", "DRIVER_10", "DRIVER_11", "DRIVER_12", "DRIVER_13", "DRIVER_14", "DRIVER_15", "DRIVER_16", "DRIVER_17", "DRIVER_18", "DRIVER_19", "DRIVER_20", 
			"DRIVER_21", "DRIVER_22", "DRIVER_23", "DRIVER_24", "DRIVER_25", "DRIVER_26", "DRIVER_27", "DRIVER_28", "DRIVER_29", "DRIVER_30", "DRIVER_31", "DRIVER_32", "DRIVER_33", "DRIVER_34"
		};
		public System.Collections.Generic.List<DriverNamesRow> Rows = new System.Collections.Generic.List<DriverNamesRow>();

		public static DriverNames Instance
		{
			get { return NestedDriverNames.instance; }
		}

		private class NestedDriverNames
		{
			static NestedDriverNames() { }
			internal static readonly DriverNames instance = new DriverNames();
		}

		private DriverNames()
		{
			Rows.Add( new DriverNamesRow("1",
														"A. Starnes",
														"1.3",
														"100",
														"4",
														"6.5",
														"1.9",
														"5",
														"1",
														"0.2",
														"0.9",
														"1",
														"2",
														"0.01",
														"-3",
														"0.03",
														"0.08",
														"0.05",
														"0.6",
														"0.95",
														"0.2",
														"0.1",
														"3",
														"250",
														"50",
														"1",
														"0",
														"0.1",
														"0.5",
														"0.7",
														"1",
														"0",
														"1.2",
														"0.8"));
			Rows.Add( new DriverNamesRow("2",
														"J. Starnes",
														"1.4",
														"100",
														"3.5",
														"6.6",
														"1.85",
														"5",
														"1",
														"0.2",
														"0.9",
														"1",
														"2",
														"0.02",
														"-3.2",
														"0.03",
														"0.08",
														"0.05",
														"0.6",
														"0.95",
														"0.2",
														"0.1",
														"3",
														"250",
														"50",
														"1",
														"0",
														"0.1",
														"0.5",
														"0.7",
														"1",
														"0",
														"1.2",
														"0.8"));
			Rows.Add( new DriverNamesRow("3",
														"J. Shrubbs",
														"1.35",
														"100",
														"3.8",
														"6.4",
														"1.94",
														"5",
														"1",
														"0.2",
														"0.9",
														"1",
														"2",
														"0.015",
														"-4",
														"0.03",
														"0.08",
														"0.05",
														"0.6",
														"0.95",
														"0.2",
														"0.1",
														"3",
														"250",
														"50",
														"1",
														"0",
														"0.1",
														"0.5",
														"0.7",
														"1",
														"0",
														"1.2",
														"0.8"));
			Rows.Add( new DriverNamesRow("4",
														"G. Barber",
														"1.5",
														"100",
														"3.9",
														"6.2",
														"1.96",
														"5",
														"1",
														"0.2",
														"0.9",
														"1",
														"2",
														"0.02",
														"-3.1",
														"0.03",
														"0.08",
														"0.05",
														"0.6",
														"0.95",
														"0.2",
														"0.1",
														"3",
														"250",
														"50",
														"1",
														"0",
														"0.1",
														"0.5",
														"0.7",
														"1",
														"0",
														"1.2",
														"0.8"));
			Rows.Add( new DriverNamesRow("5",
														"J. Turner",
														"1.45",
														"100",
														"4",
														"6.25",
														"1.9",
														"5",
														"1",
														"0.2",
														"0.9",
														"1",
														"2",
														"0.015",
														"-3.3",
														"0.03",
														"0.08",
														"0.05",
														"0.6",
														"0.95",
														"0.2",
														"0.1",
														"3",
														"250",
														"50",
														"1",
														"0",
														"0.1",
														"0.5",
														"0.7",
														"1",
														"0",
														"1.2",
														"0.8"));
			Rows.Add( new DriverNamesRow("6",
														"M. Smith",
														"1.6",
														"100",
														"3.7",
														"6.1",
														"1.94",
														"5",
														"1",
														"0.2",
														"0.9",
														"1",
														"2",
														"0.017",
														"-3.4",
														"0.03",
														"0.08",
														"0.05",
														"0.6",
														"0.95",
														"0.2",
														"0.1",
														"3",
														"250",
														"50",
														"1",
														"0",
														"0.1",
														"0.5",
														"0.7",
														"1",
														"0",
														"1.2",
														"0.8"));
			Rows.Add( new DriverNamesRow("7",
														"R. Starnes",
														"1.38",
														"100",
														"3.6",
														"6.05",
														"1.92",
														"5",
														"1",
														"0.2",
														"0.9",
														"1",
														"2",
														"0.018",
														"-3.6",
														"0.03",
														"0.08",
														"0.05",
														"0.6",
														"0.95",
														"0.2",
														"0.1",
														"3",
														"250",
														"50",
														"1",
														"0",
														"0.1",
														"0.5",
														"0.7",
														"1",
														"0",
														"1.2",
														"0.8"));
			Rows.Add( new DriverNamesRow("8",
														"J. Mitgang",
														"1.4",
														"100",
														"3.5",
														"5.94",
														"1.94",
														"5",
														"1",
														"0.2",
														"0.9",
														"1",
														"2",
														"0.02",
														"-3.8",
														"0.03",
														"0.08",
														"0.05",
														"0.6",
														"0.95",
														"0.2",
														"0.1",
														"3",
														"250",
														"50",
														"1",
														"0",
														"0.1",
														"0.5",
														"0.7",
														"1",
														"0",
														"1.2",
														"0.8"));
			Rows.Add( new DriverNamesRow("9",
														"S. Green",
														"1.25",
														"100",
														"4",
														"5.96",
														"1.78",
														"5",
														"1",
														"0.2",
														"0.9",
														"1",
														"2",
														"0.025",
														"-2.9",
														"0.03",
														"0.08",
														"0.05",
														"0.6",
														"0.95",
														"0.2",
														"0.1",
														"3",
														"250",
														"50",
														"1",
														"0",
														"0.1",
														"0.5",
														"0.7",
														"1",
														"0",
														"1.2",
														"0.8"));
			Rows.Add( new DriverNamesRow("10",
														"L. Bass",
														"1.3",
														"100",
														"3.4",
														"5.98",
														"1.79",
														"5",
														"1",
														"0.2",
														"0.9",
														"1",
														"2",
														"0.03",
														"-3.5",
														"0.03",
														"0.08",
														"0.05",
														"0.6",
														"0.95",
														"0.2",
														"0.1",
														"3",
														"250",
														"50",
														"1",
														"0",
														"0.1",
														"0.5",
														"0.7",
														"1",
														"0",
														"1.2",
														"0.8"));
			Rows.Add( new DriverNamesRow("11",
														"H. Parker",
														"1.28",
														"100",
														"3.2",
														"5.99",
														"1.69",
														"5",
														"1",
														"0.2",
														"0.9",
														"1",
														"2",
														"0.03",
														"-4",
														"0.03",
														"0.08",
														"0.05",
														"0.6",
														"0.95",
														"0.2",
														"0.1",
														"3",
														"250",
														"50",
														"1",
														"0",
														"0.1",
														"0.5",
														"0.7",
														"1",
														"0",
														"1.2",
														"0.8"));
			Rows.Add( new DriverNamesRow("12",
														"M. Starnes",
														"1.27",
														"100",
														"3.3",
														"6.01",
														"1.62",
														"5",
														"1",
														"0.2",
														"0.9",
														"1",
														"2",
														"0.029",
														"-4.3",
														"0.03",
														"0.08",
														"0.05",
														"0.6",
														"0.95",
														"0.2",
														"0.1",
														"3",
														"250",
														"50",
														"1",
														"0",
														"0.1",
														"0.5",
														"0.7",
														"1",
														"0",
														"1.2",
														"0.8"));
			Rows.Add( new DriverNamesRow("13",
														"E. Furlong",
														"1.26",
														"100",
														"3.2",
														"6",
														"1.62",
														"5",
														"1",
														"0.2",
														"0.9",
														"1",
														"2",
														"0.028",
														"-4.5",
														"0.03",
														"0.08",
														"0.05",
														"0.6",
														"0.95",
														"0.2",
														"0.1",
														"3",
														"250",
														"50",
														"1",
														"0",
														"0.1",
														"0.5",
														"0.7",
														"1",
														"0",
														"1.2",
														"0.8"));
			Rows.Add( new DriverNamesRow("14",
														"H. Mead",
														"1.25",
														"100",
														"3.3",
														"5.89",
														"1.65",
														"5",
														"1",
														"0.2",
														"0.9",
														"1",
														"2",
														"0.031",
														"-4.7",
														"0.03",
														"0.08",
														"0.05",
														"0.6",
														"0.95",
														"0.2",
														"0.1",
														"3",
														"250",
														"50",
														"1",
														"0",
														"0.1",
														"0.5",
														"0.7",
														"1",
														"0",
														"1.2",
														"0.8"));
			Rows.Add( new DriverNamesRow("15",
														"P. Mead",
														"1.17",
														"100",
														"3.1",
														"5.8",
														"1.68",
														"5",
														"1",
														"0.2",
														"0.9",
														"1",
														"2",
														"0.032",
														"-4.8",
														"0.03",
														"0.08",
														"0.05",
														"0.6",
														"0.95",
														"0.2",
														"0.1",
														"3",
														"250",
														"50",
														"1",
														"0",
														"0.1",
														"0.5",
														"0.7",
														"1",
														"0",
														"1.2",
														"0.8"));
			Rows.Add( new DriverNamesRow("16",
														"A. Cornell",
														"1.06",
														"100",
														"3",
														"5.75",
														"1.66",
														"5",
														"1",
														"0.2",
														"0.9",
														"1",
														"2",
														"0.033",
														"-4.9",
														"0.03",
														"0.08",
														"0.05",
														"0.6",
														"0.95",
														"0.2",
														"0.1",
														"3",
														"250",
														"50",
														"1",
														"0",
														"0.1",
														"0.5",
														"0.7",
														"1",
														"0",
														"1.2",
														"0.8"));
			Rows.Add( new DriverNamesRow("17",
														"S. McGivern",
														"1.3",
														"100",
														"3.05",
														"5.81",
														"1.63",
														"5",
														"1",
														"0.2",
														"0.9",
														"1",
														"2",
														"0.029",
														"-5",
														"0.03",
														"0.08",
														"0.05",
														"0.6",
														"0.95",
														"0.2",
														"0.1",
														"3",
														"250",
														"50",
														"1",
														"0",
														"0.1",
														"0.5",
														"0.7",
														"1",
														"0",
														"1.2",
														"0.8"));
			Rows.Add( new DriverNamesRow("18",
														"K. Rowe",
														"1.14",
														"100",
														"3.15",
														"5.82",
														"1.53",
														"5",
														"1",
														"0.2",
														"0.9",
														"1",
														"2",
														"0.031",
														"-5.1",
														"0.03",
														"0.08",
														"0.05",
														"0.6",
														"0.95",
														"0.2",
														"0.1",
														"3",
														"250",
														"50",
														"1",
														"0",
														"0.1",
														"0.5",
														"0.7",
														"1",
														"0",
														"1.2",
														"0.8"));
			Rows.Add( new DriverNamesRow("19",
														"M. Smith",
														"1.13",
														"100",
														"3.35",
														"5.83",
														"1.52",
														"5",
														"1",
														"0.2",
														"0.9",
														"1",
														"2",
														"0.034",
														"-5.2",
														"0.03",
														"0.08",
														"0.05",
														"0.6",
														"0.95",
														"0.2",
														"0.1",
														"3",
														"250",
														"50",
														"1",
														"0",
														"0.1",
														"0.5",
														"0.7",
														"1",
														"0",
														"1.2",
														"0.8"));
			Rows.Add( new DriverNamesRow("20",
														"S. Williams",
														"1.08",
														"100",
														"3.4",
														"5.84",
														"2.1",
														"5",
														"1",
														"0.2",
														"0.9",
														"1",
														"2",
														"0.029",
														"-5.3",
														"0.03",
														"0.08",
														"0.05",
														"0.6",
														"0.95",
														"0.2",
														"0.1",
														"3",
														"250",
														"50",
														"1",
														"0",
														"0.1",
														"0.5",
														"0.7",
														"1",
														"0",
														"1.2",
														"0.8"));
			Rows.Add( new DriverNamesRow("21",
														"J. Williams",
														"1.12",
														"100",
														"2.9",
														"5.85",
														"2",
														"5",
														"1",
														"0.2",
														"0.9",
														"1",
														"2",
														"0.04",
														"-5.4",
														"0.03",
														"0.08",
														"0.05",
														"0.6",
														"0.95",
														"0.2",
														"0.1",
														"3",
														"250",
														"50",
														"1",
														"0",
														"0.1",
														"0.5",
														"0.7",
														"1",
														"0",
														"1.2",
														"0.8"));
			Rows.Add( new DriverNamesRow("22",
														"B. Williams",
														"1.09",
														"100",
														"2.7",
														"5.92",
														"1.8",
														"5",
														"1",
														"0.2",
														"0.9",
														"1",
														"2",
														"0.038",
														"-5.5",
														"0.03",
														"0.08",
														"0.05",
														"0.6",
														"0.95",
														"0.2",
														"0.1",
														"3",
														"250",
														"50",
														"1",
														"0",
														"0.1",
														"0.5",
														"0.7",
														"1",
														"0",
														"1.2",
														"0.8"));
			Rows.Add( new DriverNamesRow("23",
														"A. Partridge",
														"1.11",
														"100",
														"2.8",
														"5.94",
														"1.9",
														"5",
														"1",
														"0.2",
														"0.9",
														"1",
														"2",
														"0.04",
														"-6",
														"0.03",
														"0.08",
														"0.05",
														"0.6",
														"0.95",
														"0.2",
														"0.1",
														"3",
														"250",
														"50",
														"1",
														"0",
														"0.1",
														"0.5",
														"0.7",
														"1",
														"0",
														"1.2",
														"0.8"));
			Rows.Add( new DriverNamesRow("24",
														"S. Coogan",
														"1.1",
														"100",
														"2.9",
														"5.95",
														"2",
														"5",
														"1",
														"0.2",
														"0.9",
														"1",
														"2",
														"0.029",
														"-7",
														"0.03",
														"0.08",
														"0.05",
														"0.6",
														"0.95",
														"0.2",
														"0.1",
														"3",
														"250",
														"50",
														"1",
														"0",
														"0.1",
														"0.5",
														"0.7",
														"1",
														"0",
														"1.2",
														"0.8"));
			Rows.Add( new DriverNamesRow("25",
														"G. Reza",
														"1",
														"100",
														"2.1",
														"5.87",
														"2.1",
														"5",
														"1",
														"0.2",
														"0.9",
														"1",
														"2",
														"0.041",
														"-8",
														"0.03",
														"0.08",
														"0.05",
														"0.6",
														"0.95",
														"0.2",
														"0.1",
														"3",
														"250",
														"50",
														"1",
														"0",
														"0.1",
														"0.5",
														"0.7",
														"1",
														"0",
														"1.2",
														"0.8"));
			Rows.Add( new DriverNamesRow("26",
														"L. Rawlings",
														"1.05",
														"100",
														"1.7",
														"5.78",
														"2.3",
														"5",
														"1",
														"0.2",
														"0.9",
														"1",
														"2",
														"0.044",
														"-9",
														"0.03",
														"0.08",
														"0.05",
														"0.6",
														"0.95",
														"0.2",
														"0.1",
														"3",
														"250",
														"50",
														"1",
														"0",
														"0.1",
														"0.5",
														"0.7",
														"1",
														"0",
														"1.2",
														"0.8"));
			Rows.Add( new DriverNamesRow("27",
														"D. Bent",
														"1",
														"100",
														"1.6",
														"5.77",
														"2.5",
														"5",
														"1",
														"0.2",
														"0.9",
														"1",
														"2",
														"0.045",
														"-10",
														"0.03",
														"0.08",
														"0.05",
														"0.6",
														"0.95",
														"0.2",
														"0.1",
														"3",
														"250",
														"50",
														"1",
														"0",
														"0.1",
														"0.5",
														"0.7",
														"1",
														"0",
														"1.2",
														"0.8"));
			Rows.Add( new DriverNamesRow("28",
														"K. Smith",
														"1.02",
														"100",
														"1.5",
														"5.75",
														"2.6",
														"5",
														"1",
														"0.2",
														"0.9",
														"1",
														"2",
														"0.06",
														"-11",
														"0.03",
														"0.08",
														"0.05",
														"0.6",
														"0.95",
														"0.2",
														"0.1",
														"3",
														"250",
														"50",
														"1",
														"0",
														"0.1",
														"0.5",
														"0.7",
														"1",
														"0",
														"1.2",
														"0.8"));
			Rows.Add( new DriverNamesRow("29",
														"H. Tibbs",
														"1.05",
														"100",
														"1.4",
														"5.7",
														"2.7",
														"5",
														"1",
														"0.2",
														"0.9",
														"1",
														"2",
														"0.04",
														"-12",
														"0.03",
														"0.08",
														"0.05",
														"0.6",
														"0.95",
														"0.2",
														"0.1",
														"3",
														"250",
														"50",
														"1",
														"0",
														"0.1",
														"0.5",
														"0.7",
														"1",
														"0",
														"1.2",
														"0.8"));
			Rows.Add( new DriverNamesRow("30",
														"C. Sale",
														"1",
														"100",
														"1.5",
														"5.6",
														"2.8",
														"5",
														"1",
														"0.2",
														"0.9",
														"1",
														"2",
														"0.03",
														"-13",
														"0.03",
														"0.08",
														"0.05",
														"0.6",
														"0.95",
														"0.2",
														"0.1",
														"3",
														"250",
														"50",
														"1",
														"0",
														"0.1",
														"0.5",
														"0.7",
														"1",
														"0",
														"1.2",
														"0.8"));
			Rows.Add( new DriverNamesRow("31",
														"S. Cornell",
														"0.9",
														"100",
														"1.6",
														"5.64",
														"3",
														"5",
														"1",
														"0.2",
														"0.9",
														"1",
														"2",
														"0.032",
														"-12.5",
														"0.03",
														"0.08",
														"0.05",
														"0.6",
														"0.95",
														"0.2",
														"0.1",
														"3",
														"250",
														"50",
														"1",
														"0",
														"0.1",
														"0.5",
														"0.7",
														"1",
														"0",
														"1.2",
														"0.8"));
			Rows.Add( new DriverNamesRow("32",
														"T. Hare",
														"1",
														"100",
														"1.4",
														"5.71",
														"2.35",
														"5",
														"1",
														"0.2",
														"0.9",
														"1",
														"2",
														"0.034",
														"-10",
														"0.03",
														"0.08",
														"0.05",
														"0.6",
														"0.95",
														"0.2",
														"0.1",
														"3",
														"250",
														"50",
														"1",
														"0",
														"0.1",
														"0.5",
														"0.7",
														"1",
														"0",
														"1.2",
														"0.8"));
			Rows.Add( new DriverNamesRow("33",
														"L. Tomlinson",
														"1.25",
														"100",
														"1.2",
														"5.73",
														"2.3",
														"5",
														"1",
														"0.2",
														"0.9",
														"1",
														"2",
														"0.037",
														"-11",
														"0.03",
														"0.08",
														"0.05",
														"0.6",
														"0.95",
														"0.2",
														"0.1",
														"3",
														"250",
														"50",
														"1",
														"0",
														"0.1",
														"0.5",
														"0.7",
														"1",
														"0",
														"1.2",
														"0.8"));
			Rows.Add( new DriverNamesRow("34",
														"N. Mansell",
														"1.25",
														"100",
														"1.1",
														"5.68",
														"2.4",
														"5",
														"1",
														"0.2",
														"0.9",
														"1",
														"2",
														"0.038",
														"-12",
														"0.03",
														"0.08",
														"0.05",
														"0.6",
														"0.95",
														"0.2",
														"0.1",
														"3",
														"250",
														"50",
														"1",
														"0",
														"0.1",
														"0.5",
														"0.7",
														"1",
														"0",
														"1.2",
														"0.8"));
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
		public DriverNamesRow GetRow(rowIds in_RowID)
		{
			DriverNamesRow ret = null;
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
		public DriverNamesRow GetRow(string in_RowString)
		{
			DriverNamesRow ret = null;
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
