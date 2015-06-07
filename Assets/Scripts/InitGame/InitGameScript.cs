using UnityEngine;
using System.Collections;
using Database;
using championship;
using System.Collections.Generic;
using Drivers;
using UnionAssets.FLE;
using Utils;

public class InitGameScript : MonoBehaviour {

	private bool _loaded = false;
	// Use this for initialization
	void Start () {
		UM_InAppPurchaseManager.instance.Init();
		DontDestroyOnLoad (this.gameObject);
		this.GetComponent<DriverLibrary> ().init ();
		this.GetComponent<CarDatabase> ().init ();
		this.GetComponent<TeamDatabase> ().init ();
		List<DriverLibraryRecord> availableDrivers = DriverLibrary.REF.getAllAvailableDrivers();
		for(int i = 0;i<availableDrivers.Count;i++) {
			GTDriver g = new GTDriver();
			g.initFromLibrary(availableDrivers[i]);
		}
		this.GetComponent<TrackDatabase>().init();
		this.GetComponent<SponsorDatabase>().init();
		if(Application.loadedLevelName=="InitGame") {
			Application.LoadLevel("MainMenu");
		}
		
		UM_InAppPurchaseManager.instance.addEventListener(UM_InAppPurchaseManager.ON_BILLING_CONNECT_FINISHED, OnConnectFinished);
	//	ChampionshipSeason champ = GameObject.Find ("ChampionshipObject").GetComponent<ChampionshipSeason>();
	//	champ.initFromDatabase();
		//StartCoroutine(LoadLevel());

	}
	private void OnConnectFinished(CEvent e) {
		UM_BillingConnectionResult result = e.data as UM_BillingConnectionResult;
		if(result.isSuccess) {
			Debug.Log("Billing init Success");
		//	UM_InAppPurchaseManager.instance.RestorePurchases();
		} else  {
			Debug.Log ("Billing init Failed");
		}
	}
	// Update is called once per frame
	void Update () {

	}



}
