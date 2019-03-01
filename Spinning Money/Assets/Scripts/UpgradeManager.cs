using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UpgradeManager : MonoBehaviour
{

    public bool FirstBuy;

    public string name;

    public double initialCost;
    public double initialRevenue;
    public double coefficient;
    public double productionMultiplicator;

    double actualCost;
    double actualRevenue;
    double actualProductivity;

    int numberOfItems;

    public Text buttonTxt;



    private void Start()
    {
        actualCost = initialCost;
        actualRevenue = initialRevenue;
        print("Started revenue: " + initialRevenue);
        if(FirstBuy == false)
        {
            StartCoroutine(Production());
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
            if(FirstBuy)
            {
                FirstBuy = false;
                StartCoroutine(Production());
            }
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
        buttonTxt.text = actualCost.ToString("0.00");
    }


    public void UpgradeItem()
    {
        print("Custo do item antes da compra: " + actualCost);
        print("Revenda do item antes da compra: " + actualRevenue);
        actualCost = actualCost * (Mathf.Pow(Convert.ToSingle(coefficient), numberOfItems));
        actualRevenue = (initialRevenue * numberOfItems) * productionMultiplicator;
        print("Custo do item depois da compra: " + actualCost);
        print("Revenda do item depois da compra: " + actualRevenue);       
    }












}
