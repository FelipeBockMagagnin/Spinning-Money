﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UpgradeManager : MonoBehaviour
{

    public string _name;

    public double initialCost;
    public double initialRevenue;
    public double coefficient;
    public double productionMultiplicator;

    double actualCost;
    public double actualRevenue;
    double actualProductivity;

    public int numberOfItems;

    public Text buttonTxt;
    public Text numberOfItemsTxt;

    private void Start()
    {
        StartCoroutine(Production());
    }

    public void StartGame(int _numberOfItems)
    {
        numberOfItems = _numberOfItems;
        //seta de acordo com o numero de items
        setInitialMultiplycator();
        print("number of items: " + _numberOfItems);
        print("productionMultiplicator" + productionMultiplicator);
        actualRevenue = (initialRevenue * _numberOfItems) * productionMultiplicator;

        if(numberOfItems == 0)
        {
            actualCost = initialCost;
        }
        else
        {
            setInitialActualcost();
            UpgradeItem();
        }

        
    }

    void setInitialActualcost()
    {
        actualCost = initialCost;
        for(int x = 1; x < numberOfItems; x++)
        {
            actualCost = actualCost * (Mathf.Pow(Convert.ToSingle(coefficient), x));
        }
    }

    IEnumerator Production()
    {
        MoneyManager.Give(actualRevenue);
        yield return new WaitForSeconds(1f);
        StartCoroutine(Production());
    }

    public void BuyItem()
    {
        if(MoneyManager.money >= actualCost)
        {   
            MoneyManager.Pay(actualCost);
            numberOfItems++;
            UpgradeItem();
        }
        else
        {
            print("Sem Dinheiro para comprar o item: " + name);
        }        
    }

    private void Update()
    {
        buttonTxt.text = actualCost.ToString("0.0");
        numberOfItemsTxt.text = numberOfItems.ToString();
    }

    public void UpgradeItem()
    {
        setMultiply();
        actualCost = actualCost * (Mathf.Pow(Convert.ToSingle(coefficient), numberOfItems));
        actualRevenue = (initialRevenue * numberOfItems) * productionMultiplicator;
        
    }

    void setInitialMultiplycator()
    {
        int times = numberOfItems / 5;
        print("Times: " + times);
        if(times == 0)
        {
            this.productionMultiplicator = 1;
        }
        else
        {
            this.productionMultiplicator = 1;
            for (int i = 1; i <= times; i++)
            {
                this.productionMultiplicator *= i * 2;
                
            }
        }
    }

    void setMultiply()
    {
        if (numberOfItems % 5 == 0)
        {            
            this.productionMultiplicator *= (numberOfItems/5)*2;
        }
        
        if(numberOfItems == 0)
        {
            this.productionMultiplicator = 1;
        }
    }












}
