using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text moneyTxt;
    public Text mpsTxt;

    public UpgradeManager[] upgrades;

    private void FixedUpdate()
    {
        moneyTxt.text = "Money: " + MoneyManager.money.ToString("0.0");
        double mps = 0;

        foreach (UpgradeManager up in upgrades)
        {
            mps += up.actualRevenue;
        }

        mpsTxt.text = "Money/s: " + mps.ToString("0.0");


    }

}
