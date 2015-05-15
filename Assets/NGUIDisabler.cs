using UnityEngine;
using System.Collections;

public class NGUIDisabler : MonoBehaviour {
	
	public UICamera cameraRef;
	public CC_Kuwahara kuwahara;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnDisable() {
		if(cameraRef!=null) {
			cameraRef.eventType = UICamera.EventType.UI_2D;
			kuwahara.enabled = false;
		}
	}
	void OnEnable() {
		GameObject uiRoot = GameObject.Find("UI Root");
		if(uiRoot!=null) {
			UICamera camera = uiRoot.GetComponentInChildren<UICamera>();
			if(camera!=null) {
				camera.eventType = UICamera.EventType.UI_3D;
				cameraRef = camera;	
				kuwahara = camera.GetComponent<CC_Kuwahara>();
				if(kuwahara==null) {
					kuwahara = camera.gameObject.AddComponent<CC_Kuwahara>();
				}
				kuwahara.enabled = true;
				
			}
		}
	}
}
