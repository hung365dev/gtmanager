using UnityEngine;
using System.Collections;
using Teams;
using PixelCrushers.DialogueSystem;

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

	public UIProgressBar engineTemp1;
	public UIProgressBar tyreWear1;

	public Color engineTempTooHot;
	public Color engineTempVeryHot;
	public Color engineTempWarm;
	public Color engineTempPerfect;
	
	public Color tireWearCold;
	public Color tireWearWarmedUp;
	public Color tireWearPerfect;
	public Color tireWearWorn;
	public Color tireWearDangerous;

	public UISprite engineSprite;
	public UISprite tireSprite;

	 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(tempLabel!=null&&racingAIRef!=null) {
		//	tempLabel.text = ""+racingAIRef.aiCar.backToLineIncrement;
			switch(racingAIRef.aiCar.racePosition) {
				default: tempLabel.text = ""+racingAIRef.aiCar.racePosition+"th";break;
				case(1): tempLabel.text = ""+racingAIRef.aiCar.racePosition+"st";break;
				case(2): tempLabel.text = ""+racingAIRef.aiCar.racePosition+"nd";break;
				case(3): tempLabel.text = ""+racingAIRef.aiCar.racePosition+"rd";break;
	
			}
			if(racingAIRef.humanControl) {
				this.engineTemp1.value = 1-racingAIRef.engineTempMonitor.heatPercent;
				this.tyreWear1.value = racingAIRef.tireWear;
				if(racingAIRef.engineTempMonitor.isGettingHot) {
					this.engineTemp1.GetComponent<UISprite>().color = engineTempWarm;
				} else if(racingAIRef.engineTempMonitor.isOverheating) {
					this.engineSprite.color = this.engineTempVeryHot;
				} else if(racingAIRef.engineTempMonitor.isTooHot) {
					this.engineSprite.color = this.engineTempTooHot;
				} else this.engineSprite.color = this.engineTempPerfect;
				
				if(racingAIRef.tireWearLevel==ETireWear.Cold) {
					this.tireSprite.color = this.tireWearCold;
				} else if(racingAIRef.tireWearLevel==ETireWear.Warm) {
					this.tireSprite.color = this.tireWearWarmedUp;
				} else if(racingAIRef.tireWearLevel==ETireWear.Perfect) {
					this.tireSprite.color = this.tireWearPerfect;
				} else if(racingAIRef.tireWearLevel==ETireWear.LightWear) {
					this.tireSprite.color = this.tireWearWorn;
				} else if(racingAIRef.tireWearLevel==ETireWear.Worn) {
					this.tireSprite.color = this.tireWearWorn;
				}	else if(racingAIRef.tireWearLevel==ETireWear.Dangerous) {
					this.tireSprite.color = this.tireWearDangerous;
				}
			}

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
			if(DialogueLua.GetVariable("HintArrowNitroBoost").AsInt==1) {
				DialogueLua.SetVariable("HintArrowNitroBoost",2);
				RaceManager.REF.doConversation("NitroBoost");
				RacingAI.considerNitroTutorials = false;
			}
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
		if(driverMessage!=null) {
			driverMessage.text = msg;
			
			TweenAlpha[] alphas = driverMessage.GetComponents<TweenAlpha>();
			for(int i = 0;i<alphas.Length;i++) {
				alphas[i].enabled = true;
			}
		}
	}
}
