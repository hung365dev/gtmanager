using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;

public class TutorialArrow : MonoBehaviour {

	public string variableName;
	public UISprite arrowSprite;
	public TweenPosition tweenPosition;

	public int currentVariableValue;
	// Use this for initialization
	void Start () {
		Lua.Result r = DialogueLua.GetVariable(variableName);
		if(r.AsInt>1) {
			Destroy(this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		Lua.Result r = DialogueLua.GetVariable(variableName);
		currentVariableValue = r.AsInt;
		if(r.AsInt==1) {
			arrowSprite.enabled = true;
			tweenPosition.enabled = true;
		} else {
			arrowSprite.enabled = false;
			tweenPosition.enabled = false;
		}
	}
}
