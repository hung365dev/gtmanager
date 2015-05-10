using UnityEngine;
using System.Collections;
using Database;
using championship;

public class InitGameScript : MonoBehaviour {

	private bool _loaded = false;
	// Use this for initialization
	void Start () {
		
		DontDestroyOnLoad (this.gameObject);
		this.GetComponent<DriverLibrary> ().init ();
		this.GetComponent<CarDatabase> ().init ();
		this.GetComponent<TeamDatabase> ().init ();
		this.GetComponent<TrackDatabase>().init();
		ChampionshipSeason champ = GameObject.Find ("ChampionshipObject").GetComponent<ChampionshipSeason>();
		champ.initFromDatabase();
		//StartCoroutine(LoadLevel());

	}
	
	// Update is called once per frame
	void Update () {

	}



}
