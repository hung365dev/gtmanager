using UnityEngine;
using System.Collections;
using Teams;

public class DriverFaceManager : MonoBehaviour {

	public UI2DSprite faceSprite;
	public UILabel driverName;
	public UILabel engineTemp;
	public UILabel driverMessage;

	public RacingAI racingAIRef;

	public UIButton btnEngineEasy;
	public UIButton btnEngineNormal;
	public UIButton btnEngineHard;
	
	public UIButton btnTyresEasy;
	public UIButton btnTyresNormal;
	public UIButton btnTyresHard;


	public UIButton btnNitro;
	public UILabel remainingNitros;

	public UILabel tempLabel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(tempLabel!=null&&racingAIRef!=null) {
			tempLabel.text = ""+racingAIRef.aiCar.GetCorneringSpeedFactor();
		}
	}

	public void init(RacingAI aAI) {
		faceSprite.sprite2D = aAI.driverRecord.record.sprite;
		driverName.text = aAI.driverName;
		aAI.messageHolder = this;
		racingAIRef = aAI;

		this.btnEngineEasy.onClick.Add(new EventDelegate(this,"onEngineEasy"));
		this.btnEngineNormal.onClick.Add(new EventDelegate(this,"onEngineNormal"));
		this.btnEngineHard.onClick.Add(new EventDelegate(this,"onEngineHard"));
		
		this.btnTyresEasy.onClick.Add(new EventDelegate(this,"onTyresEasy"));
		this.btnTyresNormal.onClick.Add(new EventDelegate(this,"onTyresNormal"));
		this.btnTyresHard.onClick.Add(new EventDelegate(this,"onTyresHard"));


		this.btnNitro.onClick.Add (new EventDelegate(this,"onUseNitro"));

		remainingNitros.text = ""+aAI.nitrosRemaining;
	}

	public void onUseNitro() {
		if(racingAIRef.nitrosRemaining>0) {
			racingAIRef.useNitro();
			remainingNitros.text = ""+racingAIRef.nitrosRemaining;
		}
	}
	private void highlightEngineButtons() {
		switch(racingAIRef.currentOrders) {
			case(Racing.EDriverOrders.TakeItEasy):
				this.btnEngineEasy.isEnabled = false;
				this.btnEngineNormal.isEnabled = true;
				this.btnEngineHard.isEnabled = true;
			break;
			case(Racing.EDriverOrders.DriveNormal):
				this.btnEngineEasy.isEnabled = true;
				this.btnEngineNormal.isEnabled = false;
				this.btnEngineHard.isEnabled = true;
			break;
			case(Racing.EDriverOrders.DoOrDie):
				this.btnEngineEasy.isEnabled = true;
				this.btnEngineNormal.isEnabled = true;
				this.btnEngineHard.isEnabled = false;
			break;
			case(Racing.EDriverOrders.RaceComplete):
				this.btnEngineEasy.isEnabled = false;
				this.btnEngineNormal.isEnabled = false;
				this.btnEngineHard.isEnabled = false;
			break;

		}
	}
	private void highlightTyresButtons() {
		switch(racingAIRef.currentTyreOrders) {
		case(Racing.EDriverOrders.TakeItEasy):
			this.btnTyresEasy.isEnabled = false;
			this.btnTyresNormal.isEnabled = true;
			this.btnTyresHard.isEnabled = true;
			break;
		case(Racing.EDriverOrders.DriveNormal):
			this.btnTyresEasy.isEnabled = true;
			this.btnTyresNormal.isEnabled = false;
			this.btnTyresHard.isEnabled = true;
			break;
		case(Racing.EDriverOrders.DoOrDie):
			this.btnTyresEasy.isEnabled = true;
			this.btnTyresNormal.isEnabled = true;
			this.btnTyresHard.isEnabled = false;
			break;
		case(Racing.EDriverOrders.RaceComplete):
			this.btnTyresEasy.isEnabled = false;
			this.btnTyresNormal.isEnabled = false;
			this.btnTyresHard.isEnabled = false;
			break;
			
		}
	}
	public void onEngineEasy() {
		racingAIRef.changeEngineOrders(Racing.EDriverOrders.TakeItEasy);
		highlightEngineButtons();
	}
	public void onEngineNormal() {
		racingAIRef.changeEngineOrders(Racing.EDriverOrders.DriveNormal);
		highlightEngineButtons();
	}
	public void onEngineHard() {
		racingAIRef.changeEngineOrders(Racing.EDriverOrders.DoOrDie);
		highlightEngineButtons();
	}
	public void onTyresEasy() {
		racingAIRef.changeTyreOrders(Racing.EDriverOrders.TakeItEasy);
		highlightTyresButtons();
	}
	public void onTyresNormal() {
		racingAIRef.changeTyreOrders(Racing.EDriverOrders.DriveNormal);
		highlightTyresButtons();
	}
	public void onTyresHard() {
		racingAIRef.changeTyreOrders(Racing.EDriverOrders.DoOrDie);
		highlightTyresButtons();
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
