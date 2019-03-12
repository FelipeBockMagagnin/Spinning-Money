﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UpgradeManager : MonoBehaviour
{

    public string name;

    public double initialCost;
    public double initialRevenue;
    public double coefficient;
    public double productionMultiplicator;

    double actualCost;
    public double actualRevenue;
    double actualProductivity;

    public int numberOfItems;

    public Text buttonTxt;


    private void Start()
    {
        MoneyManager.mpsMultiply = 1;
        MoneyManager.moneyMultiply = 1;
        actualCost = initialCost;
        actualRevenue = initialRevenue;
        print("Started revenue: " + initialRevenue);
        actualRevenue = (initialRevenue * numberOfItems) * productionMultiplicator;
        StartCoroutine(Production());
    }

    IEnumerator Production()
    {
        MoneyManager.Give(actualRevenue*MoneyManager.mpsMultiply);
        yield return new WaitForSeconds(1f);
        StartCoroutine(Production());
    }

    public void BuyItem()
    {
        if(MoneyManager.money >= actualCost)
        {   
            MoneyManager.Pay(actualCost);
            numberOfItems++;
            print("Numero de itens: " + numberOfItems);
            print("Item:  " + name + " comprado");
            UpgradeItem();
        }
        else
        {
            print("Sem Dinheiro para comprar o item: " + name);
        }        
    }

    private void Update()
    {
        buttonTxt.text = numberOfItems + " - " + name +  ": " + actualCost.ToString("0.0");
    }

    public void UpgradeItem()
    {
        setMultiply();
        actualCost = actualCost * (Mathf.Pow(Convert.ToSingle(coefficient), numberOfItems));
        actualRevenue = (initialRevenue * numberOfItems) * productionMultiplicator;        
    }

    void setMultiply()
    {
        if(numberOfItems % 5 == 0)
        {
            productionMultiplicator *= 2;
        }
    }












}
