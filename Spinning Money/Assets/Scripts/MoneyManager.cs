using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MoneyManager
{
    public static double money;
    public static double moneyMultiply;

    public static void Pay(double value)
    {
        money -= value;
    }

    public static void Give(double value)
    {
        money += value;
    }



}
