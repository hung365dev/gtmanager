using UnityEngine;
using System.Collections;

public class NGUIDisabler : MonoBehaviour {
	
	public UICamera cameraRef;
	public CC_RadialBlur blur;
// 	public CC_AnalogTV analogTV;
	public static float PAUSED_TIME_SCALE = 0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnDisable() {
		Time.timeScale = 1f;
		if(cameraRef!=null) {
			cameraRef.eventType = UICamera.EventType.UI_2D;
			
			if(Application.loadedLevelName=="Garage") {
				blur.enabled = false;
			//	analogTV.enabled = false;
			}
		}
	}
	void OnEnable() {
		Time.timeScale = PAUSED_TIME_SCALE;
		GameObject uiRoot = GameObject.Find("UI Root");
		if(uiRoot!=null) {
			UICamera camera = uiRoot.GetComponentInChildren<UICamera>();
			if(camera!=null) {
				camera.eventType = UICamera.EventType.UI_3D;
				cameraRef = camera;	
				if(Application.loadedLevelName=="Garage") {
					blur = camera.GetComponent<CC_RadialBlur>();
					if(blur==null) {
						blur = camera.gameObject.AddComponent<CC_RadialBlur>();
					}
					blur.enabled = true;
			/*		analogTV = camera.GetComponent<CC_AnalogTV>();
					if(analogTV==null) {
						analogTV = camera.gameObject.AddComponent<CC_AnalogTV>();
					}*/
					//analogTV.enabled = true;
				}
			}
		}
	}
}
