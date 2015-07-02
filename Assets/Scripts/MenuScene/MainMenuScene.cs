using UnityEngine;
using System.Collections;
using MenuScene;
using PixelCrushers.DialogueSystem;
using championship;
using Utils;
using Drivers;
using System.Collections.Generic;
using Database;

public class MainMenuScene : MonoBehaviour {

	public static bool AllowOmegaCode = false;
	public UIButton playGameBtn;
	public UIButton settingsBtn;
	public UIButton unlockGameBtn;
	public UILabel unlockGameLbl;
	public UIButton contactBtn;

	public SettingsScreen settingsScreen;
	public GameObject settingsScreenPrefab;
	
	public GameObject playGameScreen;
	public GameObject mtxScreen;
	public GameObject topLogo;
	public GameObject bottomText;
	public static MainMenuScene REF;
	public NewGameMaker gameMaker;
	// Use this for initialization
	void Awake () {
		REF = this;
		PersistentDataManager.Reset();
		if(UM_InAppPurchaseManager.instance.IsProductPurchased("full_game")) {
			if(SaveGameUtils.fullGameOwned==0) {
				SaveGameUtils.fullGameOwned = 1;
				SaveGameUtils.saveSettings();
			}
		}		
		if(UM_InAppPurchaseManager.instance.IsProductPurchased("full_gameplus")) {
			if(SaveGameUtils.fullGameOwned<2) {
				SaveGameUtils.fullGameOwned = 2;
				SaveGameUtils.saveSettings();
			}
		}
		StartCoroutine(doLoadJSON());
		GameObject g = GameObject.Find("GameLoadObj");
		if(g!=null) {
			Destroy(g);
		}
		
		SaveGameUtils.loadSettings();
		
	}

	public IEnumerator doLoadJSON() {
		yield return null;
		WWW tWWW = new WWW("http://www.blueomega.me/rm.json?r="+UnityEngine.Random.Range(0,1000000));
		while(!tWWW.isDone) {
			yield return new WaitForSeconds(0.1f);
		} 
		yield return tWWW;
		//	Debug.Log ("JSON Loaded: "+tWWW.text);
		JSONObject j = new JSONObject(tWWW.text);
		//			Debug.Log (j.ToString());
		accessJSONData(j);
	}
	void accessJSONData(JSONObject obj){
		switch(obj.type){
		case JSONObject.Type.OBJECT:
			for(int i = 0; i < obj.list.Count; i++){
				string key = (string)obj.keys[i];
				
				JSONObject j = (JSONObject)obj.list[i];
				//						Debug.Log ("Loaded Key: "+key);
				switch(key) {
					case("allowOmegaCode"):MainMenuScene.AllowOmegaCode = (j.str=="true");break;
				}
				accessJSONData(j); 
			}
			break;
		case JSONObject.Type.ARRAY:
			foreach(JSONObject j in obj.list){
				accessJSONData(j);
			}
			break;
		case JSONObject.Type.STRING:
			//			Debug.Log(obj.str);
			break;
		case JSONObject.Type.NUMBER:
			//	Debug.Log(obj.n);
			break;
		case JSONObject.Type.BOOL:
			//					Debug.Log(obj.b);
			break;
		case JSONObject.Type.NULL:
			//	Debug.Log("NULL");
			break;
			
		}
	}

	public void onContact() {
		Application.OpenURL("http://www.blueomega.me/contact");
	}
	public void doGameMaker(int aIndex) {  
		
		GTDriver.allDrivers = new List<GTDriver>();
		ChampionshipSeason.ACTIVE_SEASON = null;
		gameMaker.gameObject.SetActive(true);
		playGameScreen.gameObject.SetActive(false);
	}
	public void onOpenMTXScreen() {
		toggleMyStuff(false);
		mtxScreen.gameObject.SetActive(true);
	}
	private void toggleMyStuff(bool aShow) { 
		playGameBtn.gameObject.SetActive(aShow);
		settingsBtn.gameObject.SetActive(aShow);
		unlockGameBtn.gameObject.SetActive(aShow);
		contactBtn.gameObject.SetActive(aShow);
		topLogo.gameObject.SetActive(aShow);
		bottomText.gameObject.SetActive(aShow);
	}
	public void onBackToMainMenu() {
		 
		GTDriver.allDrivers = new List<GTDriver>();
		ChampionshipSeason.ACTIVE_SEASON = null;
		mtxScreen.gameObject.SetActive(false);
		toggleMyStuff(true);
		playGameScreen.gameObject.SetActive(false);
	} 
	public void onPlayGameBtn() {
		TeamDatabase.REF.init();
		GTDriver.allDrivers =  new List<GTDriver>();
		if(UM_InAppPurchaseManager.instance.IsProductPurchased("full_game")) {
			if(SaveGameUtils.fullGameOwned==0) {
				SaveGameUtils.fullGameOwned = 1;
				SaveGameUtils.saveSettings();
			}
		}		
		if(UM_InAppPurchaseManager.instance.IsProductPurchased("full_gameplus")) {
			if(SaveGameUtils.fullGameOwned<2) {
				SaveGameUtils.fullGameOwned = 2;
				SaveGameUtils.saveSettings();
			}
		}
		ChampionshipSeason.ACTIVE_SEASON = null;
		toggleMyStuff(false);
		playGameScreen.gameObject.SetActive(true);
	}
	public void onCloseSettings() {
		settingsScreen = null;
	}
	public void onOpenSettingsScreen() {
		if(settingsScreen==null) {
			GameObject g = NGUITools.AddChild(GameObject.Find("UI Root"),settingsScreenPrefab);
			settingsScreen = g.GetComponent<SettingsScreen>();
		}
	}
	// Update is called once per frame 
	void Update () {
	
	}
}
