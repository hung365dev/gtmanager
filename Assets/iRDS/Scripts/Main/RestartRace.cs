using UnityEngine;
using System.Collections;

public class RestartRace : MonoBehaviour {

	IRDSPlaceCars placeCars;
	// Use this for initialization
	void Start () {
		placeCars = GameObject.FindObjectOfType(typeof (IRDSPlaceCars)) as IRDSPlaceCars;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.R))
		{
			placeCars.RestartRaceAutoPositionCarsOnGrid();
			IRDSCarCamera.SetInitialView(true);
		}
		
		if (Input.GetKeyUp(KeyCode.Space))
		{
			foreach(IRDSCarControllerAI car in IRDSStatistics.mainInstance.GetAllDriversList())
			{
				Debug.Log (car.GetCarName() + "  " + car.myGridPosition + " " + car.racePosition);
			}
			
		}
		
		if (Input.GetKeyUp(KeyCode.Y))
		{
			
			IRDSCarControllerAI[] allCars = GameObject.FindSceneObjectsOfType(typeof (IRDSCarControllerAI)) as IRDSCarControllerAI[];
			Transform[] gridpositions = placeCars.GetGridPositions().GetComponentsInChildren<Transform>();
			int i = 1;
			foreach(IRDSCarControllerAI car in allCars)
			{
				car.transform.position = gridpositions[i].position;
				car.transform.rotation = gridpositions[i].rotation;
				car.GetComponent<Rigidbody>().velocity = Vector3.zero;
				car.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
				i++;
			}
			IRDSStatistics.RestartRaceWithoutDestroyingCars();
		}
	}
}
