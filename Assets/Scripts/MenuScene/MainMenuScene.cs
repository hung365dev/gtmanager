using UnityEngine;
using System.Collections;
using MenuScene;
using PixelCrushers.DialogueSystem;
using championship;
using Utils;

public class MainMenuScene : MonoBehaviour {


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
		GameObject g = GameObject.Find("GameLoadObj");
		if(g!=null) {
			Destroy(g);
		}
		
		SaveGameUtils.loadSettings();
		
	}
	public void doGameMaker(int aIndex) {  
		
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
		
		ChampionshipSeason.ACTIVE_SEASON = null;
		mtxScreen.gameObject.SetActive(false);
		toggleMyStuff(true);
		playGameScreen.gameObject.SetActive(false);
	}
	public void onPlayGameBtn() {
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
