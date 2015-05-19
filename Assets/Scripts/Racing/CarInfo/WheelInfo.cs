using System;
using UnityEngine;
using Cars;


namespace Racing
{
	[System.Serializable]
	public class WheelInfo
	{
		public float tireTemp;
		public float dividedTireWear;

		private IRDSWheel _wheelRef;
		public WheelInfo (IRDSWheel aWheel,GTCar aCar)
		{
			_wheelRef = aWheel;
			_wheelRef.SetWear(true);
			_wheelRef.realTireMode = true;
			_wheelRef.SetTyreHardness(20f);
			
		}

		public void Update() {
			tireTemp = _wheelRef.GetTyreTemp();
			dividedTireWear = (float) _wheelRef.dB.GetValue(2)/_wheelRef.dq;
	
		}
	}
}

