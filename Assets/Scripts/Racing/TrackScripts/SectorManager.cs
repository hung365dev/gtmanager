using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Racing;

public class SectorManager : MonoBehaviour {

	public bool isStartFinish = false;
	public string sectorName;

	public SectorTimeTriplet currentFastest;
	public TrackSectorManager sectorManager;
	public List<SectorTimeTriplet> recordedTimes = new List<SectorTimeTriplet>();
	// Use this for initialization
	void Start () {
		sectorManager = this.GetComponentInParent<TrackSectorManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter(Collider aOther) {
		//Debug.Log ("Entered this trigger");
		IRDSCarControllerAI ai = aOther.transform.GetComponentInParent<IRDSCarControllerAI>();
		RacingAI customAI = aOther.transform.GetComponentInParent<RacingAI>();

		if((!isStartFinish||ai.LookAheadConst<=6f)&&ai.GetCurrentTotalRaceTime()>5f) {
			SectorTimeTriplet thisOne = new SectorTimeTriplet(ai,customAI);

			if(recordedTimes.Count>1&&recordedTimes[recordedTimes.Count-1].lapNumber==thisOne.lapNumber) {
				// We can now figure out how far behind the car infront we are
				float timeDiff = thisOne.totalTime-recordedTimes[recordedTimes.Count-1].totalTime;
				recordedTimes[recordedTimes.Count-1].customAI.carBehindTime = timeDiff;
				recordedTimes[recordedTimes.Count-1].customAI.carBehind = ai;

				thisOne.customAI.carInfrontTime = timeDiff;
				thisOne.customAI.carInfront = recordedTimes[recordedTimes.Count-1].car;
				thisOne.customAI.carBehindTime = 0;
				thisOne.customAI.carBehind = null;

			}
			recordedTimes.Add(thisOne);
			if(currentFastest == null) {
				currentFastest = thisOne;
			} else {
				if(thisOne.time<currentFastest.time) {
					currentFastest = thisOne;
					if(sectorManager!=null) {
						
					}
				}
			}

		} else {
		}

	}
}
