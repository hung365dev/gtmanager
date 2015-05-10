using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RacePositionsTable : MonoBehaviour {


	public GameObject tableItemPrefab;
	public UIGrid grid;
	public List<RacePositionHolder> cars;
	public float lastUpdate;
	public const float TIME_BETWEEN_UPDATES = 0.25f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(cars==null||cars.Count==0&&RaceManager.REF.hasStarted) {
			lastUpdate = Time.time;
			GameObject[] go = GameObject.FindGameObjectsWithTag("Player");
			for(int i = 0;i<go.Length;i++) {
				GameObject child = NGUITools.AddChild(grid.gameObject,tableItemPrefab);
				RacePositionHolder rph = child.GetComponent<RacePositionHolder>();
				rph.ai = go[i].GetComponent<IRDSCarControllerAI>();
				rph.racingAI = go[i].GetComponent<RacingAI>();
				if(rph.ai!=null) {
					rph.myLabel.text = rph.ai.GetDriverName();
					rph.init();
					
					cars.Add(rph);
				} else {
					Debug.LogError(go[i].name+" Was marked as a Player!");
					Destroy(child.gameObject);
				}
			}
			
			grid.animateSmoothly = true;
		} else if(RaceManager.REF.hasStarted) {
 
			if(Time.time-lastUpdate>TIME_BETWEEN_UPDATES) {
				for(int i = 0;i<cars.Count;i++) {
					cars[i].doUpdate();
				}
				
				grid.repositionNow = true;
				lastUpdate = Time.time; 
			}

		}
	}
}
