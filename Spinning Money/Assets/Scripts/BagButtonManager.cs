using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagButtonManager : MonoBehaviour
{
    [Header("Bag Level")]
    public Button bagLevelbutton;
    [HideInInspector]
    public int startBagLevel;
    [HideInInspector]
    public int actualBagLevel;
    public double[] bagValues;

    [Header("Money Level")]
    public Button moneyLevelbutton;
    [HideInInspector]
    public int startMoneyLevel;
    [HideInInspector]
    public int actualMoneyLevel;
    public double[] moneyValues;

    [Header("Money Quantity Level")]
    public Button moneyQuantitybutton;
    [HideInInspector]
    public int startMoneyQuantityLevel;
    [HideInInspector]
    public int actualMoneyQuantityLevel;
    public double[] moneyQuantityValues;

    [Header("Rotation Level")]
    public Button rotationLevelbutton;
    [HideInInspector]
    public int startRotationLevel;
    [HideInInspector]
    public int actualRotationLevel;
    public double[] rotationValues;

    public BagManager bagManager;


    private void Start()
    {
        LoadLevels();
        StartComponents();
        bagManager.setBagAtributes();
    }

    void StartComponents()
    {
        actualBagLevel = startBagLevel;
        bagManager.bagLevel = startBagLevel;

        actualMoneyLevel = startMoneyLevel;
        bagManager.moneyLevel = startMoneyLevel;

        actualMoneyQuantityLevel = startMoneyQuantityLevel;
        bagManager.moneyQuantityLevel = startMoneyQuantityLevel;

        actualRotationLevel = startRotationLevel;
        bagManager.rotationLevel = startRotationLevel;
    }

    void LoadLevels()
    {
        startBagLevel = 1;
        startMoneyLevel = 1;
        startMoneyQuantityLevel = 1;
        startRotationLevel = 1;
    }

    private void FixedUpdate()
    {
        SetTextButtons();
    }

    void SetTextButtons()
    {
        bagLevelbutton.GetComponentInChildren<Text>().text = "Bag Up - Lvl " + actualBagLevel.ToString() + " cost: " + bagValues[actualBagLevel - 1];
        moneyLevelbutton.GetComponentInChildren<Text>().text = "Money Upgrade - Lvl " + actualMoneyLevel.ToString() + " cost: " + moneyValues[actualMoneyLevel - 1];
        moneyQuantitybutton.GetComponentInChildren<Text>().text = "Money Quantity Upgrade - Lvl " + actualMoneyQuantityLevel.ToString() + " cost: " + moneyQuantityValues[actualMoneyQuantityLevel - 1];
        rotationLevelbutton.GetComponentInChildren<Text>().text = "Rotation Upgrade - Lvl " + actualRotationLevel.ToString() + " cost: " + rotationValues[actualRotationLevel - 1];
    }

    public void BuyButton(string name)
    {
        if(name == "bag upgrade")
        {
            if(MoneyManager.money >= bagValues[actualBagLevel - 1] && actualBagLevel < 6)
            {
                MoneyManager.Pay(bagValues[actualBagLevel - 1]);
                actualBagLevel++;
                bagManager.bagLevel = actualBagLevel;
                bagManager.setBagAtributes();                
                Debug.Log("Comprou bag upgrade, nivel atual: " + actualBagLevel);
                MoneyManager.GrowMultiply(actualBagLevel);
            }
            else
            {
                Debug.Log("Não há dinheiro para a compra ou nivel max alcançado");
            }
        }
        else if (name == "money upgrade")
        {
            if(MoneyManager.money >= moneyValues[actualMoneyLevel - 1] && actualMoneyLevel < 5)
            {
                MoneyManager.Pay(moneyValues[actualMoneyLevel - 1]);
                actualMoneyLevel++;
                bagManager.moneyLevel = actualMoneyLevel;
                bagManager.setBagAtributes();
                MoneyManager.GrowMultiply(actualMoneyLevel);
                Debug.Log("Comprou money upgrade, nivel atual: " + actualMoneyLevel);
            } 
            else
            {
                Debug.Log("Não há dinheiro para a compra ou nivel max alcançado");
            }
        }
        else if (name == "money quantity upgrade")
        {
            if (MoneyManager.money >= moneyQuantityValues[actualMoneyQuantityLevel - 1] && actualMoneyQuantityLevel < 5)
            {
                MoneyManager.Pay(moneyQuantityValues[actualMoneyQuantityLevel - 1]);
                actualMoneyQuantityLevel++;
                bagManager.moneyQuantityLevel = actualMoneyQuantityLevel;
                bagManager.setBagAtributes();
                MoneyManager.GrowMultiply(actualMoneyQuantityLevel);
                Debug.Log("Comprou money quantity upgrade, nivel atual: " + actualMoneyQuantityLevel);
            }
            else
            {
                Debug.Log("Não há dinheiro para a compra ou nivel max alcançado");
            }
        }
        else if (name == "rotation upgrade")
        {
            if (MoneyManager.money >= rotationValues[actualRotationLevel - 1] && actualRotationLevel < 5)
            {
                MoneyManager.Pay(rotationValues[actualRotationLevel - 1]);
                actualRotationLevel++;
                bagManager.rotationLevel = actualRotationLevel;
                bagManager.setBagAtributes();
                MoneyManager.GrowMultiply(actualRotationLevel);
                Debug.Log("Comprou Rotation upgrade, nivel atual: " + actualRotationLevel);
            }
            else
            {
                Debug.Log("Não há dinheiro para a compra ou nivel max alcançado");
            }
        }




    }



}