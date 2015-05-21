using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Racing;

public class DriverOrderLibrary : MonoBehaviour {

	public static DriverOrderLibrary REF;
	public List<DriverOrderSetup> tyreOrders;
	public List<DriverOrderSetup> engineOrders;
	// Use this for initialization
	void Start () {
		REF = this;	
	}

	public DriverOrderSetup getTyreOrderFromEnum(EDriverOrders aOrder) {
		for(int i = 0;i<tyreOrders.Count;i++) {
			if(tyreOrders[i].orderType==aOrder) {
				return tyreOrders[i];
			}
		}
		return tyreOrders[1];
	}
	public DriverOrderSetup getEngineOrderFromEnum(EDriverOrders aOrder) {
		for(int i = 0;i<engineOrders.Count;i++) {
			if(engineOrders[i].orderType==aOrder) {
				return engineOrders[i];
			}
		}
		return engineOrders[1];
	}

	// Update is called once per frame
	void Update () {
	
	}
}
