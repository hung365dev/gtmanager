using UnityEngine;
using System.Collections;
using Championship;
using System;
using championship;

public class EndOfRaceFinances : MonoBehaviour {

	public UILabel prizeMoneyGainedLabel;
	public UILabel driversPayLabel;
	public UILabel driversBonusLabel;
	
	public UILabel repairsLabel;
	public UILabel sponsorsLabel;
	
	public UILabel totalProfitLossLabel;

	public UILabel betsLabel;


	public Color green;
	public Color red;

	public delegate void OnCloseFinances ();
	public OnCloseFinances onCloseFinances;

	// Use this for initialization
	void Start () {
		int totalPrizeMoney = RaceEndFinances.mostRecent.prizeA+RaceEndFinances.mostRecent.prizeB;
		int totalDriversPay = RaceEndFinances.mostRecent.driverACost+RaceEndFinances.mostRecent.driverBCost;
		int totalDriversBonus = RaceEndFinances.mostRecent.driverABonus+RaceEndFinances.mostRecent.driverBBonus;
		int repairs = RaceEndFinances.mostRecent.damagesA+RaceEndFinances.mostRecent.damagesB;
		int sponsors = Convert.ToInt32(RaceEndFinances.mostRecent.sponsorIncome);

		prizeMoneyGainedLabel.text = ""+totalPrizeMoney.ToString("C0");
		driversPayLabel.text = ""+totalDriversPay.ToString("C0");
		driversBonusLabel.text = ""+totalDriversBonus.ToString("C0");
		repairsLabel.text = ""+repairs.ToString("C0");
		sponsorsLabel.text = ""+sponsors.ToString("C0");
		
		betsLabel.text = ""+RaceEndFinances.mostRecent.bets.ToString("C0");
		int profitLoss = totalPrizeMoney+sponsors-repairs-totalDriversBonus-totalDriversPay+RaceEndFinances.mostRecent.bets;
		ChampionshipSeason.ACTIVE_SEASON.getUsersTeam().cash += profitLoss;
		totalProfitLossLabel.text = ""+profitLoss.ToString("C0");
	}
	 
	public void onClose() {
		if(onCloseFinances!=null) {
			onCloseFinances();
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
