using UnityEngine;
using System.Collections;

public class TakeScreenshot : MonoBehaviour {
	public UISprite thisSprite;
	public UILabel thisLabel;
	// Use this for initialization
	void Start () {
		thisSprite = this.GetComponent<UISprite>();
		thisLabel = this.GetComponent<UILabel>();
	}
	
	// Update is called once per frame
	void Update () {
		if(thisSprite.enabled==false) {
			Texture2D tex = new Texture2D(Screen.width, Screen.height);
			
			tex.ReadPixels(new Rect(0,0,Screen.width,Screen.height),0,0);
			tex.Apply();
			UM_ShareUtility.ShareMedia("Racing Manager for iOS and Android","Download Racing Manager Today!",tex);
			thisSprite.enabled = true;
			thisLabel.enabled = true;
		}
	}

	public void doScreenshot() { 
		thisSprite.enabled = false;
		thisLabel.enabled = false;
 

		//UM_ShareUtility.FacebookShare("Racing Manager for iOS and Android", tex);
	}
}
