using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;

public class UIManager : MonoBehaviour
{
    public Text moneyTxt;
    public Text mpsTxt;

    public Text StatsMoney;
    public Text StatsTotalMoney;
    public Text StatsMoneyMultipliply;
    public Text StatsMPS;


    public double mps = 0;

    public UpgradeManager[] upgrades;

    private void FixedUpdate()
    {
        string MoneyFormat = string.Format("{0:#,0.#}", MoneyManager.money);
        moneyTxt.text = MoneyFormat;

        double _mps = 0;

        foreach (UpgradeManager up in upgrades)
        {
            _mps += up.actualRevenue;
        }

        string MpsMoneyFormat = string.Format("{0:#,0.#}", _mps * MoneyManager.AllmoneyMultiply);

        mpsTxt.text = "/s " + MpsMoneyFormat;

        mps = _mps;
        MoneyManager.TotalMPS = mps;

        ShowStats();

    }

    private void ShowStats()
    {
        string moneyFormat = string.Format("{0:#,0.#}", MoneyManager.money);
        StatsMoney.text = "Money: " + moneyFormat;

        string totalMoneyFormat = string.Format("{0:#,0.#}", MoneyManager.totalMoney);
        StatsTotalMoney.text = "Total Money: " + totalMoneyFormat;

        StatsMoneyMultipliply.text = "Money Multiply: " + MoneyManager.moneyMultiply * MoneyManager.AllmoneyMultiply;

        string MpsMoneyFormat = string.Format("{0:#,0.#}", mps * MoneyManager.AllmoneyMultiply);
        StatsMPS.text = "Money/second: " + MpsMoneyFormat;
    }

}
