using UnityEngine;
using System.Collections;
using Teams;

public class DriverFaceManager : MonoBehaviour {

	public UI2DSprite faceSprite;
	public UILabel driverName;
	public UILabel engineTemp;
	public UILabel driverMessage;

	public RacingAI racingAIRef;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void init(RacingAI aAI) {
		faceSprite.sprite2D = aAI.driverRecord.record.sprite;
		driverName.text = aAI.driverName;
		aAI.messageHolder = this;
		racingAIRef = aAI;
	}

	public void doMessage(EDriverMessage aMessageType) {

		string msg = "Unknown Message";
		racingAIRef.lastMessage = aMessageType;
		switch(aMessageType) {
		case(EDriverMessage.Avoiding):
			msg = "I'm having to avoid other cars!";
			break;
		case(EDriverMessage.BrakingOnOpponent):
			msg = "The car ahead is holding me up!";
			break;
		case(EDriverMessage.Damage):
			msg = "I've damaged the car!";
			break;
		case(EDriverMessage.GettingHot):
			msg = "The car's starting to overheat!";
			break;
		case(EDriverMessage.Overheating):
			msg = "The car's overheating!";
			break;
		case(EDriverMessage.Overtaking):
			msg = "I'm going for the overtake!";
			break;
		case(EDriverMessage.TiresWorn):
			msg = "These tires are badly worn!";
			break;
		case(EDriverMessage.TooHot):
			msg = "The engines overheated and failing!";
			break;
		}
		
		//	msg += "Human Error: "+aDriver.GetComponent<IRDSCarControllerAI>().GetHumanError();
		driverMessage.text = msg;
		
		TweenAlpha[] alphas = driverMessage.GetComponents<TweenAlpha>();
		for(int i = 0;i<alphas.Length;i++) {
			alphas[i].enabled = true;
		}
	}
}
