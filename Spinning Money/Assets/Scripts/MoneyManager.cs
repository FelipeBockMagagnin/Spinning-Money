using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MoneyManager
{
    public static double money;
    public static double moneyMultiply;
    public static double mpsMultiply;

    public static void GrowMpsMultiply(double value)
    {
        mpsMultiply += value;
    }

    public static void GrowMultiply(double value)
    {
        moneyMultiply *= 2;
        Debug.Log("money multiply: " + moneyMultiply);
    }

    public static void Pay(double value)
    {
        money -= value;
    }

    public static void Give(double value)
    {
        money += value;
    }



}
