using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {
	public UILabel loadingLabel;
	public static string levelToLoad;
	public static string levelLoadText;
	public CC_BrightnessContrastGamma brightnessController;
	// Use this for initialization
	void Start () {
		loadingLabel.text = levelLoadText;
		StartCoroutine(loadLevel());
		brightnessController.brightness = 0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private IEnumerator loadLevel() {
		yield return new WaitForEndOfFrame();
		
		AsyncOperation async = Application.LoadLevelAsync(levelToLoad);
		while(!async.isDone) {
			if(brightnessController.brightness<1f) {
				brightnessController.brightness += 0.1f;
			}
			yield return new WaitForEndOfFrame();
		}
		while(brightnessController.brightness>0f) {
			brightnessController.brightness -= 0.1f;
			yield return new WaitForEndOfFrame();

		}
		yield return async;
		Debug.Log("Loading complete");

	}
}
