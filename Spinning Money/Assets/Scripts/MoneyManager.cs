using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MoneyManager
{
    public static double money;
    public static double totalMoney;
    public static double moneyMultiply;
    public static double AllmoneyMultiply;
    public static double TotalMPS;

    /// <summary>
    /// Assing value to the variables
    /// </summary>
    /// <param name="_money"></param>
    /// <param name="_totalMoney"></param>
    /// <param name="_moneyMultiply"></param>
    public static void StartGame(double _money, double _totalMoney, double _moneyMultiply)
    {
        AllmoneyMultiply = 1;
        money = _money;
        totalMoney = _totalMoney;
        moneyMultiply = _moneyMultiply;
        ActivementsAndRanking.UpdateLeaderBoard();
    }

    /// <summary>
    /// Grow the multiply of money
    /// </summary>
    /// <param name="value"></param>
    public static void GrowMultiply(double value)
    {
        if (value > 3)
        {
            value = 2;
        }
        moneyMultiply *= value;
    }


    public static void Pay(double value)
    {
        money -= value;
    }

    public static void Give(double value)
    {
        money += value * AllmoneyMultiply;
        totalMoney += value * AllmoneyMultiply;
    }
}
