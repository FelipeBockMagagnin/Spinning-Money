using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text moneyTxt;
    public Text mpsTxt;

    public Text StatsMoney;
    public Text StatsTotalMoney;
    public Text StatsMoneyMultipliply;


    public double mps = 0;

    public UpgradeManager[] upgrades;

    private void FixedUpdate()
    {
        moneyTxt.text = MoneyManager.money.ToString("0.0");

        double _mps = 0;

        foreach (UpgradeManager up in upgrades)
        {
            _mps += up.actualRevenue;
        }

        mpsTxt.text = "/s " + (_mps* MoneyManager.AllmoneyMultiply).ToString("0.0");

        mps = _mps;

        ShowStats();

    }

    private void ShowStats()
    {
        StatsMoney.text = "Money: " + MoneyManager.money.ToString("0.0");
        StatsTotalMoney.text = "Total Money: " + MoneyManager.totalMoney.ToString("0.0");
        StatsMoneyMultipliply.text = "Money Multiply: " + MoneyManager.moneyMultiply * MoneyManager.AllmoneyMultiply;
    }

}
