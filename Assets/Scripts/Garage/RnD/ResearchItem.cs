using UnityEngine;
using System.Collections;
using Cars;
using GoogleFu;
using System.Collections.Generic;

public class ResearchItem : MonoBehaviour {


	public int researchItemID;
	public RnDRow researchRow;

	public ResearchScreenMain parent;
	private UIButton _button;
	// Use this for initialization

	public GTCar carRef;
	void Start () {
		initResearchRow();
		parent = this.GetComponentInParent<ResearchScreenMain>();
		_button = this.gameObject.AddComponent<UIButton>();
		_button.state = UIButtonColor.State.Normal;
		this.gameObject.AddComponent<BoxCollider2D>();
		this.GetComponent<UIWidget>().autoResizeBoxCollider = true;
		this.GetComponent<UIWidget>().ResizeCollider();
		this.GetComponent<UIWidget>().depth = 10;
		_button.onClick.Add(new EventDelegate(this,"onClicked"));
		GarageManager.REF.doConversation("Research_Tutorial1");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onClicked() {
		parent.selectKid(this,this.GetComponent<UISprite>());
	}


	public void deselect() {
		getDefaultColourForPart();
	}
	private void getDefaultColourForPart() {
		if(this.carRef!=null) {
			if(this.carRef.hasPreRequisiteParts(researchRow._partprerequisites)) {
				// Car part is available to be put in.
				if(this.carRef.hasPart(researchRow)!=null) {
					this._button.defaultColor = parent.unlockedColour;
				} else {
					this._button.defaultColor = parent.defaultColour;
				}
			} else {
				this._button.defaultColor = parent.unavailableColour;
			}
		} else {
			_button.defaultColor = parent.defaultColour;
		}
	}

	public void select() {
		_button.defaultColor = parent.selectedColour;
	}
	private void initResearchRow() {
		List<RnDRow> rows = RnD.Instance.Rows;
		for(int i = 0;i<rows.Count;i++) {
			if(rows[i]._id==researchItemID) {
				researchRow = rows[i];
			}
		}
	}

	public void initFromCar(GTCar aCar) {
		if(researchRow==null) {
			initResearchRow();
		}


	}
}
