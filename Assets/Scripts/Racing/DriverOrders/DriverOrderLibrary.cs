using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Racing;

public class DriverOrderLibrary : MonoBehaviour {

	public static DriverOrderLibrary REF;
	public List<DriverOrderSetup> driverOrders;
	// Use this for initialization
	void Start () {
		REF = this;	
	}

	public DriverOrderSetup getOrderFromEnum(EDriverOrders aOrder) {
		for(int i = 0;i<driverOrders.Count;i++) {
			if(driverOrders[i].orderType==aOrder) {
				return driverOrders[i];
			}
		}
		return driverOrders[1];
	}
	// Update is called once per frame
	void Update () {
	
	}
}
