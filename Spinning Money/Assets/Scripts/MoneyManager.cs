using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MoneyManager
{
    public static double money;
    public static double totalMoney;
    public static double moneyMultiply;



    public static void StartGame(double _money, double _totalMoney, double _moneyMultiply)
    {
        money = _money;
        totalMoney = _totalMoney;
        moneyMultiply = _moneyMultiply;
    }

    public static void GrowMultiply(double value)
    {
        if(value > 3)
        {
            value = 3;
        }
        moneyMultiply *= value;
        Debug.Log("money multiply: " + moneyMultiply);
    }

    public static void Pay(double value)
    {
        money -= value;
    }

    public static void Give(double value)
    {
        money += value;
        totalMoney += value;
    }



}
