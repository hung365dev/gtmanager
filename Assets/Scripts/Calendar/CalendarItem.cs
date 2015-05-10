using UnityEngine;
using System.Collections;
using System;
using championship;
using Database;
using Teams;

[ExecuteInEditMode]
public class CalendarItem : MonoBehaviour {

	// Use this for initialization
	public int thisIndex;
	public UILabel title;

	public Color tint;
	public Color original;

	public UITexture researchIcon;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.UpdateMyAnchors();
	}

	public void initLabels() {
		if(this.title==null) {
			title = this.transform.FindChild("CalendarDate").GetComponent<UILabel>();
		}

		if(thisIndex==7) {
			title.text = "Return to Menu";
			return;
		}

		
	}
	public void setToDayOfYear(int aDayOfYear) {
		initLabels();

		DateTime theDate = new DateTime( 2016, 1, 1 ).AddDays( aDayOfYear );
		title.text = theDate.ToLongDateString().Substring(0,theDate.ToLongDateString().Length-5);
		if(aDayOfYear==ChampionshipSeason.ACTIVE_SEASON.secondsPast) {
			TweenColor.Begin(this.gameObject,0.25f,this.tint);
			//this.GetComponent<UISprite>().color = this.tint;
		} else {
			TweenColor.Begin(this.gameObject,0.25f,this.original);
			//this.GetComponent<UISprite>().color = ;
		}
		GTTeam myTeam = ChampionshipSeason.ACTIVE_SEASON.getUsersTeam();
		TrackDatabaseRecord tdr = ChampionshipSeason.ACTIVE_SEASON.seasonForTeam(myTeam).eventOnDay(aDayOfYear);
		UITexture t= this.GetComponentInChildren<UITexture>();

		if(tdr!=null) {
			Texture texture1 = (Texture) Resources.Load ("Race/Thumbnails/"+tdr.imagePrefabName);
			t.mainTexture = texture1;
		} else {
			t.mainTexture = null;
		}

		if(myTeam.hasResearchCompletingOnDay(aDayOfYear)) {
			this.researchIcon.gameObject.SetActive(true);
		} else {
			this.researchIcon.gameObject.SetActive(false);
		}
	}
	[ContextMenu("SetMyAnchors")]
	public void UpdateMyAnchors() {
		float leftAnchor = 0.01f;
		float rightAnchor = 0.24f;
		switch(thisIndex%4) {
			case(0):break;
			case(1):
				leftAnchor = 0.25f;
				rightAnchor = 0.49f;
			break;

			case(2):
				leftAnchor = 0.50f;
				rightAnchor = 0.74f;
			break;

			case(3):
				leftAnchor = 0.75f;
				rightAnchor = 0.99f;
			break;
		}

		float topAnchor = 0.0f;
		float bottomAnchor = 0.49f;

		if(thisIndex>3) {
			topAnchor = 0.50f;
			bottomAnchor = 0.99f;
		}

		UIWidget widget = this.GetComponent<UIWidget>();
		if(widget!=null) {
			GameObject go = GameObject.Find("CalendarContainer");
			if(go!=null) {
				Transform t = go.transform;
				widget.leftAnchor.target = t;
				widget.leftAnchor.relative = leftAnchor;
				widget.leftAnchor.absolute = 0;
				widget.rightAnchor.target = t;
				widget.rightAnchor.relative = rightAnchor;
				widget.rightAnchor.absolute = 0;
				widget.topAnchor.absolute = 0;
				widget.topAnchor.relative = 1f-topAnchor;
				widget.topAnchor.target = t;
				widget.bottomAnchor.absolute = 0;
				widget.bottomAnchor.relative = 1f-bottomAnchor;
				widget.bottomAnchor.target = t;

			}
		} 
			 

	}
}
