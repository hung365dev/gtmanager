// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using UnityEngine;
using Cars;
using Database;
using GoogleFu;
using Teams;
using championship;


namespace Garage
{
	public class BuyCarsScreen : MonoBehaviour
	{
		public GameObject carOnSale;
		public CarLibraryRecord car;
		public GameObject parent;
		public static int currentIndex = 0;

		private GTCar _carToReplace;
		private CarDetails _carDetailsScreen;
		public BuyCarsScreen ()
		{
		}

		public void init(CarDetails aCarDetailsScreen,GTCar aCarToReplace) {
			GarageManager.REF.interfacePanel.gameObject.SetActive(false);

			GarageCameraController camController = GameObject.Find("Main Camera").GetComponent<GarageCameraController>();

			camController.lookAtThis = GameObject.Find ("GarageCenter");
			GameObject g = GameObject.Find("CameraPathForCarOnSale");

			if(g!=null) {
				CameraPath cp = g.GetComponent<CameraPath>();
				cp.enabled = true;
				
				CameraPathAnimator cpa = g.GetComponent<CameraPathAnimator>();
				cpa.enabled = true;
			}
			Lean.LeanTouch.OnFingerSwipe += OnFingerSwipe;
			showCar(currentIndex);
			_carToReplace = aCarToReplace;
			_carDetailsScreen = aCarDetailsScreen;
		}


		public void onBuyThisCar() {
			Debug.Log ("Buying this Car!");
			GTTeam humansTeam = ChampionshipSeason.ACTIVE_SEASON.getUsersTeam();

			int indexOfCar = humansTeam.indexForCar(_carToReplace);

			_carToReplace.replaceCar(CarDatabase.REF.cars[currentIndex]);

			onGoBackAScreen();
		}
		public void onGoBackAScreen() {
			Debug.Log ("Going back a screen!");
			Destroy(this.gameObject);
			_carDetailsScreen.reInit(this._carToReplace);
		}
		public void OnDestroy() {
			GameObject g = GameObject.Find("CameraPathForCarOnSale");
			if(carOnSale!=null) {
				Destroy(carOnSale.gameObject);
			}
			if(g!=null) {
				CameraPath cp = g.GetComponent<CameraPath>();
				cp.enabled = false;
				
				CameraPathAnimator cpa = g.GetComponent<CameraPathAnimator>();
				cpa.enabled = false;
			}
		}
		public void showCar(int aCarIndex) {
			if(carOnSale!=null) {
				Destroy(carOnSale.gameObject);
				carOnSale = null;
			}
			if(aCarIndex>=CarDatabase.REF.cars.Count) {
				aCarIndex = 0;
			}
			if(aCarIndex<0) {
				aCarIndex = CarDatabase.REF.cars.Count-1;
			}
			currentIndex = aCarIndex;
			car = CarDatabase.REF.cars[aCarIndex];
			GameObject c = car.carPrefab;
			
			parent = GameObject.Find ("GarageManager").transform.FindChild("GarageCenter").gameObject;
			GameObject thisCar = GameObject.Instantiate(c);
			//	thisCar.transform.SetParent(parent.transform);
			thisCar.transform.position = parent.transform.position;
			thisCar.GetComponent<RacingAI>().initSmokes();
			thisCar.GetComponent<RacingAI>().hidePilot();
			SpriteRenderer[] renderers = thisCar.GetComponentsInChildren<SpriteRenderer>();
			for(int i = 0;i<renderers.Length;i++) {			
				Destroy(renderers[i].gameObject);
			}
//thisCar.GetComponent<RacingAI>()
			carOnSale = thisCar;
			deleteIRDSClasses(carOnSale);
			this.GetComponent<CarDetails>().showCar (car);

		}
		public void deleteIRDSClasses(GameObject aObject) {
			
			if(aObject.GetComponent<IRDSCarControllerAI>()!=null) {
				Destroy(aObject.GetComponent<IRDSCarControllerAI>());
			}

			if(aObject.GetComponent<IRDSSoundController>()!=null) {
				Destroy(aObject.GetComponent<IRDSSoundController>());
			}
			if(aObject.GetComponent<IRDSAerodynamicResistance>()!=null) {
				Destroy(aObject.GetComponent<IRDSAerodynamicResistance>());
			}
			if(aObject.GetComponent<IRDSCarDamage>()!=null) {
				Destroy(aObject.GetComponent<IRDSCarDamage>());
			}
			if(aObject.GetComponent<IRDSNavigateTWaypoints>()!=null) {
				Destroy(aObject.GetComponent<IRDSNavigateTWaypoints>());
			}
			if(aObject.GetComponent<IRDSPlayerControls>()!=null) {
				Destroy(aObject.GetComponent<IRDSPlayerControls>());
			}
			if(aObject.GetComponent<IRDSPerCarGUI>()!=null) {
				Destroy(aObject.GetComponent<IRDSPerCarGUI>());
			}
			if(aObject.GetComponent<IRDSDrivetrain>()!=null) {
			//	Destroy(aObject.GetComponent<IRDSDrivetrain>());
			}
			GameObject[] gs = GameObject.FindObjectsOfType<GameObject>();
			for(int i = 0;i<gs.Length;i++) {
				if(gs[i].name.Contains("CurrentWP_")) {
					Destroy(gs[i]);
				}
			}
		}
		public void OnFingerSwipe(Lean.LeanFinger finger)
		{

			// Store the swipe delta in a temp variable
			var swipe = finger.SwipeDelta;
			
			if (swipe.x < -Mathf.Abs(swipe.y))
			{
				Debug.Log ("You swiped left!");
			}
			
			if (swipe.x > Mathf.Abs(swipe.y))
			{
				Debug.Log ("You swiped right!");
			}
			
			if (swipe.y < -Mathf.Abs(swipe.x))
			{
				Debug.Log ("You swiped down!");
				showCar(currentIndex+1);
			}
			
			if (swipe.y > Mathf.Abs(swipe.x))
			{
				Debug.Log ("You swiped up!");
				showCar(currentIndex-1);
			}

		}

		public void OnEnable() {

		}

		public void OnDisable() {
			
			Lean.LeanTouch.OnFingerSwipe -= OnFingerSwipe;
		}
	} 
}

