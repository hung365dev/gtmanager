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
	public UILabel lbl;
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
		
		lbl = this.GetComponentInChildren<UILabel>();
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onClicked() {
		parent.selectKid(this,this.GetComponent<UISprite>());
	}


	public void deselect(GTCar aCar) {
		carRef = aCar;
		getDefaultColourForPart();
	}
	private void getDefaultColourForPart() {
		
		if(this.carRef!=null) {
			if(carRef.hasPart(researchRow)!=null)
				lbl.text = carRef.hasPart(researchRow).activeLevel+"/"+researchRow._maxlevelstounlock; else 
					lbl.text = "0/"+researchRow._maxlevelstounlock; 
			if(carRef.partBeingResearched==null) {
				
				if(this.carRef.hasPreRequisiteParts(researchRow._partprerequisites)) {
					// Car part is available to be put in.
					if(this.carRef.hasPart(researchRow)!=null) {
						this._button.defaultColor = parent.unlockedColour;
						this._button.isEnabled = false;
					} else {
						this._button.defaultColor = parent.defaultColour;
						this._button.isEnabled = true;
					}
				} else {
					this._button.defaultColor = parent.unavailableColour;
					this._button.isEnabled = false;
				}
			} else {
				if(this.carRef.partBeingResearched.researchRow==researchRow) {
					this._button.defaultColor = parent.defaultColour;
				} else {
					this._button.defaultColor = parent.unavailableColour;
					this._button.isEnabled = false;
				}
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
		carRef = aCar;
		if(researchRow==null) {
			initResearchRow();
		}


	}
}
