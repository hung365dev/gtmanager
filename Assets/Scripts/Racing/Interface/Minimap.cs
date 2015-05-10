using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using championship;
using Teams;

public class Minimap : MonoBehaviour {

	public float xDivider = 100f;
	public float zDivider = 100f;
	public float xStart = 0f;
	public float yStart = 0f;
	public List<GameObject> cars;
	public List<GameObject> icons;

	public Rect trackBounds = new Rect();
	public bool configureMode = true;

	public float xScaleDivider = 1f;
	public float yScaleDivider = 1f;

	public bool useXInsteadOfZ = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(ChampionshipSeason.ACTIVE_SEASON==null) {
			return;
		}
		if(cars==null||cars.Count==0) {
			UIWidget widget = this.GetComponent<UIWidget>();
			xScaleDivider = widget.localSize.x/trackBounds.width;
			yScaleDivider = widget.localSize.y/trackBounds.height;
			GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
			if(players.Length>0) {
				cars = new List<GameObject>();
				int j =0;
				for(int i = 0;i<players.Length;i++) {
					RacingAI ai = players[i].GetComponentInParent<RacingAI>();
					if(ai!=null) {

						GTTeam team = ChampionshipSeason.ACTIVE_SEASON.getTeamFromDriver(ai.driverRecord);
						icons[j].GetComponent<UITexture>().color = team.teamColor;
						j++;
						cars.Add(players[i]);
					}
				}
			}
		} else {
			for(int i=0;i<cars.Count&&i<icons.Count;i++) {
				Transform carTransform = cars[i].gameObject.transform;
				Transform iconTransform = icons[i].gameObject.transform;
				if(!useXInsteadOfZ) 
					iconTransform.localPosition = new Vector3((carTransform.position.x/xDivider+xStart)*xScaleDivider,(carTransform.position.z/zDivider+yStart)*yScaleDivider,0f);
				else 
						iconTransform.localPosition = new Vector3((carTransform.position.x/xDivider+xStart)*xScaleDivider,(carTransform.position.z/zDivider+yStart)*yScaleDivider,0f);
				
				float yRot = carTransform.rotation.y;
				Quaternion r = iconTransform.rotation;

				r.z = yRot;
				iconTransform.rotation = r;
				if(carTransform.position.x<trackBounds.xMin) {
					trackBounds.xMin = carTransform.position.x;
				}
				if(carTransform.position.x>trackBounds.xMax) {
					trackBounds.xMax = carTransform.position.x;
				}
				if(carTransform.position.z>trackBounds.yMax) {
					trackBounds.yMax = carTransform.position.z;
				}
				if(carTransform.position.z<trackBounds.yMin) {
					trackBounds.yMin = carTransform.position.z;
				}
			}
		}
	}
}
