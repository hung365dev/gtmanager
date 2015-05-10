using UnityEngine;
using System.Collections;
 
[RequireComponent (typeof (TextMesh))]
[RequireComponent (typeof (MeshRenderer))]
//[RequireComponent (typeof (GUITexture))]
public class IRDSObjectLabel : MonoBehaviour {
 
//public Transform target;  // Object that this label should follow
//public Vector3 offset = Vector3.up;    // Units in world space to offset; 1 unit above object by default
//public bool clampToScreen = false;  // If true, label will be visible even if object is off screen
//public float clampBorderSize = 0.05f;  // How much viewport space to leave at the borders when a label is being clamped
public bool useMainCamera = true;   // Use the camera tagged MainCamera
public Camera cameraToUse ;   // Only use this if useMainCamera is false
public bool addCarPos = false;
public bool enableForPlayerCar = false;
//GUITexture backGroundTexture;
	
Camera cam ;
Transform thisTransform;
Transform camTransform;
	TextMesh text;
	IRDSCarControllerAI AI;
	int lastRacePosition = 0;
 
	void Start () 
    {

		text = GetComponent<TextMesh>();
		AI = transform.root.GetComponent<IRDSCarControllerAI>();
	    thisTransform = transform;
		if (useMainCamera)
        	cam = Camera.main;
    	else
        	cam = cameraToUse;
    	camTransform = cam.transform;
		if (AI != null)
			text.text = AI.GetDriverName();
		if (!enableForPlayerCar && IRDSStatistics.GetCurrentCar() && IRDSStatistics.GetCurrentCar() == AI){
			GetComponent<Renderer>().enabled = false;
		}
	}
 
 
    void Update()
    {
		if (AI != null && !enableForPlayerCar && this.enabled == true && IRDSStatistics.GetCurrentCar() && IRDSStatistics.GetCurrentCar() == AI)
		{
			GetComponent<Renderer>().enabled = false;
		}else if (GetComponent<Renderer>().enabled == false) GetComponent<Renderer>().enabled = true;
 
		if (addCarPos){
			if (lastRacePosition != AI.racePosition)
				text.text = AI.racePosition + " " + AI.GetDriverName();
			lastRacePosition = AI.racePosition;
		}
        thisTransform.rotation = camTransform.rotation;
    }
}