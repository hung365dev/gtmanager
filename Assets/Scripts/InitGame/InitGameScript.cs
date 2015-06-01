using UnityEngine;
using System.Collections;
using Database;
using championship;
using System.Collections.Generic;
using Drivers;

public class InitGameScript : MonoBehaviour {

	private bool _loaded = false;
	// Use this for initialization
	void Start () {
		
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
	//	ChampionshipSeason champ = GameObject.Find ("ChampionshipObject").GetComponent<ChampionshipSeason>();
	//	champ.initFromDatabase();
		//StartCoroutine(LoadLevel());

	}
	
	// Update is called once per frame
	void Update () {

	}



}
