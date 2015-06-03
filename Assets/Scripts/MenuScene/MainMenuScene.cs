using UnityEngine;
using System.Collections;
using MenuScene;

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
	void Start () {
		REF = this;
	}
	public void doGameMaker(int aIndex) {
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
		mtxScreen.gameObject.SetActive(false);
		toggleMyStuff(true);
		playGameScreen.gameObject.SetActive(false);
	}
	public void onPlayGameBtn() {
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
