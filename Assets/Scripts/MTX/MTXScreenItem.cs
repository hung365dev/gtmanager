using UnityEngine;
using System.Collections;
using UnionAssets.FLE;

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
		} else  {
			
		}
	}
	

	public void OnEnable() {
		//	UM_InAppPurchaseManager.instance.Purchase(item_id);	
		UM_InAppProduct product = UM_InAppPurchaseManager.instance.GetProductById(item_id);
		UM_InAppPurchaseManager.instance.addEventListener(UM_InAppPurchaseManager.ON_PURCHASE_FLOW_FINISHED, OnPurchaseFinished);
		priceLabel.text =product.LocalizedPrice;
		
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
