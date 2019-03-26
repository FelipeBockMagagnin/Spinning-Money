using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class OfflineTime : MonoBehaviour
{
    public GameObject OfflineEarningsPanel;

    public Text TimePassedtxt;
    public Text EarnedCoinstxt;

    public Button doubleCoinsButton;

    public UpgradeManager item1;
    public UpgradeManager item2;
    public UpgradeManager item3;
    public UpgradeManager item4;

    public double earnedCoins;

    private void ActiveOfflineEarningsPanel(TimeSpan time)
    {
        int minPassed = time.Minutes;
        int hoursPassed = time.Hours;
        if (hoursPassed >= 4)
        {
            minPassed = 0;
            hoursPassed = 4;
        }
        TimePassedtxt.text = "TimePassed: " + hoursPassed + " hours and " + minPassed + " minutes";


        earnedCoins = item1.actualRevenue + item2.actualRevenue + item3.actualRevenue + item4.actualRevenue;

        earnedCoins = ((minPassed * earnedCoins) + (hoursPassed * 60 * earnedCoins)) * 4;
        EarnedCoinstxt.text = "EarnedCoins: " + earnedCoins;

        OfflineEarningsPanel.GetComponent<Animator>().SetBool("active", true);
    }

    public void CloseOfflineEarningsPanel()
    {
        MoneyManager.Give(earnedCoins);
        OfflineEarningsPanel.GetComponent<Animator>().SetBool("active", false);
    }

    public void WhatAdAndDoubleEarnedCoins()
    {
        earnedCoins *= 2;
        EarnedCoinstxt.text = "EarnedCoins: " + earnedCoins;
        doubleCoinsButton.interactable = false;
    }

    public void OnGameStartup()
    {
        if (PlayerPrefs.HasKey("LastShutdownTime"))
        {
            long lastShutdownTime;
            long.TryParse(PlayerPrefs.GetString("LastShutdownTime"), out lastShutdownTime);
            print("Last shutdown: " + lastShutdownTime);

            TimeSpan timePassed = DateTime.Now - new DateTime(lastShutdownTime);

            ActiveOfflineEarningsPanel(timePassed);
        }
    }

    public void SaveLastShutdownTime()
    {
        PlayerPrefs.SetString("LastShutdownTime", DateTime.Now.Ticks.ToString());
    }
}