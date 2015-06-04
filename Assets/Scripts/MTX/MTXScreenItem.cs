using UnityEngine;
using System.Collections;
using UnionAssets.FLE;
using Utils;

public class MTXScreenItem : MonoBehaviour {

	public string item_id;
	public UILabel priceLabel;
		
	// Use this for initialization
	void Start () {
	
	}
	private void OnPurchaseFinished(CEvent e) {
		UM_PurchaseResult result = e.data as UM_PurchaseResult;
		if(result.isSuccess) {
			priceLabel.text = "PURCHASED!";
			if(item_id=="full_game") {
				if(SaveGameUtils.fullGameOwned==0) {
					SaveGameUtils.fullGameOwned = 1;
					SaveGameUtils.saveSettings();
				}
			}
			if(item_id=="full_gameplus") {
				if(SaveGameUtils.fullGameOwned<2) {
					SaveGameUtils.fullGameOwned = 2;
					SaveGameUtils.saveSettings();
				}
			}
			if(Application.loadedLevelName=="Garage") {
				GarageManager.REF.onMTXComplete();
			}
		} else  {
			
		}
	}
	

	public void OnEnable() {
		//	UM_InAppPurchaseManager.instance.Purchase(item_id);	
		UM_InAppProduct product = UM_InAppPurchaseManager.instance.GetProductById(item_id);

		if(UM_InAppPurchaseManager.instance.IsProductPurchased(item_id)) {
			this.GetComponent<UIButton>().enabled = false;
			priceLabel.text = "OWNED";
			if(item_id=="full_game"&&SaveGameUtils.fullGameOwned==0) {
				SaveGameUtils.fullGameOwned = 1;
				SaveGameUtils.saveSettings();
			}
			if(item_id=="full_gameplus"&&SaveGameUtils.fullGameOwned<2) {
				SaveGameUtils.fullGameOwned = 2;
				SaveGameUtils.saveSettings();
			}
		} else {
			UM_InAppPurchaseManager.instance.addEventListener(UM_InAppPurchaseManager.ON_PURCHASE_FLOW_FINISHED, OnPurchaseFinished);
			priceLabel.text =product.LocalizedPrice;
		}
		
	}
	public void OnDisable() {
		if(UM_InAppPurchaseManager.instance!=null)
			UM_InAppPurchaseManager.instance.removeEventListener(UM_InAppPurchaseManager.ON_PURCHASE_FLOW_FINISHED, OnPurchaseFinished);
	}
	public void OnBuy() {
		UM_InAppPurchaseManager.instance.Purchase(item_id);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
